using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Модель прямой линии, заданной формулой a*x + b*y = c.
	/// </summary>
	public class TLineStraight : iFunction
	{
		/// <summary>
		/// Множитель для X в формуле прямой
		/// </summary>
		private float a;
		/// <summary>
		/// Множитель для Y в формуле прямой
		/// </summary>
		private float b;
		/// <summary>
		/// Свободный коэфициент в формуле прямой
		/// </summary>
		private float c;
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen = Pens.Black;
		/// <summary>
		/// Будет-ли происходить упрощение уравнения прямой при создании и изменении коэфициентов.
		/// Упростить возможно только целочисленные коэфициенты, но алгоритм отработает с любыми.
		/// </summary>
		public static bool simplify = true;

		/// <summary>
		/// Провести прямую через отрезок
		/// </summary>
		/// <param name="segment">Исходный отрезок</param>
		public TLineStraight(TSegment segment)
			: this(segment.PointBegin.X, segment.PointBegin.Y, segment.PointEnd.X, segment.PointEnd.Y)
		{ }

		/// <summary>
		/// Провести прямую через 2 точки
		/// </summary>
		/// <param name="pt1">Первая точка</param>
		/// <param name="pt2">Вторая точка</param>
		public TLineStraight(PointF pt1, PointF pt2)
			: this(pt1.X, pt1.Y, pt2.X, pt2.Y)
		{ }

		/// <summary>
		/// Провести прямую через луч
		/// </summary>
		/// <param name="ray">Целево луч</param>
		public TLineStraight(TRay ray)
			: this(ray.Vector.Y, -ray.Vector.X, 0)
		{
			this.c = this.a * ray.Begin.X + this.b * ray.Begin.Y;
			if (simplify)
				Simplify();
		}

		/// <summary>
		/// Провести прямую через 2 точки
		/// </summary>
		/// <param name="x1">Координата X первой точки</param>
		/// <param name="y1">Координата Y первой точки</param>
		/// <param name="x2">Координата X второй точки</param>
		/// <param name="y2">Координата Y второй точки</param>
		public TLineStraight(float x1, float y1, float x2, float y2)
		{
			this.b = x1 - x2;
			this.a = y2 - y1;
			this.c = this.A * x1 + this.B * y1;
			if (simplify)
				Simplify();
		}

		/// <summary>
		/// Создать прямую с заданными коэфициентами
		/// </summary>
		/// <param name="a">Коэфициент при X</param>
		/// <param name="b">Коэфициент при Y</param>
		/// <param name="c">Свободный коэфициент</param>
		public TLineStraight(float a, float b, float c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			if (simplify)
				Simplify();
		}

		/// <summary>
		/// Множитель для X в формуле прямой
		/// </summary>
		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		/// <summary>
		/// Множитель для Y в формуле прямой
		/// </summary>
		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}


		/// <summary>
		/// Свободный коэфициент в формуле прямой
		/// </summary>
		public float C
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

