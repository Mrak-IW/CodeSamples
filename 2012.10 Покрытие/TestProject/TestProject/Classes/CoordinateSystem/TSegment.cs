using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Отрезок, заданный в виде начальной и конечной точек
	/// </summary>
	public class TSegment : iFigure
	{
		/// <summary>
		/// Начало отрезка
		/// </summary>
		private PointF begin;
		/// <summary>
		/// Конец отрезка
		/// </summary>
		private PointF end;
		/// <summary>
		/// Максимальные значения переменных в данной фигуре
		/// </summary>
		private PointF max = new PointF();
		/// <summary>
		/// Минимальные значения переменных в данной фигуре
		/// </summary>
		private PointF min = new PointF();
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		private Pen pen = Pens.Black;

		/// <summary>
		/// Создать отрезок, соединяющий две точки. Концы отрезка присваиваются как ссылки,
		/// а не создаются заново.
		/// </summary>
		/// <param name="begin">Начало отрезка</param>
		/// <param name="end">Конец отрезка</param>
		public TSegment(PointF begin, PointF end)
		{
			this.begin = begin;
			this.PointEnd = end;
		}

		/// <summary>
		/// Создать отрезок, соединяющий две точки.
		/// </summary>
		/// <param name="beginX">Координата X начала отрезка</param>
		/// <param name="beginY">Координата Y начала отрезка</param>
		/// <param name="endX">Координата X конца отрезка</param>
		/// <param name="endY">Координата Y конца отрезка</param>
		public TSegment(float beginX, float beginY, float endX, float endY)
		{
			this.begin = new PointF(beginX, beginY);
			this.PointEnd = new PointF(endX, endY);	//Используем свойство, поскольку в нём также пересчитаются минимальные и максимальные координаты.
		}

		/// <summary>
		/// Получить длину отрезка
		/// </summary>
		public float Length
		{
			get
			{
				float buf = (float)Math.Sqrt((end.X - begin.X) * (end.X - begin.X) + (end.Y - begin.Y) * (end.Y - begin.Y));
				return buf;
			}
		}

		/// <summary>
		/// Начало отрезка
		/// </summary>
		public PointF PointBegin
		{
			get
			{
				return this.begin;
			}
			set
			{
				this.begin = value;
				//Пересчёт минимальных и максимальных значений переменных
				min.X = end.X < begin.X ? end.X : begin.X;
				min.Y = end.Y < begin.Y ? end.Y : begin.Y;
				max.X = end.X > begin.X ? end.X : begin.X;
				max.Y = end.Y > begin.Y ? end.Y : begin.Y;
			}
		}

		/// <summary>
		/// Конец отрезка
		/// </summary>
		public PointF PointEnd
		{
			get
			{
				return this.end;
			}
			set
			{
				this.end = value;
				//Пересчёт минимальных и максимальных значений переменных
				min.X = end.X < begin.X ? end.X : begin.X;
				min.Y = end.Y < begin.Y ? end.Y : begin.Y;
				max.X = end.X > begin.X ? end.X : begin.X;
				max.Y = end.Y > begin.Y ? end.Y : begin.Y;
			}
		}

#region iFigure Members

		/// <summary>
		/// Минимальные значения переменных в данной фигуре
		/// </summary>
		public PointF Min
		{
			get
			{
				return this.min;
			}
		}

		/// <summary>
		/// Максимальные значения переменных в данной фигуре
		/// </summary>
		public PointF Max
		{
			get
			{
				return this.max;
			}
		}

		/// <summary>
		/// Отрисовать фигуру на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="coordinates">Система координат, в которой находится фигура</param>
		public void Draw(Graphics g, TCoordinateSystemDecart coordinates)
		{
			Point pt1, pt2;
			pt1 = coordinates.GetPointOnGraphicsObject(this.PointBegin);
			pt2 = coordinates.GetPointOnGraphicsObject(this.PointEnd);
			g.DrawLine(this.pen, pt1, pt2);
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="pt">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF pt)
		{
			//Если точка находится на векторе, она, вместе с началом данного вектора, образует новый вектор,
			//который можно получить из заданного умножением на число от 0 до 1. Это и проверим:
			float cx, cy;
			PointF ptVector = new PointF(pt.X - begin.X, pt.Y - begin.Y);
			PointF segVector = new PointF(end.X - begin.X, end.Y - begin.Y);
			cx = ptVector.X / segVector.X;
			cy = ptVector.Y / segVector.Y;
			//Теперь обработаем горизонтальные и вертикальные отрезки
			if (ptVector.X == 0 && ptVector.X == segVector.X)
				cx = cy;
			if (ptVector.Y == 0 && ptVector.Y == segVector.Y)
				cy = cx;
			//Проверяем условие и возвращаем результат
			return TConstants.IsEqualFloat(cx, cy) && cx >= 0 && cx <= 1;
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
		/// Получить расстояние от заданной точки до границы данной фигуры
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			TLineStraight straight = new TLineStraight(this);
			TLineStraight perp = straight.GetPerpendicular(pt);
			PointF cross;
			float db, de;
			TTests.IsCrossing(straight, perp, out cross);
			if (this.PointIsOnFigure(cross))
			{
				return TTests.GetDistance(pt, cross);
			}
			else
			{
				db = TTests.GetDistance(pt, this.begin);
				de = TTests.GetDistance(pt, this.end);
				return db > de ? de : db;
			}
		}

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		public PointF GetNearestPoint(PointF pt)
		{
			PointF cross;
			float db, de;
			TLineStraight line = new TLineStraight(this);
			TLineStraight perp = line.GetPerpendicular(pt);
			if (TTests.IsCrossing(this, perp, out cross))
			{
				return cross;
			}
			else
			{
				db = TTests.GetDistance(pt, this.begin);
				de = TTests.GetDistance(pt, this.end);
				return db > de ? this.end : this.begin;
			}
		}

#endregion iFigure Members


		/// <summary>
		/// Представить фигуру в виде текстового описания
		/// </summary>
		public override string ToString()
		{
			return "{X = " + begin.X + "; Y = " + begin.Y + "} -> {X = " + end.X + "; Y = " + end.Y + "}";
		}

	}
}
