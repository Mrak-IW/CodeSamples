using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDivision
{
	public class TEncoder
	{
		/// <summary>
		/// Чиповая последовательность
		/// </summary>
		private int[] chipCode;

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
		/// Закодировать очередь при помощи чиповой последовательности и распределить по каналам.
		/// </summary>
		/// <param name="queue">Очередь бит на кодирование. Представлены в виде 0 и 1.</param>
		public TQueue[] Encode(TQueue bitQueue)
		{
			TQueue bufQueue = new TQueue(bitQueue);
			int i, j, bit;
			//Создаём очереди импульсов для каждого канала.
			TQueue[] res = new TQueue[this.ChipCode.Length];
			for (i = 0; i < res.Length; i++)
				res[i] = new TQueue(bufQueue.Length);

			//Начинаем кодирование
			for (i = 0; i < bufQueue.Length; i++)	//i - количество уже закодированных бит
			{
				bit = bufQueue.Pop();
				if (bit == 0)
					bit = -1;
				else if (bit != 1)
					throw new Exception("Странный у тебя бит какой-то... Значение #" + i + " = " + bit);
				for (j = 0; j < res.Length; j++)	//j - номер чипа в последовательности
				{
					res[j].Push(bit * chipCode[j]);
				}
			}

			return res;
		}

		/// <summary>
		/// Закодировать очередь при помощи чиповой последовательности и запихнуть в один канал.
		/// </summary>
		/// <param name="queue">Очередь бит на кодирование. Представлены в виде 0 и 1.</param>
		public TQueue EncodeSingleChannel(TQueue queue)
		{
			TQueue[] buf = this.Encode(queue);
			TQueue res = new TQueue(buf.Length * buf[0].Length);
			int i, j;
			for (i = 0; i < buf[0].Length; i++)
			{
				for (j = 0; j < buf.Length; j++)
				{
					res.Push(buf[j][i]);
				}
			}

			return res;
		}
		
		/// <summary>
		/// Создать кодировщик с заданным чип-кодом.
		/// </summary>
		/// <param name="chipCode">Чиповая последовательность кодировщика</param>
		public TEncoder(int[] chipCode)
		{
			this.ChipCode = chipCode;
		}
	}
}
