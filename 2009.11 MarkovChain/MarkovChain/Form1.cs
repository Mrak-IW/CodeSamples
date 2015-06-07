#define VECTOR

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Matrix;



//0.2	0.5	0.3
//0.4	0.2	0.4
//0.6	0.3	0.1

namespace MarkovChain
{
	public partial class Form1 : Form
	{
		private FileStream fs = null;
		StreamWriter logfile = null;
		/// <summary>
		/// Переключатель, отвечающий за сохранение лога в файл.
		/// </summary>
		public bool logging = false;
		public int[] statehistory;
		public FRM_GenerateSettings frmGenerate = null;
		public FRM_Settings frmSettings = null;
		public FRM_Epur frmEpur = null;
		//public FRM_NonMarkov frmNonMarkov = null;
		/// <summary>
		/// Стартовая матрица переходов
		/// </summary>
		private TMarkovChain sMatr = new TMarkovChain(0, 0);
		/// <summary>
		/// Матрица переходов, вычисленная в результате эксперимента
		/// </summary>
		public TMatrix pMatr = new TMatrix(0, 0);
		/// <summary>
		/// Единая строка формата для вывода матриц. Смотри справку MSDN по индексу "double.ToString method"
		/// </summary>
		public string format = "F3";
		private string filename = "Сеанс " + System.DateTime.Now.ToString().Replace(':', '-') + ".log";
		/// <summary>
		/// Сигнализирует на другие формы, что данные обновились. После считывания, флажок сбрасывается;
		/// </summary>
		public bool NewData
		{
			get
			{
				bool buf = newData;
				newData = false;
				return buf;
			}
			set
			{
				newData = value;
			}
		}
		private bool newData = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void BTN_Start_Click(object sender, EventArgs e)
		{
			int i, j, sold, snew, ss;
			double reason, sum, sumcnt;
			double[] cnt;
			TMatrix bufp, bufs;

			//На всякий случай, еще раз считываем матрицу из строки (если там уже другая сгенерирована)
			TB_StartMatrix_Leave(null, null);

			if (fs == null && logging)
			{
				fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
				logfile = new StreamWriter(fs);
			}

			#region "Реализация собственно марковской цепи"
			//Подготавливаем матрицу для накопления статистики состояний:
			pMatr = new TMatrix(sMatr.Heigth, sMatr.Width);
			//Цикл переключения состояний
			LB_Test.Items.Clear();							//Очистил лог состояний
			statehistory = new int[Convert.ToInt32(NUD_DispFirst.Value)];	//Создал массив для истории состояний необходимого размера
			sMatr.CurrentState = CB_States.SelectedIndex;	//Задал начальное состояние
			sold = sMatr.CurrentState;						//Запомнил текущее состояние
			double zero = 0;								//Искусственно получаем неопределенность 0/0. Ну так, для красоты...
			reason = 0 / zero;
			for (i = 0; i < NUD_StepCount.Value; i++)		//Цикл переключения состояний
			{
				if (i < NUD_DispFirst.Value)
				{
					LB_Test.Items.Add(reason.ToString(format) + "    =>    " + TMarkovChain.GenerateState(sold));
					statehistory[i] = sold;		//Запоминаем состояние в историю состояний
				}
				snew = sMatr.Next(out reason);
				pMatr[sold, snew]++;

				sold = snew;
			}

			//Создал и обнулил массив счетчиков переходов
			cnt = new double[sMatr.StateCount];
			for (i = 0; i < cnt.Length; i++) cnt[i] = 0;
			//Подсчитываем число переходов в каждое из состояний, а также
			//приводим матрицу с накопленной статистикой переходов в нормализованный вид:

			//TB_PractMatrix.Text = pMatr.ToString(format);

			for (i = 0; i < pMatr.Heigth; i++)
			{
				sum = 0;
				for (j = 0; j < pMatr.Width; j++)
				{
					sum += pMatr[i, j];
					cnt[i] += pMatr[i, j];
				}
				for (j = 0; j < pMatr.Width; j++)
				{
					pMatr[i, j] /= sum;
				}
			}
			/*pMatr[0, 0] = 0.226;
			pMatr[0, 1] = 0.508;
			pMatr[0, 2] = 0.266;
			pMatr[1, 0] = 0.413;
			pMatr[1, 1] = 0.228;
			pMatr[1, 2] = 0.359;
			pMatr[2, 0] = 0.606;
			pMatr[2, 1] = 0.303;
			pMatr[2, 2] = 0.091;*/
			#endregion
			#region "Подсчет и вывод статистики"
			//Вывод экспериментальной матрицы
			TB_PractMatrix.Text = /*TB_PractMatrix.Text + */"Экспериментальная матрица переходов:\r\n" + pMatr.ToString(format);
			//Вывод матрицы граничных условий
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nМатрица граничных условий:\r\n" + sMatr.BorderMatrix();
			//Вывод количества переходов
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nКоличество переходов из состояния:\r\n";
			for (i = 0; i < cnt.Length; i++)
			{
				TB_PractMatrix.Text = TB_PractMatrix.Text + TMarkovChain.GenerateState(i) + "  :  " + cnt[i] + "\r\n";
			}

			BTN_MatrixPow.Enabled = true;

			//Возведение матрицы в степень
			bufs = sMatr;

			for (i = 1; i < NUD_Pow.Value; i++)
				bufs = bufs * sMatr;
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nТеоретическая матрица, возведенная в степень " + NUD_Pow.Value + ":\r\n" + bufs.ToString(format);

			bufp = pMatr;

			for (i = 1; i < NUD_Pow.Value; i++)
				bufp = bufp * pMatr;
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nЭкспериментальная матрица, возведенная в степень " + NUD_Pow.Value + ":\r\n" + bufp.ToString(format);
			//#if VECTOR
			//Реализуем вычисление критерия согласия хи-квадрат:
			sumcnt = 0;
			for (i = 0; i < cnt.Length; i++)
				sumcnt += cnt[i];
			sum = 0;
			for (j = 0; j < sMatr.Width; j++)
			{
				sum += sumcnt * (pMatr[0, j] - sMatr[0, j]) * (pMatr[0, j] - sMatr[0, j]) / sMatr[0, j];
			}
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nКритерий согласия Хи-квадрат (по векторам) = " + sum.ToString(format) + "\r\n";
			try
			{
				ss = pMatr.Width - 3;
				TB_PractMatrix.Text = TB_PractMatrix.Text + "Гипотеза" + (TMarkovChain.Test(ss, sum) ? "" : " не") + " принята\r\n";
				TB_PractMatrix.Text = TB_PractMatrix.Text + "Диапазон значений для принятия решения = " + ss + " : [" + TMarkovChain.table[ss - 1, 0].ToString(format) + "; " + TMarkovChain.table[ss - 1, 1].ToString(format) + "]\r\n";
			}
			catch (Exception ex)
			{
				TB_PractMatrix.Text = TB_PractMatrix.Text + ex.Message + "\r\n";
			}
			//#else
			//Реализуем вычисление критерия согласия хи-квадрат:
			sum = 0;
			for (i = 0; i < sMatr.Heigth; i++)
			{
				for (j = 0; j < sMatr.Width; j++)
				{
					sum += (Convert.ToDouble(cnt[i]) / sMatr[i, j]) * (pMatr[i, j] - sMatr[i, j]) * (pMatr[i, j] - sMatr[i, j]);
				}
			}
			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nКритерий согласия Хи-квадрат (по матрицам) = " + sum.ToString(format) + "\r\n";
			try
			{
				ss = pMatr.Width * pMatr.Heigth - 3;
				TB_PractMatrix.Text = TB_PractMatrix.Text + "Гипотеза" + (TMarkovChain.Test(ss, sum) ? "" : " не") + " принята\r\n";
				TB_PractMatrix.Text = TB_PractMatrix.Text + "Диапазон значений для принятия решения = " + ss + " : [" + TMarkovChain.table[ss - 1, 0].ToString(format) + "; " + TMarkovChain.table[ss - 1, 1].ToString(format) + "]\r\n";
			}
			catch (Exception ex)
			{
				TB_PractMatrix.Text = TB_PractMatrix.Text + ex.Message + "\r\n";
			}
			//#endif
			#endregion

			NewData = true;

			if (logging)
			{
				//Теперь необходимо все это записать в лог:
				logfile.WriteLine("\\====================================================================/\r\n");
				logfile.WriteLine("Теоретическая матрица:\r\n" + sMatr.ToString(format));
				logfile.WriteLine("Начальное состояние:\t" + CB_States.SelectedItem.ToString() + "\r\nЧисло переходов:\t" + NUD_StepCount.Value);
				logfile.WriteLine(TB_PractMatrix.Text);
				logfile.Flush();
			}

			if (frmEpur != null) frmEpur.Focus();
		}

