using System;
using System.Collections.Generic;
using System.Text;
using Matrix;

namespace MarkovChain
{
	public class TMarkovChain : TMatrix
	{
		/// <summary>
		/// Таблица значений квантилей хи-квадрат для вероятностей 0,3 и 0,1. Приведено для степеней свободы от 1 до 50.
		/// </summary>
		public static double[,] table = {	{1.0742,	2.7055 },
											{2.4079,	4.6052 },
											{3.6649,	6.2514 },
											{4.8784,	7.7794 },
											{6.0644,	9.2364 },
											{7.2311,	10.6446},
											{8.3834,	12.0170},
											{9.5245,	13.3616},
											{10.6564,	14.6837},	
											{11.7807,	15.9872},	
											{12.8987,	17.2750},	
											{14.0111,	18.5493},	
											{15.1187,	19.8119},	
											{16.2221,	21.0641},	
											{17.3217,	22.3071},	
											{18.4179,	23.5418},	
											{19.5110,	24.7690},	
											{20.6014,	25.9894},	
											{21.6891,	27.2036},	
											{22.7745,	28.4120},	
											{23.8578,	29.6151},	
											{24.9390,	30.8133},	
											{26.0184,	32.0069},	
											{27.0960,	33.1962},	
											{28.1719,	34.3816},	
											{29.2463,	35.5632},	
											{30.3193,	36.7412},	
											{31.3909,	37.9159},	
											{32.4612,	39.0875},	
											{33.5302,	40.2560},	
											{34.5981,	41.4217},	
											{35.6649,	42.5847},	
											{36.7307,	43.7452},	
											{37.7954,	44.9032},	
											{38.8591,	46.0588},	
											{39.9220,	47.2122},	
											{40.9839,	48.3634},	
											{42.0451,	49.5126},	
											{43.1053,	50.6598},	
											{44.1649,	51.8051},	
											{45.2236,	52.9485},	
											{46.2817,	54.0902},	
											{47.3390,	55.2302},	
											{48.3957,	56.3685},	
											{49.4517,	57.5053},	
											{50.5071,	58.6405},	
											{51.5619,	59.7743},	
											{52.6161,	60.9066},	
											{53.6697,	62.0375},	
											{54.7228,	63.1671} 
										};
		/// <summary>
		/// Проверка значения хи-квадрат на принадлежность к интервалу вероятностей [0.3, 0.1]
		/// </summary>
		/// <param name="ss">Количество степеней свободы</param>
		/// <param name="value">Проверяемое значение</param>
		static public bool Test(int ss, double value)
		{
			bool fl = false;

			try
			{
				if (table[ss - 1, 0] <= value && table[ss - 1, 1] >= value)
					fl = true;
			}
			catch
			{
				throw new Exception("Данные для степени свободы " + ss + " не содержаться в таблице. Диапазон степеней свободы: [1, " + (table.GetLength(0)) + "]");
			}

			return fl;
		}
		/// <summary>
		/// Датчик случайных чисел для марковской цепи.
		/// </summary>
		protected Random rnd = new Random();
		/// <summary>
		/// Степень точности, с которой сравниваются числа с плавающей точкой
		/// </summary>
		public static double eps = 0.000001;
		/// <summary>
		/// Текущее состояние Марковской цепи.
		/// </summary>
		public int CurrentState
		{
			get { return currentState; }
			set
			{
				if (value >= 0 && value < this.StateCount)
					currentState = value;
				else
					throw new Exception("Попытка задать состояние №" + value + ". Допустимый диапазон состояний = [0; " + (StateCount - 1) + "]");
			}
		}
		private int currentState = 0;

