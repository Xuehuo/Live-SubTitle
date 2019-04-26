using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewTek;
using NewTek.NDI;
using NewTek.NDI.WPF;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Text;

namespace Ndi_SubTitle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> ST_Files = new Dictionary<string, string>();
        private string Using_FilePath;
        private string Selected_FilePath;

        private List<SubTitle> subTitles = new List<SubTitle>();
        Graphics lst_ST_Color;
        SubTitle Preview;
        SubTitle Program;
        int run_printer = 0;

        static int Fade_Time = 500; //ms
        static int fps = 25;
        static Point Point_Sub1 = new Point(90, 20);
        static Point Point_Sub2 = new Point(90, 90);
        Font Render_Font;
        //subcoord1 = (90, 850)subcoord2 = (90, 920)

        private Thread t_render;
        private bool stop_render = false;
        bool isOutputing = false;
        SubTitle cmd_Fading;
        bool isFading = false;
        bool isFadingComplete = false;

        bool Clear = false;
        object clear_lock = new object();

        Sender sender;
        private void Render()
        {
            sender = new Sender("Example", true);
            var videoFrame = new VideoFrame(1920, 180, (32.0f / 3.0f), fps, 1);
            var bmp = new Bitmap(videoFrame.Width, videoFrame.Height, videoFrame.Stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, videoFrame.BufferPtr);
            var graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GC.KeepAlive(graphics);
            var sw = new Stopwatch();
            int max_alpha = 255; //max: 2^8
            int Fading_i = Fade_Time * 2 / fps; //delta X pre Frame
            var normal_brush = new SolidBrush(Color.FromArgb(max_alpha, Color.White));
            int Fading_X = 0;
            SubTitle Fading = null;
            isOutputing = false;
            while (!stop_render)
            {
                if (stop_render)
                {
                    stop_render = false;
                    break;
                }
                if (sender.GetConnections(10000) < 1)
                {
                    Console.WriteLine("No current connections, so no rendering needed.");
                    Thread.Sleep(100);
                    isOutputing = false;
                    continue;
                }
                else
                    isOutputing = true;
                sw.Reset();
                sw.Start();
                //***Render Start***

                // Clear it
                graphics.Clear(Color.FromArgb(0,0,0,0));
                if (Clear)
                {
                    lock (clear_lock)
                        Clear = false;
                    goto EndRender;
                }

                if (cmd_Fading != null)  //check command from main thread
                {
                    Console.WriteLine("Detect New Fade Command!");
                    Fading = cmd_Fading.Clone();
                    cmd_Fading = null;
                    isFading = true;
                    isFadingComplete = false;
                    Fading_X = -255;
                }
                if (isFading)
                {
                    Console.WriteLine("Fading:" + Fading_X.ToString());
                    if (Fading_X < 0)
                    {
                        if (Program != null)
                        {
                            var origin_brush = new SolidBrush(Color.FromArgb(0 - Fading_X, Color.White));
                            graphics.DrawString(Program.First_Sub, Render_Font, origin_brush, Point_Sub1);
                            graphics.DrawString(Program.Second_Sub, Render_Font, origin_brush, Point_Sub2);
                        }
                    }
                    else
                    {

                        if (Fading != null)
                        {
                            var fading_brush = new SolidBrush(Color.FromArgb(Fading_X > 255 ? 255 : Fading_X, Color.White));
                            graphics.DrawString(Fading.First_Sub, Render_Font, fading_brush, Point_Sub1);
                            graphics.DrawString(Fading.Second_Sub, Render_Font, fading_brush, Point_Sub2);
                        }
                    }
                    if (Fading_X >= 255)
                    {
                        Fading = null;
                        isFadingComplete = true;
                        isFading = false;
                        Fading_X = -255;
                        Console.WriteLine("End Fade");
                    }
                    else
                        Fading_X += Fading_i;
                }
                else if (Program != null)
                {
                    graphics.DrawString(Program.First_Sub, Render_Font, normal_brush, Point_Sub1);
                    graphics.DrawString(Program.Second_Sub, Render_Font, normal_brush, Point_Sub2);
                }
            // We now submit the frame. Note that this call will be clocked so that we end up submitting at exactly 25fps.

            EndRender:
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");
                sender.Send(videoFrame);
            }
            sender.Dispose();
            sender = null;
            isOutputing = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lst_ST_Color = lst_SubTitle.CreateGraphics();
            Render_Font = new Font(new FontFamily("Arial"), 50);
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                FontFamily[] fontFamilies = fontsCollection.Families;
                List<string> fonts = new List<string>();
                foreach (FontFamily font in fontFamilies)
                {
                    cmb_Fonts.Items.Add(font.Name);
                }
            }
            cmb_Fonts.SelectedIndex = 1;
        }

        private List<SubTitle> GenerateSubTitles(string filePath)
        {
            /* 
        counter = 1
        file_counter = 1
        while True:
        if counter > len(subList):
        break
        ## 创建新图片
        subString1 = subList[counter-1]
        if len(subList) == counter:
        subString2 = ""
        else:
        subString2 = subList[counter]
        if subString2.strip() is "":
        counter -= 1
        if subString1.strip() is "":
        counter -= 1
        subString1 = ""
        subString2 = ""
        file_counter += 1
        counter += 2
        */

            List<string> lines;
            try { lines = new List<string>(File.ReadAllLines(filePath, GetTxtEncoding.GetType(filePath))); }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!!!");
                Console.WriteLine(e.ToString());
                return new List<SubTitle>();
            }
            while (string.IsNullOrWhiteSpace(lines[lines.Count - 1]))
                lines.RemoveAt(lines.Count - 1);
            List<SubTitle> lst = new List<SubTitle>();
            lst.Add(new SubTitle(0, "", ""));
            int counter = 1;
            int file_counter = 1;
            while (true)
            {
                if (counter > lines.Count)
                    break;
                string sub1 = lines[counter - 1];
                string sub2 = "";
                if (counter == lines.Count)
                    sub2 = "";
                else
                    sub2 = lines[counter];
                if (sub2.Trim() == "")
                    counter -= 1;
                if (sub1.Trim() == "")
                {
                    counter -= 1;
                    sub1 = "";
                    sub2 = "";
                }
                lst.Add(new SubTitle(file_counter, sub1, sub2));
                file_counter++;
                counter += 2;
            }
            return lst;
        }

        private int SendSubTitleToPreview(SubTitle st)
        {
            Preview = st;
            lb_pre_id.Text = "Preview " + st.id.ToString();
            lb_preview.Text = st.ToString(true);
            return Preview.id;
        }

        private int SendSubTitleToProgram(SubTitle st)
        {
            st.HasShown();
            Program = st;
            run_printer = st.id;
            lb_pgm_id.Text = "Program " + st.id.ToString();
            lb_program.Text = st.ToString(true);
            run_printer++;
            return st.id;
        }

        private void lst_SubTitle_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0)
                return;
            SubTitle st = subTitles[e.Index];
            // See if the item is selected.
            if (subTitles[st.id].Has_Shown)
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), lst_SubTitle.GetItemRectangle(st.id));

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // Selected. Draw with the system highlight color.
                e.Graphics.DrawString(st.ToString(), lst_SubTitle.Font, new SolidBrush(Color.Yellow), e.Bounds.Left, e.Bounds.Top);
            }
            else
            {
                SolidBrush br = new SolidBrush(e.ForeColor);

                // Not selected. Draw with ListBox's foreground color.
                e.Graphics.DrawString(st.ToString(), lst_SubTitle.Font, br, e.Bounds.Left, e.Bounds.Top);
            }

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        private void btn_fade_Click(object sender = null, EventArgs e = null)  //Fade
        {
            if (!isOutputing)
                return;
            if (subTitles.Count == 0)
                return;
            if (lst_SubTitle.SelectedIndex < 0)
                return;
            if (subTitles.Count > lst_SubTitle.SelectedIndex)
            {
                cmd_Fading = Preview;
                isFadingComplete = false;
                Thread.Sleep(10);
                while (!isFadingComplete)
                    Thread.Sleep(10);
                SendSubTitleToProgram(Preview);
                if (run_printer != subTitles.Count)
                    lst_SubTitle.SetSelected(run_printer, true);
            }
            if (subTitles.Count == 1)
                return;
            if (subTitles.Count > run_printer)
                SendSubTitleToPreview(subTitles[run_printer]);

        }

        private void btn_Hard_Click(object sender = null, EventArgs e = null)//Send Directly Preview To Program
        {
            if (!isOutputing)
                return;
            if (subTitles.Count == 0)
                return;
            if (lst_SubTitle.SelectedIndex < 0)
                return;
            if (subTitles.Count > lst_SubTitle.SelectedIndex)
            {
                SendSubTitleToProgram(subTitles[lst_SubTitle.SelectedIndex]);
                if (run_printer != subTitles.Count)
                    lst_SubTitle.SetSelected(run_printer, true);
            }
            if (subTitles.Count == 1)
                return;
            if (subTitles.Count > run_printer)
                SendSubTitleToPreview(subTitles[run_printer]);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (t_render != null)
                return;
            stop_render = false;
            t_render = new Thread(Render);
            t_render.Start();
            lb_Status.ForeColor = Color.Green;
            lb_Status.Text = "NDI On";
        }

        private void btn_stop_Click(object sender = null, EventArgs e = null)
        {
            btn_stop.Text = "Stopping....";
            stop_render = true;
            if (t_render != null)
                t_render.Join();
            t_render = null;
            lb_Status.ForeColor = Color.Red;
            lb_Status.Text = "NDI Off";
            btn_stop.Text = "Stop";
        }

        private void lst_SubTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendSubTitleToPreview(subTitles[lst_SubTitle.SelectedIndex]);
        }

        private void btn_Clear_Click(object sender = null, EventArgs e = null)
        {
            Program = null;
            lock (clear_lock)
                Clear = true;
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (lst_File.SelectedItems.Count > 0)
            {
                string fileName = lst_File.SelectedItems[0].ToString();
                Using_FilePath = ST_Files[fileName];
                lb_program_file.Text = "Loaded File  : " + Using_FilePath;
                //TODO : Event?
                subTitles.Clear();
                lst_SubTitle.Items.Clear();
                run_printer = 0;
                subTitles = GenerateSubTitles(Using_FilePath);
                foreach (var st in subTitles)
                    lst_SubTitle.Items.Add(st);
            }
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            if (lst_File.SelectedItems.Count > 0)
            {
                string fileName = lst_File.SelectedItems[0].ToString();
                lst_File.Items.Remove(fileName);
                ST_Files.Remove(fileName);
                Selected_FilePath = "";
                lb_selected_file.Text = "Selected File : None";
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            //   ofd.Reset();
            ofd.Filter = "Txt File (*.txt)|*.txt|All Files|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var filePath in ofd.FileNames)
                {
                    if (File.Exists(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);
                        if (!lst_File.Items.Contains(fileName))
                        {
                            lst_File.Items.Add(fileName);
                            ST_Files.Add(fileName, filePath);
                        }
                    }
                }
            }
        }

        private void lst_File_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_File.SelectedItems.Count > 0)
            {
                string fileName = lst_File.SelectedItems[0].ToString();
                Selected_FilePath = ST_Files[fileName];
                lb_selected_file.Text = "Selected File : " + Selected_FilePath;
            }
        }

        private void cmb_Fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedItem != null)
            {
                Console.WriteLine("Change Font To " + cmb.SelectedItem.ToString());
                Render_Font = new Font(new FontFamily(cmb.SelectedItem.ToString()), 50);
            }
        }

        private void btn_Lock_Font_Click(object sender, EventArgs e)
        {
            if (cmb_Fonts.Enabled) //unlock
            {
                // lock it
                cmb_Fonts.Enabled = false;
                btn_Lock_Font.ForeColor = Color.Green;
                btn_Lock_Font.Text = "Locked";
            }
            else
            {
                // unlock it
                cmb_Fonts.Enabled = true;
                btn_Lock_Font.ForeColor = Color.Red;
                btn_Lock_Font.Text = "UnLock";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = false;
            if (e.KeyCode == Keys.Space)       // Fade
            {
                btn_fade_Click();
            }
            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
            {
                btn_Clear_Click();
            }
            else if (e.KeyCode == Keys.Enter)   // Hard
            {
                btn_Hard_Click();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (lst_SubTitle.SelectedIndex - 1 >= 0)
                    lst_SubTitle.SelectedIndex = lst_SubTitle.SelectedIndex - 1;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (lst_SubTitle.SelectedIndex > 0 && lst_SubTitle.SelectedIndex + 1 <= lst_SubTitle.Items.Count)
                    lst_SubTitle.SelectedIndex = lst_SubTitle.SelectedIndex + 1;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_stop_Click();
        }

        private void btn_Clear_Fade_Click(object sender, EventArgs e)
        {

        }
    }
}
