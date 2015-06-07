using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoordinateSystem
{
	/// <summary>
	/// Содержит некоторые константы. Хотя... Фактически их можно поменять во время выполнения программы.
	/// Так что это - настройки.
	/// </summary>
	public class TConstants
	{
		/// <summary>
		/// Если координаты отличаются не более, чем на эту величину, считать их равными.
		/// </summary>
		public static double epsilon = 0.00001;

		/// <summary>
		/// Сравнение чисел с плавающей точкой с учётом возможной погрешности вычислений
		/// </summary>
		/// <param name="number1">Первое из чисел</param>
		/// <param name="number2">Второе из чисел</param>
		public static bool IsEqualFloat(float number1, float number2)
		{
			//return number1.Equals(number2);
			return number1 > number2 - epsilon && number1 < number2 + epsilon;
		}

		/// <summary>
		/// Сравнение точек с координатами типа float с учётом возможной погрешности вычислений
		/// </summary>
		/// <param name="pt1">Первая точка</param>
		/// <param name="pt2">Вторая точка</param>
		public static bool IsEqualPointF(PointF pt1, PointF pt2)
		{
			return pt1.X > pt2.X - epsilon && pt1.Y > pt2.Y - epsilon && pt1.X < pt2.X + epsilon && pt1.Y < pt2.Y + epsilon;
		}

		/// <summary>
		/// Проверяет, можно ли считать указанные точки одной точкой, с указанным допуском.
		/// Применяется для завершения полигона кликом.
		/// </summary>
		/// <param name="pt1">Точка</param>
		/// <param name="pt2">Точка</param>
		/// <param name="epsilon">Допуск в единицах системы координат</param>
		public static bool IsEqualPointF(PointF pt1, PointF pt2, float epsilon)
		{
			return pt1.X > pt2.X - epsilon && pt1.Y > pt2.Y - epsilon && pt1.X < pt2.X + epsilon && pt1.Y < pt2.Y + epsilon;
		}
	}
}
