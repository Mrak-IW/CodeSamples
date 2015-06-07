using System.Drawing;
using System.Collections.Generic;

namespace GraphEditor
{
	partial class FRM_Main
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MMI_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Load = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_SaveAnTable = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_LoadAnTable = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Analyse = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.MMI_About = new System.Windows.Forms.ToolStripMenuItem();
			this.PAN_Graph = new System.Windows.Forms.Panel();
			this.PB_Graph = new System.Windows.Forms.PictureBox();
			this.GB_EdgeOptions = new System.Windows.Forms.GroupBox();
			this.BTN_Apply = new System.Windows.Forms.Button();
			this.LBL_Y = new System.Windows.Forms.Label();
			this.LBL_X = new System.Windows.Forms.Label();
			this.NUD_Y = new System.Windows.Forms.NumericUpDown();
			this.NUD_X = new System.Windows.Forms.NumericUpDown();
			this.LBL_Value = new System.Windows.Forms.Label();
			this.TB_Value = new System.Windows.Forms.TextBox();
			this.LBL_Hint = new System.Windows.Forms.Label();
			this.TB_Hint = new System.Windows.Forms.TextBox();
			this.CB_Type = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LBL_StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
			this.OFD_Load = new System.Windows.Forms.OpenFileDialog();
			this.SFD_Save = new System.Windows.Forms.SaveFileDialog();
			this.GB_Analyse = new System.Windows.Forms.GroupBox();
			this.TB_Analyse = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.PAN_Graph.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Graph)).BeginInit();
			this.GB_EdgeOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_X)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.GB_Analyse.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_File,
            this.MMI_Edit,
            this.MMI_Help});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(575, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MMI_File
			// 
			this.MMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_SaveAs,
            this.MMI_Load,
            this.MMI_SaveAnTable,
            this.MMI_LoadAnTable,
            this.MMI_Exit});
			this.MMI_File.Name = "MMI_File";
			this.MMI_File.Size = new System.Drawing.Size(45, 20);
			this.MMI_File.Text = "Файл";
			// 
			// MMI_SaveAs
			// 
			this.MMI_SaveAs.Name = "MMI_SaveAs";
			this.MMI_SaveAs.Size = new System.Drawing.Size(218, 22);
			this.MMI_SaveAs.Text = "Сохранить как...";
			this.MMI_SaveAs.Click += new System.EventHandler(this.MMI_SaveAs_Click);
			// 
			// MMI_Load
			// 
			this.MMI_Load.Name = "MMI_Load";
			this.MMI_Load.Size = new System.Drawing.Size(218, 22);
			this.MMI_Load.Text = "Загрузить";
			this.MMI_Load.Click += new System.EventHandler(this.MMI_Load_Click);
			// 
			// MMI_SaveAnTable
			// 
			this.MMI_SaveAnTable.Name = "MMI_SaveAnTable";
			this.MMI_SaveAnTable.Size = new System.Drawing.Size(218, 22);
			this.MMI_SaveAnTable.Text = "Сохранить таблицу анализа";
			this.MMI_SaveAnTable.Click += new System.EventHandler(this.MMI_SaveAnTable_Click);
			// 
			// MMI_LoadAnTable
			// 
			this.MMI_LoadAnTable.Name = "MMI_LoadAnTable";
			this.MMI_LoadAnTable.Size = new System.Drawing.Size(218, 22);
			this.MMI_LoadAnTable.Text = "Загрузить таблицу анализа";
			this.MMI_LoadAnTable.Click += new System.EventHandler(this.MMI_LoadAnTable_Click);
			// 
			// MMI_Exit
			// 
			this.MMI_Exit.Name = "MMI_Exit";
			this.MMI_Exit.Size = new System.Drawing.Size(218, 22);
			this.MMI_Exit.Text = "Выход";
			this.MMI_Exit.Click += new System.EventHandler(this.MMI_Exit_Click);
			// 
			// MMI_Edit
			// 
			this.MMI_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_Settings,
            this.MMI_Analyse});
			this.MMI_Edit.Name = "MMI_Edit";
			this.MMI_Edit.Size = new System.Drawing.Size(56, 20);
			this.MMI_Edit.Text = "Правка";
			// 
			// MMI_Settings
			// 
			this.MMI_Settings.Name = "MMI_Settings";
			this.MMI_Settings.Size = new System.Drawing.Size(128, 22);
			this.MMI_Settings.Text = "Настройки";
			this.MMI_Settings.Click += new System.EventHandler(this.MMI_Settings_Click);
			// 
			// MMI_Analyse
			// 
			this.MMI_Analyse.Name = "MMI_Analyse";
			this.MMI_Analyse.Size = new System.Drawing.Size(128, 22);
			this.MMI_Analyse.Text = "Анализ";
			this.MMI_Analyse.Click += new System.EventHandler(this.MMI_Analyse_Click);
			// 
			// MMI_Help
			// 
			this.MMI_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMI_About});
			this.MMI_Help.Name = "MMI_Help";
			this.MMI_Help.Size = new System.Drawing.Size(62, 20);
			this.MMI_Help.Text = "Справка";
			// 
			// MMI_About
			// 
			this.MMI_About.Name = "MMI_About";
			this.MMI_About.Size = new System.Drawing.Size(138, 22);
			this.MMI_About.Text = "О программе";
			this.MMI_About.Click += new System.EventHandler(this.MMI_About_Click);
			// 
			// PAN_Graph
			// 
			this.PAN_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PAN_Graph.AutoScroll = true;
			this.PAN_Graph.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.PAN_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PAN_Graph.Controls.Add(this.PB_Graph);
			this.PAN_Graph.Location = new System.Drawing.Point(13, 28);
			this.PAN_Graph.Name = "PAN_Graph";
			this.PAN_Graph.Size = new System.Drawing.Size(377, 441);
			this.PAN_Graph.TabIndex = 2;
			// 
			// PB_Graph
			// 
			this.PB_Graph.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PB_Graph.Location = new System.Drawing.Point(4, 4);
			this.PB_Graph.MinimumSize = new System.Drawing.Size(100, 100);
			this.PB_Graph.Name = "PB_Graph";
			this.PB_Graph.Size = new System.Drawing.Size(400, 400);
			this.PB_Graph.TabIndex = 0;
			this.PB_Graph.TabStop = false;
			this.PB_Graph.MouseLeave += new System.EventHandler(this.PB_Graph_MouseLeave);
			this.PB_Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Graph_MouseMove);
			this.PB_Graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_Graph_MouseClick);
			this.PB_Graph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Graph_MouseDown);
			this.PB_Graph.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Graph_Paint);
			this.PB_Graph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Graph_MouseUp);
			this.PB_Graph.SizeChanged += new System.EventHandler(this.PB_Graph_SizeChanged);
			this.PB_Graph.MouseEnter += new System.EventHandler(this.PB_Graph_MouseEnter);
			// 
			// GB_EdgeOptions
			// 
			this.GB_EdgeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GB_EdgeOptions.Controls.Add(this.BTN_Apply);
			this.GB_EdgeOptions.Controls.Add(this.LBL_Y);
			this.GB_EdgeOptions.Controls.Add(this.LBL_X);
			this.GB_EdgeOptions.Controls.Add(this.NUD_Y);
			this.GB_EdgeOptions.Controls.Add(this.NUD_X);
			this.GB_EdgeOptions.Controls.Add(this.LBL_Value);
			this.GB_EdgeOptions.Controls.Add(this.TB_Value);
			this.GB_EdgeOptions.Controls.Add(this.LBL_Hint);
			this.GB_EdgeOptions.Controls.Add(this.TB_Hint);
			this.GB_EdgeOptions.Controls.Add(this.CB_Type);
			this.GB_EdgeOptions.Location = new System.Drawing.Point(396, 32);
			this.GB_EdgeOptions.Name = "GB_EdgeOptions";
			this.GB_EdgeOptions.Size = new System.Drawing.Size(175, 308);
			this.GB_EdgeOptions.TabIndex = 0;
			this.GB_EdgeOptions.TabStop = false;
			this.GB_EdgeOptions.Text = "Добавляемая вершина";
			// 
			// BTN_Apply
			// 
			this.BTN_Apply.Enabled = false;
			this.BTN_Apply.Location = new System.Drawing.Point(9, 280);
			this.BTN_Apply.Name = "BTN_Apply";
			this.BTN_Apply.Size = new System.Drawing.Size(158, 23);
			this.BTN_Apply.TabIndex = 3;
			this.BTN_Apply.Text = "Применить";
			this.BTN_Apply.UseVisualStyleBackColor = true;
			this.BTN_Apply.Click += new System.EventHandler(this.BTN_Apply_Click);
			// 
			// LBL_Y
			// 
			this.LBL_Y.AutoSize = true;
			this.LBL_Y.Location = new System.Drawing.Point(27, 256);
			this.LBL_Y.Name = "LBL_Y";
			this.LBL_Y.Size = new System.Drawing.Size(14, 13);
			this.LBL_Y.TabIndex = 6;
			this.LBL_Y.Text = "Y";
			// 
			// LBL_X
			// 
			this.LBL_X.AutoSize = true;
			this.LBL_X.Location = new System.Drawing.Point(27, 235);
			this.LBL_X.Name = "LBL_X";
			this.LBL_X.Size = new System.Drawing.Size(14, 13);
			this.LBL_X.TabIndex = 6;
			this.LBL_X.Text = "X";
			// 
			// NUD_Y
			// 
			this.NUD_Y.Enabled = false;
			this.NUD_Y.Location = new System.Drawing.Point(47, 254);
			this.NUD_Y.Name = "NUD_Y";
			this.NUD_Y.Size = new System.Drawing.Size(120, 20);
			this.NUD_Y.TabIndex = 5;
			this.NUD_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NUD_Y.ValueChanged += new System.EventHandler(this.NUD_Y_ValueChanged);
			// 
			// NUD_X
			// 
			this.NUD_X.Enabled = false;
			this.NUD_X.Location = new System.Drawing.Point(47, 228);
			this.NUD_X.Name = "NUD_X";
			this.NUD_X.Size = new System.Drawing.Size(120, 20);
			this.NUD_X.TabIndex = 4;
			this.NUD_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NUD_X.ValueChanged += new System.EventHandler(this.NUD_X_ValueChanged);
			// 
			// LBL_Value
			// 
			this.LBL_Value.AutoSize = true;
			this.LBL_Value.Location = new System.Drawing.Point(7, 186);
			this.LBL_Value.Name = "LBL_Value";
			this.LBL_Value.Size = new System.Drawing.Size(58, 13);
			this.LBL_Value.TabIndex = 4;
			this.LBL_Value.Text = "Значение:";
			// 
			// TB_Value
			// 
			this.TB_Value.Location = new System.Drawing.Point(9, 202);
			this.TB_Value.Name = "TB_Value";
			this.TB_Value.Size = new System.Drawing.Size(158, 20);
			this.TB_Value.TabIndex = 0;
			this.TB_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TB_Value.TextChanged += new System.EventHandler(this.TB_Value_TextChanged);
			// 
			// LBL_Hint
			// 
			this.LBL_Hint.AutoSize = true;
			this.LBL_Hint.Location = new System.Drawing.Point(7, 57);
			this.LBL_Hint.Name = "LBL_Hint";
			this.LBL_Hint.Size = new System.Drawing.Size(109, 13);
			this.LBL_Hint.TabIndex = 2;
			this.LBL_Hint.Text = "Описание вершины:";
			// 
			// TB_Hint
			// 
			this.TB_Hint.Location = new System.Drawing.Point(9, 73);
			this.TB_Hint.Multiline = true;
			this.TB_Hint.Name = "TB_Hint";
			this.TB_Hint.Size = new System.Drawing.Size(160, 108);
			this.TB_Hint.TabIndex = 1;
			// 
			// CB_Type
			// 
			this.CB_Type.Items.AddRange(new object[] {
            "Стандартная",
            "AND",
            "OR",
            "XOR",
            "MIN",
            "SUM"});
			this.CB_Type.Location = new System.Drawing.Point(7, 29);
			this.CB_Type.Name = "CB_Type";
			this.CB_Type.Size = new System.Drawing.Size(160, 21);
			this.CB_Type.TabIndex = 2;
			this.CB_Type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_Type_KeyPress);
			this.CB_Type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CB_Type_KeyDown);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_StatusBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 473);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(575, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// LBL_StatusBar
			// 
			this.LBL_StatusBar.Name = "LBL_StatusBar";
			this.LBL_StatusBar.Size = new System.Drawing.Size(76, 17);
			this.LBL_StatusBar.Text = "LBL_StatusBar";
			// 
			// OFD_Load
			// 
			this.OFD_Load.DefaultExt = "gre";
			this.OFD_Load.FileName = "default";
			this.OFD_Load.Filter = "Граф *.gre|*.gre|All files *.*|*.*";
			// 
			// SFD_Save
			// 
			this.SFD_Save.DefaultExt = "gre";
			this.SFD_Save.Filter = "Граф *.gre|*.gre|All files *.*|*.*";
			// 
			// GB_Analyse
			// 
			this.GB_Analyse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.GB_Analyse.Controls.Add(this.TB_Analyse);
			this.GB_Analyse.Location = new System.Drawing.Point(397, 347);
			this.GB_Analyse.Name = "GB_Analyse";
			this.GB_Analyse.Size = new System.Drawing.Size(174, 122);
			this.GB_Analyse.TabIndex = 1;
			this.GB_Analyse.TabStop = false;
			this.GB_Analyse.Text = "Анализ";
			this.GB_Analyse.Visible = false;
			// 
			// TB_Analyse
			// 
			this.TB_Analyse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Analyse.Location = new System.Drawing.Point(7, 20);
			this.TB_Analyse.Multiline = true;
			this.TB_Analyse.Name = "TB_Analyse";
			this.TB_Analyse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_Analyse.Size = new System.Drawing.Size(159, 96);
			this.TB_Analyse.TabIndex = 0;
			// 
			// FRM_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 495);
			this.Controls.Add(this.GB_Analyse);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.GB_EdgeOptions);
			this.Controls.Add(this.PAN_Graph);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(480, 400);
			this.Name = "FRM_Main";
			this.Text = "Редактор графов";
			this.Load += new System.EventHandler(this.FRM_Main_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FRM_Main_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FRM_Main_KeyUp);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_Main_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_Main_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.PAN_Graph.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_Graph)).EndInit();
			this.GB_EdgeOptions.ResumeLayout(false);
			this.GB_EdgeOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD_X)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.GB_Analyse.ResumeLayout(false);
			this.GB_Analyse.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Panel PAN_Graph;
		private System.Windows.Forms.ToolStripMenuItem MMI_File;
		private System.Windows.Forms.ToolStripMenuItem MMI_Edit;
		private System.Windows.Forms.ToolStripMenuItem MMI_Settings;

		#region Элементы, введенные МНОЙ

		public TFRM_Settings FRM_Settings;
		/// <summary>
		/// Сигнализирует, ноходится ли курсор мыши над полем редактирования
		/// </summary>
		public bool MouseOnGraph = false;
		/// <summary>
		/// Сигнализирует, нажата ли левая кнопка мыши на PB_Graph
		/// </summary>
		public bool flMouseDown = false;
		/// <summary>
		/// Координаты мыши, преобразованные в точку сетки, когда была нажата левая кнопка
		/// </summary>
		Point mouse;
		/// <summary>
		/// Перетаскиваемая вершина
		/// </summary>
		TEdgeRegular DragEdge = null;
		/// <summary>
		/// Сигнализирует, был ли изменен граф в поле редактирования
		/// </summary>
		private bool graphChanged = false;
		/// <summary>
		/// Сигнализирует, зажат ли Control
		/// </summary>
		private bool Control = false;
		/// <summary>
		/// Здесь запоминаются начальные позиции для выделенных вершин. Используется при групповом перемещении.
		/// </summary>
		private List<Point> SelPositions = new List<Point>();
		/// <summary>
		/// Последнее значение NUD_X до изменения
		/// </summary>
		private int lastNUD_X = 0;
		/// <summary>
		/// Последнее значение NUD_Y до изменения
		/// </summary>
		private int lastNUD_Y = 0;

		#endregion

		/// <summary>
		/// Объект, на котором отображается граф
		/// </summary>
		public System.Windows.Forms.PictureBox PB_Graph;
		private System.Windows.Forms.GroupBox GB_EdgeOptions;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel LBL_StatusBar;
		private System.Windows.Forms.ComboBox CB_Type;
		private System.Windows.Forms.Label LBL_Value;
		private System.Windows.Forms.TextBox TB_Value;
		private System.Windows.Forms.Label LBL_Hint;
		private System.Windows.Forms.TextBox TB_Hint;
		private System.Windows.Forms.Label LBL_X;
		private System.Windows.Forms.NumericUpDown NUD_Y;
		private System.Windows.Forms.NumericUpDown NUD_X;
		private System.Windows.Forms.Label LBL_Y;
		private System.Windows.Forms.Button BTN_Apply;
		/// <summary>
		/// Элемент главного меню
		/// </summary>
		private System.Windows.Forms.ToolStripMenuItem MMI_Help;
		/// <summary>
		/// Элемент главного меню
		/// </summary>
		private System.Windows.Forms.ToolStripMenuItem MMI_About;
		/// <summary>
		/// Элемент главного меню
		/// </summary>
		private System.Windows.Forms.ToolStripMenuItem MMI_SaveAs;
		/// <summary>
		/// Элемент главного меню
		/// </summary>
		private System.Windows.Forms.ToolStripMenuItem MMI_Load;
		/// <summary>
		/// Элемент главного меню
		/// </summary>
		private System.Windows.Forms.ToolStripMenuItem MMI_Exit;
		/// <summary>
		/// Диалог открытия файлов
		/// </summary>
		private System.Windows.Forms.OpenFileDialog OFD_Load;
		/// <summary>
		/// Диалог сохранения файлов
		/// </summary>
		private System.Windows.Forms.SaveFileDialog SFD_Save;
		private System.Windows.Forms.ToolStripMenuItem MMI_Analyse;
		private System.Windows.Forms.TextBox TB_Analyse;
		private System.Windows.Forms.ToolStripMenuItem MMI_SaveAnTable;
		private System.Windows.Forms.ToolStripMenuItem MMI_LoadAnTable;
		public System.Windows.Forms.GroupBox GB_Analyse;
	}
}

