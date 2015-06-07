using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Класс, содержащий методы разнообразных проверок.
	/// Пересечения фигур, проверки расстояний, другие математические операции.
	/// </summary>
	public static class TTests
	{
		/// <summary>
		/// Проверка, пересекает ли одна прямая другую
		/// </summary>
		/// <param name="line1">Целевая прямая</param>
		/// <param name="line2">Целевая прямая</param>
		/// <param name="cp">Сюда будет возвращена точка пересечения.
		/// Если там будет бесконечность - прямые параллельны (не подтверждено).
		/// Если {NaN; NaN} - прямые совпадают (не подтверждено).</param>
		public static bool IsCrossing(TLineStraight line1, TLineStraight line2, out PointF cp)
		{
			cp = new PointF();
			cp.Y = (line1.A * line2.C - line1.C * line2.A) / (line2.B * line1.A - line2.A * line1.B);
			if (line1.A != 0)
				cp.X = line1.GetX(cp.Y);
			else
				cp.X = line2.GetX(cp.Y);
			//Возвращаем true, если в процессе вычислений не возникло бесконечности или неорпеделённости типа 0/0.
			return (!float.IsInfinity(cp.X) && !float.IsInfinity(cp.Y) && !float.IsNaN(cp.X) && !float.IsNaN(cp.Y));
		}

		/// <summary>
		/// Пересекаются ли отрезок и прямая
		/// </summary>
		/// <param name="segment">Целевой отрезок</param>
		/// <param name="line">Целевая прямая</param>
		/// <param name="cp">Сюда будет возвращена точка пересечения.
		/// Если отрезок не пересекает прямую, тут будет точка пересечения прямой с продолжением отрезка.
		/// Если там будет бесконечность - отрезок параллелен прямой (не подтверждено).
		/// Если {NaN; NaN} - отрезок лежит на прямой (не подтверждено).
		///</param>
		public static bool IsCrossing(TSegment segment, TLineStraight line, out PointF cp)
		{
			TLineStraight buf = new TLineStraight(segment);
			return (TTests.IsCrossing(buf, line, out cp) && cp.X >= segment.Min.X && cp.X <= segment.Max.X);
		}

		/// <summary>
		/// Пересекает ли этот отрезок другой отрезок.
		/// </summary>
		/// <param name="segment1">Целевой отрезок</param>
		/// <param name="segment2">Целевой отрезок</param>
		/// <param name="cp">Сюда будет возвращена точка пересечения.
		/// Если отрезки не пересекаются, тут будет точка пересечения прямой с продолжением отрезка.
		/// Если там будет бесконечность - отрезки параллельны (не подтверждено).
		/// Если {NaN; NaN} - отрезки совпадают более, чем в одной точке (не подтверждено).
		///</param>
		public static bool IsCrossing(TSegment segment1, TSegment segment2, out PointF cp)
		{
			TLineStraight buf = new TLineStraight(segment2);

			return (IsCrossing(segment1, buf, out cp)
				&& cp.X >= segment1.Min.X && cp.X <= segment1.Max.X
				&& cp.X >= segment2.Min.X && cp.X <= segment2.Max.X);
		}

		/// <summary>
		/// Пересекается ли луч с отрезком
		/// </summary>
		/// <param name="ray">Проверяемый луч</param>
		/// <param name="segment">Проверяемый отрезок</param>
		/// <param name="cp">
		/// Сюда будет возвращена точка пересечения.
		/// Если луч не пересекает прямую, тут будет точка пересечения прямой с продолжением луча.
		/// Если там будет бесконечность - луч параллелен прямой (не подтверждено).
		/// Если {NaN; NaN} - луч лежит на прямой (не подтверждено).
		/// </param>
		public static bool IsCrossing(TRay ray, TSegment segment, out PointF cp)
		{
			TLineStraight rayLine = new TLineStraight(ray);
			bool fl = IsCrossing(segment, rayLine, out cp);
			if (fl) //А зачем считать дальше, если нет пересечения?
			{
				//Проверяем, что точка лежит в одном "секторе" с лучём:
				//Функцией проверки принадлежит ли точка данному лучу не пользуюсь из жадности.
				//Там проверяется, лежит-ли точка на одной прямой с лучём, а здесь это уже известно.
				fl &= (cp.X <= ray.Begin.X && ray.Vector.X <= 0)
					|| (cp.X >= ray.Begin.X && ray.Vector.X >= 0);
				//|| (TConstants.IsEqualFloat(cp.X, Begin.X) && TConstants.IsEqualFloat(Vector.X, 0));
				fl &= (cp.Y <= ray.Begin.Y && ray.Vector.Y <= 0)
					|| (cp.Y >= ray.Begin.Y && ray.Vector.Y >= 0);
				//|| (TConstants.IsEqualFloat(cp.Y, Begin.Y) && TConstants.IsEqualFloat(Vector.Y, 0));
				//fl &= ray.PointIsOnFigure(cp);
			}
			return fl;
		}

		/// <summary>
		/// Пересекается ли луч с прямой
		/// </summary>
		/// <param name="line">Проверяемая прямая</param>
		/// <param name="ray">Проверяемый луч</param>
		/// <param name="cp">
		/// Сюда будет возвращена точка пересечения.
		/// Если луч не пересекает прямую, тут будет точка пересечения прямой с продолжением луча.
		/// Если там будет бесконечность - луч параллелен прямой (не подтверждено).
		/// Если {NaN; NaN} - луч лежит на прямой (не подтверждено).
		/// </param>
		public static bool IsCrossing(TRay ray, TLineStraight line, out PointF cp)
		{
			TLineStraight rayLine = new TLineStraight(ray);
			bool fl = TTests.IsCrossing(line, rayLine, out cp);
			if (fl) //А зачем считать дальше, если нет пересечения?
			{
				//Проверяем, что точка лежит в одном "секторе" с лучём:
				//Функцией проверки принадлежит ли точка данному лучу не пользуюсь из жадности.
				//Там проверяется, лежит-ли точка на одной прямой с лучём, а здесь это уже известно.
				fl &= (cp.X <= ray.Begin.X && ray.Vector.X <= 0)
					|| (cp.X >= ray.Begin.X && ray.Vector.X >= 0);
				//|| (TConstants.IsEqualFloat(cp.X, Begin.X) && TConstants.IsEqualFloat(Vector.X, 0));
				fl &= (cp.Y <= ray.Begin.Y && ray.Vector.Y <= 0)
					|| (cp.Y >= ray.Begin.Y && ray.Vector.Y >= 0);
				//|| (TConstants.IsEqualFloat(cp.Y, Begin.Y) && TConstants.IsEqualFloat(Vector.Y, 0));
				//fl &= ray.PointIsOnFigure(cp);
			}
			return fl;
		}
		
		/// <summary>
		/// Пересекает-ли окружность заданную прямую
		/// </summary>
		/// <param name="circle">Целевая окружность</param>
		/// <param name="line">Целевая прямая</param>
		/// <param name="cp">Сюда будет возвращена точка или точки пересечения.</param>
		public static bool IsCrossing(TCircle circle, TLineStraight line, out PointF[] cp)
		{
			//Проводим перпендикуляр из центра окружности к прямой
			TLineStraight perp = line.GetPerpendicular(circle.Center);

			//Находим проекцию центра окружности на прямую
			PointF p;
			TTests.IsCrossing(line, perp, out p);

			//Находим расстояние от центра окружности до прямой
			float d = (circle.Center.Y - p.Y) * (circle.Center.Y - p.Y) + (circle.Center.X - p.X) * (circle.Center.X - p.X);
			d = (float)Math.Sqrt(d);

			//Если расстояние до прямой больше радиуса окружности
			if (d > circle.Radius)
			{
				cp = null;
				return false;
			}
			//Если расстояние до прямой совпадает с радиусом окружности
			else if (d < circle.Radius + TConstants.epsilon && d > circle.Radius - TConstants.epsilon)
			{
				cp = new PointF[1];
				cp[0] = p;
				return true;
			}

			//Находим расстояние от проекции центра до точек пересечения прямой и окружности
			d = (float)Math.Sqrt(circle.Radius * circle.Radius - d * d);

			//Находим множитель для получения точек пересечения из A, B и проекции центра
			//окружности на прямую
			float mult = (float)Math.Sqrt((line.A * line.A + line.B * line.B) / (d * d));

			//Находим точки пересечения прямой и окружности
			cp = new PointF[2];
			cp[0] = new PointF(p.X + line.B / mult, p.Y - line.A / mult);
			cp[1] = new PointF(p.X - line.B / mult, p.Y + line.A / mult);
			return true;
		}

		/// <summary>
		/// Пересекает-ли окружность заданный луч
		/// </summary>
		/// <param name="circle">Целевая окружность</param>
		/// <param name="ray">Целевой луч</param>
		/// <param name="cp">Сюда будет возвращена точка или точки пересечения.</param>
		public static bool IsCrossing(TCircle circle, TRay ray, out PointF[] cp)
		{
			TLineStraight line = new TLineStraight(ray);
			PointF[] pts;
			if (TTests.IsCrossing(circle, line, out pts))
			{
				switch (pts.Length)
				{
					case 1:
						cp = pts;
						break;
					case 2:
						int fl = 0;	//1 - точка пересечения pts[0]; 2 - точка пересечения - pts[1]; 3 - обе точки подходят.
						if (ray.IsPointInSameSector(pts[0]))
							fl = 1;
						if (ray.IsPointInSameSector(pts[1]))
							fl += 2;
						if (fl < 3)
						{	//Если точка пересечения одна
							cp = new PointF[1];
							cp[0] = pts[fl - 1];
						}
						else	//Если точек пересечения две
							cp = pts;
						break;
					default:
						throw new Exception("o_O Вы не должны были этого увидеть. Теперь мне придётся вас убить. O_o");
						break;
				}
				return true;
			}
			//Если мы сюда добрались, значит пересечения не произошло
			cp = null;
			return false;
		}

		/// <summary>
		/// Получить все точки пересечения ломаной с лучём
		/// </summary>
		/// <param name="cracked">Проверяемая ломаная</param>
		/// <param name="ray">Проверяемый луч</param>
		public static List<PointF> GetCrosspoints(TLineCracked cracked, TRay ray)
		{
			//Реализуется метод трассировки луча
			List<PointF> crosspoints = new List<PointF>();
			PointF cp;

			//Получаем массив отрезков, из которых состоит полигон:
			TSegment[] segments = cracked.Segments;

			foreach (TSegment e in segments)
			{
				//Пересечение считается только в том случае, если луч проходит не по нижнему концу отрезка.
				if (TTests.IsCrossing(ray, e, out cp) && !TConstants.IsEqualFloat(cp.Y, e.Min.Y))
				{
					crosspoints.Add(cp);
				}
			}

			if (crosspoints.Count == 0)
				return null;
			else
				return crosspoints;
		}

		/// <summary>
		/// Получить все точки пересечения полигона с лучём
		/// </summary>
		/// <param name="ray">Целевой луч</param>
		/// <param name="polygon"></param>
		public static List<PointF> GetCrosspoints(TPolygon polygon, TRay ray)
		{
			//Реализуется метод трассировки луча
			List<PointF> crosspoints = new List<PointF>();
			PointF cp;

			//Получаем массив отрезков, из которых состоит полигон:
			TSegment[] edges = polygon.Segments;

			foreach (TSegment e in edges)
			{
				//Пересечение считается только в том случае, если луч проходит не по нижнему концу отрезка.
				if (TTests.IsCrossing(ray, e, out cp) && !TConstants.IsEqualFloat(cp.Y, e.Min.Y))
				{
					crosspoints.Add(cp);
				}
			}

			if (crosspoints.Count == 0)
				return null;
			else
				return crosspoints;
		}

		/// <summary>
		/// Получить все точки пересечения окружности с отрезком
		/// </summary>
		/// <param name="circle">Целевая окружность</param>
		/// <param name="segment">Целевой отрезок</param>
		public static List<PointF> GetCrosspoints(TCircle circle, TSegment segment)
		{
			PointF[] pts;
			List<PointF> res = new List<PointF>();
			if (TTests.IsCrossing(circle, new TLineStraight(segment), out pts))
			{
				foreach (PointF pt in pts)
					if (segment.PointIsOnFigure(pt))
						res.Add(pt);
			}
			return res.Count > 0 ? res : null;
		}

		/// <summary>
		/// Получить все точки пересечения окружности с полигоном
		/// </summary>
		/// <param name="circle">Целевая окружность</param>
		/// <param name="polygon">Целевой полигон</param>
		public static List<PointF> GetCrosspoints(TCircle circle, TPolygon polygon)
		{
			List<PointF> res = new List<PointF>();
			TSegment [] segments = polygon.Segments;
			foreach (TSegment seg in segments)
			{
				res.AddRange(TTests.GetCrosspoints(circle, seg));
				//TODO:	в данной реализации, если точка пересечения с окружностью приходится на угол
				//		полигона, она учитывается дважды
			}
			return res;
		}

		/// <summary>
		/// Получить расстояние между двумя точками
		/// </summary>
		/// <param name="pt1">Первая точка</param>
		/// <param name="pt2">Вторая точка</param>
		public static float GetDistance(PointF pt1, PointF pt2)
		{
			return (float)Math.Sqrt((pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y));
		}

		/// <summary>
		/// Найти наибольший общий делитель двух чисел
		/// </summary>
		/// <param name="f1">Первое число</param>
		/// <param name="f2">Второе число</param>
		public static float NOD(float f1, float f2)
		{
			if (float.IsNaN(f1) || float.IsNaN(f2)) return float.NaN;
			//Реализован алгоритм Эвклида
			if (f1 < 0) f1 = -f1;
			if (f2 < 0) f2 = -f2;
			if (f1 < 1 || f2 < 1) return 1;
			while (!TConstants.IsEqualFloat(f1, f2) && !TConstants.IsEqualFloat(f1, 0) && !TConstants.IsEqualFloat(f2, 0))
			{
				if (f1 > f2)
					f1 %= f2;
				else
					f2 %= f1;
				if (f1 < 1 && f2 < 1)
					return 1;
			}
			return f1 > f2 ? f1 : f2;
		}

		/// <summary>
		/// Найти наименьшее общее кратное двух чисел
		/// </summary>
		/// <param name="f1">Первое число</param>
		/// <param name="f2">Второе число</param>
		public static float NOK(float f1, float f2)
		{
			if (float.IsNaN(f1) || float.IsNaN(f2)) return float.NaN;
			return f1 * f2 / NOD(f1, f2);
		}
	}
}