		/// <summary>
		/// Конструктор создания матрицы из строки
		/// </summary>
		/// <param name="s">Строка, из которой читаем элементы. Строки матрицы должны быть разделены
		/// знаком перевода строки, элементы - пробелами либо табуляцией.</param>
		public TMarkovChain(string s)
			: base(s)
		{ }
		/// <summary>
		/// Конструктор для создания матрицы произвольного размера
		/// </summary>
		/// <param name="width">Количество строк</param>
		/// <param name="height">Количество столбцов</param>
		public TMarkovChain(int height, int width)
			: base(height, width)
		{ }
		/// <summary>
		/// Генерация матрицы из строки
		/// </summary>
		/// <param name="s">Строка, из которой читаем элементы. Строки матрицы должны быть разделены
		/// знаком перевода строки, элементы - пробелами либо табуляцией.</param>
		public static TMarkovChain FromString(string s)
		{
			return new TMarkovChain(s);
		}
		/// <summary>
		/// Get: Количество состояний системы. Зависит от размеров матрицы. 0 - значит что-то не то с размерами.
		/// </summary>
		public int StateCount
		{
			get
			{
				return (Width == Heigth && Width > 0) ? Width : 0;
			}
		}
		/// <summary>
		/// Проверка имеющейся матрицы на пригодность, как матрицы переходов. Если вернет пустую строку - претензий к матрице нет. Иначе - текст ошибки.
		/// </summary>
		public string Test()
		{
			int i, j;
			double sum;
			string sbuf;
			bool fl;

			//Проверка на нормализацию матрицы по строкам и неотрицательность значений
			sbuf = " ";
			fl = true;	//Дополнительный флаг, который указывает, надо-ли продолжать выполнение циклов.
			for (i = 0; i < this.Heigth && fl; i++)
			{
				sum = 0;
				for (j = 0; j < this.Width && fl; j++)
				{
					if (this[i, j] < 0)
					{
						fl = false;
						sbuf = "Элемент {" + i + "; " + j + "} < 0 !!!";
					}
					else
					{
						sum += this[i, j];
					}
				}
				if (fl && (sum - 1) * (sum - 1) > (eps * eps)) sbuf = sbuf + " Строка " + i + " не нормирована, сумма = " + sum + ";";
			}

			//Проверка на квадратность
			if (this.Heigth != this.Width || this.Width == 0)
				sbuf = "Неверные! Размеры матрицы (" + this.Heigth + "x" + this.Width + ")";

			if (sbuf != " ")
				sbuf = sbuf.Trim() + " Корректная работа алгоритма невозможна.";
			else
				sbuf = "";

			return sbuf;
		}
		/// <summary>
		/// Генерируем имя состояния, исходя из его порядкового номера
		/// </summary>
		/// <param name="i">Порядковый номер состояния</param>
		static public string GenerateState(int i)
		{
			if (i / ('Z' - 'A') == 0) return Convert.ToChar('A' + i % ('Z' - 'A')).ToString();
			else return GenerateState(i / ('Z' - 'A') - 1) + Convert.ToChar('A' + i % ('Z' - 'A'));
		}
		/// <summary>
		/// Переводит цепь в следующее состояние, исходя из текущего состояния и матрицы перехода. Возвращает номер состояния.
		/// </summary>
		public int Next()
		{
			double x;
			return Next(out x);
		}
		/// <summary>
		/// Переводит цепь в следующее состояние, исходя из текущего состояния и матрицы перехода. Возвращает номер состояния.
		/// </summary>
		/// <param name="reason">Сюда возвращаем то случайное число, руководствуясь которым произошел переход.</param>
		public int Next(out double reason)
		{
			double x, sum;
			int i;

			x = rnd.NextDouble();
			sum = 0;
			for (i = 0; i < StateCount; i++)
			{
				if (x >= sum && x <= sum + this[CurrentState, i])
				{
					CurrentState = i;
					break;
				}
				sum += this[CurrentState, i];
			}

			reason = x;
			return CurrentState;
		}
		/// <summary>
		/// Генерирует блок значений <i>немарковского</i> процесса для текущего состояния марковского.
		/// Возвращает заданное количество значений <i>случайной величины</i>.
		/// <i>Закон распределения</i>, которому случайная величина подчиняется, зависит от настроек
		/// поведения (behavior) и <i>текущего состояния</i> марковской цепи.
		/// </summary>
		/// <param name="cnt">Количество значений</param>
		/// <param name="behavior">Поведение немарковского процесса</param>
		static public double[] NoMarkovValues(int cnt, TEffect behavior, int state)
		{
			if (behavior == null) throw new Exception("Немарковский процесс не может сгенерировать следующее состояние. Не задано поведение (behavior == null)");
			//Проверка на корректность введенного промежутка
			if (cnt <= 0) return null;

			double[] arr = null;
			Random rnd = new Random();

			arr = new double[cnt];
			//Задаем текущий закон распределения
			behavior.curMode = state;
			//Заполняем массив выходных значений
			for (int i = 0; i < cnt; i++)
			{
				arr[i] = behavior.Next;
			}

			return arr;
		}
		/// <summary>
		/// Генерация текстового представления матрицы граничных условий
		/// </summary>
		public string BorderMatrix()
		{
			int i, j;
			double sum;
			string s = " ";
			for (i = 0; i < Heigth; i++)
			{
				sum = 0;
				for (j = 0; j < Width; j++)
				{
					s = s + sum + (j == 0 ? "<=p" : "<p") + GenerateState(i) + GenerateState(j) + "<=" + (this[i, j] + sum) + "\t";
					sum += this[i, j];
				}
				s = s.Trim() + "\r\n";
			}
			return s;
		}
	}
}
