using System;
using System.Collections.Generic;
using System.Text;
using Image_PGM;

namespace Perceptron
{
	/// <summary>
	/// Нейрон с произвольным чичлом входов типа byte
	/// </summary>
	public class Perceptron
	{
		protected double teta = 0;
		protected double[] weight;
		protected byte[] receptorField;
		double koef = 0.7;
		bool changeTeta = false;

		/// <summary>
		/// Создать нейрон с заданной длиной рецепторного поля (количеством входов) 
		/// </summary>
		/// <param name="length">Количество входов</param>
		public Perceptron(int length)
		{ 
			weight = new double[length];
			receptorField = new byte[length];
		}

		/// <summary>
		/// Создать нейрон с заданной длиной рецепторного поля (количеством входов) 
		/// </summary>
		/// <param name="length">Количество входов</param>
		/// <param name="teta">Порог срабатывания</param>
		/// <param name="koef">Коефициент скорости обучения</param>
		/// <param name="changeTeta">Изменять ли в процессе обучения величину порога срабатывания</param>
		public Perceptron(int length, double teta, double koef, bool changeTeta)
		{
			weight = new double[length];
			receptorField = new byte[length];
			this.teta = teta;
			this.changeTeta = changeTeta;
			this.koef = koef;
		}

		/// <summary>
		/// Порог срабатывания
		/// </summary>
		public double Teta
		{
			get { return teta; }
			set { teta = value; }
		}

		/// <summary>
		/// Коефициент скорости обучения
		/// </summary>
		public double KoefNu
		{
			get { return koef; }
			set { this.koef = value; }
		}

		/// <summary>
		/// Изменять ли порог срабатывания в процессе обучения
		/// </summary>
		public bool ChangeTeta
		{
			get { return this.changeTeta; }
			set { this.changeTeta = value; }
		}

		/// <summary>
		/// Задать или получить байт на входе нейрона
		/// </summary>
		/// <param name="i">Номер байта</param>
		public byte this[int i]
		{
			get { return receptorField[i]; }
			set { receptorField[i] = value; }
		}

		/// <summary>
		/// Задать новые веса для входов.
		/// </summary>
		public double[] Weight
		{
			get { return this.weight; }
			set
			{
				if (value.Length != this.receptorField.Length)
					throw new Exception("Нельзя поменять количество входов живого нейрона. Создавай новый, вивисектор хренов.");
				this.weight = value;
			}
		}

		/// <summary>
		/// Размер рецепторного поля
		/// </summary>
		public int Length
		{
			get { return this.receptorField.Length; }
		}

		private int Limit
		{
			get
			{
				return receptorField.Length < weight.Length ? receptorField.Length : receptorField.Length;
			}
		}

		/// <summary>
		/// Получить выходной сигнал нейрона
		/// </summary>
		public byte Out
		{
			get
			{
				int i;
				double buf = 0;				
				for (i = 0; i < Limit; i++)
				{
					buf += receptorField[i] * weight[i];
				}
				buf -= teta;
				return (buf > 0 ? Convert.ToByte(1) : Convert.ToByte(0));
			}
		}

		/// <summary>
		/// Обучить нейрон на примере. Вернёт среднюю величину корректировки весов.
		/// </summary>
		/// <param name="sample">Желаемый выход нейрона при данных значениях рецепторного поля.
		/// Должен иметь значение 0 или 1</param>
		public double Teach(byte sample)
		{
			int i;
			double diff = 0;
			byte buf = this.Out;
			for (i = 0; i < Limit; i++)
			{
				diff += Math.Abs(koef * (sample - buf) * receptorField[i]);
				weight[i] += koef * (sample - buf) * receptorField[i];
			}
			if (changeTeta)
			{
				diff += Math.Abs(koef * (sample - buf));
				teta += koef * (sample - buf);
			}
			return diff / weight.Length;
		}
	}

	/// <summary>
	/// Нейрон для поиска контуров в фалах PGM
	/// </summary>
	public class ConturPerceptron : Perceptron
	{
		int width, height;

		/// <summary>
		/// Создать нейрон с прямоугольным рецепторным полем
		/// </summary>
		/// <param name="width">Входов в строке поля</param>
		/// <param name="height">Количество строк в поле</param>
		public ConturPerceptron(int width, int height, double teta, double koef, bool changeTeta)
			: base(width * height, teta, koef, changeTeta)
		{
			this.width = width;
			this.height = height;
		}

		/// <summary>
		/// Количество столбцов в рецепторном поле
		/// </summary>
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		/// <summary>
		/// Количество строк в рецепторном поле
		/// </summary>
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		/// <summary>
		/// Получить или задать значение на входе нейрона
		/// </summary>
		/// <param name="x">Номер входа по горизонтали</param>
		/// <param name="y">Номер входа по вертикали</param>
		public byte this[int x, int y]
		{
			get 
			{
				if (y >= 0 && y < height && x >= 0 && x < width)
					return this.receptorField[y * width + x];
				else
					throw new Exception("Выход индекса за границы рецепторного поля.");
			}
			set
			{
				if (y >= 0 && y < height && x >= 0 && x < width)
					this.receptorField[y * width + x] = value;
				else
					throw new Exception("Выход индекса за границы рецепторного поля.");
			}
		}

		/// <summary>
		/// Получить из PGM-изображенияжж рецепторное поле с центром в заданных координатах.
		/// Если поле имеет чётные размеры и центра не имеет, вместо центра берётся ближайшая
		/// к нему точка со стороны нулевых координат.
		/// </summary>
		/// <param name="image">Изображение</param>
		/// <param name="x">Координата по горизонтали</param>
		/// <param name="y">Координата по вертикали</param>
		public void GetReceptorField(PGM_Image image, int x, int y)
		{
			int i, j;
			for (i = 0; i < this.width; i++)
				for (j = 0; j < this.height; j++)
				{
					this[i, j] = image[x + i - this.width / 2, y + j - this.height / 2];
				}
		}

		public override string ToString()
		{
			string buf = "Рецепторное поле:\r\n";
			int i, j;
			for (i = 0; i < this.height; i++)
			{
				for (j = 0; j < this.width; j++)
				{
					buf = buf + "\t" + this[j, i];
				}
				buf = buf + "\r\n";
			}
			buf = buf + "Веса на входах:\r\n";
			for (i = 0; i < this.height; i++)
			{
				for (j = 0; j < this.width; j++)
				{
					buf = buf + "\t" + this.weight[i * this.width + j];
				}
				buf = buf + "\r\n";
			}
			buf += "Порог срабатывания = " + teta + "\r\n";
			return buf;
		}

		public string ToString(string formatString)
		{
			string buf = "Рецепторное поле:\r\n";
			int i, j;
			for (i = 0; i < this.height; i++)
			{
				for (j = 0; j < this.width; j++)
				{
					buf = buf + "\t" + this[j, i];
				}
				buf = buf + "\r\n";
			}
			buf = buf + "Веса на входах:\r\n";
			for (i = 0; i < this.height; i++)
			{
				for (j = 0; j < this.width; j++)
				{
					buf = buf + "\t" + this.weight[i * this.width + j].ToString(formatString);
				}
				buf = buf + "\r\n";
			}
			buf += "Порог срабатывания = " + teta + "\r\n";
			return buf;
		}
	}
}
