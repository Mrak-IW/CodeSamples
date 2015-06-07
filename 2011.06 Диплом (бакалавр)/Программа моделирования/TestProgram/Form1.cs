using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NSGraphic;
using Matrix;

namespace CodeDivision
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// Массив чип-кодов передатчиков
		/// </summary>
		TextBox[] transmitterChipCodes;
		/// <summary>
		/// Массив содержимого передатчиков
		/// </summary>
		TextBox[] transmitterTexts;
		/// <summary>
		/// Массив кнопок запуска передатчиков
		/// </summary>
		Button[] transmitterButtons;
		/// <summary>
		/// Массив, хранящий содержимое среды передачи.
		/// </summary>
		TQueue[] transmission_shared;
		/// <summary>
		/// Генератор псевдослучайной последовательность по формуле <b>next = a * seed + b</b>
		/// </summary>
		/// <param name="seed">Начальное значение</param>
		/// <param name="multiplier">Коэфициент <b>a</b></param>
		/// <param name="add">Коэфициент <b>b</b></param>
		/// <returns></returns>
		uint UIntRand(uint seed, uint multiplier, uint add)
		{
			return multiplier * seed + add;
		}

		/// <summary>
		/// Преобразование массива чисел в последовательность бит
		/// </summary>
		/// <param name="src">Исходный массив</param>
		/// <returns></returns>
		short[] ToBinArray(uint[] src)
		{
			short[] result = new short[sizeof(uint) * src.Length * 8];
			int i, j;
			uint buf;

			for (i = 0; i < src.Length; i++)
			{
				buf = src[i];
				for (j = 0; j < sizeof(uint) * 8; j++)
				{
					result[i * 8 * sizeof(uint) + j] = Convert.ToInt16(buf & 1);
					buf = buf >> 1;
				}
			}
			return result;
		}

		/// <summary>
		/// Заменяет все нули на -1
		/// </summary>
		/// <param name="src">Массив - источник</param>
		/// <returns></returns>
		short[] BitToPlusMinus(short[]src)
		{
			int i;
			short[] res = new short[src.Length];
			for (i = 0; i < src.Length; i++)
			{
				res[i] = (src[i] == 0 ? (short)-1 : src[i]);
			}
			return res;
		}


		/// <summary>
		/// Вывод массива в строку
		/// </summary>
		/// <param name="src">Выводимый массив</param>
		/// <returns></returns>
		string ShortArrayToString(short[] src)
		{
			int i;
			if (src == null || src.Length == 0) return "";

			string res = "";
			for (i = src.Length - 1; i >= 0; i--)
			{
				res = res + src[i] + "\t";
			}
			return res;
		}

		/// <summary>
		/// Вывод массива в строку
		/// </summary>
		/// <param name="src">Выводимый массив</param>
		/// <returns></returns>
		string IntArrayToString(int[] src)
		{
			int i;
			if (src == null || src.Length == 0) return "";

			string res = src[0].ToString();
			for (i = 1; i < src.Length; i++)
			{
				res = res + "\t" + src[i];
			}
			return res;
		}

		double[] IntArrayToDoubleArray(int[] src)
		{
			double[] res = new double[src.Length];
			for (int i = 0; i < src.Length; i++)
			{
				res[i] = src[i];
			}
			return res;
		}

		/// <summary>
		/// Функция корелляции последовательностей
		/// </summary>
		/// <param name="src1">Первая последовательность</param>
		/// <param name="src2">Вторая последовательность</param>
		/// <returns></returns>
		int[] ArrayCorellation(short[] src1, short[] src2)
		{
			if (src1.Length != src2.Length)
				throw new Exception("Не совпадают размеры массивов на входе функции автокорелляции.");
			int i, step;
			int[] res = new int[src1.Length];
			for (step = 0; step < src1.Length; step++)
			{
				res[step] = 0;
				for (i = 0; i < src1.Length - step; i++)
				{
					res[step] += src1[i] * src2[i+step];
				}
			}
			return res;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void BTN_MaxNum_Click(object sender, EventArgs e)
		{
			TB_Log.Text =	"uint:\r\n\tmax  = " + uint.MaxValue +
						"\r\n\tразмер = " + sizeof(uint) + " байт" +
						"\r\nulong:\r\n\tmax = " + ulong.MaxValue +
						"\r\n\tразмер = " + sizeof(ulong) + " байт" +
						"\r\nbyte:\r\n\tmax = " + byte.MaxValue +
						"\r\n\tmin = " + byte.MinValue + " байт";
		}

		private void BTN_Run_Click(object sender, EventArgs e)
		{
			uint iran = Convert.ToUInt32(NUD_seed.Value);
			uint mult = Convert.ToUInt32(NUD_miltiplier.Value);
			uint add = Convert.ToUInt32(NUD_add.Value);
			int i, count = Convert.ToInt32(NUD_count.Value);
			uint[] rnd = new uint[count];
			short[] bitarray;
			int[] autocorr;

			for (i = 0; i < count; i++)
			{
				rnd[i] = iran;
				iran = UIntRand(iran, mult, add);
			}

			bitarray = ToBinArray(rnd);
			TB_Log.Text = ShortArrayToString(bitarray);
			bitarray = BitToPlusMinus(bitarray);
			autocorr = ArrayCorellation(bitarray, bitarray);
			TB_Log.Text = TB_Log.Text + "\r\n=============\r\n" + IntArrayToString(autocorr);

			//Отображение функции автокорелляции:

			PB_Graphic.Height = 400;
			PB_Graphic.Width = 800;
			PB_Graphic.Image = new Bitmap(PB_Graphic.Width, PB_Graphic.Height);

			Graphics gr = Graphics.FromImage(PB_Graphic.Image);
			gr.Clear(Color.White);

			TGraphic acgraph = new TGraphic();

			acgraph.SizeX = PB_Graphic.Width - 70;
			acgraph.SizeY = PB_Graphic.Height - 50;
			acgraph.Left = 50;
			acgraph.Top = 25;
			//acgraph.SizeY = autocorr.Length * 25 + acgraph.aLenY;

			acgraph.arrY = IntArrayToDoubleArray(autocorr);

			acgraph.arrX = new double[autocorr.Length];
			for (i = 0; i < autocorr.Length; i++)
			{
				acgraph.arrX[i] = i;
			}

			gr.DrawString("Функция автокорелляции:", SystemFonts.CaptionFont, Brushes.Black, 30, 10);

			acgraph.MinNegX = 0;
			acgraph.MinNegY = autocorr.Min() < 0 ? autocorr.Min() : 0;
			acgraph.MaxX = autocorr.Length;
			acgraph.MaxY = autocorr.Max() > 0 ? autocorr.Max() : 0;
			acgraph.stepLinesY = (acgraph.MaxY - acgraph.MinNegY) / 20;
			acgraph.stepLinesX = (acgraph.MaxX - acgraph.MinNegX) / 40;
			acgraph.stepSubscrY = 2;
			acgraph.stepSubscrX = 4;

			Pen p = new Pen(Color.Red, 1);
			Pen l = CHB_Lines.Checked ? Pens.LightGray : null;
			acgraph.DrawAxis(gr, Pens.Black, Brushes.Black, l, l);
			acgraph.DrawPolyline(gr, p, null);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			NUD_add.Maximum = uint.MaxValue;
			NUD_add.Value = 1013904223;
			NUD_miltiplier.Maximum = uint.MaxValue;
			NUD_miltiplier.Value = 1664525;
			NUD_seed.Maximum = uint.MaxValue;
			NUD_seed.Value = 0x72727272;
			tabControl1.SelectedIndex = 1;

			transmitterChipCodes = new TextBox[3];
			transmitterChipCodes[0] = TB_ChipCode_T0;
			transmitterChipCodes[1] = TB_ChipCode_T1;
			transmitterChipCodes[2] = TB_ChipCode_T2;
			transmitterTexts = new TextBox[3];
			transmitterTexts[0] = TB_Info_T0;
			transmitterTexts[1] = TB_Info_T1;
			transmitterTexts[2] = TB_Info_T2;
			transmitterButtons = new Button[3];
			transmitterButtons[0] = BTN_Transmit_T0;
			transmitterButtons[1] = BTN_Transmit_T1;
			transmitterButtons[2] = BTN_Transmit_T2;

			SFD.InitialDirectory = Application.ExecutablePath;
		}

		private void BTN_GO1_Click(object sender, EventArgs e)
		{
			int i, j, k;
			TMatrix bufmatr = null;	//Буферная матрица для преобразования строки в массив short
			TEncoder encoder = null;	//Объект - кодировщик
			TQueue bitQueue = null;	//Очередь бит для кодировщика
			TQueue[] transmission = null;	//Среда передачи
			int[] bufarr;

			#region Получаем чиповую последовательность
				try
				{
					bufmatr = new TMatrix(TB_ChipSequence1.Text);
					bufarr = new int[bufmatr.Heigth * bufmatr.Width];
					for (i = 0, k = bufarr.Length - 1; i < bufmatr.Heigth; i++)
					{
						for (j = 0; j < bufmatr.Width; j++, k--)
						{
							if (bufmatr[i, j] != 1 && bufmatr[i, j] != -1)
								throw new Exception("Чиповая последовательность должна состоять из 1 и -1, разделённых пробельными символами.");
							bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в чиповой последовательности");
					return;
				}
				TB_ChipSequence1.Text = bufmatr.ToString("F0");
			#endregion
			encoder = new TEncoder(bufarr);
			

			if (CHB_AutoSetup.Checked)
				NUD_Limit1.Value = bufmatr.Width * bufmatr.Heigth / 2;

			
			#region Получаем последовательность бит для отправки
				try
				{
					bufmatr = new TMatrix(TB_Transmitter1.Text);
					bufarr = new int[bufmatr.Heigth * bufmatr.Width];
					for (i = 0, k = 0; i < bufmatr.Heigth; i++)
					{
						for (j = bufmatr.Width - 1; j >= 0 ; j--, k++)
						{
							if (bufmatr[i, j] != 0 && bufmatr[i, j] != 1)
								throw new Exception("Последовательность должна состоять из 1 и 0, разделённых пробельными символами.");
							bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в данных передатчика");
					return;
				}
				TB_Transmitter1.Text = bufmatr.ToString("F0");
			#endregion
			bitQueue = new TQueue(bufarr);

			transmission = encoder.Encode(bitQueue);

			//Имитируем передачу.
			if (CHB_RapidTest.Checked)
			{	//Эта ветка не даёт возможности вручную откорректировать среду передачи
				//Просто быстрый тест алгоритма с выводом исходных, конечных и промежуточных данных
				TB_Log1.Text = "Очередь бит:\r\n\t" + bitQueue + "\r\nСреда передачи:\r\n";
				for (i = 0; i < transmission.Length; i++)
				{
					TB_Log1.Text = TB_Log1.Text + "[" + i + "]\t" + transmission[i] + "\r\n";
				}

				TDecoder decoder = new TDecoder(encoder.ChipCode, encoder.ChipCode.Length / 2);
				TQueue rbq = decoder.Decode(transmission);
				TB_Log1.Text = TB_Log1.Text + "\r\nДекодированная последовательность:\r\n\t" + rbq;
			}
			else
			{
				TB_Log1.Text = "";
				for (i = 0; i < transmission.Length; i++)
				{
					TB_Log1.Text = TB_Log1.Text + transmission[i] + "\r\n";
				}
			}

			TB_Receiver1.Text = "";
		}

		private void BTN_Recieve_Click(object sender, EventArgs e)
		{
			int i, j, k;
			TMatrix bufmatr = null;	//Буферная матрица для преобразования строки в массив short
			TDecoder decoder = null;	//Объект - декодер
			TQueue[] transmission = null;	//Среда передачи
			TQueue rbq = null;		//Принятая битовая последовательность
			int[] bufarr;

			#region Получаем чиповую последовательность
				try
				{
					bufmatr = new TMatrix(TB_ChipSequence1.Text);
					bufarr = new int[bufmatr.Heigth * bufmatr.Width];
					for (i = 0, k = bufarr.Length - 1; i < bufmatr.Heigth; i++)
					{
						for (j = 0; j < bufmatr.Width; j++, k--)
						{
							if (bufmatr[i, j] == 0) bufmatr[i, j] = -1;
							if (bufmatr[i, j] != 1 && bufmatr[i, j] != -1)
								throw new Exception("Чиповая последовательность должна состоять из 1 и -1, разделённых пробельными символами.");
							bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в чиповой последовательности");
					return;
				}
				TB_ChipSequence1.Text = bufmatr.ToString("F0");
			#endregion
			decoder = new TDecoder(bufarr, Convert.ToInt32(NUD_Limit1.Value));

			#region Получаем последовательность чипов для декодирования
				try
				{
					bufmatr = new TMatrix(TB_Log1.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в данных приёмника");
					return;
				}
				TB_Log1.Text = bufmatr.ToString("F0");

				//Теперь нужно выковырять её из матрицы.
				transmission = new TQueue[bufmatr.Heigth];
				for (i = 0; i < bufmatr.Heigth; i++)
				{
					transmission[i] = new TQueue(bufmatr.Width);
					for (j = bufmatr.Width - 1; j >= 0; j--)
					{
						transmission[i].Push(Convert.ToInt32(bufmatr[i, j]));
					}
				}
			#endregion
			rbq = decoder.Decode(transmission);
			TB_Receiver1.Text = rbq.ToString();

		}

		private void BTN_Transmit_T1_Click(object sender, EventArgs e)
		{
			if (!(sender is Button)) return;

			int trNumber = 0;
			#region Выбираем передатчик, с которым будем работать
				try
				{
					trNumber = Convert.ToInt32((sender as Button).Tag);
				}
				catch
				{
					return;
				}
				string trValue = transmitterTexts[trNumber].Text;
				string trChipCode = transmitterChipCodes[trNumber].Text;
			#endregion

			int i, j, k;
			TMatrix bufmatr = null;	//Буферная матрица для преобразования строки в массив short
			TEncoder encoder = null;	//Объект - кодировщик
			TQueue bitQueue = null;	//Очередь бит для кодировщика
			TQueue[] transmission = null;	//Среда передачи
			int[] bufarr;

			#region Получаем чиповую последовательность
				try
				{
					bufmatr = new TMatrix(trChipCode);
					bufarr = new int[bufmatr.Heigth * bufmatr.Width];
					for (i = 0, k = bufarr.Length - 1; i < bufmatr.Heigth; i++)
					{
						for (j = 0; j < bufmatr.Width; j++, k--)
						{
							if (bufmatr[i, j] == 0) bufmatr[i, j] = -1;
							if (bufmatr[i, j] != 1 && bufmatr[i, j] != -1)
								throw new Exception("Чиповая последовательность должна состоять из 1 и -1, разделённых пробельными символами.");
							bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в чиповой последовательности");
					return;
				}
				transmitterChipCodes[trNumber].Text = bufmatr.ToString("F0");
			#endregion
			encoder = new TEncoder(bufarr);

			if (CHB_AutoSetup.Checked)
				NUD_Limit1.Value = bufmatr.Width * bufmatr.Heigth / 2;

			#region Получаем последовательность бит для отправки
				try
				{
					bufmatr = new TMatrix(trValue);
					bufarr = new int[bufmatr.Heigth * bufmatr.Width];
					for (i = 0, k = 0; i < bufmatr.Heigth; i++)
					{
						for (j = bufmatr.Width - 1; j >= 0; j--, k++)
						{
							if (bufmatr[i, j] != 0 && bufmatr[i, j] != 1)
								throw new Exception("Последовательность должна состоять из 1 и 0, разделённых пробельными символами.");
							bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка в данных передатчика");
					return;
				}
				transmitterTexts[trNumber].Text = bufmatr.ToString("F0");
			#endregion
			bitQueue = new TQueue(bufarr);

			if (RB_MultipleChannels.Checked)
			{
				transmission = encoder.Encode(bitQueue);
			}
			else
			{
				transmission = new TQueue[1];
				transmission[0] = encoder.EncodeSingleChannel(bitQueue);
			}
			//Имитируем передачу.
			if (transmission_shared == null)
			{
				transmission_shared = transmission;
			}
			else
			{
				for (i = 0; i < transmission_shared.Length; i++)
				{
					int limit = transmission_shared[i].Length < transmission[i].Length ? transmission_shared[i].Length : transmission[i].Length;
					for (j = 0; j < limit; j++)
					{
						transmission_shared[i][j] += transmission[i][j];
					}
				}
			}

			//TB_Transmition.Text = ShortArrayToString(transmission);
			TB_Transmition.Text = "";
			for (i = 0; i < transmission_shared.Length; i++)
			{
				TB_Transmition.Text = TB_Transmition.Text + transmission_shared[i] + "\r\n";
			}
			BTN_DrawTransmission_Click(sender, e);

			//Наполняем список доступных чип-кодов
			CB_ReceiverChipCode.Items.Clear();
			for (i = 0; i < transmitterChipCodes.Length; i++)
			{
				if (transmitterChipCodes[i].Text.Trim() != "")
					CB_ReceiverChipCode.Items.Add(new TNumString(i, "Передатчик #" + i));
			}
		}

		private void BTN_Receive3_Click(object sender, EventArgs e)
		{
			int i, j, k;
			TMatrix bufmatr = null;	//Буферная матрица для преобразования строки в массив short
			TDecoder decoder = null;	//Объект - декодер
			TQueue[] transmission = null;	//Среда передачи
			TQueue rbq = null;		//Принятая битовая последовательность
			int[] bufarr;

			#region Получаем чиповую последовательность
			try
			{
				bufmatr = new TMatrix(TB_ReceiverChipCode.Text);
				bufarr = new int[bufmatr.Heigth * bufmatr.Width];
				for (i = 0, k = bufarr.Length - 1; i < bufmatr.Heigth; i++)
				{
					for (j = 0; j < bufmatr.Width; j++, k--)
					{
						if (bufmatr[i, j] == 0) bufmatr[i, j] = -1;
						if (bufmatr[i, j] != 1 && bufmatr[i, j] != -1)
							throw new Exception("Чиповая последовательность должна состоять из 1 и -1, разделённых пробельными символами.");
						bufarr[k] = Convert.ToInt32(bufmatr[i, j]);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка в чиповой последовательности");
				return;
			}
			TB_ReceiverChipCode.Text = bufmatr.ToString("F0");
			#endregion
			decoder = new TDecoder(bufarr, Convert.ToInt32(NUD_Limit1.Value));

			#region Получаем последовательность чипов для декодирования
			try
			{
				bufmatr = new TMatrix(TB_Transmition.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка в данных приёмника");
				return;
			}
			TB_Transmition.Text = bufmatr.ToString("F0");

			//Теперь нужно выковырять её из матрицы.
			transmission = new TQueue[bufmatr.Heigth];
			for (i = 0; i < bufmatr.Heigth; i++)
			{
				transmission[i] = new TQueue(bufmatr.Width);
				for (j = bufmatr.Width - 1; j >= 0; j--)
				{
					transmission[i].Push(Convert.ToInt32(bufmatr[i, j]));
				}
			}
			#endregion

			if (RB_MultipleChannels.Checked || transmission.Length > 1)
			{
				rbq = decoder.Decode(transmission);
			}
			else
			{
				rbq = decoder.DecodeSingleChannel(transmission[0]);
			}
			TB_ReceiverValue.Text = rbq.ToString();
			BTN_DrawTransmission_Click(sender, e);
		}

		private void BTN_Clear_Click(object sender, EventArgs e)
		{
			transmission_shared = null;
			TB_Transmition.Text = "";
			TB_ReceiverValue.Text = "";
			Graphics gr = Graphics.FromImage(PB_Picture.Image);
			gr.Clear(Color.White);
			PB_Picture.Refresh();
		}

		private void BTN_DrawTransmission_Click(object sender, EventArgs e)
		{
			int[] line;
			int i, j, k;
			TMatrix bufmatr = null;	//Буферная матрица для преобразования строки в массив short
			TQueue[] transmission = null;	//Среда передачи

			#region Получаем последовательность чипов
			try
			{
				bufmatr = new TMatrix(TB_Transmition.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка в данных приёмника");
				return;
			}
			TB_Transmition.Text = bufmatr.ToString("F0");

			//Теперь нужно выковырять её из матрицы.
			transmission = new TQueue[bufmatr.Heigth];
			for (i = 0; i < bufmatr.Heigth; i++)
			{
				transmission[i] = new TQueue(bufmatr.Width);
				for (j = bufmatr.Width - 1; j >= 0; j--)
				{
					transmission[i].Push(Convert.ToInt32(bufmatr[i, j]));
				}
			}
			#endregion


			#region Отображение на графике:

			TGraphic acgraph = new TGraphic();
			acgraph.Left = 50;
			acgraph.Top = 25;

			PB_Picture.Height = acgraph.Top * 2 + (transmission.Length + 1) * 80;
			PB_Picture.Width = acgraph.Left * 2 + transmission[0].Length * 40;
			PB_Picture.Image = new Bitmap(PB_Picture.Width, PB_Picture.Height);

			Graphics gr = Graphics.FromImage(PB_Picture.Image);
			gr.Clear(Color.White);

			acgraph.SizeX = PB_Picture.Width - 70;
			acgraph.SizeY = PB_Picture.Height - 50;
			//acgraph.SizeY = autocorr.Length * 25 + acgraph.aLenY;

			line = transmission[0].Content;
			acgraph.arrY = IntArrayToDoubleArray(line);

			acgraph.arrX = new double[line.Length];
			for (i = 0; i < line.Length; i++)
			{
				acgraph.arrX[i] = i;
			}

			gr.DrawString("Среда передачи:", SystemFonts.CaptionFont, Brushes.Black, 30, 10);

			acgraph.MinNegX = 0;
			acgraph.MinNegY = 0;//line.Min() < 0 ? line.Min() : 0;
			acgraph.MaxX = line.Length;
			acgraph.MaxY = transmission.Length + 1;//line.Max() > 0 ? line.Max() : 0;
			acgraph.stepLinesY = 0.2;
			acgraph.stepLinesX = 1;
			acgraph.stepSubscrY = 5;
			acgraph.stepSubscrX = 1;

			Pen p = new Pen(Color.Red, 1);
			Pen l = CHB_Lines.Checked ? Pens.LightGray : null;
			acgraph.DrawAxis(gr, Pens.Black, Brushes.Black, l, l);
			for (i = 0; i < transmission.Length; i++)
			{
				acgraph.arrY = IntArrayToDoubleArray(transmission[i].Content);
				for (j = 0; j < acgraph.arrY.Length; j++)
				{
					acgraph.arrY[j] = acgraph.arrY[j] / 10 + i + 1;
				}
				acgraph.DrawEpur(gr, p);
			}
			#endregion
		}

		private void CMI_SaveToFile_Click(object sender, EventArgs e)
		{
			if (SFD.ShowDialog() == DialogResult.OK)
			{
				PB_Picture.Image.Save(SFD.FileName);
			}
		}

		private void BTN_AutoTest_Click(object sender, EventArgs e)
		{
			int i;
			string log = "";
			string name = "Эксперимент " + DateTime.Now.Hour.ToString("D2") + "_"
					+ DateTime.Now.Minute.ToString("D2") + "_" + DateTime.Now.Second.ToString("D2");
			string path = ".\\" + name;
			
			FileStream fslog = new FileStream(path + ".txt", FileMode.Create, FileAccess.Write);
			StreamWriter swrlog = new StreamWriter(fslog);
			for (i = 0; i < transmitterButtons.Length; i++)
			{
				if (transmitterChipCodes[i].Text.Trim() != "")
				{
					BTN_Transmit_T1_Click(transmitterButtons[i], e);
					log = log + "Передатчик #" + i + "\r\n\tЧип-код:\r\n\t" + transmitterChipCodes[i].Text
						+ "\tДанные для отправки:\r\n\t" + transmitterTexts[i].Text;
				}
			}
			log = log + "\r\nСреда передачи:\r\n" + TB_Transmition.Text + "\r\n";
			for (i = 0; i < transmitterChipCodes.Length; i++)
			{
				if (transmitterChipCodes[i].Text.Trim() != "")
				{
					TB_ReceiverChipCode.Text = transmitterChipCodes[i].Text;
					BTN_Receive3_Click(BTN_Receive3, e);

					log = log + "Приёмник #" + i + "\r\n\tЧип-код:\r\n\t" + transmitterChipCodes[i].Text
						+ "\tПолученные данные:\r\n\t" + TB_ReceiverValue.Text;
				}
			}
			swrlog.Write(log);
			swrlog.Close();
			fslog.Close();

			PB_Picture.Image.Save(path + ".png");

			MessageBox.Show("Данные эксперимента сохранены в \"" + Application.StartupPath + "\\" + name + "\"", "Автотест");
		}

		private void RB_MultipleChannels_CheckedChanged(object sender, EventArgs e)
		{
			BTN_Clear_Click(BTN_Clear, e);
			TB_Transmitter1.Text = "";
		}

		private void CB_ReceiverChipCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(sender is ComboBox)) return;
			ComboBox buf = sender as ComboBox;
			if (!(buf.SelectedItem is TNumString) && buf.SelectedIndex >= 0) return;

			//Копируем чип-код
			if (buf.SelectedIndex >= 0)
				TB_ReceiverChipCode.Text = transmitterChipCodes[(buf.SelectedItem as TNumString).Number].Text.Trim();

			//Подсвечиваем передатчик
			int i;
			for (i = 0; i < transmitterChipCodes.Length; i++)
			{
				if (buf.SelectedIndex < 0 || i != (buf.SelectedItem as TNumString).Number)
				{
					transmitterChipCodes[i].BackColor = SystemColors.Window;
				}
				else
				{
					transmitterChipCodes[i].BackColor = Color.Cyan;
				}
			}

			BTN_Receive3_Click(BTN_Receive3, e);
		}

		private void BTN_Autocorr_Save_Click(object sender, EventArgs e)
		{
			if (SFD.ShowDialog() == DialogResult.OK)
			{
				PB_Graphic.Image.Save(SFD.FileName);
			}
		}

	}

	/// <summary>
	/// Вспомогательная структура из строки и числа
	/// </summary>
	public class TNumString
	{
		private int num;
		private string text;
		public TNumString(int number, string text)
		{
			this.num = number;
			this.text = text;
		}
		/// <summary>
		/// Цифорвая часть структуры
		/// </summary>
		public int Number
		{
			get { return num; }
			set { num = value; }
		}
		/// <summary>
		/// Хранимый текст
		/// </summary>
		public string Text
		{
			get { return text; }
			set { text = value; }
		}
		public override string ToString()
		{
			return this.text;
		}
	}
}
