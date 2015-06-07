using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphEditor
{
	
	/// <summary>
	/// Класс для обычной круглой вершины со статическим значением
	/// </summary>
	[Serializable]
	public class TEdgeRegular
	{
		/// <summary>
		/// Граф, которому принадлежит вершина
		/// </summary>
		public TGraph Parent;
		/// <summary>
		/// Список дуг, входящих в эту вершину
		/// </summary>
		public List<TBow> bows = new List<TBow>();
		/// <summary>
		/// Количество входящих дуг
		/// </summary>
		public int BowsInCount
		{
			get
			{
				int i, cnt = 0;
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this) cnt++;
				return cnt;
			}
		}
		/// <summary>
		/// Тип вершины
		/// </summary>
		public virtual EdgeTypes Type
		{
			get { return EdgeTypes.Regular; }
		}
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		public TEdgeRegular(TGraph parent)
		{
			this.Parent = parent;
		}
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		protected TEdgeRegular()
		{ }		
		/// <summary>
		/// Пояснение смысла вершины
		/// </summary>
		public string Text = "";
		/// <summary>
		/// Числовое значение вершины
		/// </summary>
		protected double value = 0;
		/// <summary>
		/// Числовое значение вершины
		/// </summary>
		public virtual double Value
		{
			get { return this.value;	}
			set { this.value = value;	}
		}
		/// <summary>
		/// Положение вершины на сетке. По умолчанию = (0,0)
		/// </summary>
		public Point Pos;
		/// <summary>
		/// Смещение точки входа ребер, относительно позиции вершины
		/// </summary>
		public Point inOffs = new Point(0, 0);
		/// <summary>
		/// Смещение точки выхода ребер, относительно позиции вершины
		/// </summary>
		public Point outOffs = new Point(0, 0);
		/// <summary>
		/// Точка, в которую ребра будут входить
		/// </summary>
		public virtual Point inPoint
		{
			get
			{
				Point buf = Parent.ConvertToCoords(Pos);
				return new Point(buf.X + inOffs.X, buf.Y + inOffs.Y);
			}
		}
		/// <summary>
		/// Точка, из которой ребра будут выходить
		/// </summary>
		public virtual Point outPoint
		{
			get
			{
				Point buf = Parent.ConvertToCoords(Pos);
				return new Point(buf.X + outOffs.X, buf.Y + outOffs.Y);
			}
		}
		/// <summary>
		/// Расстояние, на которое не доходит ребро до точки входа/выхода
		/// </summary>
		public int InOutOffs
		{
			get
			{
				return (Parent != null ? Convert.ToInt32(Parent.scale * inOutOffs) : inOutOffs);
			}
			set
			{
				inOutOffs = Convert.ToInt32(value / (Parent != null ? Parent.scale : 1));
			}
		}
		private int inOutOffs = 20;
		public bool IsConnected(TEdgeRegular edge)
		{
			int i;
			for (i = 0; i < bows.Count; i++)
				if (bows[i].IsConnected(edge))
					return true;
			return false;
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отображать как выделенную</param>
		public virtual void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[4];
			Point[] curve = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Отрисовка обычной круглой вершины с надписью - значением
			g.DrawEllipse(p, (float)(coords.X - 20 * scale), (float)(coords.Y - 20 * scale), (float)(40 * scale), (float)(40 * scale));
			//Выбор, чего будем писать на вершине - значение или комментарий
			buf = Parent.DrawDescr ? Text : Value.ToString(Parent.FormatString);
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Black, coords.X - Convert.ToInt32(Value.ToString(Parent.FormatString).Length * 4 * scale) + (Value.ToString(Parent.FormatString).Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
			
		}
		/// <summary>
		/// Вершины, с которыми соединена данная вершина
		/// </summary>
		/// <param name="i">Индекс вершины (дуги) в массиве</param>
		public TEdgeRegular this[int i]
		{
			get
			{
				if (bows.Count == 0) return null;
				return (bows[i].Edge1 == this ? bows[i].Edge2 : bows[i].Edge1);
			}
		}
		/// <summary>
		/// Вывод в строку основной информации о вершине
		/// </summary>
		public override string ToString()
		{
			string s = Type.ToString() + this.Pos.ToString() + " = " + Value.ToString(Parent.FormatString);
			return s;
		}

		/* GetNodePos() и SetNodePos()
		/// <summary>
		/// Задать положение вершины на сетке
		/// </summary>
		/// <param name="pos">Новые координаты на сетке.</param>
		public bool SetNodePos(Point pos)
		{
			if (Parent == null) return false;

			this.pos = pos;
			return true;
		}
		/// <summary>
		/// Считать положение вершины на сетке
		/// </summary>
		public Point GetNodePos()
		{
			return pos;
		}*/
		/* GetValue() и SetValue(). Авось понадобятся
		/// <summary>
		/// Задать значение вершины, если возможно. Если значение задать нельзя - вернет FALSE
		/// </summary>
		/// <param name="value">Новое значение</param>
		public bool SetValue(double value)
		{
			this.value = value;
			return true;
		}
		/// <summary>
		/// Получить значение вершины
		/// </summary>
		public double GetValue()
		{
			return value;
		}*/
		/* GetEdgeType()
		/// <summary>
		/// Получить тип вершины
		/// </summary>
		public EdgeTypes GetEdgeType()
		{
			return EdgeTypes.Regular;
		}*/
	}

	[Serializable]
	public class TEdgeOR: TEdgeRegular
	{
		//public override 
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		/// :base() - вызов конструктора родительского класса по умолчанию
		private TEdgeOR():base()
		{ }
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		/// :base(parent) - вызов конструктора родительского класса с параметром
		public TEdgeOR(TGraph parent):base(parent)
		{
			int buf = Convert.ToInt32(20 * Parent.scale);
			inOffs = new Point(0, buf - Convert.ToInt32(5 * Parent.scale));
			outOffs = new Point(0, -buf);
			InOutOffs = 0;
		}
		/// <summary>
		/// Считать тип вершины
		/// </summary>
		public override EdgeTypes Type
		{
			get
			{
				return EdgeTypes.OR;
			}
		}
		/// <summary>
		/// 1 - ( П(1-Pi), i=0~N-1 ) П - произведение, где Pi - значения вершин, дуги от которых входят в данную.
		/// </summary>
		public override double Value
		{
			get
			{
				int i;
				value = (BowsInCount > 0 ? 1 : 0);
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this)
						value *= (1 - this[i].Value);
				value = 1 - value;
				return value;
			}
			set { }
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отрисовать, как выделенную</param>
		public override void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[4];
			Point[] curve = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Левый прямо отрезок
			line[0].X = Convert.ToInt32(-16 * scale + coords.X);
			line[0].Y = coords.Y;
			line[1].X = Convert.ToInt32(-16 * scale + coords.X);
			line[1].Y = Convert.ToInt32(20 * scale + coords.Y);
			//Правй прямой отрезок
			line[2].X = Convert.ToInt32(16 * scale + coords.X);
			line[2].Y = Convert.ToInt32(20 * scale + coords.Y);
			line[3].X = Convert.ToInt32(16 * scale + coords.X);
			line[3].Y = coords.Y;
			//Нижняя арка
			curve[0] = line[1];
			curve[2] = line[2];
			curve[1].X = (curve[0].X + curve[2].X) / 2;
			curve[1].Y = Convert.ToInt32(15 * scale + coords.Y);
			g.DrawLine(p, line[0], line[1]);
			g.DrawLine(p, line[2], line[3]);
			g.DrawCurve(p, curve, 1);
			//Левая часть верхней арки
			curve[0] = line[0];
			curve[2].X = coords.X;
			curve[2].Y = Convert.ToInt32(coords.Y - 20 * scale);
			curve[1].X = Convert.ToInt32((curve[0].X + curve[2].X) / 2 - 2*scale);
			curve[1].Y = Convert.ToInt32((curve[0].Y + curve[2].Y) / 2 - scale);
			g.DrawCurve(p, curve, 1);
			//Правая часть верхней арки
			curve[0] = line[3];
			curve[1].X = Convert.ToInt32((curve[0].X + curve[2].X) / 2 + 2*scale);
			g.DrawCurve(p, curve, 1);

			//Выбор, чего будем писать на вершине - значение или комментарий
			buf = Parent.DrawDescr ? Text : Value.ToString(Parent.FormatString);
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Black, coords.X - Convert.ToInt32(Value.ToString(Parent.FormatString).Length * 4 * scale) + (Value.ToString(Parent.FormatString).Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
		}
	}
	/// <summary>
	/// Операторная вершина ИЛИ
	/// </summary>
	[Serializable]
	public class TEdgeXOR : TEdgeRegular
	{
		//public override 
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		/// :base() - вызов конструктора родительского класса по умолчанию
		private TEdgeXOR()
			: base()
		{ }
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		/// :base(parent) - вызов конструктора родительского класса с параметром
		public TEdgeXOR(TGraph parent)
			: base(parent)
		{
			int buf = Convert.ToInt32(20 * Parent.scale);
			inOffs = new Point(0, buf);
			outOffs = new Point(0, -buf);
			InOutOffs = 0;
		}
		/// <summary>
		/// Считать тип вершины
		/// </summary>
		public override EdgeTypes Type
		{
			get
			{
				return EdgeTypes.XOR;
			}
		}
		/// <summary>
		/// Максимальное из значений вершин, дуги от которых входят в данную.
		/// </summary>
		public override double Value
		{
			get
			{
				int i;
				value = 0;
				//Ищем первую попавшуюся входящую дугу
				if (BowsInCount > 0)
				{
					for (i = 0; i < bows.Count && bows[i].Head != this; i++) ;
					value = this[i].Value;
				}
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this && value < this[i].Value)
						value = this[i].Value;
				return value;
			}
			set { }
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отрисовать, как выделенную</param>
		public override void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[4];
			Point[] curve = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Левый прямо отрезок
			line[0].X = Convert.ToInt32(-16 * scale + coords.X);
			line[0].Y = coords.Y;
			line[1].X = Convert.ToInt32(-16 * scale + coords.X);
			line[1].Y = Convert.ToInt32(20 * scale + coords.Y);
			//Правй прямой отрезок
			line[2].X = Convert.ToInt32(16 * scale + coords.X);
			line[2].Y = Convert.ToInt32(20 * scale + coords.Y);
			line[3].X = Convert.ToInt32(16 * scale + coords.X);
			line[3].Y = coords.Y;
			//Нижняя арка
			curve[0] = line[1];
			curve[2] = line[2];
			curve[1].X = (curve[0].X + curve[2].X) / 2;
			curve[1].Y = Convert.ToInt32(15 * scale + coords.Y);
			g.DrawLines(p, line);
			g.DrawCurve(p, curve, 1);
			//Левая часть верхней арки
			curve[0] = line[0];
			curve[2].X = coords.X;
			curve[2].Y = Convert.ToInt32(coords.Y - 20 * scale);
			curve[1].X = Convert.ToInt32((curve[0].X + curve[2].X) / 2 - 2 * scale);
			curve[1].Y = Convert.ToInt32((curve[0].Y + curve[2].Y) / 2 - scale);
			g.DrawCurve(p, curve, 1);
			//Правая часть верхней арки
			curve[0] = line[3];
			curve[1].X = Convert.ToInt32((curve[0].X + curve[2].X) / 2 + 2 * scale);
			g.DrawCurve(p, curve, 1);

			//Выбор, чего будем писать на вершине - значение или комментарий
			buf = Parent.DrawDescr ? Text : Value.ToString(Parent.FormatString);
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Black, coords.X - Convert.ToInt32(Value.ToString(Parent.FormatString).Length * 4 * scale) + (Value.ToString(Parent.FormatString).Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
		}
	}
	/// <summary>
	/// Операторная вершина И
	/// </summary>
	[Serializable]
	public class TEdgeAND : TEdgeRegular
	{
		//public override 
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		/// :base() - вызов конструктора родительского класса по умолчанию
		private TEdgeAND()
			: base()
		{ }
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		/// :base(parent) - вызов конструктора родительского класса с параметром
		public TEdgeAND(TGraph parent)
			: base(parent)
		{
			int buf = Convert.ToInt32(20 * Parent.scale);
			inOffs = new Point(0, buf);
			outOffs = new Point(0, -buf);
			InOutOffs = 0;
		}
		/// <summary>
		/// Считать тип вершины
		/// </summary>
		public override EdgeTypes Type
		{
			get
			{
				return EdgeTypes.AND;
			}
		}
		/// <summary>
		/// Произведение значений вершин, дуги от которых входят в данную.
		/// </summary>
		public override double Value
		{
			get
			{
				int i;
				value = 1;
					
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this)
						value *= this[i].Value;
				return value;
			}
			set { }
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отрисовать, как выделенную</param>
		public override void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[4];
			Point[] curve = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Левый прямо отрезок
			line[0].X = Convert.ToInt32(-16 * scale + coords.X);
			line[0].Y = Convert.ToInt32(coords.Y - 10 * scale);
			line[1].X = line[0].X;
			line[1].Y = Convert.ToInt32(20 * scale + coords.Y);
			//Правй прямой отрезок
			line[2].X = Convert.ToInt32(16 * scale + coords.X);
			line[2].Y = line[1].Y;
			line[3].X = line[2].X;
			line[3].Y = line[0].Y;
			//Верхняя арка
			curve[0] = line[0];
			curve[2] = line[3];
			curve[1].X = coords.X;
			curve[1].Y = Convert.ToInt32(-20 * scale + coords.Y);
			g.DrawLines(p, line);
			g.DrawCurve(p, curve, 1);

			//Выбор, чего будем писать на вершине - значение или комментарий
			buf = Parent.DrawDescr ? Text : Value.ToString(Parent.FormatString);
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Black, coords.X - Convert.ToInt32(Value.ToString(Parent.FormatString).Length * 4 * scale) + (Value.ToString(Parent.FormatString).Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
		}
	}

	/// <summary>
	/// Операторная вершина И
	/// </summary>
	[Serializable]
	public class TEdgeMIN : TEdgeRegular
	{
		//public override 
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		/// :base() - вызов конструктора родительского класса по умолчанию
		private TEdgeMIN()
			: base()
		{ }
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		/// :base(parent) - вызов конструктора родительского класса с параметром
		public TEdgeMIN(TGraph parent)
			: base(parent)
		{
			int buf = Convert.ToInt32(20 * Parent.scale);
			inOffs = new Point(0, buf);
			outOffs = new Point(0, -buf);
			InOutOffs = 0;
		}
		/// <summary>
		/// Считать тип вершины
		/// </summary>
		public override EdgeTypes Type
		{
			get
			{
				return EdgeTypes.MIN;
			}
		}
		/// <summary>
		/// Минимальное из значений вершин, дуги от которых входят в данную.
		/// </summary>
		public override double Value
		{
			get
			{
				int i;
				value = 0;
				//Ищем первую попавшуюся входящую дугу
				if (BowsInCount > 0)
				{
					for (i = 0; i < bows.Count && bows[i].Head != this; i++) ;
					value = this[i].Value;
				}
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this && value > this[i].Value)
						value = this[i].Value;
				return value;
			}
			set { }
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отрисовать, как выделенную</param>
		public override void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Треугольник
			line[0].X = Convert.ToInt32(-16 * scale + coords.X);
			line[0].Y = Convert.ToInt32(coords.Y + 20 * scale);
			line[1].X = Convert.ToInt32(16 * scale + coords.X);
			line[1].Y = line[0].Y;
			line[2].X = coords.X;
			line[2].Y = Convert.ToInt32(-20 * scale + coords.Y);
			g.DrawPolygon(p, line);

			//Выбор, чего будем писать на вершине - значение или комментарий
			buf = Parent.DrawDescr ? Text : Value.ToString(Parent.FormatString);
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Black, coords.X - Convert.ToInt32(Value.ToString(Parent.FormatString).Length * 4 * scale) + (Value.ToString(Parent.FormatString).Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
		}
	}

	/// <summary>
	/// Операторная вершина СУММА
	/// </summary>
	[Serializable]
	public class TEdgeSUM : TEdgeRegular
	{
		//public override 
		/// <summary>
		/// Конструктор закрытый, ибо нефиг вершины без графа создавать
		/// </summary>
		/// :base() - вызов конструктора родительского класса по умолчанию
		private TEdgeSUM()
			: base()
		{ }
		/// <summary>
		/// Создает новую вершину графа
		/// </summary>
		/// <param name="parent">Родительский граф. Его настройки будут использованы для отображения вершины. В сам граф вершину надо добавить вручную</param>
		/// :base(parent) - вызов конструктора родительского класса с параметром
		public TEdgeSUM(TGraph parent)
			: base(parent)
		{ }
		/// <summary>
		/// Считать тип вершины
		/// </summary>
		public override EdgeTypes Type
		{
			get
			{
				return EdgeTypes.SUM;
			}
		}
		/// <summary>
		/// Сумма значений вершин, дуги от которых входят в данную.
		/// </summary>
		public override double Value
		{
			get
			{
				int i;
				value = 0;
				//Ищем первую попавшуюся входящую дугу
				for (i = 0; i < bows.Count; i++)
					if (bows[i].Head == this)
						value += this[i].Value;
				return value;
			}
			set { }
		}
		/// <summary>
		/// Отрисовка вершины на объекте графики
		/// </summary>
		/// <param name="g">Целевой объект графики</param>
		/// <param name="selected">Отрисовать, как выделенную</param>
		public override void Draw(Graphics g, bool selected)
		{
			double scale = (Parent == null ? 1 : Parent.scale);
			Pen p = (selected ? new Pen(Color.Blue, 2) : new Pen(Color.Black, 1));
			int i;
			Point[] line = new Point[4];
			Point[] curve = new Point[3];
			string buf;
			//Получаем точку размещения вершины на области редактирования
			Point coords = Parent.ConvertToCoords(Pos);

			//Отрисовка обычной круглой вершины с надписью - значением
			g.DrawEllipse(p, (float)(coords.X - 20 * scale), (float)(coords.Y - 20 * scale), (float)(40 * scale), (float)(40 * scale));
			//Выбор, чего будем писать на вершине - значение или комментарий
			if (!Parent.DrawDescr)
			{
				if (bows.Count > 0)
					buf = "S=" + Value.ToString(Parent.FormatString);
				else
					buf = Type.ToString();
			}
			else
			{
				buf = Text;
			}
			//Отрисовка надписи на вершине
			g.DrawString(buf, new Font("Arial", Convert.ToInt32(10 * scale)), Brushes.Blue, coords.X - Convert.ToInt32(buf.Length * 4 * scale) + (buf.Contains(",") ? Convert.ToInt32(4 * scale) : 0), coords.Y - Convert.ToInt32(6 * scale));
			//Отрисовка дуг
			for (i = 0; i < bows.Count; i++)
				bows[i].Draw(g, bows[i].Head == this && selected);
		}
	}
}
