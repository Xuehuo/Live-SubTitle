
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Drawing.Imaging;
using NDI_SubTitle.Properties;

namespace NDI_SubTitle
{
    class Render_Form : GameWindow
    {
        public Render_Form(DisplayDevice dd, int _width, int _height, Font font, NDIConfig config)
            : base(_width, _height, new GraphicsMode(new ColorFormat(8, 8, 8, 8), 24, 8, 8),
                      "SubTitle - FullScreen", GameWindowFlags.Fullscreen, dd)
        {
            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
            height = _height;
            width = _width;

            NDI_Config = config;
            // Render Initial
            program = SubTitle.Empty;
            fading = SubTitle.Empty;
            Point_Sub1 = new Point(50, height / 2);
            Point_Sub2 = new Point(50, height / 2 + 100);

            // Style
            defaultBrush = new SolidBrush(config.Default_Color);
            this.font = font;

            bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

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

        private int height;
        private int width;

        //Render 
        private NDIConfig NDI_Config;
        public const int Alpha_Max = 255;
        public const int Alpha_Min = 255;

        private static readonly object syncLock = new object();
        private Bitmap bmp;
        private Graphics graphics;
        private int textTexture = -1;

        private Font font;
        private SolidBrush defaultBrush;
        private Point Point_Sub1;
        private Point Point_Sub2;

        private SubTitle program;
        private SubTitle fading;
        private bool isFading;
        private int Fading_X;
        private readonly int delta_X;

        private bool isChange = false;

        public void Cut(SubTitle sub)
        {
            lock (syncLock)
            {
                if (isChange)
                    return;
                program = sub;
                isChange = true;
            }
        }

        public void Fade(SubTitle sub)
        {
            lock (syncLock)
            {
                if (isChange)
                    return;
                fading = sub.Clone();
                fading.alpha = Alpha_Min;
                isFading = true;
                isChange = true;
                Fading_X = 0; //Reset Fading_X
            }
        }

        public void ChangeFont(Font font)
        {
            lock (syncLock)
                this.font = font;
        }

        private void GenerateBmp()
        {
            if (textTexture != -1)
                GL.DeleteTextures(1, ref textTexture);
            graphics.Clear(Color.Transparent);
            graphics.DrawString(program.First_Sub, font, defaultBrush, Point_Sub1);
            graphics.DrawString(program.Second_Sub, font, defaultBrush, Point_Sub2);
            bmp.Save("D:\\test.png");

            GL.ClearColor(Color.AntiqueWhite);
            GL.Enable(EnableCap.Texture2D);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out textTexture);
            GL.BindTexture(TextureTarget.Texture2D, textTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = false;
        }
        protected override void OnUnload(EventArgs e)
        {
            GL.DeleteTextures(1, ref textTexture);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (isChange)
            {
                lock (syncLock)
                {
                    GenerateBmp();
                    GL.Clear(ClearBufferMask.ColorBufferBit);

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.BindTexture(TextureTarget.Texture2D, textTexture);

                    GL.Begin(BeginMode.Quads);

                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-1.0f, -1.0f);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(1.0f, -1.0f);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(1.0f, 1.0f);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-1.0f, 1.0f);

                    GL.End();

                    ErrorCode errorCode = GL.GetError();
                    if (errorCode != ErrorCode.NoError)
                        Console.WriteLine($"OpenTK ERROR!!: {errorCode.ToString()}");

                    SwapBuffers();
                }
                isChange = false;
            }
            SwapBuffers();
        }

    }
}