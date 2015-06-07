using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Этот класс содержит алгоритмы покрытия одних фигур другими
	/// </summary>
	public static class TCoveringAlgorithm
	{
		/// <summary>
		/// Покрыть заданный полигон кругами, с центрами в вершинах равносторонних треугольников.
		/// </summary>
		/// <param name="sample">Образец круга</param>
		/// <param name="target">Целевой полигон</param>
		/// <param name="coef">Коэфициент наложения. Отношение радиуса окружности к стороне треугольника.</param>
		/// <param name="forbidden">Зоны, не нуждающиеся в покрытии</param>
		public static List<iFigure> Triangles(TPolygon target, TCircle sample, float coef, params TPolygon[] forbidden)
		{
			float beginX, beginY, endX, endY, x, y, stepX, stepY;
			PointF min, max, bufpt = new PointF();
			TCircle buf;
			List<iFigure> res = new List<iFigure>();
			bool fl;
			int fix;	//Служит для чередования рядов со смещением относительно первого вправо и без оного

			stepX = sample.Radius / coef;	//sqrt(3) == 1.7320508075688772935274463415059
			stepY = 0.866F * stepX;	//sqrt(3) / 2 == 0.86602540378443864676372317075294
			min = target.Min;
			max = target.Max;
			beginX = min.X + stepX / 2;
			beginY = min.Y + sample.Radius / 2;
			endX = max.X;
			endY = max.Y;
			

			fix = 0;
			for (y = beginY; y <= endY; y += stepY)
			{
				for (x = beginX + fix * stepX / 2; x <= endX; x += stepX)
				{
					bufpt.X = x;
					bufpt.Y = y;
					fl = target.PointIsInside(bufpt);
					if (fl)
					{
						fl = true;	//Предположим, что точка не принадлежит ни одному из "запретных" участков. Проверим это:
						if (forbidden != null && forbidden.Length > 0)
							foreach (TPolygon p in forbidden)
							{
								if (p!=null && p.PointIsInside(bufpt))
								{	//Опровергаем предположение и выходим из цикла
									fl = false;
									break;
								}
							}

						if (fl)
						{	//Теперь можно создать вокруг точки окружность
							buf = sample.Clone() as TCircle;
							buf.Center = new PointF(x, y);
							res.Add(buf);
						}
					}
				}
				fix = 1 - fix;
			}

			return res.Count > 0 ? res : null;
		}
	}
}
