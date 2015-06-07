using System;
using System.Collections.Generic;
using System.Text;
//Добавленные мной
using System.Drawing;

namespace Affin
{
	/// <summary>
	/// Класс матрицы
	/// </summary>
	public class TMatrix
	{
		/// <summary>
		/// Собственно массив. По умолчанию - вектор-столбец из 3х элементов
		/// </summary>
		private double[,] arr;
		/// <summary>
		/// А вот так мы можем обращаться к элементам матрицы
		/// </summary>
		/// <param name="row">Номер строки</param>
		/// <param name="column">Номер столбца</param>
		/// <returns>Элемент матрицы</returns>
		public double this[int row, int column]
		{
			get
			{
				return arr[row, column];
			}
			set
			{
				arr[row, column] = value;
			}
		}
		/// <summary>
		/// А это обращение к матрице, как к вектору. Если ширина == 1, то как к столбцу, иначе, обращаемся к первой строке.
		/// </summary>
		/// <param name="i">Индекс элемента вектора</param>
		/// <returns></returns>
		public double this[int i]
		{
			get
			{
				if (Width == 1)
					return arr[i, 0];
				else
					return arr[0, i];
			}
			set
			{
				if (Width == 1)
					arr[i, 0] = value;
				else
					arr[0, i] = value;
			}
		}
		/// <summary>
		/// Количество строк
		/// </summary>
		public int Heigth
		{
			get
			{
				return arr.GetLength(0);
			}
		}
		/// <summary>
		/// Количество столбцов
		/// </summary>
		public int Width
		{
			get
			{
				return arr.GetLength(1);
			}
		}
		/// <summary>
		/// Конструктор по умолчанию. Создает вектор-столбец на 3 элемента
		/// </summary>
		public TMatrix()
		{
			arr = new double[1, 2];
		}
		/// <summary>
		/// Конструктор, создающий вектор-столбец на 3 элемента и заполняющий его значениями из точки [x, y, 1]
		/// </summary>
		/// <param name="src">Точка, которую преобразуем в матрицу</param>
		public TMatrix(Point src)
		{
			arr = new double[1, 3];
			arr[0, 0] = src.X;
			arr[0, 1] = src.Y;
			arr[0, 2] = 1;
		}
		/// <summary>
		/// Конструктор для создания матрицы произвольного размера
		/// </summary>
		/// <param name="width">Количество строк</param>
		/// <param name="height">Количество столбцов</param>
		public TMatrix(int height, int width)
		{
			arr = new double[height, width];
		}
		/// <summary>
		/// Конструктор для создания вектора-строки
		/// </summary>
		/// <param name="Length">Количество элементов</param>
		public TMatrix(int Length)
		{
			arr = new double[1, Length];
		}
		/// <summary>
		/// Оператор умножения матриц
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static TMatrix operator*(TMatrix left, TMatrix right)
		{
			if (left.Width != right.Heigth)
			{
				throw new Exception("Несоответствие размеров матриц");
			}
			TMatrix buf = new TMatrix(left.Heigth,right.Width);
			int i, j, k;
			for (i = 0; i < buf.Heigth; i++)
				for (j = 0; j < buf.Width; j++)
				{
					buf[i, j] = 0;
					for (k = 0; k < left.Width; k++)
						buf[i, j] += left[i, k] * right[k, j];
				}
			return buf;
		}
		/// <summary>
		/// Возвращает матрицу поворота на заданный в градусах угол. Для преобразований на плоскости.
		/// </summary>
		/// <param name="angle">Угол поворота</param>
		/// <returns></returns>
		public static TMatrix mRotate2D(int angle)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			//Угол в радианах
			double arad = Convert.ToDouble(angle) * (Math.PI / 180);
			buf.arr[0, 0] = Math.Cos(arad);
			buf.arr[1, 1] = Math.Cos(arad);
			buf.arr[0, 1] = Math.Sin(arad);
			buf.arr[1, 0] = -Math.Sin(arad);
			buf.arr[2, 2] = 1;
			return buf;
		}
		/// <summary>
		/// Матрица перемещения на заданные расстояния
		/// </summary>
		/// <param name="X">Перемещение по X</param>
		/// <param name="Y">Перемещение по Y</param>
		/// <returns></returns>
		public static TMatrix mMove2D(double X, double Y)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = (i == j ? 1 : 0);
			buf.arr[2, 0] = X;
			buf.arr[2, 1] = Y;
			return buf;
		}
		/// <summary>
		/// Матрица масштабирования
		/// </summary>
		/// <param name="X">Масштабирование по X</param>
		/// <param name="Y">Масштабирование по Y</param>
		/// <returns></returns>
		public static TMatrix mScale2D(double X, double Y)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			buf.arr[0, 0] = X;
			buf.arr[1, 1] = Y;
			buf.arr[2, 2] = 1;
			return buf;
		}
		/// <summary>
		/// Матрица симметрии относительно прямой через начало координат
		/// </summary>
		/// <param name="a">Угол наклона прямой (относительно 0X)</param>
		/// <returns></returns>
		public static TMatrix mSymmetry2D(double a)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;

			double arad = a * Math.PI / 180;
			buf.arr[0, 0] = Math.Cos(2 * arad);
			buf.arr[0, 1] = Math.Sin(2 * arad);
			buf.arr[1, 1] = -Math.Cos(2 * arad);
			buf.arr[1, 0] = Math.Sin(2 * arad);
			buf.arr[2, 2] = 1;
			return buf;
		}
		/// <summary>
		/// Матрица сдвига относительно осей координат
		/// </summary>
		/// <param name="a">Угол сдвига</param>
		/// <returns></returns>
		public static TMatrix mShiftX2D(double a)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			double arad = a * Math.PI / 180;
			buf.arr[0, 0] = 1;
			buf.arr[0, 1] = 0;//pt[1];
			buf.arr[1, 1] = 1;
			buf.arr[1, 0] = 1 / Math.Tan(arad);
			buf.arr[2, 2] = 1;
			return buf;
		}
		/// <summary>
		/// Генерация единичной матрицы
		/// </summary>
		/// <param name="N">Размерность матрицы</param>
		/// <returns></returns>
		public static TMatrix E(int N)
		{
			TMatrix buf = new TMatrix(N, N);
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					buf[i, j] = (i == j ? 1 : 0);
			return buf;
		}
		/// <summary>
		/// Возвращает объект типа Point, если это возможно. Т.е. если у нас в наличии вектор-строка/столбец
		/// длиной 2 или 3 элемента (во втором случае последний элемент игнорируется). Если преобразование невозможно,
		/// выдаст Exception
		/// </summary>
		/// <returns></returns>
		public Point GetPoint()
		{
			//Проверка на допустимость преобразования
			if (this.Heigth != 1 && this.Width != 1 || this.Heigth > 3 || this.Width > 3) throw new Exception("Невозможно преобразовать в точку [X,Y]");

			Point res = new Point();
			res.X = Convert.ToInt32(this[0]);
			res.Y = Convert.ToInt32(this[1]);
			return res;
		}
		/// <summary>
		/// Вывод в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string res = "";
			int i,j;

			if (Width == 0 || Heigth == 0) return "*empty*";

			for (i = 0; i < Heigth; i++)
			{
				for (j = 0; j < Width; j++)
					res = (res == null ? arr[i, j].ToString("F2") : res + "   " + arr[i, j].ToString("F2"));
				res += "\r\n";
			}
			return res;
		}
	}
}
