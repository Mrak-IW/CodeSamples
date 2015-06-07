using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Окружность, заданная координатами центра и радиусом.
	/// </summary>
	public class TCircle : iClosedFigure, ICloneable
	{
		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		protected Brush brush;
		/// <summary>
		/// Перо для отрисовки линии
		/// </summary>
		protected Pen pen = Pens.Black;
		/// <summary>
		/// Центр окружности
		/// </summary>
		protected PointF center;
		/// <summary>
		/// Радиус окружности
		/// </summary>
		protected float radius;

		/// <summary>
		/// Создать окружность заданного радиуса с центром в заданной точке
		/// </summary>
		/// <param name="center">Центр окружности</param>
		/// <param name="radius">Радиус окружности</param>
		public TCircle(PointF center, float radius)
		{
			this.Center = new PointF(center.X, center.Y);
			this.Radius = radius;
		}

#region iClosedFigure Members

		/// <summary>
		/// Кисть для заливки фигуры.
		/// </summary>
		public Brush Brush
		{
			get
			{
				return this.brush;
			}
			set
			{
				this.brush = value;
			}
		}

		/// <summary>
		/// Определяет, находится ли точка внутри данной фигуры
		/// </summary>
		/// <param name="point">Точка в системе координат</param>
		public bool PointIsInside(PointF point)
		{
			float sum = (this.center.X - point.X) * (this.center.X - point.X) + (this.center.Y - point.Y) * (this.center.Y - point.Y);
			return sum <= this.radius * this.radius;
		}

#endregion iClosedFigure Members

#region iFigure Members

		/// <summary>
		/// Минимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Min
		{
			get
			{
				return new PointF(this.center.X - this.radius, this.center.Y - this.radius);
			}
		}

		/// <summary>
		/// Максимальные значений переменных в данной фигуре
		/// </summary>
		public PointF Max
		{
			get
			{
				return new PointF(this.center.X = this.radius, this.center.Y + this.radius);
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
		public virtual void Draw(Graphics g, TCoordinateSystemDecart cs)
		{
			Point pos = cs.GetPointOnGraphicsObject(this.center);
			PointF one = cs.One;	//Цена одной единицы на графике в пикселях
			if (this.brush != null)
			{
				g.FillEllipse(this.brush, pos.X - this.Radius * one.X, pos.Y - this.Radius * one.Y, this.Radius * 2 * one.X, this.Radius * 2 * one.Y);
			}

			if (this.pen != null)
			{
				g.DrawEllipse(this.pen, pos.X - this.Radius * one.X, pos.Y - this.Radius * one.Y, this.Radius * 2 * one.X, this.Radius * 2 * one.Y);
			}
		}

		/// <summary>
		/// Проверяем, принадлежит ли точка линиям данной фигуры
		/// </summary>
		/// <param name="point">Проверяемая точка</param>
		public bool PointIsOnFigure(PointF point)
		{
			float sum = (this.center.X - point.X) * (this.center.X - point.X) + (this.center.Y - point.Y) * (this.center.Y - point.Y);
			return TConstants.IsEqualFloat(sum, this.radius * this.radius);
		}

		/// <summary>
		/// Получить расстояние от заданной точки до границы данной фигуры.
		/// Если значение отрицательно, значит точка находится внутри.
		/// </summary>
		/// <param name="pt">Целевая точка, заданная в системе координат</param>
		public float GetDistance(PointF pt)
		{
			return TTests.GetDistance(pt, this.center) - this.radius;
		}

		/// <summary>
		/// Получить точку на фигуре, ближайшую к заданной.
		/// </summary>
		/// <param name="pt">Заданная точка</param>
		public PointF GetNearestPoint(PointF pt)
		{
			PointF[] pts;
			PointF res;
			PointF vector = new PointF(pt.X - this.center.X, pt.Y - this.center.Y);
			TRay ray = new TRay(this.center, vector);
			if (TTests.IsCrossing(this, ray, out pts) && pts.Length == 1)
			{ 
				res = pts[0];
			}
			else
			{
				res = new PointF(float.NaN, float.NaN);
				throw new Exception("Произошла ошибка в функции TTests.IsCrossing(TCircle, TRay, out PointF[]). Ожидалась одна точка пересечения.\r\nTCircle: " + this + "\r\nTRay: " + ray);
			}
			return res;
		}

#endregion iFigure Members

		/// <summary>
		/// Центр фигуры
		/// </summary>
		public PointF Center
		{
			get
			{
				return this.center;
			}
			set
			{
				this.center = value;
			}
		}

		/// <summary>
		/// Радиус окружности
		/// </summary>
		public float Radius
		{
			get
			{
				return this.radius;
			}
			set
			{
				this.radius = value;
			}
		}

		/// <summary>
		/// Представить фигуру в виде текстового описания
		/// </summary>
		public override string ToString()
		{
			return "{R = " + this.radius + "; C = " + this.center + "}";
		}


		#region ICloneable Members

		/// <summary>
		/// Получить точную копию объекта.
		/// </summary>
		public virtual object Clone()
		{
			TCircle res = new TCircle(this.center, this.radius);
			res.pen = this.pen;
			res.brush = this.brush;

			return res;
		}

		#endregion
	}
}
