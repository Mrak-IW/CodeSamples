using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NSGraphic;
using Matrix;

namespace AffinCurves
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// Форма для задания исходных данных
		/// </summary>
		public FRM_Data frm_Data = null;
		/// <summary>
		/// Объект - график. На нем все отображаем.
		/// </summary>
		TGraphic gr = new TGraphic();
		/// <summary>
		/// Объект графики, на котором, в конечном счете, появится изображение
		/// </summary>
		Graphics g;
		/// <summary>
		/// Массив точек, с которыми работаем в аффинных преобразованиях
		/// </summary>
		public TMatrix[] marr = null;
		/// <summary>
		/// Результирующая матрица
		/// </summary>
		public TMatrix resmatrix = TMatrix.E(3);
		/// <summary>
		/// Точки, задающие кривую Безье
		/// </summary>
		public TMatrix besier = null;
		/// <summary>
		/// Точки, задающие кривую Эрмита (). ermit[1] и ermit[2] - вектора.
		/// </summary>
		public TMatrix ermit = null;

		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Переводит массив подписей точек из вида A(i) к A(i+1).
		/// Отсекает у элементов массива первую букву, далее инкрементирует то, что осталось,
		/// если оставшаяся часть является числом. После этого, первая буква возвращается на место.
		/// </summary>
		/// <param name="sarr">Исходный массив</param>
		private string[] NextSubscribes(string[] sarr)
		{
			string s, b;
			string[] res = new string [sarr.Length];
			int i, buf;

			for (i = 0; i < sarr.Length; i++)
			{
				b = sarr[i].Substring(0, 1);
				s = sarr[i].Substring(1);
				try
				{
					buf = int.Parse(s) + 1;
				}
				catch
				{
					buf = 1;
				}
				res[i] = b + buf;
			}

			return res;
		}

		private void PB_Graphic_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			gr.stepSubscrY = 2;
			gr.stepSubscrX = 2;
			gr.autoScaleY = false;
			gr.autoScaleX = false;
			if (PB_Graphic.Image == null)
			{
				PB_Graphic.Image = new Bitmap(PB_Graphic.Width, PB_Graphic.Height);
				g = Graphics.FromImage(PB_Graphic.Image);
			}
			TC_Mode_SelectedIndexChanged(null, null);
		}

		public void TC_Mode_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			//arr[0] = new Point(20, 100);
			//arr[1] = new Point(arr[0].X, arr[0].Y + 40);
			//arr[2] = new Point(arr[0].X + 30, arr[0].Y);
			TMatrix buf;
			double[] X;
			double[] Y;
			int i;
			resmatrix = TMatrix.E(3);

			switch (TC_Mode.SelectedIndex)
			{
				case 0:
					//Конфигурируем график
					TB_ResMatrix.Text = resmatrix.ToString("F2");
					gr.MaxX = 200;
					gr.MaxY = 200;
					gr.MinNegY = -200;
					gr.MinNegX = -200;
					gr.Left = 80 + 50;
					gr.Top = 20 + 200;
					gr.SizeX = PB_Graphic.Width - gr.Left - 20 - 40;
					gr.SizeY = gr.SizeX;

					g.Clear(SystemColors.Window);
					TGraphic.DrawInjGraphBorderA4(g, 0, 0);

					if (marr == null) return;

					X = new double[marr.Length];
					Y = new double[marr.Length];
					//Наполняем график значениями
					for (i = 0; i < marr.Length; i++)
					{
						X[i] = marr[i][0];
						Y[i] = marr[i][1];
					}
					gr.arrX = X;
					gr.arrY = Y;

					//Формируем мссив подписей к точкам
					gr.arrSubsсribes = new string[marr.Length];
					for (i = 0; i < marr.Length; i++)
					{
						gr.arrSubsсribes[i] = Convert.ToChar('A' + i).ToString();
					}

					//Отрисовываем начальные точки
					
					gr.DrawAxis(g, Pens.Black, Brushes.Black, Pens.LightGray, Pens.LightGray);
					gr.DrawPolygone(g, Pens.Black, Brushes.Red);
					gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.Red);
					PB_Graphic.Refresh();
					break;

				case 1:
					//Конфигурируем график
					gr.MaxX = 450;
					gr.MaxY = 450;
					gr.MinNegY = 0;
					gr.MinNegX = 0;
					gr.Left = 80 + 50;
					gr.Top = 20 + 200;
					gr.SizeX = PB_Graphic.Width - gr.Left - 20 - 40;
					gr.SizeY = gr.SizeX;
					//Теперь создаем исходные данные
					//besier = new TMatrix(4, 2);

					if (besier == null) return;

					//Ввод начальных данных
					//ermit[0, 0] = besier[0, 0];	//10
					//ermit[0, 1] = besier[0, 1];	//20
					////besier[1, 0] = 150;
					////besier[1, 1] = 150;
					////besier[2, 0] = 240;
					////besier[2, 1] = 160;
					//ermit[1, 0] = besier[3, 0];	//270
					//ermit[1, 1] = besier[3, 1];	//100

					//TMatrix buf = (besier.row(1) - besier.row(0)) * 2;
					//ermit[2, 0] = buf[0];
					//ermit[2, 1] = buf[1];
					//buf = (besier.row(2) - besier.row(3)) * 5;
					//ermit[3, 0] = buf[0];
					//ermit[3, 1] = buf[1];

					int cnt = 100;
					double db;
					TMatrix ME = TMatrix.mErmit2D();
					TMatrix MB = TMatrix.mBesier2D();
					X = new double[cnt];
					Y = new double[cnt];
					double[] logx = new double[10];
					double[] logy = new double[10];

					g.Clear(SystemColors.Window);
					TGraphic.DrawInjGraphBorderA4(g, 0, 0);
					gr.DrawAxis(g, Pens.Black, Brushes.Black, Pens.LightGray, Pens.LightGray);

					TB_Log.Text = "Кривая Безье для направляющих точек:\r\n" + besier.ToString();
					//Отрисовка Безье
					for (i = 0; i < cnt; i++)
					{
						db = Convert.ToDouble(i) / (cnt-1);
						buf = TMatrix.mT(db) * MB * besier;// * TMatrix.mMove2D(-besier[1, 0] + besier[0, 0], -besier[1, 1] + besier[0, 1]);
						X[i] = buf[0];
						Y[i] = buf[1];
						if (i % (cnt / 10) == 0)
						{
							logx[i / (cnt / 10)] = X[i];
							logy[i / (cnt / 10)] = Y[i];
						}
					}
					//gr.arrX = logx;
					//gr.arrY = logy;
					//gr.DrawPolyline(g, null, Brushes.Red);
					gr.arrX = X;
					gr.arrY = Y;
					gr.DrawPolyline(g, Pens.Red, null);
					
					TB_Log.Text = TB_Log.Text + "Контрольные точки:";
					for (i = 0; i < 10; i++)
					{
						TB_Log.Text = TB_Log.Text + "\r\n{" + logx[i].ToString("F2") + "; " + logy[i].ToString("F2") + "}";
					}

					TB_Log.Text = TB_Log.Text + "\r\n\r\nКривая Эрмита для направляющих точек:\r\n" + ermit.ToString();
					//Отрисовка Эрмита
					for (i = 0; i < cnt; i++)
					{
						db = Convert.ToDouble(i) / (cnt - 1);
						buf = TMatrix.mT(db) * ME * ermit;
						X[i] = buf[0];
						Y[i] = buf[1];
						if (i % (cnt / 10) == 0)
						{
							logx[i / (cnt / 10)] = X[i];
							logy[i / (cnt / 10)] = Y[i];
						}
					}
					//gr.arrX = logx;
					//gr.arrY = logy;
					//gr.DrawPolyline(g, null, Brushes.RoyalBlue);
					gr.arrX = X;
					gr.arrY = Y;
					gr.DrawPolyline(g, Pens.RoyalBlue, null);
					TB_Log.Text = TB_Log.Text + "Контрольные точки:";
					for (i = 0; i < 10; i++)
					{
						TB_Log.Text = TB_Log.Text + "\r\n{" + logx[i].ToString("F2") + "; " + logy[i].ToString("F2") + "}";
					}

					//Отрисовка направляющих векторов и точек
					gr.DrawVector(g, ermit[1, 0], ermit[1, 1], ermit[1, 0] + ermit[3, 0], ermit[1, 1] + ermit[3, 1], Pens.Black, Brushes.RoyalBlue, Brushes.RoyalBlue);
					gr.DrawVector(g, ermit[0, 0], ermit[0, 1], ermit[0, 0] + ermit[2, 0], ermit[0, 1] + ermit[2, 1], Pens.Black, Brushes.Red, Brushes.Red);
					gr.arrY = new double[3];
					gr.arrX = new double[3];
					gr.arrSubsсribes = new string[2];
					gr.arrX[0] = besier[0, 0];
					gr.arrX[1] = besier[1, 0];
					gr.arrY[0] = besier[0, 1];
					gr.arrY[1] = besier[1, 1];
					gr.arrX[2] = besier[2, 0];
					gr.arrY[2] = besier[2, 1];
					gr.arrSubsсribes[0] = "P1";
					gr.arrSubsсribes[1] = "P2";
					gr.DrawPolyline(g, Pens.Black, Brushes.Red);
					gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.Black);
					gr.arrY = new double[2];
					gr.arrX = new double[2];
					gr.arrX[0] = besier[2, 0];
					gr.arrX[1] = besier[3, 0];
					gr.arrY[0] = besier[2, 1];
					gr.arrY[1] = besier[3, 1];
					gr.arrSubsсribes[0] = "P3";
					gr.arrSubsсribes[1] = "P4";
					gr.DrawPolyline(g, Pens.Black, Brushes.RoyalBlue);
					gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.Black);
					PB_Graphic.Refresh();
					break;
			}
		}

		private void BTN_Rotate_Click(object sender, EventArgs e)
		{
			TMatrix mpre;		//Текущая матрица преобразования
			TMatrix msumpre;	//Конечная матрица преобразования
			//TMatrix[] marr = new TMatrix[marr.Length];
			Point buf;
			TMatrix mrp;	//Точка - центр вращения
			int angle = 0;	//Угол вращения
			try
			{
				//Пробуем прочитать матрицу - точку из поля ввода:
				mrp = TMatrix.Parse(TB_Value.Text);
				//Проверяем, может ли она являться точкой:
				buf = mrp.GetPoint();
				//Преобразуем получившуюся точку в матрицу с коэфициентом однородности
				mrp = new TMatrix(""+mrp[0]+" "+mrp[1]+" 1");
			}
			catch (Exception ex)
			{
				ERR.SetError(TB_Value, ex.Message);
				return;
			}

			try
			{
				angle = int.Parse(TB_Angle.Text);
			}
			catch
			{
				ERR.SetError(TB_Angle, "Не получается преобразовать в целое число");
				return;
			}
			
			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";
			
			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Для поворота вокруг заданной точки, необходимо:
			//1. Сместить на вектор, равный вектору точки * -1
			//2. Повернуть вокруг начала координат
			//3. Сместить обратно на вектор точки
			msumpre = TMatrix.E(3);
			//Смещаем
			mpre = TMatrix.mMove2D(-mrp[0], -mrp[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
				//arr[i] = marr[i].GetPoint();
			}
			msumpre = msumpre * mpre;
			//Поворачиваем
			mpre = TMatrix.mRotate2D(angle);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
				//arr[i] = marr[i].GetPoint();
			}
			msumpre = msumpre * mpre;
			//Смещаем обратно
			mpre = TMatrix.mMove2D(mrp[0], mrp[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
				//arr[i] = marr[i].GetPoint();
				
			}
			msumpre = msumpre * mpre;
			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Поворот группы точек:\r\n" + sbuf + "относительно точки " + buf + " на угол "
				+ angle + ". Матрица преобразования:\r\n" + msumpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * msumpre;
			TB_ResMatrix.Text =resmatrix.ToString("F2");
		}

		private void TB_Value_TextChanged(object sender, EventArgs e)
		{
			ERR.SetError(TB_Value, "");
		}

		private void TB_Angle_TextChanged(object sender, EventArgs e)
		{
			ERR.SetError(TB_Angle, "");
		}

		private void BTN_Move_Click(object sender, EventArgs e)
		{
			TMatrix mpre;		//Текущая матрица преобразования
			Point buf;
			TMatrix mrp;		//Точка - вектор перемещения
			try
			{
				//Пробуем прочитать матрицу - точку из поля ввода:
				mrp = TMatrix.Parse(TB_Value.Text);
				//Проверяем, может ли она являться точкой:
				buf = mrp.GetPoint();
				//Преобразуем получившуюся точку в матрицу с коэфициентом однородности
				mrp = new TMatrix("" + mrp[0] + " " + mrp[1] + " 1");
			}
			catch (Exception ex)
			{
				ERR.SetError(TB_Value, ex.Message);
				return;
			}

			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Сместить на вектор, равный вектору точки
			mpre = TMatrix.mMove2D(mrp[0], mrp[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
				//arr[i] = marr[i].GetPoint();
			}
			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Смещение группы точек:\r\n" + sbuf + "на вектор "
				+ buf + ". Матрица преобразования:\r\n" + mpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * mpre;
			TB_ResMatrix.Text =resmatrix.ToString("F2");
		}

		private void BTN_Symmetry_Click(object sender, EventArgs e)
		{
			TMatrix mpre;	//Текущая матрица преобразования
			int angle = 0;	//Угол вращения

			try
			{
				angle = int.Parse(TB_Angle.Text);
			}
			catch
			{
				ERR.SetError(TB_Angle, "Не получается преобразовать в целое число");
				return;
			}

			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Симметрично отобразить относительно прямой через начало координат, с углом к оси OX = angle
			mpre = TMatrix.mSymmetry2D(angle);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}
			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Симметричное отражение группы точек:\r\n" + sbuf
				+ " относительно прямой через начало координат под углом к оси 0X = "
				+ angle + ". Матрица преобразования:\r\n" + mpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * mpre;
			TB_ResMatrix.Text =resmatrix.ToString("F2");
		}

		private void BTN_Shift_Click(object sender, EventArgs e)
		{
			TMatrix mpre;		//Текущая матрица преобразования
			int angle = 0;	//Угол сдвига
			int mode = 0;	//Режим сдвига. 0 - вдоль 0X, 1 - вдоль 0Y
			try
			{
				mode = int.Parse(TB_Value.Text);
				if (mode != 0 && mode != 1) throw new Exception();
			}
			catch
			{
				ERR.SetError(TB_Value, "Во время сдвига это поле должно принимать значения 0 или 1");
				return;
			}

			try
			{
				angle = int.Parse(TB_Angle.Text);
			}
			catch
			{
				ERR.SetError(TB_Angle, "Не получается преобразовать в целое число");
				return;
			}

			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Смещаем относительно выбранной оси
			if (mode == 0)
				mpre = TMatrix.mShiftX2D(angle);
			else
				mpre = TMatrix.mShiftY2D(angle);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}
			
			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Сдвиг (деформация) группы точек:\r\n" + sbuf + " вдоль оси " + (mode==0 ? "0X" : "0Y") + " на угол "
				+ angle + ". Матрица преобразования:\r\n" + mpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * mpre;
			TB_ResMatrix.Text =resmatrix.ToString("F2");
		}

		private void BTN_Scaling_Click(object sender, EventArgs e)
		{
			TMatrix mpre;		//Текущая матрица преобразования
			TMatrix msumpre;	//Конечная матрица преобразования
			Point buf;
			TMatrix mrp;	//Точка - центр масштабирования
			TMatrix koef;	//Коэфициенты масштабирования
			try
			{
				//Пробуем прочитать матрицу - точку из поля ввода:
				mrp = TMatrix.Parse(TB_Value.Text);
				//Проверяем, может ли она являться точкой:
				buf = mrp.GetPoint();
				//Преобразуем получившуюся точку в матрицу с коэфициентом однородности
				mrp = new TMatrix("" + mrp[0] + " " + mrp[1] + " 1");
			}
			catch (Exception ex)
			{
				ERR.SetError(TB_Value, ex.Message);
				return;
			}

			try
			{
				koef = TMatrix.Parse(TB_Angle.Text);
				if (koef.Width != 2) throw new Exception("Необходимо задать 2 числа - коэфициента масштабирования: по 0X и по 0Y");
			}
			catch (Exception ex)
			{
				ERR.SetError(TB_Angle, ex.Message);
				return;
			}

			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Для поворота вокруг заданной точки, необходимо:
			//1. Сместить на вектор, равный вектору точки * -1
			//2. Масштабировать относительно начала координат
			//3. Сместить обратно на вектор точки
			msumpre = TMatrix.E(3);
			//Смещаем
			mpre = TMatrix.mMove2D(-mrp[0], -mrp[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
				//arr[i] = marr[i].GetPoint();
			}
			msumpre = msumpre * mpre;
			//Масштабируем
			mpre = TMatrix.mScale2D(koef[0], koef[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}
			msumpre = msumpre * mpre;
			//Смещаем обратно
			mpre = TMatrix.mMove2D(mrp[0], mrp[1]);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}
			msumpre = msumpre * mpre;
			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Масштабирование группы точек:\r\n" + sbuf
				+ "относительно точки " + buf + " с коэфициентами {X=" + koef[0].ToString("F2")
				+ "; Y=" + koef[1].ToString("F2") + "}. Матрица преобразования:\r\n" + msumpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * msumpre;
			TB_ResMatrix.Text =resmatrix.ToString("F2");
		}

		private void BTN_Move_0_Click(object sender, EventArgs e)
		{
			TMatrix avgPoint = new TMatrix(2);	//Здесь будет средняя точка фигуры
			TMatrix mpre;	//Матрица преобразования
			int i;
			double sum;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Ищем среднее арифметическое координат X
			for (i = 0, sum = 0; i < marr.Length; i++)
			{
				sum += marr[i][0];
			}
			avgPoint[0] = sum / marr.Length;
			//Ищем среднее арифметическое координат Y
			for (i = 0, sum = 0; i < marr.Length; i++)
			{
				sum += marr[i][1];
			}
			avgPoint[1] = sum / marr.Length;
			//Задаем длину и направление переноса
			//avgPoint = avgPoint * -2;

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Собственно перенос
			mpre = TMatrix.mMove2D(-avgPoint[0]*2, -avgPoint[1]*2);
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}

			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			//Отрисовка порочки векторов от начала координат до средних точек начальной и конечной фигур
 			//gr.DrawVector(g, 0, 0, avgPoint[0], avgPoint[1], Pens.Black, Brushes.GhostWhite, Brushes.GhostWhite);
			//gr.DrawVector(g, 0, 0, -avgPoint[0], -avgPoint[1], Pens.Black, Brushes.GhostWhite, Brushes.GhostWhite);
			gr.DrawVector(g, avgPoint[0], avgPoint[1], -avgPoint[0], -avgPoint[1], Pens.Black, Brushes.GhostWhite, Brushes.GhostWhite);

			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Перенос группы точек:\r\n" + sbuf
				+ " отностиельно начала координат. Матрица преобразования:\r\n"
				+ mpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			resmatrix = resmatrix * mpre;
			TB_ResMatrix.Text = resmatrix.ToString("F2");
		}

		private void MMI_Save_Click(object sender, EventArgs e)
		{
			if (SFD_SaveFile.ShowDialog() == DialogResult.OK)
			{
				PB_Graphic.Image.Save(SFD_SaveFile.FileName);
				FileStream fs;
				/*if (TC_Mode.SelectedIndex == 0)
					fs = new FileStream("Affin.log", FileMode.Create, FileAccess.Write);
				else
					fs = new FileStream("Curves.log", FileMode.Create, FileAccess.Write);*/
				string str = SFD_SaveFile.FileName;
				str = str.Remove(str.LastIndexOf(".")) + ".log";
				fs = new FileStream(str, FileMode.Create, FileAccess.Write);
				StreamWriter fsw = new StreamWriter(fs);
				fsw.WriteLine(TB_Log.Text);
				if (TC_Mode.SelectedIndex == 0)
				{
					fsw.Write("Результирующая матрица:\r\n" + TB_ResMatrix.Text);
				}
				fsw.Close();
				fs.Close();
			}
			
		}

		private void MMI_Blank_Click(object sender, EventArgs e)
		{
			g.Clear(SystemColors.Window);
			TGraphic.DrawInjGraphBorderA4(g, 0, 0);
			PB_Graphic.Refresh();
		}

		private void MMI_Data_Click(object sender, EventArgs e)
		{
			if (frm_Data == null)
			{
				frm_Data = new FRM_Data();
				frm_Data.parent = this;
				frm_Data.Show();
			}
			else
			{
				frm_Data.Top = this.Top + this.Height / 5;
				frm_Data.Left = this.Left + this.Width / 5;
				frm_Data.Activate();
			}
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			BTN_Move.Enabled =
				BTN_Move_0.Enabled =
				BTN_Rotate.Enabled =
				BTN_Scaling.Enabled =
				BTN_Shift.Enabled =
				BTN_Symmetry.Enabled = marr != null;
		}

		private void BTN_ApplyMatrix_Click(object sender, EventArgs e)
		{
			TMatrix mpre;		//Текущая матрица преобразования
			
			try
			{
				mpre = TMatrix.Parse(TB_ResMatrix.Text);
				if (mpre.Heigth!=3 || mpre.Width!=3) throw new Exception("Неверные размеры матрицы.");
			}
			catch (Exception ex)
			{
				ERR.SetError(TB_Value, ex.Message);
				return;
			}

			int i;
			double[] X = new double[marr.Length];
			double[] Y = new double[marr.Length];
			string sbuf = "";

			//Сохраняем предыдущие положения точек
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}

			//Применяем матрицу
			for (i = 0; i < marr.Length; i++)
			{
				marr[i] = marr[i] * mpre;
			}

			//Заносим новые координаты на график
			for (i = 0; i < marr.Length; i++)
			{
				X[i] = marr[i][0];
				Y[i] = marr[i][1];
			}
			gr.arrX = X;
			gr.arrY = Y;

			//Отрисовываем график с подписями точек
			gr.arrSubsсribes = NextSubscribes(gr.arrSubsсribes);
			gr.DrawPolygone(g, Pens.Black, Brushes.RoyalBlue);
			gr.DrawSubscribes(g, SystemFonts.SmallCaptionFont, Brushes.RoyalBlue);
			PB_Graphic.Refresh();

			//Дополняем лог	

			TB_Log.Text = TB_Log.Text + "Применение матрицы к группе точек:\r\n" + sbuf
				+ ". Матрица преобразования:\r\n" + mpre.ToString("F2");
			//Получаем положения точек
			sbuf = "";
			for (i = 0; i < marr.Length; i++)
			{
				sbuf = sbuf + gr.arrSubsсribes[i] + ": {" + gr.arrX[i].ToString("F2") + "; " + gr.arrY[i].ToString("F2") + "}\r\n";
			}
			TB_Log.Text = TB_Log.Text + "Новые координаты:\r\n" + sbuf + "\r\n\r\n";
			//Обновляем результирующую матрицу
			//resmatrix = resmatrix * mpre;
			TB_ResMatrix.Text = resmatrix.ToString("F2");
		}

	}
}
