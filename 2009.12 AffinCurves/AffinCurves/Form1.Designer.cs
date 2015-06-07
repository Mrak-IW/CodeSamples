namespace AffinCurves
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
			this.PB_Graphic = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TC_Mode = new System.Windows.Forms.TabControl();
			this.TC_Mode_Affin = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.BTN_ApplyMatrix = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.BTN_Move_0 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.BTN_Scaling = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BTN_Shift = new System.Windows.Forms.Button();
			this.BTN_Symmetry = new System.Windows.Forms.Button();
			this.BTN_Move = new System.Windows.Forms.Button();
			this.LBL_Value = new System.Windows.Forms.Label();
			this.LBL_Angle = new System.Windows.Forms.Label();
			this.BTN_Rotate = new System.Windows.Forms.Button();
			this.TB_Angle = new System.Windows.Forms.TextBox();
			this.TB_Value = new System.Windows.Forms.TextBox();
			this.TC_Mode_Curves = new System.Windows.Forms.TabPage();
			this.LBL_ExcuseMe = new System.Windows.Forms.Label();
			this.TB_Log = new System.Windows.Forms.TextBox();
			this.ERR = new System.Windows.Forms.ErrorProvider(this.components);
			this.TB_ResMatrix = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SFD_SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.MS_MainMenu = new System.Windows.Forms.MenuStrip();
			this.MMI_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Blank = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Data = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.PB_Graphic)).BeginInit();
			this.panel1.SuspendLayout();
			this.TC_Mode.SuspendLayout();
			this.TC_Mode_Affin.SuspendLayout();
			this.TC_Mode_Curves.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).BeginInit();
			this.MS_MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// PB_Graphic
			// 
			this.PB_Graphic.BackColor = System.Drawing.SystemColors.Window;
			this.PB_Graphic.Location = new System.Drawing.Point(3, 3);
			this.PB_Graphic.Name = "PB_Graphic";
			this.PB_Graphic.Size = new System.Drawing.Size(827, 1169);
			this.PB_Graphic.TabIndex = 0;
			this.PB_Graphic.TabStop = false;
			this.PB_Graphic.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Graphic_Paint);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.PB_Graphic);
			this.panel1.Location = new System.Drawing.Point(12, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(486, 593);
			this.panel1.TabIndex = 1;
			// 
			// TC_Mode
			// 
			this.TC_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TC_Mode.Controls.Add(this.TC_Mode_Affin);
			this.TC_Mode.Controls.Add(this.TC_Mode_Curves);
			this.TC_Mode.Location = new System.Drawing.Point(504, 27);
			this.TC_Mode.Name = "TC_Mode";
			this.TC_Mode.SelectedIndex = 0;
			this.TC_Mode.Size = new System.Drawing.Size(232, 313);
			this.TC_Mode.TabIndex = 2;
			this.TC_Mode.SelectedIndexChanged += new System.EventHandler(this.TC_Mode_SelectedIndexChanged);
			// 
			// TC_Mode_Affin
			// 
			this.TC_Mode_Affin.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.TC_Mode_Affin.Controls.Add(this.label8);
			this.TC_Mode_Affin.Controls.Add(this.BTN_ApplyMatrix);
			this.TC_Mode_Affin.Controls.Add(this.label6);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Move_0);
			this.TC_Mode_Affin.Controls.Add(this.label5);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Scaling);
			this.TC_Mode_Affin.Controls.Add(this.label4);
			this.TC_Mode_Affin.Controls.Add(this.label3);
			this.TC_Mode_Affin.Controls.Add(this.label2);
			this.TC_Mode_Affin.Controls.Add(this.label1);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Shift);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Symmetry);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Move);
			this.TC_Mode_Affin.Controls.Add(this.LBL_Value);
			this.TC_Mode_Affin.Controls.Add(this.LBL_Angle);
			this.TC_Mode_Affin.Controls.Add(this.BTN_Rotate);
			this.TC_Mode_Affin.Controls.Add(this.TB_Angle);
			this.TC_Mode_Affin.Controls.Add(this.TB_Value);
			this.TC_Mode_Affin.Location = new System.Drawing.Point(4, 22);
			this.TC_Mode_Affin.Name = "TC_Mode_Affin";
			this.TC_Mode_Affin.Padding = new System.Windows.Forms.Padding(3);
			this.TC_Mode_Affin.Size = new System.Drawing.Size(224, 287);
			this.TC_Mode_Affin.TabIndex = 0;
			this.TC_Mode_Affin.Text = "Аффинные";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(97, 259);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(95, 26);
			this.label8.TabIndex = 15;
			this.label8.Text = "Результирующую\r\nматрицу";
			// 
			// BTN_ApplyMatrix
			// 
			this.BTN_ApplyMatrix.Location = new System.Drawing.Point(6, 259);
			this.BTN_ApplyMatrix.Name = "BTN_ApplyMatrix";
			this.BTN_ApplyMatrix.Size = new System.Drawing.Size(85, 23);
			this.BTN_ApplyMatrix.TabIndex = 14;
			this.BTN_ApplyMatrix.Text = "Применить";
			this.BTN_ApplyMatrix.UseVisualStyleBackColor = true;
			this.BTN_ApplyMatrix.Click += new System.EventHandler(this.BTN_ApplyMatrix_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(97, 230);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 26);
			this.label6.TabIndex = 13;
			this.label6.Text = "Относительно начала\r\nкоординат";
			// 
			// BTN_Move_0
			// 
			this.BTN_Move_0.Enabled = false;
			this.BTN_Move_0.Location = new System.Drawing.Point(6, 230);
			this.BTN_Move_0.Name = "BTN_Move_0";
			this.BTN_Move_0.Size = new System.Drawing.Size(85, 23);
			this.BTN_Move_0.TabIndex = 12;
			this.BTN_Move_0.Text = "Переместить";
			this.BTN_Move_0.UseVisualStyleBackColor = true;
			this.BTN_Move_0.Click += new System.EventHandler(this.BTN_Move_0_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(97, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 26);
			this.label5.TabIndex = 11;
			this.label5.Text = "Относительно точки.\r\nКоэф-ты. по X и Y";
			// 
			// BTN_Scaling
			// 
			this.BTN_Scaling.Enabled = false;
			this.BTN_Scaling.Location = new System.Drawing.Point(6, 200);
			this.BTN_Scaling.Name = "BTN_Scaling";
			this.BTN_Scaling.Size = new System.Drawing.Size(85, 23);
			this.BTN_Scaling.TabIndex = 10;
			this.BTN_Scaling.Text = "Масштабирование";
			this.BTN_Scaling.UseVisualStyleBackColor = true;
			this.BTN_Scaling.Click += new System.EventHandler(this.BTN_Scaling_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(97, 171);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 26);
			this.label4.TabIndex = 9;
			this.label4.Text = "Вдоль 0X- Знач = 0\r\nВдоль 0Y - Знач = 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(97, 142);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 26);
			this.label3.TabIndex = 8;
			this.label3.Text = "Отн. прямой через 0\r\nпод углом к 0X";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(97, 118);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "На вектор";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Угол+центр поворота";
			// 
			// BTN_Shift
			// 
			this.BTN_Shift.Enabled = false;
			this.BTN_Shift.Location = new System.Drawing.Point(6, 171);
			this.BTN_Shift.Name = "BTN_Shift";
			this.BTN_Shift.Size = new System.Drawing.Size(85, 23);
			this.BTN_Shift.TabIndex = 5;
			this.BTN_Shift.Text = "Сдвиг на угол";
			this.BTN_Shift.UseVisualStyleBackColor = true;
			this.BTN_Shift.Click += new System.EventHandler(this.BTN_Shift_Click);
			// 
			// BTN_Symmetry
			// 
			this.BTN_Symmetry.Enabled = false;
			this.BTN_Symmetry.Location = new System.Drawing.Point(6, 142);
			this.BTN_Symmetry.Name = "BTN_Symmetry";
			this.BTN_Symmetry.Size = new System.Drawing.Size(85, 23);
			this.BTN_Symmetry.TabIndex = 4;
			this.BTN_Symmetry.Text = "Симметрия";
			this.BTN_Symmetry.UseVisualStyleBackColor = true;
			this.BTN_Symmetry.Click += new System.EventHandler(this.BTN_Symmetry_Click);
			// 
			// BTN_Move
			// 
			this.BTN_Move.Enabled = false;
			this.BTN_Move.Location = new System.Drawing.Point(6, 113);
			this.BTN_Move.Name = "BTN_Move";
			this.BTN_Move.Size = new System.Drawing.Size(85, 23);
			this.BTN_Move.TabIndex = 3;
			this.BTN_Move.Text = "Переместить";
			this.BTN_Move.UseVisualStyleBackColor = true;
			this.BTN_Move.Click += new System.EventHandler(this.BTN_Move_Click);
			// 
			// LBL_Value
			// 
			this.LBL_Value.AutoSize = true;
			this.LBL_Value.Location = new System.Drawing.Point(3, 3);
			this.LBL_Value.Name = "LBL_Value";
			this.LBL_Value.Size = new System.Drawing.Size(128, 13);
			this.LBL_Value.TabIndex = 2;
			this.LBL_Value.Text = "Значение/точка/вектор";
			// 
			// LBL_Angle
			// 
			this.LBL_Angle.AutoSize = true;
			this.LBL_Angle.Location = new System.Drawing.Point(6, 42);
			this.LBL_Angle.Name = "LBL_Angle";
			this.LBL_Angle.Size = new System.Drawing.Size(106, 13);
			this.LBL_Angle.TabIndex = 2;
			this.LBL_Angle.Text = "Угол/коэфициенты";
			// 
			// BTN_Rotate
			// 
			this.BTN_Rotate.Enabled = false;
			this.BTN_Rotate.Location = new System.Drawing.Point(6, 84);
			this.BTN_Rotate.Name = "BTN_Rotate";
			this.BTN_Rotate.Size = new System.Drawing.Size(85, 23);
			this.BTN_Rotate.TabIndex = 2;
			this.BTN_Rotate.Text = "Разворот";
			this.BTN_Rotate.UseVisualStyleBackColor = true;
			this.BTN_Rotate.Click += new System.EventHandler(this.BTN_Rotate_Click);
			// 
			// TB_Angle
			// 
			this.TB_Angle.Location = new System.Drawing.Point(6, 58);
			this.TB_Angle.Name = "TB_Angle";
			this.TB_Angle.Size = new System.Drawing.Size(167, 20);
			this.TB_Angle.TabIndex = 1;
			this.TB_Angle.Text = "30";
			this.TB_Angle.TextChanged += new System.EventHandler(this.TB_Angle_TextChanged);
			// 
			// TB_Value
			// 
			this.TB_Value.Location = new System.Drawing.Point(6, 19);
			this.TB_Value.Name = "TB_Value";
			this.TB_Value.Size = new System.Drawing.Size(167, 20);
			this.TB_Value.TabIndex = 0;
			this.TB_Value.Text = "0; 0";
			this.TB_Value.TextChanged += new System.EventHandler(this.TB_Value_TextChanged);
			// 
			// TC_Mode_Curves
			// 
			this.TC_Mode_Curves.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.TC_Mode_Curves.Controls.Add(this.LBL_ExcuseMe);
			this.TC_Mode_Curves.Location = new System.Drawing.Point(4, 22);
			this.TC_Mode_Curves.Name = "TC_Mode_Curves";
			this.TC_Mode_Curves.Padding = new System.Windows.Forms.Padding(3);
			this.TC_Mode_Curves.Size = new System.Drawing.Size(224, 287);
			this.TC_Mode_Curves.TabIndex = 1;
			this.TC_Mode_Curves.Text = "Кривые";
			// 
			// LBL_ExcuseMe
			// 
			this.LBL_ExcuseMe.AutoSize = true;
			this.LBL_ExcuseMe.Location = new System.Drawing.Point(23, 84);
			this.LBL_ExcuseMe.Name = "LBL_ExcuseMe";
			this.LBL_ExcuseMe.Size = new System.Drawing.Size(178, 91);
			this.LBL_ExcuseMe.TabIndex = 0;
			this.LBL_ExcuseMe.Text = "Все настройки, необходимые для\r\nработы модуля, находятся\r\nв меню\"Данные\".\r\nP.S.\r\n" +
				"Последние 2 точки в матрице\r\nдля кривой Эрмита являются\r\nвекторами";
			this.LBL_ExcuseMe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TB_Log
			// 
			this.TB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Log.Location = new System.Drawing.Point(503, 346);
			this.TB_Log.Multiline = true;
			this.TB_Log.Name = "TB_Log";
			this.TB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TB_Log.Size = new System.Drawing.Size(229, 183);
			this.TB_Log.TabIndex = 3;
			// 
			// ERR
			// 
			this.ERR.ContainerControl = this;
			// 
			// TB_ResMatrix
			// 
			this.TB_ResMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ResMatrix.Location = new System.Drawing.Point(503, 548);
			this.TB_ResMatrix.Multiline = true;
			this.TB_ResMatrix.Name = "TB_ResMatrix";
			this.TB_ResMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TB_ResMatrix.Size = new System.Drawing.Size(229, 72);
			this.TB_ResMatrix.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(501, 532);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(232, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Матрица результирующего преобразования";
			// 
			// SFD_SaveFile
			// 
			this.SFD_SaveFile.DefaultExt = "bmp";
			this.SFD_SaveFile.Filter = "Bitmap *.bmp|*.bmp";
			// 
			// MS_MainMenu
			// 
			this.MS_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_File,
            this.MMI_Data});
			this.MS_MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MS_MainMenu.Name = "MS_MainMenu";
			this.MS_MainMenu.Size = new System.Drawing.Size(745, 24);
			this.MS_MainMenu.TabIndex = 6;
			this.MS_MainMenu.Text = "menuStrip1";
			// 
			// MMI_File
			// 
			this.MMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_Save,
            this.MMI_Blank});
			this.MMI_File.Name = "MMI_File";
			this.MMI_File.Size = new System.Drawing.Size(45, 20);
			this.MMI_File.Text = "Файл";
			// 
			// MMI_Save
			// 
			this.MMI_Save.Name = "MMI_Save";
			this.MMI_Save.Size = new System.Drawing.Size(129, 22);
			this.MMI_Save.Text = "Сохранить";
			this.MMI_Save.Click += new System.EventHandler(this.MMI_Save_Click);
			// 
			// MMI_Blank
			// 
			this.MMI_Blank.Name = "MMI_Blank";
			this.MMI_Blank.Size = new System.Drawing.Size(129, 22);
			this.MMI_Blank.Text = "Бланк";
			this.MMI_Blank.Click += new System.EventHandler(this.MMI_Blank_Click);
			// 
			// MMI_Data
			// 
			this.MMI_Data.Name = "MMI_Data";
			this.MMI_Data.Size = new System.Drawing.Size(59, 20);
			this.MMI_Data.Text = "Данные";
			this.MMI_Data.Click += new System.EventHandler(this.MMI_Data_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 632);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TB_ResMatrix);
			this.Controls.Add(this.TB_Log);
			this.Controls.Add(this.TC_Mode);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MS_MainMenu);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.MS_MainMenu;
			this.Name = "Form1";
			this.Text = "Преобразования на плоскости";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Activated += new System.EventHandler(this.Form1_Activated);
			((System.ComponentModel.ISupportInitialize)(this.PB_Graphic)).EndInit();
			this.panel1.ResumeLayout(false);
			this.TC_Mode.ResumeLayout(false);
			this.TC_Mode_Affin.ResumeLayout(false);
			this.TC_Mode_Affin.PerformLayout();
			this.TC_Mode_Curves.ResumeLayout(false);
			this.TC_Mode_Curves.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ERR)).EndInit();
			this.MS_MainMenu.ResumeLayout(false);
			this.MS_MainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PB_Graphic;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl TC_Mode;
		private System.Windows.Forms.TabPage TC_Mode_Affin;
		private System.Windows.Forms.TabPage TC_Mode_Curves;
		private System.Windows.Forms.Label LBL_Angle;
		private System.Windows.Forms.Button BTN_Rotate;
		private System.Windows.Forms.TextBox TB_Angle;
		private System.Windows.Forms.TextBox TB_Value;
		private System.Windows.Forms.Label LBL_Value;
		private System.Windows.Forms.TextBox TB_Log;
		private System.Windows.Forms.ErrorProvider ERR;
		private System.Windows.Forms.TextBox TB_ResMatrix;
		private System.Windows.Forms.Button BTN_Move;
		private System.Windows.Forms.Button BTN_Symmetry;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BTN_Shift;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button BTN_Scaling;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button BTN_Move_0;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.SaveFileDialog SFD_SaveFile;
		private System.Windows.Forms.MenuStrip MS_MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MMI_File;
		private System.Windows.Forms.ToolStripMenuItem MMI_Save;
		private System.Windows.Forms.ToolStripMenuItem MMI_Blank;
		private System.Windows.Forms.ToolStripMenuItem MMI_Data;
		private System.Windows.Forms.Label LBL_ExcuseMe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button BTN_ApplyMatrix;
	}
}

