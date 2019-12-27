namespace NDI_SubTitle
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_program_file = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lable_text = new System.Windows.Forms.Label();
            this.lb_selected_file = new System.Windows.Forms.Label();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.lb_pre_id = new System.Windows.Forms.Label();
            this.lb_pgm_id = new System.Windows.Forms.Label();
            this.lb_preview = new System.Windows.Forms.Label();
            this.lb_program = new System.Windows.Forms.Label();
            this.btn_fade = new System.Windows.Forms.Button();
            this.btn_Hard = new System.Windows.Forms.Button();
            this.btn_Clear_Cut = new System.Windows.Forms.Button();
            this.btn_DeleteFile = new System.Windows.Forms.Button();
            this.lst_File = new System.Windows.Forms.ListBox();
            this.lst_SubTitle = new System.Windows.Forms.ListBox();
            this.lb_Status = new System.Windows.Forms.Label();
            this.lb_Font = new System.Windows.Forms.Label();
            this.cmb_Fonts = new System.Windows.Forms.ComboBox();
            this.btn_Lock_Font = new System.Windows.Forms.Button();
            this.btn_Clear_Fade = new System.Windows.Forms.Button();
            this.btn_refresh_monitor = new System.Windows.Forms.Button();
            this.cmb_monitor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_lock_screen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_screen_width = new System.Windows.Forms.TextBox();
            this.txt_screen_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ScnStop = new System.Windows.Forms.Button();
            this.btn_scnStart = new System.Windows.Forms.Button();
            this.gp_render_mode = new System.Windows.Forms.GroupBox();
            this.rdo_Render_FullScreen = new System.Windows.Forms.RadioButton();
            this.rdo_Render_NDI = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gp_render_mode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_program_file
            // 
            resources.ApplyResources(this.lb_program_file, "lb_program_file");
            this.lb_program_file.Name = "lb_program_file";
            // 
            // btn_start
            // 
            resources.ApplyResources(this.btn_start, "btn_start");
            this.btn_start.Name = "btn_start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            resources.ApplyResources(this.btn_stop, "btn_stop");
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lable_text
            // 
            resources.ApplyResources(this.lable_text, "lable_text");
            this.lable_text.Name = "lable_text";
            // 
            // lb_selected_file
            // 
            resources.ApplyResources(this.lb_selected_file, "lb_selected_file");
            this.lb_selected_file.Name = "lb_selected_file";
            // 
            // btn_import
            // 
            resources.ApplyResources(this.btn_import, "btn_import");
            this.btn_import.Name = "btn_import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_Load
            // 
            resources.ApplyResources(this.btn_Load, "btn_Load");
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // lb_pre_id
            // 
            resources.ApplyResources(this.lb_pre_id, "lb_pre_id");
            this.lb_pre_id.Name = "lb_pre_id";
            // 
            // lb_pgm_id
            // 
            resources.ApplyResources(this.lb_pgm_id, "lb_pgm_id");
            this.lb_pgm_id.Name = "lb_pgm_id";
            // 
            // lb_preview
            // 
            resources.ApplyResources(this.lb_preview, "lb_preview");
            this.lb_preview.Name = "lb_preview";
            // 
            // lb_program
            // 
            resources.ApplyResources(this.lb_program, "lb_program");
            this.lb_program.Name = "lb_program";
            // 
            // btn_fade
            // 
            resources.ApplyResources(this.btn_fade, "btn_fade");
            this.btn_fade.Name = "btn_fade";
            this.btn_fade.UseVisualStyleBackColor = true;
            this.btn_fade.Click += new System.EventHandler(this.btn_fade_Click);
            // 
            // btn_Hard
            // 
            resources.ApplyResources(this.btn_Hard, "btn_Hard");
            this.btn_Hard.Name = "btn_Hard";
            this.btn_Hard.UseVisualStyleBackColor = true;
            this.btn_Hard.Click += new System.EventHandler(this.btn_Hard_Click);
            // 
            // btn_Clear_Cut
            // 
            resources.ApplyResources(this.btn_Clear_Cut, "btn_Clear_Cut");
            this.btn_Clear_Cut.Name = "btn_Clear_Cut";
            this.btn_Clear_Cut.UseVisualStyleBackColor = true;
            this.btn_Clear_Cut.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_DeleteFile
            // 
            resources.ApplyResources(this.btn_DeleteFile, "btn_DeleteFile");
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.UseVisualStyleBackColor = true;
            this.btn_DeleteFile.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // lst_File
            // 
            this.lst_File.AllowDrop = true;
            this.lst_File.FormattingEnabled = true;
            resources.ApplyResources(this.lst_File, "lst_File");
            this.lst_File.Name = "lst_File";
            this.lst_File.SelectedIndexChanged += new System.EventHandler(this.lst_File_SelectedIndexChanged);
            this.lst_File.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lst_File_DragDrop);
            this.lst_File.DragEnter += new System.Windows.Forms.DragEventHandler(this.Lst_File_DragEnter);
            // 
            // lst_SubTitle
            // 
            resources.ApplyResources(this.lst_SubTitle, "lst_SubTitle");
            this.lst_SubTitle.ForeColor = System.Drawing.Color.Black;
            this.lst_SubTitle.FormattingEnabled = true;
            this.lst_SubTitle.Name = "lst_SubTitle";
            this.lst_SubTitle.SelectedIndexChanged += new System.EventHandler(this.lst_SubTitle_SelectedIndexChanged);
            // 
            // lb_Status
            // 
            resources.ApplyResources(this.lb_Status, "lb_Status");
            this.lb_Status.ForeColor = System.Drawing.Color.Red;
            this.lb_Status.Name = "lb_Status";
            // 
            // lb_Font
            // 
            resources.ApplyResources(this.lb_Font, "lb_Font");
            this.lb_Font.Name = "lb_Font";
            // 
            // cmb_Fonts
            // 
            this.cmb_Fonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Fonts.FormattingEnabled = true;
            resources.ApplyResources(this.cmb_Fonts, "cmb_Fonts");
            this.cmb_Fonts.Name = "cmb_Fonts";
            this.cmb_Fonts.SelectedIndexChanged += new System.EventHandler(this.cmb_Fonts_SelectedIndexChanged);
            // 
            // btn_Lock_Font
            // 
            this.btn_Lock_Font.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btn_Lock_Font, "btn_Lock_Font");
            this.btn_Lock_Font.Name = "btn_Lock_Font";
            this.btn_Lock_Font.UseVisualStyleBackColor = true;
            this.btn_Lock_Font.Click += new System.EventHandler(this.btn_Lock_Font_Click);
            // 
            // btn_Clear_Fade
            // 
            resources.ApplyResources(this.btn_Clear_Fade, "btn_Clear_Fade");
            this.btn_Clear_Fade.Name = "btn_Clear_Fade";
            this.btn_Clear_Fade.UseVisualStyleBackColor = true;
            this.btn_Clear_Fade.Click += new System.EventHandler(this.btn_Clear_Fade_Click);
            // 
            // btn_refresh_monitor
            // 
            resources.ApplyResources(this.btn_refresh_monitor, "btn_refresh_monitor");
            this.btn_refresh_monitor.Name = "btn_refresh_monitor";
            this.btn_refresh_monitor.UseVisualStyleBackColor = true;
            this.btn_refresh_monitor.Click += new System.EventHandler(this.btn_refresh_monitor_Click);
            // 
            // cmb_monitor
            // 
            this.cmb_monitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_monitor.FormattingEnabled = true;
            resources.ApplyResources(this.cmb_monitor, "cmb_monitor");
            this.cmb_monitor.Name = "cmb_monitor";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_lock_screen
            // 
            this.btn_lock_screen.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btn_lock_screen, "btn_lock_screen");
            this.btn_lock_screen.Name = "btn_lock_screen";
            this.btn_lock_screen.UseVisualStyleBackColor = true;
            this.btn_lock_screen.Click += new System.EventHandler(this.btn_lock_screen_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txt_screen_width
            // 
            resources.ApplyResources(this.txt_screen_width, "txt_screen_width");
            this.txt_screen_width.Name = "txt_screen_width";
            // 
            // txt_screen_height
            // 
            resources.ApplyResources(this.txt_screen_height, "txt_screen_height");
            this.txt_screen_height.Name = "txt_screen_height";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btn_ScnStop
            // 
            resources.ApplyResources(this.btn_ScnStop, "btn_ScnStop");
            this.btn_ScnStop.Name = "btn_ScnStop";
            this.btn_ScnStop.UseVisualStyleBackColor = true;
            this.btn_ScnStop.Click += new System.EventHandler(this.btn_ScnStop_Click);
            // 
            // btn_scnStart
            // 
            resources.ApplyResources(this.btn_scnStart, "btn_scnStart");
            this.btn_scnStart.Name = "btn_scnStart";
            this.btn_scnStart.UseVisualStyleBackColor = true;
            this.btn_scnStart.Click += new System.EventHandler(this.btn_scnStart_Click);
            // 
            // gp_render_mode
            // 
            this.gp_render_mode.Controls.Add(this.rdo_Render_FullScreen);
            this.gp_render_mode.Controls.Add(this.rdo_Render_NDI);
            resources.ApplyResources(this.gp_render_mode, "gp_render_mode");
            this.gp_render_mode.Name = "gp_render_mode";
            this.gp_render_mode.TabStop = false;
            // 
            // rdo_Render_FullScreen
            // 
            resources.ApplyResources(this.rdo_Render_FullScreen, "rdo_Render_FullScreen");
            this.rdo_Render_FullScreen.Checked = true;
            this.rdo_Render_FullScreen.Name = "rdo_Render_FullScreen";
            this.rdo_Render_FullScreen.TabStop = true;
            this.rdo_Render_FullScreen.UseVisualStyleBackColor = true;
            this.rdo_Render_FullScreen.CheckedChanged += new System.EventHandler(this.rdo_Render_FullScreen_CheckedChanged);
            // 
            // rdo_Render_NDI
            // 
            resources.ApplyResources(this.rdo_Render_NDI, "rdo_Render_NDI");
            this.rdo_Render_NDI.Name = "rdo_Render_NDI";
            this.rdo_Render_NDI.UseVisualStyleBackColor = true;
            this.rdo_Render_NDI.CheckedChanged += new System.EventHandler(this.rdo_Render_NDI_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_refresh_monitor);
            this.groupBox1.Controls.Add(this.cmb_monitor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_lock_screen);
            this.groupBox1.Controls.Add(this.txt_screen_height);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_screen_width);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gp_render_mode);
            this.Controls.Add(this.btn_ScnStop);
            this.Controls.Add(this.btn_scnStart);
            this.Controls.Add(this.btn_Clear_Fade);
            this.Controls.Add(this.btn_Lock_Font);
            this.Controls.Add(this.cmb_Fonts);
            this.Controls.Add(this.lb_Font);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.lst_SubTitle);
            this.Controls.Add(this.lst_File);
            this.Controls.Add(this.btn_DeleteFile);
            this.Controls.Add(this.btn_Clear_Cut);
            this.Controls.Add(this.btn_Hard);
            this.Controls.Add(this.btn_fade);
            this.Controls.Add(this.lb_program);
            this.Controls.Add(this.lb_preview);
            this.Controls.Add(this.lb_pgm_id);
            this.Controls.Add(this.lb_pre_id);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.lb_selected_file);
            this.Controls.Add(this.lable_text);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lb_program_file);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gp_render_mode.ResumeLayout(false);
            this.gp_render_mode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_program_file;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label lable_text;
        private System.Windows.Forms.Label lb_selected_file;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Label lb_pre_id;
        private System.Windows.Forms.Label lb_pgm_id;
        private System.Windows.Forms.Label lb_preview;
        private System.Windows.Forms.Label lb_program;
        private System.Windows.Forms.Button btn_fade;
        private System.Windows.Forms.Button btn_Hard;
        private System.Windows.Forms.Button btn_Clear_Cut;
        private System.Windows.Forms.Button btn_DeleteFile;
        private System.Windows.Forms.ListBox lst_File;
        private System.Windows.Forms.ListBox lst_SubTitle;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Label lb_Font;
        private System.Windows.Forms.ComboBox cmb_Fonts;
        private System.Windows.Forms.Button btn_Lock_Font;
        private System.Windows.Forms.Button btn_Clear_Fade;
        private System.Windows.Forms.Button btn_refresh_monitor;
        private System.Windows.Forms.ComboBox cmb_monitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_lock_screen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_screen_width;
        private System.Windows.Forms.TextBox txt_screen_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ScnStop;
        private System.Windows.Forms.Button btn_scnStart;
        private System.Windows.Forms.GroupBox gp_render_mode;
        private System.Windows.Forms.RadioButton rdo_Render_FullScreen;
        private System.Windows.Forms.RadioButton rdo_Render_NDI;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

