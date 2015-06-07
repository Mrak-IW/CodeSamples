using System;
using System.Collections.Generic;
using System.Text;
//Добавленные мной
using System.Drawing;

namespace Matrix
{
	/// <summary>
	/// Класс матрицы
	/// </summary>
	public class TMatrix
	{
		//char[] DELIMETERS = { '\r', '\n' };
		private static Random rnd = new Random();
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
		/// Возвращает заданную строку матрицы в виде отдельной матрицы - строки.
		/// </summary>
		/// <param name="row">Номер строки.</param>
		public TMatrix row(int row)
		{
			int i;
			TMatrix buf = new TMatrix(1, this.Width);
			for (i = 0; i < this.Width; i++)
				buf[i] = this[row, i];

			return buf;
		}
		/// <summary>
		/// Возвращает заданный стстолбец матрицы в виде отдельной матрицы - столбца.
		/// </summary>
		/// <param name="col">Номер строки.</param>
		public TMatrix column(int col)
		{
			int i;
			TMatrix buf = new TMatrix(this.Heigth, 1);
			for (i = 0; i < this.Heigth; i++)
				buf[i] = this[i, col];

			return buf;
		}
		/// <summary>
		/// А это обращение к матрице, как к вектору. Если ширина == 1, то как к столбцу, иначе, обращаемся к первой строке.
		/// </summary>
		/// <param name="i">Индекс элемента вектора</param>
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
		/// Конструктор по умолчанию. Создает вектор-строку на 3 элемента
		/// </summary>
		public TMatrix()
		{
			arr = new double[1, 3];
			for (int i = 0; i < 3; i++)
				this[i] = 0;
		}
		/// <summary>
		/// Конструктор, создающий вектор-строку на 3 элемента и заполняющий его значениями из точки [x, y, 1]
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
		/// <param name="width">Количество столбцов</param>
		/// <param name="height">Количество строк</param>
		public TMatrix(int height, int width)
		{
			int i, j;
			arr = new double[height, width];
			for (i = 0; i < Heigth; i++)
				for (j = 0; j < Width; j++)
					this[i, j] = 0;
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
		/// Конструктор создания матрицы из строки
		/// </summary>
		/// <param name="s">Строка, из которой читаем элементы. Строки матрицы должны быть разделены
		/// знаком перевода строки, элементы - пробелами либо табуляцией.</param>
		public TMatrix(string s)
		{
			//Заменяем возможные разделители на пробелы или \r\n
			string src = s;
			if (src.IndexOf(", ") >= 0)
			{
				src = src.Replace(";", "\r\n");
				src = src.Replace(", ", " ");
			}
			else
			{
				src = src.Replace(";", " ");
			}
			src = src.Trim();

			if (src.Length == 0)
				throw new Exception("Из этой строки матрица не получится.");

			string[] buf;
			string[][] buf2;
			int i, j, h, w, max;
			

			//Разбиваем строку на отдельные строки матрицы, разделенные \r\n
			buf = src.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			h = buf.Length;
			buf2=new string[h][];
			//Разбиваем полученные строки на отдельные элементы, разделенные пробелами или \t
			//Заодно находим самую длинную строку. По ней будем задавть ширину матрицы.
			max = 0;
			for (i = 0; i < buf.Length; i++)
			{
				buf2[i] = buf[i].Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (buf2[i].Length > max) max = buf2[i].Length;
			}

			w = max;
			arr = new double[h, w];

			//Теперь наполняем матрицу элементами. Там, где элементов не хватит (строка короткая),
			//дополним нулями.
			for (i = 0; i < Heigth; i++)
			{
				for (j = 0; j < Width; j++)
				{
					try
					{
						this[i, j] = (j < buf2[i].Length ? DoubleParse(buf2[i][j]) : 0);
					}
					catch 
					{
						throw new Exception("Возникли проблемы с переводом в число элемента с индексами {" + i + "; " + j + "} и значением = \'" + buf2[i][j] + "\'");
					}
				}
			}
		}
		/// <summary>
		/// Генерация матрицы из строки
		/// </summary>
		/// <param name="s">Строка, из которой читаем элементы. Строки матрицы должны быть разделены
		/// знаком перевода строки, элементы - пробелами либо табуляцией.</param>
		public static TMatrix Parse(string s)
		{
			return new TMatrix(s);
		}
		/// <summary>
		/// Оператор умножения матриц
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
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
		/// Оператор сложения матриц
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public static TMatrix operator +(TMatrix left, TMatrix right)
		{
			if (left.Width != right.Width || left.Heigth!= right.Heigth)
			{
				throw new Exception("Несоответствие размеров матриц");
			}
			TMatrix buf = new TMatrix(left.Heigth, left.Width);
			int i, j;
			for (i = 0; i < buf.Heigth; i++)
				for (j = 0; j < buf.Width; j++)
				{
					buf[i, j] = left[i, j] + right[i, j];
				}
			return buf;
		}
		/// <summary>
		/// Оператор вычитания матриц
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public static TMatrix operator -(TMatrix left, TMatrix right)
		{
			if (left.Width != right.Width || left.Heigth != right.Heigth)
			{
				throw new Exception("Несоответствие размеров матриц");
			}
			TMatrix buf = new TMatrix(left.Heigth, left.Width);
			int i, j;
			for (i = 0; i < buf.Heigth; i++)
				for (j = 0; j < buf.Width; j++)
				{
					buf[i, j] = left[i, j] - right[i, j];
				}
			return buf;
		}
		/// <summary>
		/// Оператор умножения матрицы на число
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public static TMatrix operator *(TMatrix left, double right)
		{
			TMatrix buf = new TMatrix(left.Heigth, left.Width);
			int i, j;
			for (i = 0; i < buf.Heigth; i++)
				for (j = 0; j < buf.Width; j++)
				{
					buf[i, j] = left[i, j] * right;
				}
			return buf;
		}
		/// <summary>
		/// Оператор деления матрицы на число
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public static TMatrix operator /(TMatrix left, double right)
		{
			TMatrix buf = new TMatrix(left.Heigth, left.Width);
			int i, j;
			for (i = 0; i < buf.Heigth; i++)
				for (j = 0; j < buf.Width; j++)
				{
					buf[i, j] = left[i, j] / right;
				}
			return buf;
		}
		/// <summary>
		/// Генерация случайной матрицы с заданными размерами. Значения ячеек от 0 до 1.
		/// </summary>
		/// <param name="h">Количество строк</param>
		/// <param name="w">Количество столбцов</param>
		public static TMatrix RND(int h, int w)
		{
			int i, j;
			TMatrix res = new TMatrix(h, w);
			for (i = 0; i < res.Heigth; i++)
			{
				for (j = 0; j < res.Width; j++)
				{
					res[i, j] = rnd.NextDouble();
				}
			}

			return res;
		}
		/// <summary>
		/// Возвращает матрицу поворота на заданный в градусах угол относительно начала координат. Для преобразований на плоскости.
		/// </summary>
		/// <param name="angle">Угол поворота</param>
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
		/// Матрица сдвига вдоль оси 0X
		/// </summary>
		/// <param name="a">Угол сдвига</param>
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
		/// Матрица сдвига вдоль оси 0Y
		/// </summary>
		/// <param name="a">Угол сдвига</param>
		public static TMatrix mShiftY2D(double a)
		{
			TMatrix buf = new TMatrix(3, 3);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			double arad = a * Math.PI / 180;
			buf.arr[0, 0] = 1;
			buf.arr[0, 1] = 1 / Math.Tan(arad);
			buf.arr[1, 1] = 1;
			buf.arr[1, 0] = 0;
			buf.arr[2, 2] = 1;
			return buf;
		}
		/// <summary>
		/// Матрица Безье
		/// </summary>
		public static TMatrix mBesier2D()
		{
			TMatrix buf = new TMatrix(4, 4);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			buf.arr[0, 0] = -1;
			buf.arr[0, 1] = 3;
			buf.arr[0, 2] = -3;
			buf.arr[0, 3] = 1;
			buf.arr[1, 0] = 3;
			buf.arr[1, 1] = -6;
			buf.arr[1, 2] = 3;
			buf.arr[2, 0] = -3;
			buf.arr[2, 1] = 3;
			buf.arr[3, 0] = 1;
			return buf;
		}
		/// <summary>
		/// Матрица Эрмита
		/// </summary>
		public static TMatrix mErmit2D()
		{
			TMatrix buf = new TMatrix(4, 4);
			int i, j;
			for (i = 0; i < 3; i++)
				for (j = 0; j < 3; j++)
					buf.arr[i, j] = 0;
			buf.arr[0, 0] = 2;
			buf.arr[0, 1] = -2;
			buf.arr[0, 2] = 1;
			buf.arr[0, 3] = 1;
			buf.arr[1, 0] = -3;
			buf.arr[1, 1] = 3;
			buf.arr[1, 2] = -2;
			buf.arr[1, 3] = -1;
			buf.arr[2, 2] = 1;
			buf.arr[3, 0] = 1;
			return buf;
		}
		/// <summary>
		/// Генерирует строку {t^3, t^2, t, 1}
		/// </summary>
		/// <param name="t"></param>
		public static TMatrix mT(double t)
		{
			TMatrix buf = new TMatrix(4);
			buf[3] = 1;
			buf[2] = t;
			buf[1] = t * t;
			buf[0] = t * t * t;
			return buf;
		}
		/// <summary>
		/// Генерация единичной матрицы
		/// </summary>
		/// <param name="N">Размерность матрицы</param>
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
		public Point GetPoint()
		{
			//Проверка на допустимость преобразования
			if (this.Heigth != 1 && this.Width != 1 || this.Heigth > 3 || this.Width > 3 || this.Width < 1 || this.Heigth < 1 || Heigth == Width)
				throw new Exception("Невозможно преобразовать в точку [X,Y]");

			Point res = new Point();
			res.X = Convert.ToInt32(this[0]);
			res.Y = Convert.ToInt32(this[1]);
			return res;
		}
		/// <summary>
		/// Вывод в строку
		/// </summary>
		public override string ToString()
		{
			string res = "";
			int i,j;

			if (Width == 0 || Heigth == 0) return "*empty*";

			for (i = 0; i < Heigth; i++)
			{
				for (j = 0; j < Width; j++)
					res = (res == null ? arr[i, j].ToString("F2") : res + arr[i, j].ToString("F2") + " \t");
				res += "\r\n";
			}
			return res;
		}
		/// <summary>
		/// Вывод в строку
		/// </summary>
		/// <param name="format">Строка формата чисел с плавающей точкой</param>
		public string ToString(string format)
		{
			string res = "";
			int i, j;

			if (Width == 0 || Heigth == 0) return "*empty*";

			for (i = 0; i < Heigth; i++)
			{
				for (j = 0; j < Width; j++)
					res = (res == null ? arr[i, j].ToString(format) : res + arr[i, j].ToString(format) + "\t");
				res += "\r\n";
			}
			return res;
		}

		#region "Заплатка на расовую нетерпимость C# ^_^"
		/// <summary>
		/// Возвращает числовое значение строки, не взирая на настройки локализации (десятичный разделитель)
		/// </summary>
		/// <param name="s">Строка для разбора</param>
		public static double DoubleParse(string s)
		{
			//У-ха-ха-ха-ха!!!! Это заклинание вызова десятичного разделителя!!!
			string buf = s;
			buf = buf.Replace('.', System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
			buf = buf.Replace('.', System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
			return double.Parse(buf);
		}
		/// <summary>
		/// Возвращает числовое значение строки, не взирая на настройки локализации (десятичный разделитель)
		/// </summary>
		/// <param name="s">Строка для разбора</param>
		/// <param name="ret">Сюда вернем результат</param>
		public static bool DoubleTryParse(string s, out double ret)
		{
			try
			{
				ret = DoubleParse(s);
			}
			catch
			{
				ret = 0;
				return false;
			}
			return true;
		}
		#endregion
	}
}
