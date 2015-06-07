using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
	public class TEffect
	{
		public TEffect()
		{
			//behaviorList.Add(new TRandomVar(EffectType.CONST,10,0));
		}
		/// <summary>
		/// Получаем следующее значение
		/// </summary>
		public double Next
		{
			get
			{
				double buf = 0; ;
				if (behaviorList.Count < 1)
					throw new Exception("Список режимов пуст. Невозможно сгенерировать новое состояние");
				if(curMode >= 0 && curMode < behaviorList.Count)
				{
					buf = behaviorList[curMode].NextValue;
				}
				else
				{
					buf = behaviorList[0].NextValue;
				}
				return buf;
			}
		}
		/// <summary>
		/// Список, который отвечает за поведение эффекта при данном конкретном режиме работы.
		/// Индекс в массиве - номер режима. Значение по индексу - тот закон распределения, которому
		/// будет подчиняться эффект при данном номере режима
		/// </summary>
		public List<TRandomVar> behaviorList = new List<TRandomVar>();
		/// <summary>
		/// Номер текущего режима генерации значения
		/// </summary>
		public int curMode = 0;
	}

	public class TRandomVar
	{
		private Random rnd = new Random();

		/// <summary>
		/// Создает закон распределения с характеристиками
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="m">Матожидание</param>
		/// <param name="d">Дисперсия</param>
		public TRandomVar(EffectType mode, double m, double d)
		{
			this.mode = mode;
			this.m = m;
			this.d = d;
		}
		/// <summary>
		/// Следующее значение для воздействия.
		/// </summary>
		public virtual double NextValue
		{
			get
			{
				double buf;

				switch (mode)
				{
					case EffectType.RND:
						buf = rnd.NextDouble();
						return buf * d + m;
					default:
						return m;
				}
			}
		}

		/// <summary>
		/// Режим генерации значения
		/// </summary>
		public EffectType mode = EffectType.CONST;
		/// <summary>
		/// Матожидание
		/// </summary>
		public double m = 0;
		/// <summary>
		/// Дисперсия
		/// </summary>
		public double d = 0;
	}

	public enum EffectType
	{
		/// <summary>
		/// Константа
		/// </summary>
		CONST = 0,
		/// <summary>
		/// Равномерный закон распределения
		/// </summary>
		RND = 1,
	}
}
