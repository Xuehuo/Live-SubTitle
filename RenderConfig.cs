using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDI_SubTitle
{
    public class RenderConfig
    {
        // NDI Output int width, int height, float aspectRatio, int frameRateNumerator, int frameRateDenominator
        public int Width;
        public int Height;
        public float aspectRatio;
        public int frameRateNumerator;
        public int frameRateDenominator;

        // Render
        public Point Point_Sub1;
        public Point Point_Sub2;
        public Color Default_Color;
        public float fontSize;
        public int Fade_Time; //ms

        public RenderConfig(bool is_default = false)
        {
            if (is_default)
            {
                Width = 1920;
                Height = 180;
                aspectRatio = Convert.ToSingle(Width) / Convert.ToSingle(Height);
                frameRateNumerator = 50;
                frameRateDenominator = 1;

                Point_Sub1 = new Point(90, 20);
                Point_Sub2 = new Point(90, 90);
                fontSize = 25.0f;
                Default_Color = Color.White;
                Fade_Time = 500;
            }
        }

        public static RenderConfig ReadNDIConfig(JObject jo)
        {
            try
            {
                RenderConfig config = new RenderConfig();
                config.Width = Convert.ToInt32(jo["NDI_width"].ToString());
                config.Height = Convert.ToInt32(jo["NDI_height"].ToString());
                config.aspectRatio = Convert.ToSingle(config.Width) / Convert.ToSingle(config.Height);
                config.frameRateNumerator = Convert.ToInt32(jo["frameRateNumerator"].ToString());
                config.frameRateDenominator = Convert.ToInt32(jo["frameRateDenominator"].ToString());

                config.Point_Sub1 = new Point(Convert.ToInt32(jo["Point1_X"].ToString()), Convert.ToInt32(jo["Point1_Y"].ToString()));
                config.Point_Sub2 = new Point(Convert.ToInt32(jo["Point2_X"].ToString()), Convert.ToInt32(jo["Point2_Y"].ToString()));
                if (jo.ContainsKey("Color_Name"))
                    config.Default_Color = Color.FromName(jo["Color_Name"].ToString());
                else
                    config.Default_Color = Color.FromArgb(Convert.ToInt32(jo["Color"]["alpha"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["red"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["green"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["blue"].ToString()));
                config.Fade_Time = Convert.ToInt32(jo["Fade_Time"].ToString());
                return config;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new RenderConfig(true);//Return Default Setting
            }
        }
    }
}