#region iFigure Members

		/// <summary>
		/// Минимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Min
		{
			get
			{
				//Находим точку пересечения прямой с осью ординат
				PointF x0 = new PointF(0, c / b); ;

				//Находим точку пересечения с осью абсцисс
				PointF y0 = new PointF(c / a, 0);

				PointF min = new PointF();

				//Вычисляем искомые значения
				if (x0.X < y0.X) min.X = x0.X;
				else min.X = y0.X;

				if (x0.Y < y0.Y) min.Y = x0.Y;
				else min.Y = y0.Y;

				return Max;
			}
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Max
		{
			get
			{
				//Находим точку пересечения прямой с осью ординат
				PointF x0 = new PointF(0, this.GetY(0));

				//Находим точку пересечения с осью абсцисс
				PointF y0 = new PointF(this.GetX(0), 0);

				PointF max = new PointF();

				//Вычисляем искомые значения
				if (x0.X > y0.X) max.X = x0.X;
				else max.X = y0.X;

				if (x0.Y > y0.Y) max.Y = x0.Y;
				else max.Y = y0.Y;

				return max;
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
			Point begin = new Point(), end = new Point();
			PointF max = cs.Max, min = cs.Min, bufpt;
			bool flbegin = false;	//Станет true, как только мы найдём начало отрезка (а значит, прямая попала хотя-бы одной точкой в поле отображения графика)
			bool flend = false;		//Станет true, как только мы найдём конец отрезка. Введён, чтобы не выполнять лишние проверки на пересечения, ибо долго.

			//Проверяем, не пересекает-ли прямая левую границу поля графика
			TLineStraight border = new TLineStraight(1, 0, min.X);
			if (TTests.IsCrossing(this, border, out bufpt) && bufpt.Y <= cs.Max.Y && bufpt.Y >= cs.Min.Y)
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(bufpt);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(bufpt);
					flend = true;
				}
			}

			//Проверяем, не пересекает-ли прямая правую границу поля графика
			border = new TLineStraight(1, 0, max.X);
			if (TTests.IsCrossing(this, border, out bufpt) && bufpt.Y <= cs.Max.Y && bufpt.Y >= cs.Min.Y)
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(bufpt);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(bufpt);
					flend = true;
				}
			}

			//Проверяем, не пересекает-ли прямая верхнюю границу поля графика
			border = new TLineStraight(0, 1, max.Y);
			if (!flend && TTests.IsCrossing(this, border, out bufpt) && bufpt.X <= cs.Max.X && bufpt.X >= cs.Min.X)
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(bufpt);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(bufpt);
					flend = true;
				}
			}

			//Проверяем, не пересекает-ли прямая нижнюю границу поля графика
			border = new TLineStraight(0, 1, min.Y);
			if (!flend && TTests.IsCrossing(this, border, out bufpt) && bufpt.X <= cs.Max.X && bufpt.X >= cs.Min.X)
			{
				if (!flbegin)
				{
					begin = cs.GetPointOnGraphicsObject(bufpt);
					flbegin = true;
				}
				else
				{
					end = cs.GetPointOnGraphicsObject(bufpt);
					flend = true;
				}
			}

			//Теперь, собственно, переходим к рисованию
			if (flbegin && flend)
			{
				g.DrawLine(this.pen, begin, end);
			}
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			//return (this.GetY(pt.X) >= pt.Y - TConstants.epsilon && this.GetY(pt.X) <= pt.Y + TConstants.epsilon);
			return TConstants.IsEqualFloat(this.GetY(pt.X), pt.Y);
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			//Расчёт ведётся по следующей формуле: d = |(A*pt.x + B*pt.y - C)/sqrt(A*A + B*B)|
			float res = (float)((this.A * pt.X + this.B * pt.Y - this.C) / Math.Sqrt(this.A * this.A + this.B * this.B));
			return res > 0 ? res : -res;
		}

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		public PointF GetNearestPoint(PointF pt)
		{
			TLineStraight perp = this.GetPerpendicular(pt);
			PointF cross;
			TTests.IsCrossing(this, perp, out cross);
			return cross;
		}

#endregion iFigure Members

#region iFunction Members

		/// <summary>
		/// Получить значение Y при заданном значении X
		/// </summary>
		/// <param name="X">Значение X</param>
		public virtual float GetY(float X)
		{
			return (c - a * X) / b;
		}

#endregion iFunction Members

		/// <summary>
		/// Получить значение X при заданном значении Y
		/// </summary>
		/// <param name="Y">Значение Y</param>
		public virtual float GetX(float Y)
		{
			return (c - b * Y) / a;
		}

		/// <summary>
		/// Провести перпендикуляр к этой прямой через заданную точку.
		/// </summary>
		/// <param name="point">Заданная точка</param>
		public TLineStraight GetPerpendicular(PointF point)
		{
			TLineStraight p = new TLineStraight(this.B, -this.A, 0);
			p.C = p.A * point.X + p.B * point.Y;
			return p;
		}

		/// <summary>
		/// Представить фигуру в виде текстового описания
		/// </summary>
		public override string ToString()
		{
			string bminus = this.A == 0 ? "-" : "- ";
			string bplus = this.A == 0 ? "" : "+ ";
			string x = this.A != 0 ? this.A + "*x " : "";
			string y = (this.B != 0 ? (this.B > 0 ? bplus + this.B : bminus + (-this.B)) + "*y " : "");
			return "{" + x + y + "= " + this.C + "}";
		}

		/// <summary>
		/// Упростить уравнение, приведя коэфициенты к виду, когда у них нет общих делителей,
		/// кроме единицы, а первый ненулевой >= 0
		/// </summary>
		public void Simplify()
		{
			float ab, bc, coef;
			ab = TTests.NOD(this.A, this.B);
			bc = TTests.NOD(this.B, this.C);
			if (TConstants.IsEqualFloat(this.B, 0))
				bc = 1;
			if (!TConstants.IsEqualFloat(this.A, 0))
			{
				coef = this.A < 0 ? -TTests.NOD(ab, bc) : TTests.NOD(ab, bc);
			}
			else
			{
				ab = 1;
				coef = this.B < 0 ? -TTests.NOD(ab, bc) : TTests.NOD(ab, bc);
			}

			this.a /= coef;
			this.b /= coef;
			this.c /= coef;
		}
	}
}
