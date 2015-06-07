using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NSGraphic;
using Matrix;

namespace MarkovChain
{
	public partial class FRM_Epur : Form
	{
		public Form1 parent = null;
		public int stateCount = 0;
		public int[] stateHistory = null;
		public double[] stateValues = null;
		private double[] values = null;
		private TGraphic epur = new TGraphic();
		private TGraphic effect1 = new TGraphic();
		private TEffect eff1 = new TEffect();

		/// <summary>
		/// На этом объекте графики будут отображаться все ипюры
		/// </summary>
		Graphics gr;

		/// <summary>
		/// Наполняем данными, размещаем и масштабируем графики переключения состояний и эффектов
		/// </summary>
		private void RefreshGraphicStatesValues()
		{
			int i, j, cnt, k;
			int maxcnt = 40, mincnt = 10;
			double steplen = 0.05;
			int[] cnts;
			Random rnd = new Random();
			//Задаем поведение эффекта 1
			eff1.behaviorList.Add(new TRandomVar(EffectType.RND, 6, 5));
			eff1.behaviorList.Add(new TRandomVar(EffectType.CONST, 10, 0));
			eff1.behaviorList.Add(new TRandomVar(EffectType.CONST, 5, 0));
			
			//Создаем и наполняем массив значений по Y для графика переключения состояний
			epur.arrY = new double[stateHistory.Length];
			cnt = 0;										//Здесь будет общее количество точек на графиках немарковских процесов (эффектов)
			cnts = new int[stateHistory.Length];			//В этом массиве будем хранить длины промежутков.
			for (i = 0; i < stateHistory.Length; i++)
			{
				epur.arrY[i] = stateValues[stateHistory[i]];
				//epur.arrY[i] = stateHistory[i];
				cnts[i] = rnd.Next(mincnt, maxcnt);
				cnt += cnts[i];
			}

			//Создаем и наполняем массив значений по X для графиков эффектов
			values = new double[cnt];
			values[0] = 0;
			for (i = 1; i < cnt; i++)
			{
				values[i] = steplen + values[i - 1];
			}
			//Передаем массивы значений на график
			effect1.arrX = values;

			//Создаем и наполняем массив значений по X для графиков эффектов
			epur.arrX = new double[stateHistory.Length];
			epur.arrX[0] = 0;
			for (i = 1; i < stateHistory.Length; i++)
			{
				epur.arrX[i] = cnts[i - 1] * steplen + epur.arrX[i - 1];
			}

			//Создаем и наполняем массив значений по Y для графика эффекта 1
			effect1.arrY = new double[cnt];
			for (i = 0, k = 0; i < stateHistory.Length; i++)
			{
				double[] buf = TMarkovChain.NoMarkovValues(cnts[i], eff1, stateHistory[i]);
				for (j = 0; j < cnts[i]; j++, k++)
					effect1.arrY[k] = buf[j];
			}


			//epur.cntX = stateHistory.Length;
			epur.autoScaleX = true;
			epur.MaxX = stateHistory.Length;
			epur.autoScaleY = true;
			epur.stepLinesX = 1;

			effect1.MaxX = epur.MaxX;
			effect1.autoScaleY = true;
			effect1.stepLinesX = epur.stepLinesX;

			if (stateCount > 1)
			{
				epur.stepLinesY = epur.MaxY / (stateCount - 1);
				effect1.stepLinesY = effect1.MaxY / 10;
			}
		}


		/// <summary>
		/// Отрисовка графика переключения состояний с предварительным масштабированием. После использования, необходимо обновить целевой обьект.
		/// </summary>
		private void PaintEpur()
		{
			//Размещаем и масштабируем график переключения состояний
			epur.SizeX = PB_Epur.Width - 70;
			epur.Left = 50;
			epur.Top = 25;
			epur.SizeY = stateCount * 25 + epur.aLenY;


			gr.DrawString("График переключения состояний:", SystemFonts.CaptionFont, Brushes.Black, 30, 10);

			Pen p = new Pen(Color.Black, 2);
			Pen l = CHB_Lines.Checked ? Pens.LightGray : null;
			epur.DrawAxis(gr, Pens.Black, Brushes.Black, l, l);
			epur.DrawEpur(gr, p);
		}

		/// <summary>
		/// Отрисовка графика эффекта 1 с предварительным масштабированием. После использования, необходимо обновить целевой обьект.
		/// </summary>
		private void PaintEffect1()
		{
			//Размещаем и масштабируем график переключения состояний
			effect1.SizeX = PB_Epur.Width - 70;
			effect1.Left = 50;
			effect1.SizeY = 150;
			effect1.Top = 30 + epur.SizeY + 50;

			gr.DrawString("График эффекта 1:", SystemFonts.CaptionFont, Brushes.Black, 30, epur.SizeY + 50 + 10);

			Pen p = new Pen(Color.Black, 2);
			Pen l = CHB_Lines.Checked ? Pens.LightGray : null;
			effect1.DrawAxis(gr, Pens.Black, Brushes.Black, l, l);
			effect1.DrawEpur(gr, Pens.Black);
		}

