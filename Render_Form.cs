
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;


namespace NDI_SubTitle
{
    class Render_Form : GameWindow
    {
        public Render_Form(DisplayDevice dd, int width, int height,Font font,NDIConfig config)
            : base(width, height, GraphicsMode.Default,
                    "SubTitle - FullScreen", GameWindowFlags.Fullscreen,
                    dd, 4, // OpenGL major version
                    0, // OpenGL minor version
                    GraphicsContextFlags.ForwardCompatible)
        {
            program = SubTitle.Empty;
            fading = SubTitle.Empty;

            // Style
            defaultBrush = new SolidBrush(config.Default_Color);
            this.font = font;
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = false;
        }

        //Render 
        public const int Alpha_Max = 255;
        public const int Alpha_Min = 255;

        private static readonly object syncLock = new object();
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


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {

        }

    }
}