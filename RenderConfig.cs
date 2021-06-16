using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public string Remarks;

        public RenderConfig(bool is_default = false)
        {
            if (is_default)
            {
                Width = 1920;
                Height = 1080;
                aspectRatio = Convert.ToSingle(Width) / Convert.ToSingle(Height);
                frameRateNumerator = 50;
                frameRateDenominator = 1;

                Point_Sub1 = new Point(145, 871);
                Point_Sub2 = new Point(145, 943);
                fontSize = 30.0f;
                Default_Color = Color.White;
                Fade_Time = 500;

                Remarks = "default preset";
            }
        }

        public static RenderConfig ReadConfig(String path)
        {
            try
            {
                var jo = JObject.Parse(File.ReadAllText(path));

                RenderConfig config = new RenderConfig();
                config.Width = Convert.ToInt32(jo["Width"].ToString());
                config.Height = Convert.ToInt32(jo["Height"].ToString());
                config.aspectRatio = Convert.ToSingle(config.Width) / Convert.ToSingle(config.Height);
                config.frameRateNumerator = Convert.ToInt32(jo["frameRateNumerator"].ToString());
                config.frameRateDenominator = Convert.ToInt32(jo["frameRateDenominator"].ToString());

                config.Point_Sub1 = new Point(Convert.ToInt32(jo["Point1_X"].ToString()), Convert.ToInt32(jo["Point1_Y"].ToString()));
                config.Point_Sub2 = new Point(Convert.ToInt32(jo["Point2_X"].ToString()), Convert.ToInt32(jo["Point2_Y"].ToString()));
                config.Default_Color = Color.FromArgb(Convert.ToInt32(jo["Color"]["alpha"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["red"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["green"].ToString()),
                                                            Convert.ToInt32(jo["Color"]["blue"].ToString()));
                config.Fade_Time = Convert.ToInt32(jo["Fade_Time"].ToString());
                config.Remarks = jo["Remarks"].ToString();
                if (jo.ContainsKey("Font_Size"))
                    config.fontSize = Convert.ToSingle(jo["Font_Size"]);
                else
                    config.fontSize = 50;
                return config;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new RenderConfig(true);//Return Default Setting
            }
        }

        public static void SaveConfig(RenderConfig config, string filePath)
        {
            try
            {
                var writer = new StreamWriter(filePath);
                JObject jo = new JObject();
                jo["Width"] = config.Width;
                jo["Height"] = config.Height;
                jo["frameRateNumerator"] = config.frameRateNumerator;
                jo["frameRateDenominator"] = config.frameRateDenominator;

                jo["Point1_X"] = config.Point_Sub1.X;
                jo["Point1_Y"] = config.Point_Sub1.Y;
                jo["Point2_X"] = config.Point_Sub2.X;
                jo["Point2_Y"] = config.Point_Sub2.Y;

                jo["Color"] = new JObject();
                jo["Color"]["red"] = config.Default_Color.R;
                jo["Color"]["green"] = config.Default_Color.G;
                jo["Color"]["blue"] = config.Default_Color.B;
                jo["Color"]["alpha"] = config.Default_Color.A;

                jo["Fade_Time"] = config.Fade_Time;
                jo["Remarks"] = config.Remarks;
                jo["Font_Size"] = config.fontSize;
                writer.WriteLine(jo.ToString());
                writer.Flush();
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