		private void TB_States_Refresh()
		{
			int i;
			TB_States.Text = "Значения состояний:\r\n";
			for (i = 0; i < stateValues.Length; i++)
			{
				TB_States.Text = TB_States.Text + TMarkovChain.GenerateState(i) + " = " + stateValues[i] + "\r\n";
			}
		}

		public FRM_Epur()
		{
			InitializeComponent();
		}

		private void FRM_Epur_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.frmEpur = null;
			parent.NewData = true;
		}

		private void PB_Epur_Paint(object sender, PaintEventArgs e)
		{

		}

		private void PB_Epur_SizeChanged(object sender, EventArgs e)
		{
			
		}

		private void FRM_Epur_Activated(object sender, EventArgs e)
		{
			int i;
			stateHistory = parent.statehistory;
			stateCount = parent.pMatr.Width;
			//Переносим на эту форму список состояний
			CB_State.Items.Clear();
			for (i = 0; i < parent.CB_States.Items.Count; i++)
				CB_State.Items.Add(parent.CB_States.Items[i]);
			//Формируем таблицу соответствия "состояние - значение"
			if (stateValues == null || stateValues.Length != CB_State.Items.Count)
			{
				stateValues = new double[CB_State.Items.Count];
				for (i = 0; i < stateValues.Length; i++)
					stateValues[i] = i;
			}
			CB_State.SelectedIndex = 0;
			if (stateHistory != null)
			{
				//Задаем размер поля отображения графиков
				PB_Epur.Width = 70 + stateHistory.Length * Convert.ToInt32(NUD_Scale.Value);
				PB_Epur.Height = 20 + (stateCount * 25 + 50) * 4;		//Эта жуткая формула учитывает то, что графиков будет 4 с промежутками в 30 пикселей между ними
				PB_Epur.Image = new Bitmap(PB_Epur.Width, PB_Epur.Height);
				gr = Graphics.FromImage(PB_Epur.Image);
				//Инициализируем график
				if (parent.NewData)
				{
					RefreshGraphicStatesValues();
					//RefreshGraphicEffect1Values();
				}
				gr.Clear(SystemColors.Window);
				PaintEpur();
				PaintEffect1();
			}
			PB_Epur.Refresh();
		}

		private void NUD_Scale_ValueChanged(object sender, EventArgs e)
		{
			PB_Epur.Width = 70 + stateHistory.Length * Convert.ToInt32(NUD_Scale.Value);
			PB_Epur.Image = new Bitmap(PB_Epur.Width, PB_Epur.Height);
			gr = Graphics.FromImage(PB_Epur.Image);
			gr.Clear(SystemColors.Window);
			PaintEpur();
			PaintEffect1();
			PB_Epur.Refresh();
		}

		private void CB_State_SelectedIndexChanged(object sender, EventArgs e)
		{
			TB_StateValue.Text = stateValues[CB_State.SelectedIndex].ToString();
			TB_States.Text = "";
			TB_States_Refresh();
		}

		private void TB_StateValue_Validating(object sender, CancelEventArgs e)
		{

			double val;
			bool fl = TMatrix.DoubleTryParse(TB_StateValue.Text, out val);

			if (fl)
			{
				stateValues[CB_State.SelectedIndex] = val;
			}
			else
			{
				ERR.SetError(TB_StateValue, "Невозможно преобразовать в число");
			}
			PB_Epur.Refresh();
			
		}

		private void TB_StateValue_TextChanged(object sender, EventArgs e)
		{
			
			ERR.SetError(TB_StateValue, "");
			TB_States_Refresh();
		}

		private void TB_StateValue_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				TB_StateValue_Validating(null, null);
		}

		private void CHB_Lines_CheckedChanged(object sender, EventArgs e)
		{
			gr.Clear(SystemColors.Window);
			PaintEpur();
			PaintEffect1();
			PB_Epur.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PB_Epur.Image.Save("Эпюры.png");
		}

		private void TB_FormatY_TextChanged(object sender, EventArgs e)
		{
			//epur.formatY = TB_FormatY.Text;
			float proba = 0;
			try
			{
				proba.ToString(TB_FormatY.Text);
				effect1.formatY = TB_FormatY.Text;
				
			}
			catch
			{
				effect1.formatY = "F";
			}
			if (gr != null)
			{
				gr.Clear(SystemColors.Window);
				PaintEpur();
				PaintEffect1();
				PB_Epur.Refresh();
			}
		}

		private void FRM_Epur_Load(object sender, EventArgs e)
		{
			TB_FormatY.Text = "F2";
		}
	}
}
