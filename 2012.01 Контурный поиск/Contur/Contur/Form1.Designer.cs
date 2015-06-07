namespace Contur
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SC_Horizontal = new System.Windows.Forms.SplitContainer();
            this.TC_Images = new System.Windows.Forms.TabControl();
            this.TP_Image = new System.Windows.Forms.TabPage();
            this.PB_Original = new System.Windows.Forms.PictureBox();
            this.TP_Contur = new System.Windows.Forms.TabPage();
            this.PB_Contur = new System.Windows.Forms.PictureBox();
            this.TP_Result = new System.Windows.Forms.TabPage();
            this.PB_Result = new System.Windows.Forms.PictureBox();
            this.SC_Vertical = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChB_ChangeTeta = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Teta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_nuMultiplier = new System.Windows.Forms.TextBox();
            this.TB_Koef = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NUD_Epoch = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NUD_Height = new System.Windows.Forms.NumericUpDown();
            this.NUD_Width = new System.Windows.Forms.NumericUpDown();
            this.TB_PerceptronInfo = new System.Windows.Forms.TextBox();
            this.TB_Log = new System.Windows.Forms.TextBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MMI_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MMI_File_OpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MMI_File_OpenContur = new System.Windows.Forms.ToolStripMenuItem();
            this.MMI_Teach = new System.Windows.Forms.ToolStripMenuItem();
            this.MMI_CreateContur = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Log = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CM_Log_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.SC_Horizontal.Panel1.SuspendLayout();
            this.SC_Horizontal.Panel2.SuspendLayout();
            this.SC_Horizontal.SuspendLayout();
            this.TC_Images.SuspendLayout();
            this.TP_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Original)).BeginInit();
            this.TP_Contur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Contur)).BeginInit();
            this.TP_Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Result)).BeginInit();
            this.SC_Vertical.Panel1.SuspendLayout();
            this.SC_Vertical.Panel2.SuspendLayout();
            this.SC_Vertical.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Epoch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.CM_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // SC_Horizontal
            // 
            this.SC_Horizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SC_Horizontal.Location = new System.Drawing.Point(0, 27);
            this.SC_Horizontal.Name = "SC_Horizontal";
            this.SC_Horizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_Horizontal.Panel1
            // 
            this.SC_Horizontal.Panel1.Controls.Add(this.TC_Images);
            // 
            // SC_Horizontal.Panel2
            // 
            this.SC_Horizontal.Panel2.Controls.Add(this.SC_Vertical);
            this.SC_Horizontal.Size = new System.Drawing.Size(775, 512);
            this.SC_Horizontal.SplitterDistance = 218;
            this.SC_Horizontal.TabIndex = 0;
            // 
            // TC_Images
            // 
            this.TC_Images.Controls.Add(this.TP_Image);
            this.TC_Images.Controls.Add(this.TP_Contur);
            this.TC_Images.Controls.Add(this.TP_Result);
            this.TC_Images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Images.Location = new System.Drawing.Point(0, 0);
            this.TC_Images.Name = "TC_Images";
            this.TC_Images.SelectedIndex = 0;
            this.TC_Images.Size = new System.Drawing.Size(775, 218);
            this.TC_Images.TabIndex = 0;
            // 
            // TP_Image
            // 
            this.TP_Image.AutoScroll = true;
            this.TP_Image.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TP_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Image.Controls.Add(this.PB_Original);
            this.TP_Image.Location = new System.Drawing.Point(4, 22);
            this.TP_Image.Name = "TP_Image";
            this.TP_Image.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Image.Size = new System.Drawing.Size(767, 192);
            this.TP_Image.TabIndex = 0;
            this.TP_Image.Text = "Рисунок";
            this.TP_Image.UseVisualStyleBackColor = true;
            // 
            // PB_Original
            // 
            this.PB_Original.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PB_Original.Location = new System.Drawing.Point(2, 2);
            this.PB_Original.Name = "PB_Original";
            this.PB_Original.Size = new System.Drawing.Size(100, 50);
            this.PB_Original.TabIndex = 0;
            this.PB_Original.TabStop = false;
            // 
            // TP_Contur
            // 
            this.TP_Contur.AutoScroll = true;
            this.TP_Contur.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TP_Contur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Contur.Controls.Add(this.PB_Contur);
            this.TP_Contur.Location = new System.Drawing.Point(4, 22);
            this.TP_Contur.Name = "TP_Contur";
            this.TP_Contur.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Contur.Size = new System.Drawing.Size(767, 192);
            this.TP_Contur.TabIndex = 1;
            this.TP_Contur.Text = "Контур";
            this.TP_Contur.UseVisualStyleBackColor = true;
            // 
            // PB_Contur
            // 
            this.PB_Contur.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PB_Contur.Location = new System.Drawing.Point(2, 2);
            this.PB_Contur.Name = "PB_Contur";
            this.PB_Contur.Size = new System.Drawing.Size(100, 50);
            this.PB_Contur.TabIndex = 1;
            this.PB_Contur.TabStop = false;
            // 
            // TP_Result
            // 
            this.TP_Result.AutoScroll = true;
            this.TP_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Result.Controls.Add(this.PB_Result);
            this.TP_Result.Location = new System.Drawing.Point(4, 22);
            this.TP_Result.Name = "TP_Result";
            this.TP_Result.Size = new System.Drawing.Size(767, 192);
            this.TP_Result.TabIndex = 2;
            this.TP_Result.Text = "Результат";
            this.TP_Result.UseVisualStyleBackColor = true;
            // 
            // PB_Result
            // 
            this.PB_Result.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PB_Result.Location = new System.Drawing.Point(3, 3);
            this.PB_Result.Name = "PB_Result";
            this.PB_Result.Size = new System.Drawing.Size(100, 50);
            this.PB_Result.TabIndex = 2;
            this.PB_Result.TabStop = false;
            // 
            // SC_Vertical
            // 
            this.SC_Vertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_Vertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SC_Vertical.Location = new System.Drawing.Point(0, 0);
            this.SC_Vertical.Name = "SC_Vertical";
            // 
            // SC_Vertical.Panel1
            // 
            this.SC_Vertical.Panel1.Controls.Add(this.splitContainer2);
            this.SC_Vertical.Panel1MinSize = 210;
            // 
            // SC_Vertical.Panel2
            // 
            this.SC_Vertical.Panel2.Controls.Add(this.TB_Log);
            this.SC_Vertical.Size = new System.Drawing.Size(775, 290);
            this.SC_Vertical.SplitterDistance = 211;
            this.SC_Vertical.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TB_PerceptronInfo);
            this.splitContainer2.Size = new System.Drawing.Size(211, 290);
            this.splitContainer2.SplitterDistance = 196;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChB_ChangeTeta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TB_Teta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_nuMultiplier);
            this.groupBox1.Controls.Add(this.TB_Koef);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NUD_Epoch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NUD_Height);
            this.groupBox1.Controls.Add(this.NUD_Width);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры нейрона";
            // 
            // ChB_ChangeTeta
            // 
            this.ChB_ChangeTeta.AutoSize = true;
            this.ChB_ChangeTeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChB_ChangeTeta.Location = new System.Drawing.Point(5, 172);
            this.ChB_ChangeTeta.Name = "ChB_ChangeTeta";
            this.ChB_ChangeTeta.Size = new System.Drawing.Size(185, 17);
            this.ChB_ChangeTeta.TabIndex = 12;
            this.ChB_ChangeTeta.Text = "Изменять порог срабатывания";
            this.ChB_ChangeTeta.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Порог срабатывания";
            // 
            // TB_Teta
            // 
            this.TB_Teta.Location = new System.Drawing.Point(127, 146);
            this.TB_Teta.Name = "TB_Teta";
            this.TB_Teta.Size = new System.Drawing.Size(75, 20);
            this.TB_Teta.TabIndex = 10;
            this.TB_Teta.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Множитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Коэф. обучения";
            // 
            // TB_nuMultiplier
            // 
            this.TB_nuMultiplier.Location = new System.Drawing.Point(127, 120);
            this.TB_nuMultiplier.Name = "TB_nuMultiplier";
            this.TB_nuMultiplier.Size = new System.Drawing.Size(75, 20);
            this.TB_nuMultiplier.TabIndex = 7;
            this.TB_nuMultiplier.Text = "1";
            // 
            // TB_Koef
            // 
            this.TB_Koef.Location = new System.Drawing.Point(127, 94);
            this.TB_Koef.Name = "TB_Koef";
            this.TB_Koef.Size = new System.Drawing.Size(75, 20);
            this.TB_Koef.TabIndex = 6;
            this.TB_Koef.Text = "0,7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Эпох обучения";
            // 
            // NUD_Epoch
            // 
            this.NUD_Epoch.Location = new System.Drawing.Point(127, 71);
            this.NUD_Epoch.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NUD_Epoch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Epoch.Name = "NUD_Epoch";
            this.NUD_Epoch.Size = new System.Drawing.Size(78, 20);
            this.NUD_Epoch.TabIndex = 4;
            this.NUD_Epoch.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Высота поля";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ширина поля";
            // 
            // NUD_Height
            // 
            this.NUD_Height.Location = new System.Drawing.Point(127, 45);
            this.NUD_Height.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUD_Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Height.Name = "NUD_Height";
            this.NUD_Height.Size = new System.Drawing.Size(78, 20);
            this.NUD_Height.TabIndex = 1;
            this.NUD_Height.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NUD_Width
            // 
            this.NUD_Width.Location = new System.Drawing.Point(127, 19);
            this.NUD_Width.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUD_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Width.Name = "NUD_Width";
            this.NUD_Width.Size = new System.Drawing.Size(78, 20);
            this.NUD_Width.TabIndex = 0;
            this.NUD_Width.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // TB_PerceptronInfo
            // 
            this.TB_PerceptronInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_PerceptronInfo.Location = new System.Drawing.Point(0, 0);
            this.TB_PerceptronInfo.Multiline = true;
            this.TB_PerceptronInfo.Name = "TB_PerceptronInfo";
            this.TB_PerceptronInfo.ReadOnly = true;
            this.TB_PerceptronInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_PerceptronInfo.Size = new System.Drawing.Size(211, 90);
            this.TB_PerceptronInfo.TabIndex = 0;
            this.TB_PerceptronInfo.WordWrap = false;
            // 
            // TB_Log
            // 
            this.TB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Log.Location = new System.Drawing.Point(0, 0);
            this.TB_Log.Multiline = true;
            this.TB_Log.Name = "TB_Log";
            this.TB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Log.Size = new System.Drawing.Size(560, 290);
            this.TB_Log.TabIndex = 1;
            this.TB_Log.WordWrap = false;
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 542);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(775, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_File,
            this.MMI_Teach,
            this.MMI_CreateContur});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(775, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MMI_File
            // 
            this.MMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_File_OpenImage,
            this.MMI_File_OpenContur});
            this.MMI_File.Name = "MMI_File";
            this.MMI_File.Size = new System.Drawing.Size(48, 20);
            this.MMI_File.Text = "Файл";
            // 
            // MMI_File_OpenImage
            // 
            this.MMI_File_OpenImage.Name = "MMI_File_OpenImage";
            this.MMI_File_OpenImage.Size = new System.Drawing.Size(170, 22);
            this.MMI_File_OpenImage.Text = "Открыть рисунок";
            this.MMI_File_OpenImage.Click += new System.EventHandler(this.MMI_OpenImage_Click);
            // 
            // MMI_File_OpenContur
            // 
            this.MMI_File_OpenContur.Name = "MMI_File_OpenContur";
            this.MMI_File_OpenContur.Size = new System.Drawing.Size(170, 22);
            this.MMI_File_OpenContur.Text = "Открыть контур";
            this.MMI_File_OpenContur.Click += new System.EventHandler(this.MMI_OpenContur_Click);
            // 
            // MMI_Teach
            // 
            this.MMI_Teach.Name = "MMI_Teach";
            this.MMI_Teach.Size = new System.Drawing.Size(66, 20);
            this.MMI_Teach.Text = "Обучить";
            this.MMI_Teach.Click += new System.EventHandler(this.MMI_Teach_Click);
            // 
            // MMI_CreateContur
            // 
            this.MMI_CreateContur.Name = "MMI_CreateContur";
            this.MMI_CreateContur.Size = new System.Drawing.Size(119, 20);
            this.MMI_CreateContur.Text = "Построить контур";
            this.MMI_CreateContur.Click += new System.EventHandler(this.MI_CreateContur_Click);
            // 
            // CM_Log
            // 
            this.CM_Log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CM_Log_Clear});
            this.CM_Log.Name = "CM_Log";
            this.CM_Log.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CM_Log.Size = new System.Drawing.Size(127, 26);
            // 
            // CM_Log_Clear
            // 
            this.CM_Log_Clear.Name = "CM_Log_Clear";
            this.CM_Log_Clear.Size = new System.Drawing.Size(126, 22);
            this.CM_Log_Clear.Text = "Очистить";
            this.CM_Log_Clear.Click += new System.EventHandler(this.CM_Log_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 564);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.SC_Horizontal);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.SC_Horizontal.Panel1.ResumeLayout(false);
            this.SC_Horizontal.Panel2.ResumeLayout(false);
            this.SC_Horizontal.ResumeLayout(false);
            this.TC_Images.ResumeLayout(false);
            this.TP_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Original)).EndInit();
            this.TP_Contur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Contur)).EndInit();
            this.TP_Result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Result)).EndInit();
            this.SC_Vertical.Panel1.ResumeLayout(false);
            this.SC_Vertical.Panel2.ResumeLayout(false);
            this.SC_Vertical.Panel2.PerformLayout();
            this.SC_Vertical.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Epoch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Width)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CM_Log.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

	   private System.Windows.Forms.SplitContainer SC_Horizontal;
        private System.Windows.Forms.PictureBox PB_Original;
	   private System.Windows.Forms.PictureBox PB_Contur;
	   private System.Windows.Forms.OpenFileDialog OFD;
	   private System.Windows.Forms.TextBox TB_Log;
	   private System.Windows.Forms.TabControl TC_Images;
	   private System.Windows.Forms.TabPage TP_Image;
	   private System.Windows.Forms.TabPage TP_Contur;
	   private System.Windows.Forms.SplitContainer SC_Vertical;
	   private System.Windows.Forms.SplitContainer splitContainer2;
	   private System.Windows.Forms.TextBox TB_PerceptronInfo;
	   private System.Windows.Forms.StatusStrip statusStrip;
	   private System.Windows.Forms.MenuStrip MainMenu;
	   private System.Windows.Forms.ToolStripMenuItem MMI_File;
	   private System.Windows.Forms.ToolStripMenuItem MMI_File_OpenImage;
	   private System.Windows.Forms.ToolStripMenuItem MMI_File_OpenContur;
	   private System.Windows.Forms.ContextMenuStrip CM_Log;
	   private System.Windows.Forms.ToolStripMenuItem CM_Log_Clear;
	   private System.Windows.Forms.NumericUpDown NUD_Height;
	   private System.Windows.Forms.NumericUpDown NUD_Width;
	   private System.Windows.Forms.GroupBox groupBox1;
	   private System.Windows.Forms.Label label2;
	   private System.Windows.Forms.Label label1;
	   private System.Windows.Forms.Label label3;
	   private System.Windows.Forms.NumericUpDown NUD_Epoch;
	   private System.Windows.Forms.TabPage TP_Result;
	   private System.Windows.Forms.PictureBox PB_Result;
	   private System.Windows.Forms.TextBox TB_Koef;
	   private System.Windows.Forms.ToolStripMenuItem MMI_Teach;
	   private System.Windows.Forms.ToolStripMenuItem MMI_CreateContur;
	   private System.Windows.Forms.TextBox TB_nuMultiplier;
	   private System.Windows.Forms.Label label4;
	   private System.Windows.Forms.Label label5;
	   private System.Windows.Forms.Label label6;
	   private System.Windows.Forms.TextBox TB_Teta;
	   private System.Windows.Forms.CheckBox ChB_ChangeTeta;

    }
}

