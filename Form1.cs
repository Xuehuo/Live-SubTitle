using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
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

        // it means which SubTitle is being programed
        int run_printer = 0;

        SubTitle Previewing = SubTitle.Empty;

        NDIRender Renderer;
        CancellationTokenSource cancelNDI;

        #region Form
        private void Form1_Load(object sender, EventArgs e)
        {
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Space))
            {   //Fade to Blank
                Console.WriteLine("ShortCut: Ctrl + Space");
                btn_Clear_Fade_Click();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Enter))
            {   //Cut to Blank
                Console.WriteLine("ShortCut: Ctrl + Enter");
                btn_Clear_Click();
                return true;
            }
            else if (keyData == Keys.Space)
            {   // Fade
                Console.WriteLine("ShortCut: Space");
                btn_fade_Click();
                return true;
            }
            else if (keyData == Keys.Enter)
            {   //fade to blank
                Console.WriteLine("ShortCut: Enter");
                btn_Hard_Click();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_stop_Click();
        }
        #endregion

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

        private void Preview(SubTitle st)
        {
            lb_pre_id.Text = "Preview " + st.id.ToString();
            lb_preview.Text = st.ToString(true);
        }

        private void Program(SubTitle st)
        {
            lb_pgm_id.Text = "Program " + st.id.ToString();
            lb_program.Text = st.ToString(true);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Renderer != null)
                return;
            cancelNDI = new CancellationTokenSource();
            Renderer = new NDIRender(cancelNDI.Token, new Font(new FontFamily("Arial"), 50));
            Task.Run(async () => await Renderer.Run());
            lb_Status.ForeColor = Color.Green;
            lb_Status.Text = "NDI On";
        }

        private void btn_stop_Click(object sender = null, EventArgs e = null)
        {
            btn_stop.Text = "Stopping....";
            if (Renderer != null)
            {
                cancelNDI.Cancel();
                Renderer = null;
            }
            lb_Status.ForeColor = Color.Red;
            lb_Status.Text = "NDI Off";
            btn_stop.Text = "Stop";
        }

        private void lst_SubTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Previewing = subTitles[lst_SubTitle.SelectedIndex];
                Preview(Previewing);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }

        #region Files
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
        #endregion

        #region Fonts
        private void cmb_Fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedItem != null)
            {
                Console.WriteLine("Change Font To " + cmb.SelectedItem.ToString());
                //Render_Font = new Font(new FontFamily(cmb.SelectedItem.ToString()), 50);
                if (Renderer != null)
                    Renderer.ChangeFont(new Font(new FontFamily(cmb.SelectedItem.ToString()), 50));
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
        #endregion

        #region Change Buttons
        private void btn_Clear_Fade_Click(object sender = null, EventArgs e = null)
        {
            if (Renderer == null)
                return;
            Renderer.Fade(SubTitle.Empty);
            Program(SubTitle.Empty);
        }

        private void btn_fade_Click(object sender = null, EventArgs e = null)  //Fade
        {
            if (Renderer == null)
                return;
            if (subTitles.Count == 0)
                return;
            if (lst_SubTitle.SelectedIndex < 0)
                return;
            if (subTitles.Count > lst_SubTitle.SelectedIndex)
            {
                Renderer.Fade(Previewing);
                Program(Previewing);
                run_printer = Previewing.id + 1;
                if (run_printer != subTitles.Count)
                    lst_SubTitle.SetSelected(run_printer, true);
            }
        }

        private void btn_Hard_Click(object sender = null, EventArgs e = null)//Send Directly Preview To Program
        {
            if (Renderer == null)
                return;
            if (subTitles.Count == 0)
                return;
            if (lst_SubTitle.SelectedIndex < 0)
                return;
            if (subTitles.Count > lst_SubTitle.SelectedIndex)
            {
                Renderer.Cut(Previewing);
                Program(Previewing);
                run_printer = Previewing.id + 1;
                if (run_printer != subTitles.Count)
                    lst_SubTitle.SetSelected(run_printer, true);
            }
        }

        private void btn_Clear_Click(object sender = null, EventArgs e = null)
        {
            if (Renderer == null)
                return;
            Program(SubTitle.Empty);
            Renderer.Cut(SubTitle.Empty);
        }
        #endregion

    }
}
