using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GraphEditor
{
	[Serializable]
	public class TGraph
	{
		/// <summary>
		/// Высота сетки графа по-умолчанию
		/// </summary>
		const int DEF_HEIGHT = 7;
		/// <summary>
		/// Ширина сетки графа по-умолчанию
		/// </summary>
		const int DEF_WIDTH = 7;
		/// <summary>
		/// Если это значение равно TRUE, то вместо числовых значений вершин на графе будут отображаться их описания
		/// </summary>
		public bool DrawDescr = false;
		/// <summary>
		/// Это поле может использоваться для выведения текста подсказки для графа. Сюда записывается текст вершины.
		/// </summary>
		public string hint;
		/// <summary>
		/// Масштаб, в котором отображаются вершины
		/// </summary>
		public double scale = 1;
		/// <summary>
		/// Шаг сетки для вершин по оси X
		/// </summary>
		public int stepX = 50;
		/// <summary>
		/// Шаг сетки для вершин по оси Y
		/// </summary>
		public int stepY = 50;
		/// <summary>
		/// Смещение графа вниз
		/// </summary>
		public int yOffs = 300;
		//Так объявляется встроенный список из элементов типа TEdgeRegular. Сейчас он пуст
		/// <summary>
		/// Список вершин графа
		/// </summary>
		private List<TEdgeRegular> arr = new List<TEdgeRegular>();
		/// <summary>
		/// Список выбранных вершин графа
		/// </summary>
		public List<TEdgeRegular> selected = new List<TEdgeRegular>();
		//Это - свойство
		/// <summary>
		/// Количество вершин графа
		/// </summary>
		public int Count
		{
			//Получаем значение свойства
			get
			{
				return arr.Count;
			}
		}
		//Индексатор. Теперь можно обращаться к вершине графа, как graph[i]
		/// <summary>
		/// Получаем вершину графа по индексу
		/// </summary>
		/// <param name="i">индекс</param>
		/// <returns></returns>
		public TEdgeRegular this[int i]
		{
			get 
			{
				if (i >= Count)
					throw new Exception("Столько вершин в графе нет");
				return arr[i];
			}
		}
		/// <summary>
		/// Конвертирует координаты на поле редактирования в координаты на сетке
		/// </summary>
		/// <param name="coords"></param>
		public Point ConvertToNodePos(Point coords)
		{
			Point res = new Point(coords.X, coords.Y);
			//Разворот на 180 по Y и смещение
			res.Y = yOffs - res.Y;
			//Преобразование в координаты сетки
			res.Y = Convert.ToInt32((res.Y - stepY + (stepY / 2) * scale) / (stepY * scale));
			res.X = Convert.ToInt32((res.X - stepY + (stepX / 2) * scale) / (stepX * scale));

			if (res.Y < 0) res.Y = 0;
			if (res.X < 0) res.X = 0;
			if (res.Y >= height) res.Y = height - 1;
			if (res.X >= width) res.X = width - 1;
			return res;
		}
		/// <summary>
		/// Конвертирует координаты на сетке в координаты на поле редактирования
		/// </summary>
		/// <param name="coords"></param>
		public Point ConvertToCoords(Point nodePos)
		{
			Point res = new Point(nodePos.X, nodePos.Y);
			
			//Преобразование в координаты сетки
			res.X = Convert.ToInt32((stepX / 2) * scale + res.X * stepX * scale);
			res.Y = Convert.ToInt32((stepY / 2) * scale + res.Y * stepY * scale);

			//Разворот на 180 по Y и смещение
			res.Y = yOffs - res.Y;
			return res;
		}
		/// <summary>
		/// Размер графа в пикселях.
		/// </summary>
		public Point SizeInPixels
		{
			get
			{
				return new Point(Width * stepX, Height * stepY);
			}
		}
		/// <summary>
		/// Высота сетки для отображения графа (количество узлов)
		/// </summary>
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				int max = HeightMin;
				height = max > value ? max : value;
			}
		}
		private int height = DEF_HEIGHT;
		/// <summary>
		/// Минимальная высота сетки для отображения графа (координата самой верхней вершины + 1)
		/// </summary>
		public int HeightMin
		{
			get
			{
				if (Count == 0) return DEF_HEIGHT;

				int i, max = arr[0].Pos.Y;
				for (i = 1; i < Count; i++)
				{
					if (arr[i].Pos.Y > max)
						max = arr[i].Pos.Y;
				}
				return max + 1;
			}
		}
		/// <summary>
		/// Ширина сетки для отображения графа (количество узлов)
		/// </summary>
		public int Width
		{
			get
			{
				
				return width;
			}
			set
			{
				int max = WidthMin;
				width = max > value ? max : value;
			}
		}
		private int width = DEF_WIDTH;
		/// <summary>
		/// Минимальная ширина сетки для отображения графа (координата самой правой вершины + 1)
		/// </summary>
		public int WidthMin
		{
			get
			{
				if (Count == 0) return DEF_WIDTH;

				int i, max = arr[0].Pos.X;
				for (i = 1; i < Count; i++)
				{
					if (arr[i].Pos.X > max)
						max = arr[i].Pos.X;
				}
				return max + 1;
			}
		}
		/// <summary>
		/// Добавить вершину в граф
		/// </summary>
		/// <param name="coords">Позиция на области редактирования, куды пользователь ткнул, либо просто поместить вершину нужно</param>
		public void AddEdge(Point coords, string text, EdgeTypes type, double value)
		{
			TEdgeRegular e;
			switch (type)
			{
				case EdgeTypes.Regular:
					e = new TEdgeRegular(this);
					break;
				case EdgeTypes.OR:
					e = new TEdgeOR(this);
					break;
				case EdgeTypes.XOR:
					e = new TEdgeXOR(this);
					break;
				case EdgeTypes.AND:
					e = new TEdgeAND(this);
					break;
				case EdgeTypes.MIN:
					e = new TEdgeMIN(this);
					break;
				case EdgeTypes.SUM:
					e = new TEdgeSUM(this);
					break;
				default:
					throw new Exception("Попытка создать вершину неопознанного типа: \"" + type.ToString()+"\"");
			}
			//Задаем координаты вершины
			e.Pos = ConvertToNodePos(coords);
			if (e == null)
				throw new Exception("Добавляемая вершина не создана и имеет значение null");
			int i;
			for (i = 0; i < Count; i++)
				if (arr[i].Pos == e.Pos)
					throw new Exception("Добавляемая вершина полностью совпадает по координатам с уже имеющейся. Больше так не делай :)");
			e.Parent = this;
			e.Value = value;
			e.Text = text;
			arr.Add(e);
		}
		/// <summary>
		/// Заменить вершину на вершину другого типа (если новый тип не совпадает с типом вершины), с сохранением значения (если возможно), описания и всех связей
		/// </summary>
		/// <param name="edge">Ссылка на вершину</param>
		/// <param name="type">Новый тип вершины</param>
		public void ChangeType(TEdgeRegular edge, EdgeTypes type)
		{
			int i;
			//Если тип подходит, не заморачиваемся.
			if (edge.Type == type) return;

			TEdgeRegular e;
			switch (type)
			{
				case EdgeTypes.Regular:
					e = new TEdgeRegular(this);
					break;
				case EdgeTypes.OR:
					e = new TEdgeOR(this);
					break;
				case EdgeTypes.XOR:
					e = new TEdgeXOR(this);
					break;
				case EdgeTypes.AND:
					e = new TEdgeAND(this);
					break;
				case EdgeTypes.MIN:
					e = new TEdgeMIN(this);
					break;
				default:
					throw new Exception("Попытка создать вершину неопознанного типа: \"" + type.ToString() + "\"");
			}
			arr.Add(e);
			e.Value = edge.Value;
			e.Pos = edge.Pos;
			e.Text = edge.Text;
			TEdgeRegular edge1, edge2;
			for (i = 0; i < edge.bows.Count; i++)
			{
				edge1 = edge.bows[i].Edge1 == edge ? e : edge.bows[i].Edge1;
				edge2 = edge.bows[i].Edge2 == edge ? e : edge.bows[i].Edge2;
				AddBow(edge1, edge2, edge.bows[i].Type, edge.bows[i].value);
			}
			e.Parent = edge.Parent;

			for (i = 0; i < e.bows.Count; i++)
			{
				if (e.bows[i].Edge1 == edge)
					e.bows[i].Edge1 = e;
				if (e.bows[i].Edge2 == edge)
					e.bows[i].Edge2 = e;
				if (e.bows[i].Head == edge)
					throw new Exception("Стрелка дуги указывает на удаляемую вершину");
			}
			DelEdge(edge);
			if (selected.Contains(edge))
			{
				selected.Insert(selected.IndexOf(edge), e);
				selected.Remove(edge);
			}
			//arr.Add(e);
		}
		/// <summary>
		/// Добавление дуги между двумя вершинами. Если хотя-бы одна из вершин в графе не содержится, вернет FALSE
		/// </summary>
		/// <param name="e1">Первый конец дуги</param>
		/// <param name="e2">Второй конец дуги</param>
		/// <param name="type">Направленность дуги</param>
		/// <param name="value">Вес дуги</param>
		public bool AddBow(TEdgeRegular e1, TEdgeRegular e2, BowTypes type, double value)
		{
			if (!arr.Contains(e1) || !arr.Contains(e2) || e1.IsConnected(e2) || e2.IsConnected(e1))
				return false;
			TBow bow = new TBow(e1, e2, type, value);
			return true;
		}
		/// <summary>
		/// Отрисовать граф на объекте графики GraphicsObj, инициализированном ранее
		/// </summary>
		public void Draw(Graphics g, Point pos)
		{
			int i;
			yOffs = pos.Y;
			if (g == null)
				throw new Exception("Не инициализирован объект графики, на котором отрисовывается граф");
			Pen p_Black2 = new Pen(Color.Black, 2);

			for (i = 0; i < Count; i++)
			{
				this.arr[i].Draw(g, false);
			}
		}

		/// <summary>
		/// Отрисовать граф на объекте графики GraphicsObj, инициализированном ранее
		/// </summary>
		public void DrawSelected(Graphics g)
		{
			int i;

			if (g == null)
				throw new Exception("Не инициализирован объект графики, на котором отрисовывается граф");
			Pen p_Black2 = new Pen(Color.Black, 2);

			for (i = 0; selected!=null && i < selected.Count; i++)
			{
				selected[i].Draw(g, true);
			}
		}

		/// <summary>
		/// Добавляет вершину в выбранные, либо убирает ее из выбранных
		/// </summary>
		/// <param name="pos">Приблизительные координаты вершины</param>
		public void SelectDeselect(Point pos)
		{
			TEdgeRegular buf = FindByCoords(pos);
			if (buf != null)
			{
				if (selected.Contains(buf))
					selected.Remove(buf);
				else
					selected.Add(buf);
			}
		}

		/// <summary>
		/// Добавляет вершину в выбранные, либо убирает ее из выбранных
		/// </summary>
		/// <param name="edge">Вершина</param>
		public void SelectDeselect(TEdgeRegular edge)
		{
			if (edge != null)
			{
				if (selected.Contains(edge))
					selected.Remove(edge);
				else
					selected.Add(edge);
			}
		}

		/// <summary>
		/// Находит вершину в графе по ее приблизительным координатам
		/// </summary>
		/// <param name="pos">Координаты. Точка, куда ткнули мышью.</param>
		/// <returns></returns>
		public TEdgeRegular FindByCoords(Point pos)
		{
			TEdgeRegular res = null;
			int i;
			Point buf;

			for (i = 0; i < Count; i++)
			{
				buf = ConvertToCoords(arr[i].Pos);
				if ((pos.X - buf.X) * (pos.X - buf.X) + (pos.Y - buf.Y) * (pos.Y - buf.Y) <= 400 * scale * scale)
					res = arr[i];
			}
			return res;
		}
		/// <summary>
		/// Находит вершину в графе по ее позиции на сетке
		/// </summary>
		/// <param name="pos">Позиция на сетке</param>
		/// <returns></returns>
		public TEdgeRegular FindByPos(Point pos)
		{
			TEdgeRegular res = null;
			int i;

			for (i = 0; i < Count; i++)
			{
				if (pos.X == arr[i].Pos.X && pos.Y == arr[i].Pos.Y)
					res = arr[i];
			}
			return res;
		}
		/// <summary>
		/// Удаляет заданную вершину из графа (если она там есть, конечно)
		/// </summary>
		/// <param name="edge">Удаляемая вершина</param>
		public void DelEdge(TEdgeRegular edge)
		{
			try
			{
				int i;
				//Очистка связей вершины
				for (i = 0; i < edge.bows.Count; i++)
				{
					//Отсоединяем дугу со стороны другой вершины
					edge[i].bows.Remove(edge.bows[i]);
				}
				//Очищаем список дуг, на всякий случай
				edge.bows.Clear();
				//Удаляем вершину из графа
				arr.Remove(edge);
				//if (selected.Contains(edge))
				//	selected.Remove(edge);
			}
			catch
			{
				throw new Exception("Удаляемая вершина в графе отсутствует");
			}
		}

		/// <summary>
		/// Удаляет из графа все вершины, которые вошли в список выбранных
		/// </summary>
		public void DelSelected()
		{
			int i;
			for (i = 0; i < selected.Count; i++)
			{
				DelEdge(selected[i]);
			}
			selected.Clear();
		}

		/// <summary>
		/// Сохранение графа в бинарный файл
		/// </summary>
		/// <param name="FileName"></param>
		public void SaveToFile(string FileName)
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream
			   (FileName, FileMode.Create, FileAccess.Write);
			bf.Serialize(fs, this);
			fs.Close();
		}

		/// <summary>
		/// Создает граф, загружая его из файла
		/// </summary>
		/// <param name="fisher"></param>
		static public TGraph LoadFromFile(string FileName)
		{
			TGraph graph;
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream
			   (FileName, FileMode.Open, FileAccess.Read);
			graph = (TGraph)bf.Deserialize(fs);
			fs.Close();
			return graph;
		}

        /// <summary>
        /// Строка формата для числовых значений вершин
        /// </summary>
        private string formatString;

        /// <summary>
        /// Строка формата для числовых значений вершин
        /// </summary>
        public string FormatString
        {
            get
            {
                return this.formatString == null ? "" : this.formatString;
            }
            set
            {
                this.formatString = value;
            }
        }
	}
}
