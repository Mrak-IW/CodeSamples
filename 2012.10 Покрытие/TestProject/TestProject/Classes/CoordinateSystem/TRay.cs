using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Модель луча, заданного начальной точкой, уравнением прямой и направлением по переменным X и Y
	/// </summary>
	public class TRay : iFigure
	{
		/// <summary>
		/// Начальная точка луча
		/// </summary>
		private PointF begin;
		/// <summary>
		/// Вектор направления луча
		/// </summary>
		private PointF vector;
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen;

		/// <summary>
		/// Создать луч с началом в заданной точке
		/// </summary>
		/// <param name="begin">Начальная точка</param>
		/// <param name="vector">Вектор направления</param>
		public TRay(PointF begin, PointF vector)
		{
			this.begin = begin;
			this.vector = vector;
		}

		/// <summary>
		/// Создать луч с началом в заданной точке, параллельный заданной прямой
		/// </summary>
		/// <param name="begin">Начальная точка</param>
		/// <param name="line">Направляющая прямая</param>
		public TRay(PointF begin, TLineStraight line)
		{
			this.begin = begin;
			this.vector = new PointF(-line.B, line.A);
		}

		/// <summary>
		/// Получить или задать начальную точку луча
		/// </summary>
		public PointF Begin
		{
			get
			{
				return this.begin;
			}
			set
			{
				this.begin = value;
			}
		}

		/// <summary>
		/// Получить или задать вектор направления луча
		/// </summary>
		public PointF Vector
		{
			get
			{
				return this.vector;
			}
			set
			{
				this.vector = value;
			}
		}


		/// <summary>
		/// Проверить, лежит ли заданная точка в одном "сегменте" с лучом,
		/// если через начало луча провести линии, параллельные осям координат.
		/// </summary>
		/// <param name="pt">Целевая точка</param>
		public bool IsPointInSameSector(PointF pt)
		{
			return ((pt.X <= Begin.X && Vector.X <= 0)
				|| (pt.X >= Begin.X && Vector.X >= 0)
				//|| (TConstants.IsEqualFloat(pt.X, Begin.X) && TConstants.IsEqualFloat(Vector.X, 0))
				)
				&&
				((pt.Y <= Begin.Y && Vector.Y <= 0)
				|| (pt.Y >= Begin.Y && Vector.Y >= 0)
				//|| (TConstants.IsEqualFloat(pt.Y, Begin.Y) && TConstants.IsEqualFloat(Vector.Y, 0))
				);
		}


		#region iFigure Members

		/// <summary>
		/// Минимальные значений переменных в данной фигуре.
		/// Для ускорения работы рекомендуется буферизовать это значение на время
		/// активного использования.
		/// </summary>
		public PointF Min
		{
			get
			{
				TLineStraight line = new TLineStraight(this);
				PointF buf = line.Min;
				buf.X = buf.X < this.Begin.X ? buf.X : this.Begin.X;
				buf.Y = buf.Y < this.Begin.Y ? buf.Y : this.Begin.Y;
				return buf;
			}
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре.
		/// Для ускорения работы рекомендуется буферизовать это значение на время
		/// активного использования.
		/// </summary>
		public PointF Max
		{
			get 
			{
				TLineStraight line = new TLineStraight(this);
				PointF buf = line.Max;
				buf.X = buf.X > this.Begin.X ? buf.X : this.Begin.X;
				buf.Y = buf.Y > this.Begin.Y ? buf.Y : this.Begin.Y;
				return buf;
			}
		}

		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		public Pen Pen
		{
			get
			{
				return this.pen;
			}
			set
			{
				this.pen = value;
			}
		}

		/// <summary>
		/// Отрисовать фигуру на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="cs">Система координат, в которой находится фигура</param>
		public void Draw(Graphics g, TCoordinateSystemDecart cs)
		{
			TSegment border;
			Point begin = new Point();
			Point end = new Point();
			bool flbegin = false;	//Станет true, как только мы найдём начало отрезка (а значит, прямая попала хотя-бы одной точкой в поле отображения графика)
			bool flend = false;		//Станет true, как только мы найдём конец отрезка. Введён, чтобы не выполнять лишние проверки на пересечения, ибо долго.
			PointF min = cs.Min;
			PointF max = cs.Max;
			PointF cp;

			//Находим точку пересечения с левой границей системы координат:
			border = new TSegment(min.X, min.Y, min.X, max.Y);
			if (TTests.IsCrossing(this, border, out cp))
			{
				begin = cs.GetPointOnGraphicsObject(cp);
				flbegin = true;
			}

			//Находим точку пересечения с правой границей системы координат:
			border = new TSegment(max.X, min.Y, max.X, max.Y);
			if (TTests.IsCrossing(this, border, out cp))
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(cp);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(cp);
					flend = true;
				}
			}

			//Находим точку пересечения с верхней границей системы координат:
			border = new TSegment(max.X, max.Y, min.X, max.Y);
			if (!flend && TTests.IsCrossing(this, border, out cp))
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(cp);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(cp);
					flend = true;
				}
			}

			//Находим точку пересечения с нижней границей системы координат:
			border = new TSegment(max.X, min.Y, min.X, min.Y);
			if (!flend && TTests.IsCrossing(this, border, out cp))
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(cp);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(cp);
					flend = true;
				}
			}

			//Если начало луча было внутри видимой области системы координат:
			if (!flend && flbegin)
			{
				end = cs.GetPointOnGraphicsObject(this.Begin);
				flend = true;
			}

			if (flbegin && flend)
			{
				g.DrawLine(this.Pen, begin, end);
			}
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка данному лучу.
		/// </summary>
		/// <param name="pt">Целевая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			bool fl;
			float c, buf;
			//Проверяем, что точка лежит на одной прямой с лучём:
			c = this.begin.X * this.vector.Y - this.begin.Y * this.vector.X;
			buf = pt.X * this.vector.Y - pt.Y * this.vector.X;
			fl = TConstants.IsEqualFloat(c, buf);

			//Проверяем, что точка лежит в одном "секторе" с лучом:
			return fl && this.IsPointInSameSector(pt);
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			PointF nearest = this.GetNearestPoint(pt);
			return TTests.GetDistance(pt, nearest);
		}

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		public PointF GetNearestPoint(PointF pt)
		{
			TLineStraight line = new TLineStraight(this);
			PointF res = line.GetNearestPoint(pt);
			if (!this.IsPointInSameSector(res))
				res = new PointF(this.begin.X, this.begin.Y);
			return res;
		}

		#endregion

		/// <summary>
		/// Представить фигуру в виде текстового описания
		/// </summary>
		public override string ToString()
		{
			return "{Begin = " + this.begin + "; Vector = " + this.vector + "}";
		}
	}
}