		private void TB_StartMatrix_Leave(object sender, EventArgs e)
		{
			int i;
			string sbuf;

			//Пытаемся считать матрицу из строки
			ErrP.SetError(TB_StartMatrix, "");
			try
			{
				sMatr = TMarkovChain.FromString(TB_StartMatrix.Text);
			}
			catch (Exception ex)
			{
				ErrP.SetError(TB_StartMatrix, ex.Message);
				BTN_Start.Enabled = false;
				return;
			}
			//Приведение введенной мтрицы в удобочитаемый вид
			TB_StartMatrix.Text = sMatr.ToString(format);

#if DEBUG	//Директива для условной компиляции. MSVisualStudio может переключаться между режимами
			//DEBUG и RELEASE (см. верхнее меню Standard, поле "Solution Configuration") и соответственно режиму
			//автоматически определяет одноименную константу. Т.е. аналогом будет определение константы вручную:
			//#ifndef DEBUG
			//#define DEBUG
			//#endif
			//TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\n" + sMatr.ToString(format);
#endif
			#region "Проверка матрицы на корректность и юзера на криворукость"
			sbuf = sMatr.Test();

			ErrP.SetError(TB_StartMatrix, sbuf);
			BTN_Start.Enabled = (sbuf == "");

			if (sbuf != "") return;
			#endregion

			//Теперь, когда криворукость пользователя проверена, можно сгенерировать список состояний
            if (sender != null && e != null)
            {
                CB_States.Items.Clear();
                for (i = 0; i < sMatr.Width; i++)
                {
                    CB_States.Items.Add(TMarkovChain.GenerateState(i));
                }
                //Задаем начальное состояние марковской цепи
                CB_States.SelectedIndex = 0;
            }
			
		}

