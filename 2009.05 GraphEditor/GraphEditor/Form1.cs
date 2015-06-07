using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GraphEditor
{
	public partial class FRM_Main : Form
	{
		#region Описание строковых констант
			//Варианты предопределенных значений полей ввода
			const string SNoDescr = "<нет описания>";
			const string SNotChange = "<не изменять>";
			//Варианты строк интерфейса
			const string SNoTable = "Не подключен список интервалов для анализа";
			const string SNoEdges = "<нет выбранных вершин>";
			const string SAskForSave = "В поле редактирования присутствует граф. Вы хотите его сохранить?";
			//Строки сообщений об ошибках
			const string SDebugMode = "Режим отладки. Вай, бяда!";
			//Заголовки всплывающих окон
			const string SWarning = "Предупреждение";
			const string SError = "Ошибка";
			const string SExit = "Выход";
			//Тексты некоторых ошибок
			const string SInvalidFile = "У нас тут бяка с файлом";
		#endregion
		public bool DebugMode = false;
		/// <summary>
		/// Граф, над которым работаем
		/// </summary>
		public TGraph graph = new TGraph();
		/// <summary>
		/// Список интервалов для анализа
		/// </summary>
		public List<TAnRec> lst = new List<TAnRec>();
		/// <summary>
		/// Возвращает числовое значение строки, не взирая на настройки локализации (десятичный разделитель)
		/// </summary>
		/// <param name="s">Строка для разбора</param>
		private double DoubleParse(string s)
		{
			//У-ха-ха-ха-ха!!!! Это заклинание вызова десятичного разделителя!!!
			string buf = s;
			buf = buf.Replace('.', System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
			buf = buf.Replace('.', System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
			return double.Parse(buf);
		}
		/// <summary>
		/// Возвращает числовое значение строки, не взирая на настройки локализации (десятичный разделитель)
		/// </summary>
		/// <param name="s">Строка для разбора</param>
		private double DoubleTryParse(string s)
		{
			//У-ха-ха-ха-ха!!!! Это заклинание вызова десятичного разделителя!!!
			double val;
			try
			{
				val = DoubleParse(s);
			}
			catch
			{
				val = 0;
			}
			return val;
		}
		/// <summary>
		/// Поиск минимальных и максимальных координат группы вершин. Вернет TRUE в случае удачи.
		/// </summary>
		/// <param name="lst">Группа вершин, в которой ищем.</param>
		/// <param name="min">Сюда вернем минимальные координаты</param>
		/// <param name="max">Сюда вернем максимальные координаты</param>
		bool FindMinMax(List<TEdgeRegular> lst, out Point min, out Point max)
		{
			int i;

			if (lst == null || lst.Count == 0 || graph.Count == 0 || graph == null)
			{
				min = new Point(0,0);
				max = new Point(0, 0);
				return false;
			}

			max = new Point(0, 0);
			min = new Point(graph.Width, graph.Height);
			//Находим минимальные и максимальные координаты выделенной группы вершин
			for (i = 0; i < graph.selected.Count; i++)
			{
				if (graph.selected[i].Pos.X < min.X)
					min.X = graph.selected[i].Pos.X;
				if (graph.selected[i].Pos.Y < min.Y)
					min.Y = graph.selected[i].Pos.Y;
				if (graph.selected[i].Pos.X > max.X)
					max.X = graph.selected[i].Pos.X;
				if (graph.selected[i].Pos.Y > max.Y)
					max.Y = graph.selected[i].Pos.Y;
			}
			return true;
		}
		/// <summary>
		/// Получаем тип вершины из значения, выбранного в CB_Type
		/// </summary>
		private EdgeTypes getEdgeType()
		{
			EdgeTypes res;
			string s;
			try
			{
				s = CB_Type.SelectedItem.ToString();
			}
			catch
			{
				s = "";
			}
			switch (s)
			{
				case "AND":
					res = EdgeTypes.AND;
					break;
				case "OR":
					res = EdgeTypes.OR;
					break;
				case "XOR":
					res = EdgeTypes.XOR;
					break;
				case "MIN":
					res = EdgeTypes.MIN;
					break;
				case "SUM":
					res = EdgeTypes.SUM;
					break;
				default:
					res = EdgeTypes.Regular;
					break;
			}
			return res;
		}
		/// <summary>
		/// Лавинно обновить интерфейс програмы
		/// </summary>
		public void InterfaceRefresh()
		{
			int i, j;
			if (graph.selected.Count > 0)
			{
				//Запоминаем позиции выделенных вершин
				SelPositions.Clear();
				for (i = 0; i < graph.selected.Count; i++)
					SelPositions.Add(graph.selected[i].Pos);

				GB_EdgeOptions.Text = "Параметры выделенных вершин";
				
				BTN_Apply.Enabled = true;

				CB_Type.SelectedIndex = Convert.ToInt32(graph.selected[graph.selected.Count - 1].Type);

				if (graph.selected.Count > 1)
				{
					TB_Hint.Text = SNotChange;
					TB_Value.Text = SNotChange;

					//Находим минимальные и максимальные координаты выделенной группы вершин
					Point max, min;
					if (FindMinMax(graph.selected, out min, out max))
					{
						//Назначаем пределы для изменения координат группы
						NUD_X.Maximum = graph.Width - 1 - max.X;
						NUD_X.Minimum = -min.X;
						NUD_Y.Maximum = graph.Height - 1 - max.Y;
						NUD_Y.Minimum = -min.Y;
						NUD_X.Value = 0;
						NUD_Y.Value = 0;
					}
					else if (DebugMode)
					{
						NUD_X.Maximum = 0;
						NUD_X.Minimum = 0;
						NUD_Y.Maximum = 0;
						NUD_Y.Minimum = 0;
						/*NUD_X.Value = 0;
						NUD_Y.Value = 0;
						NUD_X.Value = 0;
						NUD_Y.Value = 0;*/
						MessageBox.Show("Ошибка при определении минимальных и максимальных координат выделенных вершин. Возможно, граф и список выделенных отсутствуют или имеют нулевое количество элементов",SDebugMode);
					}
					
				}
				else
				{
					TB_Hint.Text = (graph.selected[0].Text == "" ? SNoDescr : graph.selected[0].Text);
					TB_Value.Text = graph.selected[0].Value.ToString();
					//Назначаем пределы для координат вершины
					NUD_X.Minimum = Convert.ToDecimal(0);
					NUD_X.Maximum = graph.Width - 1;
					NUD_Y.Minimum = NUD_X.Minimum;
					NUD_Y.Maximum = graph.Height - 1;

					NUD_X.Value = graph.selected.Count == 1 ? graph.selected[0].Pos.X : 0;
					NUD_Y.Value = graph.selected.Count == 1 ? graph.selected[0].Pos.Y : 0;
				}

				#region "Реализация анализа значения"

				string s;
				bool fl = false;

				TB_Analyse.Text = "";

				if (lst.Count > 0)
					for (i = 0; i < graph.selected.Count; i++)
					{
						s = graph.selected[i].ToString();
						for (j = 0; j < lst.Count; j++)
						{
							
							if (lst[j].TestValue(graph.selected[i].Value) != "")
							{
								s += "\r\n  " + lst[j].TestValue(graph.selected[i].Value);
								fl = true;
							}
						}
						if (!fl)
							s = graph.selected[i].ToString() + "\r\n  <Не входит ни в один из интервалов>";

						if (TB_Analyse.Text == "")
							TB_Analyse.Text = s + "\r\n\r\n";
						else
							TB_Analyse.Text += s + "\r\n\r\n";
					}
				else
					TB_Analyse.Text = SNoTable;

				#endregion
			}
			else
			{
				GB_EdgeOptions.Text = "Добавляемая вершина";
				//NUD_X.Enabled = false;
				//NUD_Y.Enabled = false;
				BTN_Apply.Enabled = false;
				TB_Analyse.Text = SNoEdges;
			}

			NUD_X.Enabled = (graph.selected.Count > 0);
			NUD_Y.Enabled = (graph.selected.Count > 0);
		}

		public FRM_Main()
		{
			InitializeComponent();
		}

		private void PB_Graph_Paint(object sender, PaintEventArgs e)
		{
			Graphics g;
			g = e.Graphics;
			graph.Draw(g, new Point(0,PB_Graph.Height));
			graph.DrawSelected(g);
		}

		private void PB_Graph_MouseMove(object sender, MouseEventArgs e)
		{
			Point loc = new Point(e.X,e.Y);
			int offs = (graph != null ? graph.yOffs : 300);
			LBL_StatusBar.Text = loc.X.ToString() + ":" + (-loc.Y + offs).ToString() + graph.ConvertToNodePos(loc).ToString();
			TEdgeRegular buf = graph.FindByCoords(loc);
			if (buf != null)
			{
				LBL_StatusBar.Text = LBL_StatusBar.Text + " : " + buf.Type.ToString() + " - " + (buf.Text == "" ? SNoDescr : buf.Text);
			}

			#region Реализация перетаскивания вершин
			if (flMouseDown && DragEdge != null)
			{
				if (buf != null && DebugMode) LBL_StatusBar.Text = buf.ToString();
				if (graph.FindByPos(graph.ConvertToNodePos(loc)) == null)
				{
					DragEdge.Pos = graph.ConvertToNodePos(loc);
					PB_Graph.Refresh();
				}
				graphChanged = true;
			}
			#endregion
		}

		private void FRM_Main_Load(object sender, EventArgs e)
		{
			FRM_Settings = new TFRM_Settings();
			FRM_Settings.FRM_MainForm = this;
			PB_Graph.Width = graph.SizeInPixels.X;
			PB_Graph.Height = graph.SizeInPixels.Y;
			//graph.yOffs = PB_Graph.Height;
			//Задаем начальный тип вершин
			CB_Type.SelectedIndex = 0;
			SFD_Save.InitialDirectory = Application.StartupPath;
			OFD_Load.InitialDirectory = Application.StartupPath;

		}

		private void MMI_Settings_Click(object sender, EventArgs e)
		{
			FRM_Settings.Visible = true;
		}

		private void PB_Graph_SizeChanged(object sender, EventArgs e)
		{
			graph.yOffs = PB_Graph.Height;
			PB_Graph.Refresh();
		}

		private void PB_Graph_MouseClick(object sender, MouseEventArgs e)
		{
			Point pos = new Point(e.Location.X, e.Location.Y);
			PAN_Graph.Focus();
			TEdgeRegular edge = graph.FindByCoords(pos);
			int i;
			double val;
			
			//Проверка какой кнопкой кликнули
			switch (e.Button)
			{	//Если кликнули левой кнопкой
				case MouseButtons.Left:
					if (edge != null)	//Если кликнули на вершину и зажат Control - выделяем ее или снимаем выделение
					{
						if (!Control)	//Если Control не зажат,  сбрасываем всё выделение и начинаем выделять по-новой
						{
							graph.selected.Clear();
						}
						graph.SelectDeselect(edge);
						InterfaceRefresh();
					}
					else				//Иначе - создаем вершину в месте клика
					{
						//if (!double.TryParse(TB_Value.Text, out val))
						//	val = 0;
						try
						{
							val = DoubleTryParse(TB_Value.Text);
							string descr = "";
							switch (TB_Hint.Text)
							{
								case SNotChange:
								case SNoDescr:
									break;
								default:
									descr = TB_Hint.Text;
									break;
							}
							graph.AddEdge(pos, descr, getEdgeType(), val);
							//this.Text = pos.ToString();
						}
						catch (Exception ex)
						{
							if (DebugMode)
								MessageBox.Show(ex.Message,SDebugMode);
						}
						graphChanged = true;
					}
					break;
				//Если кликнули правой кнопкой
				case MouseButtons.Right:
					if (edge != null)
					{
						//Соединяем все выделенные вершины с той, на которую кликнули
						for (i = 0; i < graph.selected.Count; i++)
							if (graph.selected[i] != edge)
								//edge.AddBowFrom(graph.selected[i]);
								graph.AddBow(graph.selected[i], edge, BowTypes.To2, 0);
						graphChanged = true;
					}
					break;
			}
			PB_Graph.Refresh();
			Graphics g = PB_Graph.CreateGraphics();
			graph.Draw(g, new Point(0, PB_Graph.Height));
			graph.DrawSelected(g);
		}

		private void FRM_Main_KeyDown(object sender, KeyEventArgs e)
		{
			if (MouseOnGraph == true)
			{
				switch ((int)e.KeyData)
				{
					case (int)Keys.Delete:
						if (!TB_Value.Focused && !TB_Hint.Focused)
						{
							graph.DelSelected();
							PB_Graph.Refresh();
							graphChanged = true;
							e.Handled = true;
							InterfaceRefresh();
						}
						break;
					case (int)Keys.Escape:
						graph.selected.Clear();
						PB_Graph.Refresh();
						InterfaceRefresh();
						//e.Handled = true;
						break;
					case (int)Keys.ControlKey + (int)Keys.Control:
						Control = true;
						//this.Text = "Yep";
						//e.Handled = true;
						break;
				}
				//Text = ((int)e.KeyData).ToString() + " " + ((int)Keys.Control + (int)Keys.D).ToString();
				
			}
			switch (e.KeyData)
			{
				case Keys.F1:
					MMI_About_Click(null, null);
					break;
			}

		}

		private void FRM_Main_KeyUp(object sender, KeyEventArgs e)
		{
			Control = false;
		}

		private void FRM_Main_KeyPress(object sender, KeyPressEventArgs e)
		{
			int i;

			//Text = Convert.ToInt32(e.KeyChar).ToString();
			//Таким образом отлавливаем нажатие Ctrl+Key. Увы, способа без применения "магических чисел" я не нашел :)
			switch (Convert.ToInt32(e.KeyChar))
			{
				case 1:		//Ctrl+A
					graph.selected.Clear();
					for (i = 0; i < graph.Count; i++)
						graph.selected.Add(graph[i]);
					PB_Graph.Refresh();
					InterfaceRefresh();
					break;
				case 19:	//Ctrl+S
					MMI_SaveAs_Click(null, null);
					break;
				case 6:		//Ctrl+F
					MMI_Load_Click(null, null);
					break;
			}
			/*if (!TB_Value.Focused)
			{
				if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',')
					TB_Value.Text = TB_Value.Text + e.KeyChar.ToString();
				if ((int)e.KeyChar == 8 && TB_Value.Text.Length > 0)
					TB_Value.Text = TB_Value.Text.Remove(TB_Value.Text.Length - 1);
				if (e.KeyChar == '-' && !TB_Value.Text.Contains("-"))
					TB_Value.Text = "-" + TB_Value.Text;
				if (e.KeyChar == '+')
					TB_Value.Text = TB_Value.Text.Replace("-", "");
				//TB_Value.Focus();
			}*/
		}


		private void PB_Graph_MouseEnter(object sender, EventArgs e)
		{
			MouseOnGraph = true;
		}

		private void PB_Graph_MouseLeave(object sender, EventArgs e)
		{
			MouseOnGraph = false;
		}

		private void BTN_Apply_Click(object sender, EventArgs e)
		{
			if (graph.selected.Count == 0)
			{
				MessageBox.Show("По идее, эта кнопка сейчас должна быть неактивна", SError);
				return;
			}

			int i;
			Point pos = new Point(Convert.ToInt32(NUD_X.Value), Convert.ToInt32(NUD_Y.Value));
			double val;
			bool fl = true;		//Индикатор правильности ввода значения
			try
			{
				val = DoubleParse(TB_Value.Text);
			}
			catch
			{
				val = 0;
				fl = false;
			}

			for (i = 0; i < graph.selected.Count; i++)
			{
				try
				{
					graph.ChangeType(graph.selected[i], getEdgeType());
				}
				catch (Exception ex)
				{
					if (DebugMode)
						MessageBox.Show(ex.Message, SDebugMode);
				}
				if (TB_Hint.Text != SNotChange)
					graph.selected[i].Text = TB_Hint.Text;
				if (graph.selected[i].Type == EdgeTypes.Regular && fl)
					graph.selected[i].Value = val;
				/*if (graph.selected.Count == 1)
				{
					if (graph.FindByPos(pos) == null)
						graph.selected[0].Pos = pos;
					NUD_X.Value = graph.selected[0].Pos.X;
					NUD_Y.Value = graph.selected[0].Pos.Y;
				}*/
			}

			PB_Graph.Refresh();
			graphChanged = true;
		}

		private void CB_Type_KeyDown(object sender, KeyEventArgs e)
		{
			//Это замена ненайденному мной параметру ReadOnle у CB_Type
			if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
				e.Handled = true;
			
		}

		private void CB_Type_KeyPress(object sender, KeyPressEventArgs e)
		{
			//Это замена ненайденному мной параметру ReadOnle у CB_Type
			e.Handled = true;
		}

		private void PB_Graph_MouseDown(object sender, MouseEventArgs e)
		{
			flMouseDown = true;
			mouse = e.Location;
			DragEdge = graph.FindByCoords(mouse);
			if (DebugMode)
			{
				if (DragEdge != null)
					Text = DragEdge.ToString();
				else
					Text = "null";
			}
		}

		private void PB_Graph_MouseUp(object sender, MouseEventArgs e)
		{
			flMouseDown = false;
			DragEdge = null;
		}

		private void MMI_About_Click(object sender, EventArgs e)
		{
			FRM_About frm = new FRM_About();
			frm.Visible = true;
		}

		private void MMI_Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MMI_SaveAs_Click(object sender, EventArgs e)
		{
			Control = false;
			if (SFD_Save.ShowDialog() == DialogResult.OK)
			{
				graph.SaveToFile(SFD_Save.FileName);
				graphChanged = false;
			}
		}

		private void MMI_Load_Click(object sender, EventArgs e)
		{
			Control = false;
			if(graphChanged)
				switch (MessageBox.Show(SAskForSave, SExit, MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						if (SFD_Save.ShowDialog() == DialogResult.OK)
						{
							graph.SaveToFile(SFD_Save.FileName);
						}
						else
							return;
						break;
					case DialogResult.Cancel:
						return;
						//break;
					case DialogResult.No:
						break;
					default:
						MessageBox.Show("O_o");
						break;
				}
			if (OFD_Load.ShowDialog() == DialogResult.OK)
			{
				try
				{
					graph = TGraph.LoadFromFile(OFD_Load.FileName);
					PB_Graph.Width = graph.SizeInPixels.X;
					PB_Graph.Height = graph.SizeInPixels.Y;
					graphChanged = false;
					PB_Graph.Refresh();
					InterfaceRefresh();
				}
				catch 
				{
					graph = new TGraph();
					PB_Graph.Width = graph.SizeInPixels.X;
					PB_Graph.Height = graph.SizeInPixels.Y;
					graphChanged = false;
					PB_Graph.Refresh();
					InterfaceRefresh();
					MessageBox.Show(SInvalidFile,SError);
				}
			}
		}

		private void FRM_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (graph.Count > 0 && graphChanged)
				switch (MessageBox.Show(SAskForSave, SExit, MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						if (SFD_Save.ShowDialog() == DialogResult.OK)
						{
							graph.SaveToFile(SFD_Save.FileName);
						}
						else
							e.Cancel = true;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
					case DialogResult.No:
						break;
					default:
						MessageBox.Show("O_o");
						break;
				}
		}

		private void MMI_Analyse_Click(object sender, EventArgs e)
		{
			TFRM_Analyse af = new TFRM_Analyse();
			af.parent = this;
			af.ShowDialog();
		}

		private void MMI_SaveAnTable_Click(object sender, EventArgs e)
		{
			if (lst.Count == 0)
			{
				MessageBox.Show("Список интервалов не задан. Сохранять нечего",SWarning);
				return;
			}

			int i;
			string buf = SFD_Save.Filter;
			string FileName = "";
			SFD_Save.Filter = "Таблица интервалов *.toi|*.toi|All files *.*|*.*";

			if (SFD_Save.ShowDialog() == DialogResult.OK)
			{
				FileName = SFD_Save.FileName;
				FileStream fs = new FileStream
				   (FileName, FileMode.Create, FileAccess.Write);
				StreamWriter fsw = new StreamWriter(fs);
				fsw.WriteLine(lst.Count);
				for (i = 0; i < lst.Count; i++)
				{
					fsw.WriteLine(lst[i].ToString()); 
				}
				fsw.Close();
				fs.Close();
			}

			SFD_Save.Filter = buf;
		}

		private void MMI_LoadAnTable_Click(object sender, EventArgs e)
		{
			string buf = OFD_Load.Filter;
			int count = 0, i;
			TAnRec rec;
			OFD_Load.Filter = "Таблица интервалов *.toi|*.toi|All files *.*|*.*";

			if (OFD_Load.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream
				   (OFD_Load.FileName, FileMode.Open, FileAccess.Read);
				StreamReader fsr = new StreamReader(fs);

				try
				{
					count = int.Parse(fsr.ReadLine());
					for (i = 0; i < count; i++)
					{
						rec = new TAnRec();
						rec.begin = DoubleParse(fsr.ReadLine());
						rec.end = DoubleParse(fsr.ReadLine());
						rec.description = fsr.ReadLine().Replace("<r>", "\r").Replace("<n>", "\n").Replace("<t>", "\t").Replace("<s>", " " );
						lst.Add(rec);
					}
					GB_Analyse.Visible = true;
				}
				catch
				{
					MessageBox.Show(SInvalidFile, SError);
					return;
				}
				
				fsr.Close();
				fs.Close();
			}

			InterfaceRefresh();

			OFD_Load.Filter = buf;
		}

		private void TB_Value_TextChanged(object sender, EventArgs e)
		{
			if (TB_Value.Text != SNotChange)
			{
				int i;
				double val = 0;
				val = DoubleTryParse(TB_Value.Text);
				for (i = 0; i < graph.selected.Count; i++)
					graph.selected[i].Value = val;
				PB_Graph.Refresh();
			}
		}

		/// <summary>
		/// Перемещает выделенные вершины на расстояние, указанное в NUD_X и NUD_Y. Выход за пределы видимой сетки не проверяет.
		/// </summary>
		private void MoveSelected()
		{
			int i;
			Point pos = new Point(Convert.ToInt32(NUD_X.Value), Convert.ToInt32(NUD_Y.Value));
			Point buf = new Point();

			
			if (graph.selected.Count == 1)
			{
				if (graph.FindByPos(pos) == null)
					graph.selected[0].Pos = pos;
				graphChanged = true;
				//NUD_X.Value = graph.selected[0].Pos.X;
				//NUD_Y.Value = graph.selected[0].Pos.Y;
			}
			else
			{
				//Ищем минимальные и максимальные координаты группы
				Point min, max;
				int h, w, limw, limh;
				FindMinMax(graph.selected, out min, out max);
				//Задаем порядок обхода списка выделенных вершин
				bool flx = NUD_X.Value - lastNUD_X < 0;
				bool fly = NUD_Y.Value - lastNUD_Y < 0;
				
				limw = flx ? max.X : min.X;
				limh = fly ? max.Y : min.Y;

				for (w = flx ? min.X : max.X; (flx ? w <= limw : w >= limw); w = (flx ? w + 1 : w - 1))
					for (h = fly ? min.Y : max.Y; (fly ? h <= limh : h >= limh); h = (fly ? h + 1 : h - 1))
					{
						//Выставляем индекс на номер выделенной вершины с координатами (w,h)
						for (i = 0; i < graph.selected.Count && graph.selected[i].Pos != new Point(w, h); i++) ;
						if (i < graph.selected.Count)
						{	//throw new Exception("MoveSelected: ошибка в цикле обхода вершин");
							//Перемещение вершины
							buf.X = pos.X + SelPositions[i].X;
							buf.Y = pos.Y + SelPositions[i].Y;
							if (graph.FindByPos(buf) == null || graph.FindByPos(buf) == graph.selected[i])
								graph.selected[i].Pos = buf;
						}
					}

				//Старый простой порядок обхода вершин
				/*for (i = 0; i < graph.selected.Count; i++)
				{
					buf.X = pos.X + SelPositions[i].X;
					buf.Y = pos.Y + SelPositions[i].Y;
					if (graph.FindByPos(buf) == null || graph.FindByPos(buf) == graph.selected[i])
						graph.selected[i].Pos = buf;
				}*/
				graphChanged = true;
			}
			PB_Graph.Refresh();
		}

		private void NUD_X_ValueChanged(object sender, EventArgs e)
		{
			//Функция будет работать только в случае, если это поле получило фокус ввода.
			//По моим предположениям, это должно обеспечить ее выполнение только в случае изменения значения пользователем, а на программные изменения реагировать не должно.
			if (!NUD_X.Focused) return;
			try
			{
				MoveSelected();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, SError);
			}
			lastNUD_X = Convert.ToInt32(NUD_X.Value);
		}

		private void NUD_Y_ValueChanged(object sender, EventArgs e)
		{

			//Функция будет работать только в случае, если это поле получило фокус ввода.
			//По моим предположениям, это должно обеспечить ее выполнение только в случае изменения значения пользователем, а на программные изменения реагировать не должно.
			if (!NUD_Y.Focused) return;
			try
			{
				MoveSelected();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, SError);
			}
			lastNUD_Y = Convert.ToInt32(NUD_Y.Value);
		}
	}
}
