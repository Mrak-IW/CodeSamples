using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDivision
{
	/// <summary>
	/// Очередь со строго фиксированной длиной. Новые значения помещаются по старшим адресам очереди.
	/// Выталкивание происходит с нулевого адреса.
	/// При добавлении одного значения, одно значение выталкивается.
	/// </summary>
	public class TQueue
	{
		/// <summary>
		/// Создать очередь с заданной длиной
		/// </summary>
		/// <param name="length">Длина создаваемой очереди</param>
		public TQueue(int length)
		{
			this.content = new int[length];

			for (int i = 0; i < this.content.Length; i++)
			{
				this.content[i] = 0;
			}

			this.indexRear = CorrectIndex(-1);
		}

		/// <summary>
		/// Создать очередь с заданным содержимым (из массива)
		/// </summary>
		/// <param name="array">Массив с содержимым очереди</param>
		public TQueue(int[] template)
		{
			int i;
			this.content = new int[template.Length];
			for (i = 0; i < content.Length; i++)
			{
				this.content[i] = template[i];
			}

			this.indexRear = CorrectIndex(-1);
		}

		/// <summary>
		/// Создать очередь с заданным содержимым (из массива)
		/// </summary>
		/// <param name="array">Массив с содержимым очереди</param>
		public TQueue(TQueue template)
		{
			int i;
			this.content = new int[template.Length];
			for (i = 0; i < content.Length; i++)
			{
				this.content[i] = template[i];
			}
			this.indexRear = CorrectIndex(-1);
		}

		/// <summary>
		/// Получить или задать элемент очереди с данным индексом
		/// </summary>
		/// <param name="index"></param>
		public int this[int index]
		{
			get
			{
				try
				{
					return this.content[CorrectIndex(IndexHead + index)];
				}
				catch (IndexOutOfRangeException ex)
				{
					throw new IndexOutOfRangeException("Индекс находится за границами массива.");
				}
			}
			set
			{
				try
				{
					this.content[CorrectIndex(IndexHead + index)] = value;
				}
				catch (IndexOutOfRangeException ex)
				{
					throw new IndexOutOfRangeException("Индекс находится за границами массива.");
				}
			}
		}

		/// <summary>
		/// Содержимое очереди
		/// </summary>
		private int[] content;

		/// <summary>
		/// Считать или задать содержимое очереди целиком.
		/// </summary>
		public int[] Content
		{
			get
			{
				int i;
				int[] res = new int[content.Length];
				for (i = 0; i < content.Length; i++)
				{
					res[i] = this[i];
				}
				return res;
			}
			set
			{
				this.content = new int[value.Length];
				value.CopyTo(this.content, 0);
				this.indexRear = CorrectIndex(-1);
			}
		}

		/// <summary>
		/// Количество элементов в очереди
		/// </summary>
		public int Length
		{
			get
			{
				if (this.content == null) return 0;
				return this.content.Length;
			}
		}

		/// <summary>
		/// Вытолкнуть элемент из очереди. Возвращает вытолкнутый элемент.
		/// В очередь при этом заталкивается ноль.
		/// </summary>
		public int Pop()
		{
			return Push(0);
		}

		/// <summary>
		/// Затолкнуть новый элемент в очередь.
		/// Вернёт элемент, вытолкнутый при этом из очереди.
		/// </summary>
		/// <param name="newElement">Новый элемент очереди</param>
		public int Push(int newElement)
		{
			int res = content[IndexHead];
			indexRear = IndexHead;
			content[indexRear] = newElement;
			return res;
		}

		/// <summary>
		/// Индекс конца очереди. В конец добавляются новые элементы.
		/// </summary>
		private int indexRear;

		/// <summary>
		/// Индекс начала очереди. По этому индексу находится нулевой элемент очереди.
		/// </summary>
		private int IndexHead
		{
			get { return CorrectIndex(indexRear + 1); }
			set { indexRear = CorrectIndex(value - 1); }
		}

		/// <summary>
		/// Загнать число в поле вычетов по модулю длины очереди
		/// </summary>
		/// <param name="index">Исходный индекс</param>
		private int CorrectIndex(int index)
		{
			int res = index;
			while (res < 0)
				res += content.Length;
			if (res >= content.Length)
				res %= content.Length;
			return res;
		}

		/// <summary>
		/// Вывести содержимое очереди в строку, начиная со старших адресов.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			int i;
			string res = "";

			for (i = Length - 1; i >= 0; i--)
			{
				res = res /*+ "[" + i + "]" */+ this[i] + "\t";
			}
			return res;
		}

		/// <summary>
		/// Изменить размер очереди. При уменьшении обрезаются данные на старших адресах.
		/// </summary>
		/// <param name="newSize">Новый размер очереди</param>
		public void Resize(int newSize)
		{
			int[] buf = new int[newSize];
			int i, lim;
			lim = (this.Length < newSize ? this.Length : newSize);
			for (i = 0; i < lim ; i++)
			{
				buf[newSize - i - 1] = this[Length - i - 1];
			}
			this.Content = buf;
		}
	}
}