		private void TB_StartMatrix_TextChanged(object sender, EventArgs e)
		{
			BTN_Start.Enabled = true;
			BTN_MatrixPow.Enabled = false;
			ErrP.SetError(TB_StartMatrix, "");
		}

		private void CB_States_SelectedIndexChanged(object sender, EventArgs e)
		{
			sMatr.CurrentState = CB_States.SelectedIndex;
		}

		private void BTN_MatrixPow_Click(object sender, EventArgs e)
		{
			int i;
			TMatrix buf = pMatr;

			for (i = 1; i < NUD_Pow.Value; i++)
				buf = buf * pMatr;

			TB_PractMatrix.Text = TB_PractMatrix.Text + "\r\nЭкспериментальная матрица, возведенная в степень " + NUD_StepCount.Value + ":\r\n" + buf.ToString(format);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			TB_StartMatrix.Text = "0.2\t0.5\t0.3\r\n0.4\t0.2\t0.4\r\n0.6\t0.3\t0.1";
			SSTRL_Label.Text = "";
			NUD_DispFirst.Maximum = NUD_StepCount.Value;
		}

		private void LB_Test_SelectedIndexChanged(object sender, EventArgs e)
		{
			SSTRL_Label.Text = (LB_Test.SelectedIndex >= 0 ? "Строка: " + LB_Test.SelectedIndex.ToString() : "");
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (fs != null)
			{
				if (logfile != null)
				{
					logfile.Flush();
					logfile.Close();
				}
				fs.Close();
			}
		}

		private void MMI_TestCases_Click(object sender, EventArgs e)
		{
			if (frmGenerate == null)
			{
				frmGenerate = new FRM_GenerateSettings();
				frmGenerate.parent = this;
				frmGenerate.Show();
			}
			else
			{
				frmGenerate.Focus();
			}
		}

		private void NUD_StepCount_ValueChanged(object sender, EventArgs e)
		{
			NUD_DispFirst.Maximum = NUD_StepCount.Value;
		}

		private void MMI_Settings_Click(object sender, EventArgs e)
		{
			if (frmSettings == null)
			{
				frmSettings = new FRM_Settings();
				frmSettings.parent = this;
				frmSettings.Show();
			}
			else
			{
				frmSettings.Focus();
			}
		}

		private void MMI_Ipur_Click(object sender, EventArgs e)
		{
			//Если истории состояний нет и небыло
			if (statehistory == null) return;

			//int i;

			if (frmEpur == null)
			{
				frmEpur = new FRM_Epur();
				frmEpur.parent = this;
				frmEpur.Show();
			}
			else
			{
				frmEpur.Focus();
			}
		}

		private void MMI_NonMarkov_Click(object sender, EventArgs e)
		{
			/*if (frmNonMarkov == null)
			{
				frmNonMarkov = new FRM_NonMarkov();
				frmNonMarkov.frmParent = this;
				frmNonMarkov.Show();
			}
			else
			{
				frmNonMarkov.Focus();
				frmNonMarkov.Top = this.Top + 70;
				frmNonMarkov.Left = this.Left + 70;
			}*/
		}
				   
	}
}
