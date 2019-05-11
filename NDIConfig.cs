using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDI_SubTitle
{
    public class NDIConfig
    {
        // NDI Output int width, int height, float aspectRatio, int frameRateNumerator, int frameRateDenominator
        public int NDI_width;
        public int NDI_height;
        public float aspectRatio;
        public int frameRateNumerator;
        public int frameRateDenominator;

        // Render
        public Point Point_Sub1;
        public Point Point_Sub2;
        public Color Default_Color;
        public int Fade_Time; //ms

        public NDIConfig(bool is_default = false)
        {
            if (is_default)
            {
                NDI_width = 1920;
                NDI_height = 180;
                aspectRatio = Convert.ToSingle(NDI_width) / Convert.ToSingle(NDI_height);
                frameRateNumerator = 50;
                frameRateDenominator = 1;

                Point_Sub1 = new Point(90, 20);
                Point_Sub2 = new Point(90, 90);
                Default_Color = Color.White;
                Fade_Time = 500;
            }
        }

        public static NDIConfig ReadNDIConfig(JObject jo)
        {
            try
            {
                NDIConfig config = new NDIConfig();
                config.NDI_width = Convert.ToInt32(jo["NDI_width"].ToString());
                config.NDI_height = Convert.ToInt32(jo["NDI_height"].ToString());
                config.aspectRatio = Convert.ToSingle(config.NDI_width) / Convert.ToSingle(config.NDI_height);
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
                return new NDIConfig(true);//Return Default Setting
            }
        }
    }
}
