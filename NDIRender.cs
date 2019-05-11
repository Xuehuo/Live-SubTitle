using NewTek.NDI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;


namespace NDI_SubTitle
{
    public class NDIRender
    {
        public const int Alpha_Max = 255;
        public const int Alpha_Min = 255;

        private static readonly object syncLock = new object();
        private readonly CancellationToken cancellationToken;

        private readonly VideoFrame videoFrame;
        private Bitmap bmp;
        private Graphics graphics;

        private Font font;
        private SolidBrush defaultBrush;
        private static Point Point_Sub1 = new Point(90, 20);
        private static Point Point_Sub2 = new Point(90, 90);

        private SubTitle program;
        private SubTitle fading;
        private bool isFading;
        private int Fading_X;
        private readonly int delta_X;

        public NDIRender(CancellationToken cancellationToken, NDIConfig config, Font font)
        {
            this.cancellationToken = cancellationToken;

            // We are going to create a 1920x180 frame at 50p, progressive (default).
            this.videoFrame = new VideoFrame(config.NDI_width, config.NDI_height, config.aspectRatio, config.frameRateNumerator, config.frameRateDenominator);
            bmp = new Bitmap(videoFrame.Width, videoFrame.Height, videoFrame.Stride,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb, videoFrame.BufferPtr);
            graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // NDI Renderer
            program = SubTitle.Empty;
            fading = SubTitle.Empty;

            // Style
            defaultBrush = new SolidBrush(config.Default_Color);
            this.font = font;

            // Fade Setting
            isFading = false;
            // For delta_X, We plus delta_X into alpha
            // Fade Effect will last for 500ms 
            // So every frame it will change 255/(50frames/2steps) = 10
            delta_X = Alpha_Max / (config.frameRateNumerator / config.frameRateDenominator) * 2;

            // If Fading_X <  Alpha_Max / 2 ,it's the former part (from program to empty)
            // If Fading_X >= Alpha_Max / 2 ,it's the latter part (from empty to fading )
            // If Fading_X >= Alpha_Max     ,it means fade ends   (set program as fading)
            Fading_X = 0;
        }

        public void Cut(SubTitle sub)
        {
            lock (syncLock)
            {
                if (isFading)
                    return;
                program = sub;
            }
        }

        public void Fade(SubTitle sub)
        {
            lock (syncLock)
            {
                if (isFading)
                    return;
                fading = sub.Clone();
                fading.alpha = Alpha_Min;
                isFading = true;
                Fading_X = 0; //Reset Fading_X
            }
        }

        public void ChangeFont(Font font)
        {
            lock (syncLock)
                this.font = font;
        }

        private void DrawFrame()
        {
            lock (syncLock)
            {
                graphics.Clear(Color.Transparent);
                if (!isFading)
                { // As Normal
                    graphics.DrawString(program.First_Sub, font, defaultBrush, Point_Sub1);
                    graphics.DrawString(program.Second_Sub, font, defaultBrush, Point_Sub2);
                }
                else
                {   // BUG   !!!! 
                    // FADING 
                    if (Fading_X >= Alpha_Max)
                    {
                        Fading_X = 255;
                        isFading = false; //end fade
                        program = fading;
                    }
                    if (Fading_X < Alpha_Max / 2) //Alpha_Max/2 = 127.5
                    {
                        // from program to empty
                        // It's 0 -> 127 , but alpha should be 255 -> 0
                        // So we use 255 - Fading_X * 2
                        int alpha = Alpha_Max - Fading_X * 2;
                        if (alpha < 0)
                            alpha = 0;
                        var brush = new SolidBrush(Color.FromArgb(alpha, Color.White));
                        graphics.DrawString(program.First_Sub, font, brush, Point_Sub1);
                        graphics.DrawString(program.Second_Sub, font, brush, Point_Sub2);
                    }
                    else if (Fading_X >= Alpha_Max / 2)
                    {
                        // from empty to fading 
                        // It's 128 -> 255,but alpha should be 0 -> 255
                        // So we use Fading_X * 2 - 255
                        int alpha = Fading_X * 2 - Alpha_Max;
                        if (alpha > 255)
                            alpha = 255;
                        var brush = new SolidBrush(Color.FromArgb(alpha, Color.White));
                        graphics.DrawString(fading.First_Sub, font, brush, Point_Sub1);
                        graphics.DrawString(fading.Second_Sub, font, brush, Point_Sub2);
                    }
                    Fading_X += delta_X;
                }
            }
        }

        public async Task<int> Run()
        {
            // Note that some of these using statements are sharing the same scope and
            // will be disposed together simply because I dislike deeply nested scopes.
            // You can manually handle .Dispose() for longer lived objects or use any pattern you prefer.

            // When creating the sender use the Managed NDIlib Send example as the failover for this sender
            // Therefore if you run both examples and then close this one it demonstrates failover in action
            string failoverName = string.Format("{0} (NDIlib Send Example)", System.Net.Dns.GetHostName());

            // this will show up as a source named "Example" with all other settings at their defaults
            using (Sender sendInstance = new Sender("Example", true, false, null, failoverName))
            {
                // We will send 10000 frames of video.
                while (!cancellationToken.IsCancellationRequested)
                {
                    // are we connected to anyone?
                    if (sendInstance.GetConnections(100) < 1)
                    {
                        // no point rendering
                        Console.WriteLine("No current connections, so no rendering needed.");

                        // Wait a bit, otherwise our limited example will end before you can connect to it
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                    {
                        // We now submit the frame. Note that this call will be clocked so that we end up submitting at exactly 29.97fps.
                        lock (syncLock)
                        {
                            DrawFrame();
                            sendInstance.Send(videoFrame);
                        }
                    }
                } // using sendInstance
                sendInstance.Dispose();
                return 0;
            } // Main
        }
    }
}