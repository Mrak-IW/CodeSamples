using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NSGraphic
{
    public class TGraphic
    {
		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public TGraphic()
		{ }
		/// <summary>
		/// Конструктор создания по образцу (копирует настройки)
		/// </summary>
		/// <param name="template">Образец</param>
		public TGraphic(TGraphic template)
		{
			this.aLenX = template.aLenX;
			this.aLenY = template.aLenY;
			this.arrX = template.arrX;
			this.arrY = template.arrY;
			this.autoScaleX = template.autoScaleX;
			this.autoScaleY = template.autoScaleY;
			this.Left = template.Left;
			this.Top = template.Top;
			this.MaxX = template.MaxX;
			this.MaxY = template.MaxY;
			this.MinNegX = template.MinNegX;
			this.MinNegY = template.MinNegY;
			this.SizeX = template.SizeX;
			this.SizeY = template.SizeY;
			this.stepLinesX = template.stepLinesX;
			this.stepLinesY = template.stepLinesY;
			this.stepSubscrX = template.stepSubscrX;
			this.stepSubscrY = template.stepSubscrY;
		}
		/// <summary>
		/// Строка формата для отображения подписей по оси X
		/// </summary>
		public string formatX = "";
		/// <summary>
		/// Строка формата для отображения подписей по оси Y
		/// </summary>
		public string formatY = "";
		/// <summary>
		/// Отступ слева от границ объекта графики
		/// </summary>
		public int Left
		{
			get { return left; }
			set 
			{
				left = value;
				zero.X = 0;
				zero.X = left - CoordsToPointOnGraphicsObject(MinNegX, 0).X;
			}
		}
		/// <summary>
		/// PRIVATE Отступ слева от границ объекта графики
		/// </summary>
		private int left = 0;
		/// <summary>
		/// Отступ сверху от границ объекта графики
		/// </summary>
		public int Top
		{
			get { return top; }
			set
			{
				top = value;
				zero.Y = 0;
				zero.Y = top - CoordsToPointOnGraphicsObject(0, MaxY).Y + aLenY;
			}
		}
		/// <summary>
		/// PRIVATE Отступ сверху от границ объекта графики
		/// </summary>
		private int top = 0;

        /// <summary>
        /// Размер графика по оси Х
        /// </summary>
		public int SizeX
		{
			get { return sizeX; }
			set
			{
				sizeX = value;
				zero.X = 0;
				zero.X = left - CoordsToPointOnGraphicsObject(MinNegX, 0).X;
			}
		}
		private int sizeX = 125;
		/// <summary>
		/// Шаг линий сетки по оси Х
		/// </summary>
		public double stepLinesX = 10;
		/// <summary>
		/// На сколько линий сетки по оси X приходится одна подпись
		/// </summary>
		public int stepSubscrX = 1;
		/// <summary>
		/// Длина выступающей "стрелки" на оси 0X (arrow Len)
		/// </summary>
		public int aLenX = 25;
        /// <summary>
		/// Размер графика по оси Y
        /// </summary>
		public int SizeY
		{
			get { return sizeY; }
			set
			{
				sizeY = value;
				zero.Y = 0;
				zero.Y = top - CoordsToPointOnGraphicsObject(0, MaxY).Y + aLenY;
			}
		}
		private int sizeY = 125;
		/// <summary>
		/// Шаг линий сетки по оси Y
		/// </summary>
		public double stepLinesY = 10;
		/// <summary>
		/// На сколько линий сетки по оси Y приходится одна подпись
		/// </summary>
		public int stepSubscrY = 1;
		/// <summary>
		/// Длина выступающей "стрелки" на оси 0Y (arrow Len)
		/// </summary>
		public int aLenY = 25;
		/// <summary>
		/// Величина маркеров на графике, будь то точки, либо стрелки векторов.
		/// </summary>
		public int markerSize = 4;
        /// <summary>
        /// Точка на форме, где будет располагаться начало координат
        /// </summary>
        private Point zero = new Point(0,0);
        /// <summary>
        /// Массив значений по оси Х
        /// </summary>
		public double[] arrX = { 0 };
        /// <summary>
        /// Массив значений по оси Y
        /// </summary>
		public double[] arrY = { 0 };
		public string[] arrSubsсribes = { "" };
		/// <summary>
		/// Верхняя граница отображаемых на графике значений по оси X
		/// </summary>
		public double MaxX
		{
			set
			{
				maxX = value;
			}
			get
			{
				int i;
				if (autoScaleX && arrX.Length > 0)
				{
					//Находим максимальное значение по оси 0X
					maxX = 0;
					for (i = 0; i < arrX.Length; i++)
					{
						if (arrX[i] > maxX) maxX = arrX[i];
					}
				}
				if (maxX == MinNegX) maxX = 100;
				return maxX;
			}
		}
		private double maxX = 100;
		/// <summary>
		/// Верхняя граница отображаемых на графике значений по оси Y
		/// </summary>
		public double MaxY
		{
			set
			{
				maxY = value;
			}
			get
			{
				int i;
				if (autoScaleY && arrY.Length > 0)
				{
					//Находим максимальное значение по оси 0Y
					maxY = 0;
					for (i = 0; i < arrY.Length; i++)
					{
						if (arrY[i] > maxY) maxY = arrY[i];
					}
				}
				if (maxY == MinNegY) maxY = 100;
				return maxY;
			}
		}
		private double maxY = 100;
		/// <summary>
		/// Минимальное отрицательное значение по оси 0X
		/// </summary>
		public double MinNegX
		{
			set
			{
				minNegX = value < 0 ? value : 0;
			}
			get
			{
				int i;
				if (autoScaleX && arrX.Length > 0)
				{
					//Находим минимальное отрицательное значение по оси 0X
					minNegX = 0;
					for (i = 0; i < arrX.Length; i++)
					{
						if (arrX[i] < minNegX) minNegX = arrX[i];
					}
				}
				//if (MaxX == minNegX) MinNegX = -100;
				return minNegX;
			}
		}
		private double minNegX = 0;
		/// <summary>
		/// Минимальное отрицательное значение по оси 0Y
		/// </summary>
		public double MinNegY
		{
			set
			{
				minNegY = value < 0 ? value : 0;
			}
			get
			{
				int i;
				if (autoScaleY && arrY.Length > 0)
				{
					//Находим минимальное отрицательное значение по оси 0Y
					minNegY = 0;
					for (i = 0; i < arrY.Length; i++)
					{
						if (arrY[i] < minNegY) minNegY = arrY[i];
					}
				}
				//if (MaxY == minNegY) MinNegY = -100;
				return minNegY;
			}
		}
		/// <summary>
		/// Минимальное отрицательное значение по оси 0Y
		/// </summary>
		private double minNegY = 0;
		/// <summary>
		/// Автоматическое определение верхней границы значений по оси X
		/// </summary>
		public bool autoScaleX = false;
		/// <summary>
		/// Автоматическое определение верхней границы значений по оси Y
		/// </summary>
		public bool autoScaleY = false;

        /// <summary>
		/// Выводит систему координат
        /// </summary>
        /// <param name="g">Объект графики</param>
        /// <param name="axisP">Перо, которым рисуем оси и насечки</param>
        /// <param name="subdcrB">Кисть, которой пишем подписи к осям</param>
		/// <param name="linesH">Перо, которым рисуем горизонтальные линии линии сетки. Если NULL, то эти линии не рисуем.</param>
		/// <param name="linesV">Перо, которым рисуем вертикальные линии линии сетки. Если NULL, то эти линии не рисуем.</param>
		public void DrawAxis(Graphics g, Pen axisP, Brush subdcrB, Pen linesH, Pen linesV)
		{

			int i;
			Point buf = new Point();
			Point buf1 = new Point();
			double valX, valY;
			Font font = SystemFonts.SmallCaptionFont;

			

			//Защита от дурака
			if (arrX.Length == 0 || arrY.Length == 0)
				throw new Exception("Попытка вывести график, при отсутствии координат точек");

			#region Отрисовка подписей по оси 0Y и горизонтальных линий сетки
			//Положительная часть

			for (valY = 0, i = 0; valY <= MaxY; valY += stepLinesY, i++)
			{
				buf = CoordsToPointOnGraphicsObject(MinNegX, valY);
				if (i % stepSubscrY == 0)
					g.DrawString((valY).ToString(formatY), font, Brushes.Black, buf.X - (valY).ToString(formatY).Length * font.Size - 3, buf.Y - font.Height / 2);
				//Отрисовка горизонтальных линий сетки
				if (linesH != null)
				{
					g.DrawLine(linesH, buf.X, buf.Y, buf.X + sizeX - aLenX, buf.Y);
				}
				buf = CoordsToPointOnGraphicsObject(0, valY);
				//Отрисовка насечек
				g.DrawLine(axisP, buf.X - 3, buf.Y, buf.X + 3, buf.Y);
			}
			//Отрицательная часть
			for (valY = -stepLinesY, i = 1; valY >= MinNegY; valY -= stepLinesY, i++)
			{
				buf = CoordsToPointOnGraphicsObject(MinNegX, valY);
				if (i % stepSubscrY == 0)
					g.DrawString((valY).ToString(formatY), font, Brushes.Black, buf.X - (valY).ToString(formatY).Length * font.Size - 3, buf.Y - font.Height / 2);
				//Отрисовка горизонтальных линий сетки
				if (linesH != null)
				{
					g.DrawLine(linesH, buf.X, buf.Y, buf.X + sizeX - aLenX, buf.Y);
				}
				buf = CoordsToPointOnGraphicsObject(0, valY);
				//Отрисовка насечек
				g.DrawLine(axisP, buf.X - 3, buf.Y, buf.X + 3, buf.Y);
			}
			#endregion

			#region Отрисовка подписей по оси 0X и вертикальных линий сетки
			//Положительная часть
			for (valX = 0, i = 0; valX <= MaxX; valX += stepLinesX, i++)
			{
				buf = CoordsToPointOnGraphicsObject(valX, MinNegY);
				if (i % stepSubscrX == 0)
					g.DrawString((valX).ToString(formatX), font, Brushes.Black, buf.X - (valX).ToString(formatX).Length * font.Size / 2, buf.Y);
				//Отрисовка вертикальных линий сетки
				if (linesV != null)
				{
					g.DrawLine(linesV, buf.X, buf.Y, buf.X, buf.Y - SizeY + aLenY);
				}
				buf = CoordsToPointOnGraphicsObject(valX, 0);
				//Отрисовка насечек
				g.DrawLine(axisP, buf.X, buf.Y - 3, buf.X, buf.Y + 3);
			}
			//Отрицательная часть
			for (valX = -stepLinesX, i = 1; valX >= MinNegX; valX -= stepLinesX, i++)
			{
				buf = CoordsToPointOnGraphicsObject(valX, MinNegY);
				if (i % stepSubscrX == 0)
					g.DrawString((valX).ToString(formatX), font, Brushes.Black, buf.X - (valX).ToString(formatX).Length * font.Size / 2, buf.Y);
				//Отрисовка вертикальных линий сетки
				if (linesV != null)
				{
					g.DrawLine(linesV, buf.X, buf.Y, buf.X, buf.Y - SizeY + aLenY);
				}
				buf = CoordsToPointOnGraphicsObject(valX, 0);
				//Отрисовка насечек
				g.DrawLine(axisP, buf.X, buf.Y - 3, buf.X, buf.Y + 3);
				//
			}
			#endregion

			#region Отрисовка осей
			//Получаем точку, куда упирается ось Y
			buf = CoordsToPointOnGraphicsObject(0, MaxY);
			buf.Y -= aLenY;
			//Получаем точку, откуда начинается ось Y
			buf1 = CoordsToPointOnGraphicsObject(0, MinNegY);
			//Рисуем ось Y
			g.DrawLine(axisP, buf1, buf);
			DrawArrow(g, buf1, buf, axisP, linesV != null ? linesV.Brush : Brushes.White);
			//Получаем точку, куда упирается ось X
			buf = CoordsToPointOnGraphicsObject(MaxX, 0);
			buf.X += aLenX;
			//Получаем точку, откуда начинается ось X
			buf1 = CoordsToPointOnGraphicsObject(MinNegX, 0);
			//Рисуем ось X
			g.DrawLine(axisP, buf1, buf);
			DrawArrow(g, buf1, buf, axisP, linesH != null ? linesH.Brush : axisP.Brush);
			#endregion
        }

		/// <summary>
		/// Рисуем стандартный график
		/// </summary>
		/// <param name="g">Объект графики, на котором рисуем</param>
		/// <param name="p">Перо, которым рисуем линию. Если NULL - линию не рисуем</param>
		/// <param name="b">Кисть, которой рисуем точки. Если NULL - точки не рисуем</param>
		public void DrawPolyline(Graphics g, Pen p, Brush b)
		{
			Point[] points = new Point[(arrX.Length < arrY.Length ? arrX.Length : arrY.Length)];
			//Отрисовка линий
			
			for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
			{
				points[i] = CoordsToPointOnGraphicsObject(arrX[i], arrY[i]);
			}
			if (p != null)
			{
				g.DrawLines(p, points);
			}
			//Отрисовка точек
			if (b != null)
			{
				for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
				{
					//g.FillEllipse(b, points[i].X - 5, points[i].Y - 5, 10, 10);
					//if (p != null) g.DrawEllipse(p, points[i].X - 5, points[i].Y - 5, 10, 10);
					DrawPoint(g, points[i], p, b);
				}
			}
		}

		/// <summary>
		/// Рисуем многоугольник
		/// </summary>
		/// <param name="g">Объект графики, на котором рисуем</param>
		/// <param name="p">Перо, которым рисуем линию. Если NULL - линию не рисуем</param>
		/// <param name="b">Кисть, которой рисуем точки. Если NULL - точки не рисуем</param>
		public void DrawPolygone(Graphics g, Pen p, Brush b)
		{
			Point[] points = new Point[(arrX.Length < arrY.Length ? arrX.Length : arrY.Length)];
			//Отрисовка линий
			if (p != null)
			{
				for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
				{
					points[i] = CoordsToPointOnGraphicsObject(arrX[i], arrY[i]);
					//g.DrawString(i.ToString(),SystemFonts.CaptionFont,Brushes.Black,points[i]);
				}
				g.DrawPolygon(p, points);
			}
			//Отрисовка точек
			if (b != null)
			{
				for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
				{
					/*g.FillEllipse(b, points[i].X - 5, points[i].Y - 5, 10, 10);
					g.DrawEllipse(p, points[i].X - 5, points[i].Y - 5, 10, 10);*/
					DrawPoint(g, points[i], p, b);
				}
				
			}
		}

		/// <summary>
		/// Рисуем гистограмму
		/// </summary>
		/// <param name="g"></param>
		public void DrawGist(Graphics g, Pen p, Brush b)
		{
			//DrawAxis(g);

			Point[] points = new Point[(arrX.Length < arrY.Length ? arrX.Length : arrY.Length)];
			//Получаем массив точек - середин оснований столбцов
			for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
			{
				points[i] = CoordsToPointOnGraphicsObject(arrX[i], arrY[i]);
				//g.DrawString(i.ToString(),SystemFonts.CaptionFont,Brushes.Black,points[i]);
			}
			//Отрисовка столбиков
			int w = CoordsToPointOnGraphicsObject(stepLinesX, 0).X - CoordsToPointOnGraphicsObject(0, 0).X;//(SizeX - aLenX) / arrX.Length;
			
			Point buf = CoordsToPointOnGraphicsObject(0,0);
			for (int i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
			{
				g.FillRectangle(b, points[i].X - w / 2, points[i].Y, w, buf.Y - points[i].Y);
				g.DrawRectangle(p, points[i].X - w/2, points[i].Y, w, buf.Y - points[i].Y);
			}
			//DrawPoint(g, zero, p, Brushes.Red);
			//DrawPoint(g, CoordsToPointOnGraphicsObject(stepLinesX, 0), p, Brushes.Red);
		}
	
		/// <summary>
		/// Рисуем эпюры
		/// </summary>
		/// <param name="g"></param>
		public void DrawEpur(Graphics g, Pen p)
		{
			int i;

			//DrawAxis(g);

			Point[] points = new Point[(arrX.Length < arrY.Length ? arrX.Length : arrY.Length)];
			//Вычисление координат на объекте графики
			for (i = 0; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
			{
				points[i] = CoordsToPointOnGraphicsObject(arrX[i], arrY[i]);
				//g.DrawString(i.ToString(),SystemFonts.CaptionFont,Brushes.Black,points[i]);
			}
			//Отрисовка ступенек
			Point buf = CoordsToPointOnGraphicsObject(0, 0);
			for (i = 1; i < (arrX.Length < arrY.Length ? arrX.Length : arrY.Length); i++)
			{
				g.DrawLine(p, points[i - 1].X, points[i - 1].Y,points[i].X, points[i - 1].Y);
				g.DrawLine(p, points[i].X, points[i - 1].Y, points[i].X, points[i].Y);
			}

			buf = RotateSK(SizeX, 0);
			g.DrawLine(p, points[i - 1].X, points[i - 1].Y, buf.X, points[i - 1].Y);

		}
		
		/// <summary>
		/// Отрисовать вектор.
		/// </summary>
		/// <param name="beginX">Координата начальной точки по оси X</param>
		/// <param name="beginY">Координата начальной точки по оси X</param>
		/// <param name="endX">Координата конечной точки по оси Y</param>
		/// <param name="endY">Координата конечной точки по оси Y</param>
		/// <param name="line">Перо, которой рисуем линию и обводку стрелки и начала</param>
		/// <param name="end">Кисть для заливки стрелки. NULL - нет стрелки</param>
		/// <param name="begin">Кисть для заливки начала. NULL - нет начала</param>
		public void DrawVector(Graphics g, double beginX, double beginY, double endX, double endY, Pen line, Brush end, Brush begin)
		{
			Point bp = CoordsToPointOnGraphicsObject(beginX, beginY);	//Точка начала вектора на объекте гравики
			Point ep = CoordsToPointOnGraphicsObject(endX, endY);		//Точка конца вектора на объекте гравики

			g.DrawLine(line, bp, ep);

			if (end != null)	//Отрисовка стрелки
			{
				DrawArrow(g, bp, ep, line, end);
			}

			if (begin != null)	//Отрисовка точки начала
			{
				DrawPoint(g, bp, line, begin);
			}
		}
		
		/// <summary>
		/// Отрисовка стрелки, указывающей на заданную точку.
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="beginp">Точка, откуда выходит стрелка</param>
		/// <param name="endp">Точка, куда указывает стрелка</param>
		/// <param name="pen"></param>
		/// <param name="brush"></param>
		private void DrawArrow(Graphics g, Point beginp, Point endp, Pen pen, Brush brush)
		{
			//Point bp = CordsToPointOnGraphics(beginX, beginY);	//Точка начала вектора на объекте гравики
			//Point ep = CordsToPointOnGraphics(endX, endY);		//Точка конца вектора на объекте гравики
			if (beginp.X != endp.X || beginp.Y != endp.Y)
			{
				Point[] arr = new Point[3];
				arr[0] = endp;
				double coef = 3;		//Отношение длина/ширина стрелки
				double x = endp.X - beginp.X;		//Длина вектора по X
				double y = endp.Y - beginp.Y;		//Длина вектора по Y
				double L = Math.Sqrt(x * x + y * y);	//Длина вектора
				double h = coef * y * markerSize / L;	//длина стрелки по Y
				double w = coef * x * markerSize / L;	//длина стрелки по X
				double Bx = endp.X - w;	//Точка, в которой находится середина тупого конца стрелки
				double By = endp.Y - h;
				double k = y * markerSize / L;	//Смещение углов стрелки, относительно точки B по оси X
				double p = x * markerSize / L;	//Смещение углов стрелки, относительно точки B по оси X
				arr[1] = new Point(Convert.ToInt32(Bx - k), Convert.ToInt32(By + p));
				arr[2] = new Point(Convert.ToInt32(Bx + k), Convert.ToInt32(By - p));
				g.FillPolygon(brush, arr);
				g.DrawPolygon(pen, arr);
			}
			else
			{
				DrawPoint(g, endp, pen, brush);
			}
		}
		public void DrawSubscribes(Graphics g, Font font, Brush brush)
		{
			int i, cnt;
			Point buf;

			if (arrX == null || arrY == null || arrSubsсribes == null)
				return;
			cnt = arrX.Length > arrY.Length ? arrY.Length : arrX.Length;
			if (cnt > arrSubsсribes.Length)
				cnt = arrSubsсribes.Length;

			for (i = 0; i < cnt; i++)
			{
				buf = CoordsToPointOnGraphicsObject(arrX[i],arrY[i]);
				buf.X = Convert.ToInt32(buf.X - arrSubsсribes.Length * font.Size / 2);
				buf.Y = buf.Y + markerSize;
				g.DrawString(arrSubsсribes[i], font, brush, buf);
			}
		}
		/// <summary>
		/// Подпрограмма отрисовки точки на графике
		/// </summary>
		/// <param name="g">Объект графики</param>
		/// <param name="point">Точка</param>
		/// <param name="pen">Обвод</param>
		/// <param name="brush">Заливка</param>
		private void DrawPoint(Graphics g, Point point, Pen pen, Brush brush)
		{
			if (brush != null) g.FillEllipse(brush, point.X - markerSize, point.Y - markerSize, 2 * markerSize, 2 * markerSize);
			if (pen != null) g.DrawEllipse(pen, point.X - markerSize, point.Y - markerSize, 2 * markerSize, 2 * markerSize);
		}
		/// <summary>
		/// Преобразует координаты точки на графике в координаты точки на объекте
		/// </summary>
		/// <param name="pt">Точка на графике</param>
        private Point RotateSK(Point pt)
        {
			Point res = new Point(pt.X + zero.X, zero.Y - pt.Y);
			return res;
        }

		/// <summary>
		/// Преобразует координаты точки на графике в координаты точки на объекте
		/// </summary>
		/// <param name="pt">Точка на графике</param>
		private Point RotateSK(int X, int Y)
		{
			Point res = new Point(X + zero.X, zero.Y - Y);
			return res;
		}
		/// <summary>
		/// Преобразует координаты точки на графике в координаты точки на объекте
		/// </summary>
		/// <param name="X">Координата по оси 0X</param>
		/// <param name="Y">Координата по оси 0Y</param>
		private Point CoordsToPointOnGraphicsObject(double X, double Y)
		{
			Point buf = new Point();
			buf.X = Convert.ToInt32((SizeX - aLenX) * (X - MinNegX) / (MaxX - MinNegX));
			buf.Y = Convert.ToInt32((SizeY - aLenY) * (Y - MinNegY) / (MaxY - MinNegY));
			buf = RotateSK(buf);

			return buf;
		}
		/// <summary>
		/// Преобразует координаты точки на объекте в координаты точки на графике
		/// </summary>
		/// <param name="X">OUT Координата по оси 0X</param>
		/// <param name="Y">OUT Координата по оси 0Y</param>
		/// <param name="pt">Точка на объекте графики</param>
		private void PointOnGraphicsObjectToCoords(out double X, out double Y, Point pt)
		{
			X = Convert.ToDouble(pt.X) * (MaxX - MinNegX) / (SizeX - aLenX) - zero.X + MinNegX;
			Y = Convert.ToDouble(pt.Y) * (MaxY - MinNegY) / (SizeY - aLenY) + zero.Y + MinNegY;
		}

		/// <summary>
		/// Отрисовка рамки для чертежа (инженерная графика) для формата A4
		/// </summary>
		/// <param name="g">Смещение рамки вниз</param>
		/// <param name="top">Смещение рамки вниз</param>
		/// <param name="Left">Смещение рамки влево</param>
		static public void DrawInjGraphBorderA4(Graphics g, int top, int Left)
		{
			Pen bold = new Pen(Color.Black, 2);
			Pen regular = new Pen(Color.Black, 1);
			int leftMargin = 78, margin = 19;
			int Height = 1170, Width = 825;
			double pxInMm = 3.9;
			Font ft = new Font("Times", (float)10);
			int i;

			Point begin = new Point();
			Point end = new Point();

			//Отрисовка внешней рамки
			Rectangle mainrect = new Rectangle(Left + leftMargin, top + margin, Width - leftMargin - margin, Height - 2 * margin);
			g.DrawRectangle(bold, mainrect);
			//Вспомогательная надпись
			Rectangle rect = new Rectangle(Left + leftMargin, top + margin, 273, 58);
			g.DrawRectangle(bold, rect);
			#region Ой, блин... Основная надпись пошла
			//Внешний прямоугольник
			rect = new Rectangle(leftMargin, Height - margin - 215, mainrect.Width, 215);
			g.DrawRectangle(bold, rect);
			//Вертикальные жирные линии
			begin.X = rect.Left + Convert.ToInt32(7 * pxInMm)+1; 
			begin.Y = rect.Top;
			end.X = begin.X;
			end.Y = begin.Y + Convert.ToInt32(25 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.X = begin.X + Convert.ToInt32(10 * pxInMm)+1;
			end.X = begin.X;
			end.Y = begin.Y + Convert.ToInt32(55 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(23 * pxInMm)+1;
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(15 * pxInMm)+1;
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(10 * pxInMm)+1;
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(70 * pxInMm)+1;
			begin.Y = begin.Y + Convert.ToInt32(15 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(15 * pxInMm)+1;
			end.Y = end.Y - Convert.ToInt32(20 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X + Convert.ToInt32(17 * pxInMm)+1;
			g.DrawLine(bold, begin, end);

			begin.X = end.X = begin.X - Convert.ToInt32(17 * pxInMm) - 1;
			begin.X = end.X = begin.X + Convert.ToInt32(5 * pxInMm) + 1;
			begin.Y = begin.Y + Convert.ToInt32(20 * pxInMm);
			end.Y = end.Y + Convert.ToInt32(5 * pxInMm);
			g.DrawLine(bold, begin, end);

			//Горизонтальные жирные линии
			begin.X = Width - margin;
			end.X = begin.X - Convert.ToInt32(120 * pxInMm) - 1;
			begin.Y = end.Y = rect.Top + Convert.ToInt32(15 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.Y = end.Y = begin.Y + Convert.ToInt32(25 * pxInMm);
			g.DrawLine(bold, begin, end);

			begin.Y = end.Y = begin.Y - Convert.ToInt32(5 * pxInMm);
			end.X = end.X + Convert.ToInt32(70 * pxInMm) + 1;
			g.DrawLine(bold, begin, end);

			begin.Y = end.Y = begin.Y - Convert.ToInt32(15 * pxInMm);
			g.DrawLine(bold, begin, end);

			end.X = rect.Left;
			begin.X = Width - margin - Convert.ToInt32(120 * pxInMm) - 1;
			g.DrawLine(bold, begin, end);

			begin.Y = end.Y = begin.Y + Convert.ToInt32(5 * pxInMm);
			g.DrawLine(bold, begin, end);

			//Горизонталные тонкие линии
			begin.Y = end.Y = rect.Top + Convert.ToInt32(5 * pxInMm) - 2;
			begin.X = begin.X - 1;
			for (i = 0; i < 10; i++)
			{
				g.DrawLine(regular, begin, end);
				begin.Y = end.Y = end.Y + Convert.ToInt32(5 * pxInMm);
			}

			//Вертикальные тонкие линии
			begin.X = end.X = Width - margin - Convert.ToInt32(45 * pxInMm) - 2;
			begin.Y = rect.Top + Convert.ToInt32(20 * pxInMm);
			end.Y = begin.Y + Convert.ToInt32(15 * pxInMm);
			for (i = 0; i < 3; i++)
			{
				g.DrawLine(regular, begin, end);
				begin.X = end.X = end.X + Convert.ToInt32(5 * pxInMm);
			}

			//Надписи
			begin.X = rect.Left + Convert.ToInt32(7 * pxInMm) + 4;
			begin.Y = rect.Top + Convert.ToInt32(20 * pxInMm) + 2;
			g.DrawString("Лист", ft, Brushes.Black, begin);

			begin.X = rect.Left + 4;
			begin.Y = rect.Top + Convert.ToInt32(25 * pxInMm) + 2;
			g.DrawString("Разраб", ft, Brushes.Black, begin);

			begin.Y = begin.Y + Convert.ToInt32(5 * pxInMm);
			g.DrawString("Пров", ft, Brushes.Black, begin);

			begin.X = rect.Left + Convert.ToInt32(17 * pxInMm) + 4;
			begin.Y = rect.Top + Convert.ToInt32(20 * pxInMm) + 2;
			g.DrawString("Фамилия", ft, Brushes.Black, begin);

			begin.X = begin.X + Convert.ToInt32(23 * pxInMm) + 4;
			g.DrawString("Подпись", ft, Brushes.Black, begin);

			begin.X = begin.X + Convert.ToInt32(15 * pxInMm) + 2;
			g.DrawString("Дата", ft, Brushes.Black, begin);

			begin.Y = begin.Y - Convert.ToInt32(5 * pxInMm);
			begin.X = Width - margin - Convert.ToInt32(50 * pxInMm) + 14;
			g.DrawString("Лит", ft, Brushes.Black, begin);

			begin.X = begin.X + Convert.ToInt32(15 * pxInMm) + 2;
			g.DrawString("Масса", ft, Brushes.Black, begin);

			begin.X = begin.X + Convert.ToInt32(15 * pxInMm);
			g.DrawString("Масштаб", ft, Brushes.Black, begin);

			begin.Y = begin.Y + Convert.ToInt32(20 * pxInMm);
			begin.X = Width - margin - Convert.ToInt32(50 * pxInMm) + 14;
			g.DrawString("Лист", ft, Brushes.Black, begin);

			begin.X = begin.X + Convert.ToInt32(20 * pxInMm);
			g.DrawString("Листов", ft, Brushes.Black, begin);
			#endregion
		}
    }
}
