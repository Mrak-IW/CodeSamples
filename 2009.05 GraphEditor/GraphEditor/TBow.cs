using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphEditor
{
	/// <summary>
	/// Дуга графа
	/// </summary>
	[Serializable]
	public class TBow
	{
		/// <summary>
		/// Конец дуги
		/// </summary>
		public TEdgeRegular Edge1
		{
			get { return edge1; }
			set
			{
				if (type == BowTypes.To1)
					Head = value;
				edge1 = value;
			}
		}
		private TEdgeRegular edge1;
		/// <summary>
		/// Конец дуги
		/// </summary>
		public TEdgeRegular Edge2
		{
			get { return edge2; }
			set
			{
				if (type == BowTypes.To2)
					Head = value;
				edge2 = value;
			}
		}
		private TEdgeRegular edge2;
		/// <summary>
		/// Тип дуги
		/// </summary>
		private BowTypes type = BowTypes.NoVector;
		/// <summary>
		/// Тип дуги
		/// </summary>
		public BowTypes Type
		{
			set
			{
				type = value;
				switch (type)
				{
					case BowTypes.To1:
						head = edge1;
						break;
					case BowTypes.To2:
						head = edge2;
						break;
					case BowTypes.NoVector:
						head = null;
						break;
					default:
						throw new Exception("Попытка задать неопознанный тип дуги");
						break;
				}
			}
			get
			{ 
				return type;
			}
		}
		/// <summary>
		/// Вершина, на которую указывает дуга. Readonly.
		/// </summary>
		public TEdgeRegular Head
		{
			get { return head; }
			set
			{
				if (value != edge1 && value != edge2)
					throw new Exception("Попытка задать направление дуги на \"левую\" вершину.");
				else
					head = value;
			}
		}
		public TEdgeRegular Rear
		{
			get 
			{
				if (head == null)
					return null;
				else
					return (edge1 == head ? edge2 : edge1);
			}
		}
		/// <summary>
		/// Вершина, на которую указывает дуга.
		/// </summary>
		private TEdgeRegular head = null;
		/// <summary>
		/// Вес дуги
		/// </summary>
		public double value = 0;
		/// <summary>
		/// Конструктор дуги между двумя вершинами. АВТОМАТИЧЕСКИ добавляет дугу в списки дуг обеих вершин
		/// </summary>
		/// <param name="e1">Первый конец дуги</param>
		/// <param name="e2">Второй конец дуги</param>
		public TBow(TEdgeRegular e1, TEdgeRegular e2, BowTypes type, double value)
		{
			edge1 = e1;
			edge2 = e2;
			e1.bows.Add(this);
			e2.bows.Add(this);
			this.Type = type;
			this.value = value;
		}
		/// <summary>
		/// Проверяет, не подключена ли дуга к указанной вершине
		/// </summary>
		/// <param name="e">Проверяемая вершина</param>
		public bool IsConnected(TEdgeRegular e)
		{
			bool fl = edge1 == e || edge2 == e;
			bool fl2 = e.bows.Contains(this);
			if (fl != fl2)
				throw new Exception("**Соединение вершин и ребер некорректно**");
			return fl;
		}
		public void Draw(Graphics g, bool selected)
		{
			int h, w, l, ox, oy;
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			Point pin;
			Point pout;
			TEdgeRegular ein, eout;

			if (Type != BowTypes.NoVector)
			{
				pin = new Point(Head.inPoint.X, Head.inPoint.Y);
				pout = new Point(Rear.outPoint.X, Rear.outPoint.Y);
				ein = Head;
				eout = Rear;
			}
			else
			{
				pin = new Point(edge1.inPoint.X, edge1.inPoint.Y);
				pout = new Point(edge2.outPoint.X, edge2.outPoint.Y);
				ein = edge1;
				eout = edge2;
			}
			//Вычисляем "ширину" и "высоту" линии
			w = pin.X - pout.X;
			h = pin.Y - pout.Y;
			//Вычисляем длину линии
			l = Convert.ToInt32(Math.Sqrt(h * h + w * w));
			//Вычисляем смещение для точки входа
			ox = ein.InOutOffs * w / l;
			oy = ein.InOutOffs * h / l;
			pin.X -= ox;
			pin.Y -= oy;
			//Вычисляем смещение для точки выхода
			ox = eout.InOutOffs * w / l;
			oy = eout.InOutOffs * h / l;
			pout.X += ox;
			pout.Y += oy;

			g.DrawLine(p, pin, pout);
		}

	}

	public enum BowTypes
	{
		/// <summary>
		/// Ненаправленная дуга
		/// </summary>
		NoVector = 0,
		/// <summary>
		/// Дуга от вершины Edge2 к вершине Edge1
		/// </summary>
		To1 = 1,
		/// <summary>
		/// Дуга от вершины Edge1 к вершине Edge2
		/// </summary>
		To2 = 2,
	}
}
