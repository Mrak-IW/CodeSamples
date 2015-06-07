using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDivision
{
	public class TDecoder
	{
		/// <summary>
		/// Чиповая последовательность
		/// </summary>
		private int[] chipCode;
		/// <summary>
		/// Порог чувствительности
		/// </summary>
		private int limit;

		/// <summary>
		/// Считать или задать чиповую последовательность. Должна быть представлена в виде +1 и -1.
		/// </summary>
		public int[] ChipCode
		{
			get
			{
				return this.chipCode;
			}
			set
			{
				for (int i = 0; i < value.Length; i++)
				{
					if (value[i] != 1 && value[i] != -1)
						throw new Exception("Чиповая последовательность должна быть представлена в виде +1 и -1");
				}
				this.chipCode = value;
			}
		}

		/// <summary>
		/// Задать или прочитать порог чувствительности.
		/// </summary>
		public int Limit
		{
			get
			{
				return this.limit;
			}
			set
			{
				this.limit = (value >= 0 ? value : -value);
			}
		}

		/// <summary>
		/// Декодировать массив чип-последовательностей.
		/// </summary>
		/// <param name="chipQueues">Массив из очередей импульсов. Номер очереди соответствует номеру чипа в коде, с которым та перемножается.</param>
		public TQueue Decode(TQueue[] chipQueues)
		{
			if (chipQueues.Length != this.ChipCode.Length)
				throw new Exception("Полученный массив очередей импульсов не соответствует по размерам текущей чиповой последовательности.");

			int i, j, sum, k;
			TQueue res = new TQueue(chipQueues[0].Length);
			
			for (i = 0, k = 0; i < chipQueues[0].Length; i++)
			{	//i - номер бита в очереди
				//k - количество реально принятых бит
				sum = 0;
				for (j = 0; j < chipQueues.Length; j++)
				{	//j - номер чипа в последовательности
					sum += chipQueues[j][i] * ChipCode[j];
				}
				//Проверка, является-ли принятая последовательность битом.
				k++;
				if (sum >= this.Limit)
					res.Push(1);
				else if (sum <= -this.Limit)
					res.Push(0);
				else
					k--;
			}
			res.Resize(k);

			return res;
		}

		/// <summary>
		/// Декодировать чип-последовательность (одноканальный режим)
		/// </summary>
		/// <param name="chipQueue">Очередь импульсов.</param>
		public TQueue DecodeSingleChannel(TQueue chipQueue)
		{
			int i, j, sum, k;
			TQueue res = new TQueue(chipQueue.Length);

			for (i = 0, k = 0; i < chipQueue.Length - this.ChipCode.Length + 1; i++)
			{	//i - номер бита в очереди
				//k - количество реально принятых бит
				for (j = 0, sum = 0; j < this.ChipCode.Length; j++)
				{
					sum += chipQueue[i + j] * this.ChipCode[j];
				}
				//Проверка, является-ли принятая последовательность битом.
				k++;
				if (sum >= this.Limit)
					res.Push(1);
				else if (sum <= -this.Limit)
					res.Push(0);
				else
					k--;
			}
			res.Resize(k);

			return res;
		}

		/// <summary>
		/// Создать декодер с заданным чип-кодом.
		/// </summary>
		/// <param name="chipCode">Чиповая последовательность кодировщика</param>
		public TDecoder(int[] chipCode, int limit)
		{
			this.ChipCode = chipCode;
			this.Limit = limit;
		}
	}
}
