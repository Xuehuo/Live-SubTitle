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
            this.SuspendLayout();
            // 
            // lb_program_file
            // 
            this.lb_program_file.AutoSize = true;
            this.lb_program_file.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_program_file.Location = new System.Drawing.Point(12, 12);
            this.lb_program_file.Name = "lb_program_file";
            this.lb_program_file.Size = new System.Drawing.Size(143, 17);
            this.lb_program_file.TabIndex = 2;
            this.lb_program_file.Text = "Loaded File  : ";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(1113, 16);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(141, 65);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(1281, 16);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(141, 65);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lable_text
            // 
            this.lable_text.AutoSize = true;
            this.lable_text.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_text.Location = new System.Drawing.Point(269, 98);
            this.lable_text.Name = "lable_text";
            this.lable_text.Size = new System.Drawing.Size(106, 24);
            this.lable_text.TabIndex = 5;
            this.lable_text.Text = "Status: ";
            // 
            // lb_selected_file
            // 
            this.lb_selected_file.AutoSize = true;
            this.lb_selected_file.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_selected_file.Location = new System.Drawing.Point(12, 39);
            this.lb_selected_file.Name = "lb_selected_file";
            this.lb_selected_file.Size = new System.Drawing.Size(134, 17);
            this.lb_selected_file.TabIndex = 6;
            this.lb_selected_file.Text = "Selected File:";
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(12, 94);
            this.btn_import.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(83, 36);
            this.btn_import.TabIndex = 7;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(181, 94);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(83, 36);
            this.btn_Load.TabIndex = 8;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // lb_pre_id
            // 
            this.lb_pre_id.AutoSize = true;
            this.lb_pre_id.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_pre_id.Location = new System.Drawing.Point(1119, 268);
            this.lb_pre_id.Name = "lb_pre_id";
            this.lb_pre_id.Size = new System.Drawing.Size(103, 25);
            this.lb_pre_id.TabIndex = 9;
            this.lb_pre_id.Text = "Preview";
            // 
            // lb_pgm_id
            // 
            this.lb_pgm_id.AutoSize = true;
            this.lb_pgm_id.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_pgm_id.Location = new System.Drawing.Point(1119, 118);
            this.lb_pgm_id.Name = "lb_pgm_id";
            this.lb_pgm_id.Size = new System.Drawing.Size(103, 25);
            this.lb_pgm_id.TabIndex = 10;
            this.lb_pgm_id.Text = "Program";
            // 
            // lb_preview
            // 
            this.lb_preview.AutoSize = true;
            this.lb_preview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_preview.Location = new System.Drawing.Point(1120, 309);
            this.lb_preview.Name = "lb_preview";
            this.lb_preview.Size = new System.Drawing.Size(179, 20);
            this.lb_preview.TabIndex = 11;
            this.lb_preview.Text = "Sub Title Preview";
            // 
            // lb_program
            // 
            this.lb_program.AutoSize = true;
            this.lb_program.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_program.Location = new System.Drawing.Point(1119, 159);
            this.lb_program.Name = "lb_program";
            this.lb_program.Size = new System.Drawing.Size(179, 20);
            this.lb_program.TabIndex = 12;
            this.lb_program.Text = "Sub Title Program";
            // 
            // btn_fade
            // 
            this.btn_fade.Location = new System.Drawing.Point(1281, 445);
            this.btn_fade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_fade.Name = "btn_fade";
            this.btn_fade.Size = new System.Drawing.Size(141, 65);
            this.btn_fade.TabIndex = 13;
            this.btn_fade.Text = "Fade (Space)";
            this.btn_fade.UseVisualStyleBackColor = true;
            this.btn_fade.Click += new System.EventHandler(this.btn_fade_Click);
            // 
            // btn_Hard
            // 
            this.btn_Hard.Location = new System.Drawing.Point(1113, 445);
            this.btn_Hard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Hard.Name = "btn_Hard";
            this.btn_Hard.Size = new System.Drawing.Size(141, 65);
            this.btn_Hard.TabIndex = 14;
            this.btn_Hard.Text = "Cut (Enter)";
            this.btn_Hard.UseVisualStyleBackColor = true;
            this.btn_Hard.Click += new System.EventHandler(this.btn_Hard_Click);
            // 
            // btn_Clear_Cut
            // 
            this.btn_Clear_Cut.Location = new System.Drawing.Point(1113, 521);
            this.btn_Clear_Cut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Clear_Cut.Name = "btn_Clear_Cut";
            this.btn_Clear_Cut.Size = new System.Drawing.Size(141, 70);
            this.btn_Clear_Cut.TabIndex = 15;
            this.btn_Clear_Cut.Text = "Clear (Ctrl+Enter)";
            this.btn_Clear_Cut.UseVisualStyleBackColor = true;
            this.btn_Clear_Cut.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.Location = new System.Drawing.Point(101, 94);
            this.btn_DeleteFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Size = new System.Drawing.Size(75, 36);
            this.btn_DeleteFile.TabIndex = 16;
            this.btn_DeleteFile.Text = "Delete";
            this.btn_DeleteFile.UseVisualStyleBackColor = true;
            this.btn_DeleteFile.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // lst_File
            // 
            this.lst_File.AllowDrop = true;
            this.lst_File.FormattingEnabled = true;
            this.lst_File.ItemHeight = 15;
            this.lst_File.Location = new System.Drawing.Point(12, 136);
            this.lst_File.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lst_File.Name = "lst_File";
            this.lst_File.Size = new System.Drawing.Size(252, 484);
            this.lst_File.TabIndex = 17;
            this.lst_File.SelectedIndexChanged += new System.EventHandler(this.lst_File_SelectedIndexChanged);
            this.lst_File.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lst_File_DragDrop);
            this.lst_File.DragEnter += new System.Windows.Forms.DragEventHandler(this.Lst_File_DragEnter);
            // 
            // lst_SubTitle
            // 
            this.lst_SubTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lst_SubTitle.ForeColor = System.Drawing.Color.Black;
            this.lst_SubTitle.FormattingEnabled = true;
            this.lst_SubTitle.ItemHeight = 20;
            this.lst_SubTitle.Location = new System.Drawing.Point(269, 136);
            this.lst_SubTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lst_SubTitle.Name = "lst_SubTitle";
            this.lst_SubTitle.ScrollAlwaysVisible = true;
            this.lst_SubTitle.Size = new System.Drawing.Size(837, 484);
            this.lst_SubTitle.TabIndex = 18;
            this.lst_SubTitle.SelectedIndexChanged += new System.EventHandler(this.lst_SubTitle_SelectedIndexChanged);
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.ForeColor = System.Drawing.Color.Red;
            this.lb_Status.Location = new System.Drawing.Point(367, 105);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(63, 15);
            this.lb_Status.TabIndex = 20;
            this.lb_Status.Text = "NDI Off";
            // 
            // lb_Font
            // 
            this.lb_Font.AutoSize = true;
            this.lb_Font.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Font.Location = new System.Drawing.Point(12, 64);
            this.lb_Font.Name = "lb_Font";
            this.lb_Font.Size = new System.Drawing.Size(134, 17);
            this.lb_Font.TabIndex = 22;
            this.lb_Font.Text = "Font File    :";
            // 
            // cmb_Fonts
            // 
            this.cmb_Fonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Fonts.FormattingEnabled = true;
            this.cmb_Fonts.Location = new System.Drawing.Point(153, 64);
            this.cmb_Fonts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Fonts.Name = "cmb_Fonts";
            this.cmb_Fonts.Size = new System.Drawing.Size(287, 23);
            this.cmb_Fonts.TabIndex = 23;
            this.cmb_Fonts.SelectedIndexChanged += new System.EventHandler(this.cmb_Fonts_SelectedIndexChanged);
            // 
            // btn_Lock_Font
            // 
            this.btn_Lock_Font.ForeColor = System.Drawing.Color.Red;
            this.btn_Lock_Font.Location = new System.Drawing.Point(445, 59);
            this.btn_Lock_Font.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Lock_Font.Name = "btn_Lock_Font";
            this.btn_Lock_Font.Size = new System.Drawing.Size(97, 30);
            this.btn_Lock_Font.TabIndex = 24;
            this.btn_Lock_Font.Text = "UnLock";
            this.btn_Lock_Font.UseVisualStyleBackColor = true;
            this.btn_Lock_Font.Click += new System.EventHandler(this.btn_Lock_Font_Click);
            // 
            // btn_Clear_Fade
            // 
            this.btn_Clear_Fade.Location = new System.Drawing.Point(1281, 521);
            this.btn_Clear_Fade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Clear_Fade.Name = "btn_Clear_Fade";
            this.btn_Clear_Fade.Size = new System.Drawing.Size(141, 70);
            this.btn_Clear_Fade.TabIndex = 25;
            this.btn_Clear_Fade.Text = "Fade Clear (Ctrl+Space)";
            this.btn_Clear_Fade.UseVisualStyleBackColor = true;
            this.btn_Clear_Fade.Click += new System.EventHandler(this.btn_Clear_Fade_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 628);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

