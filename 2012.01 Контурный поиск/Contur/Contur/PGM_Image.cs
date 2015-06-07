using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Image_PGM
{
	public class PGM_Image
	{
		#region Поля
		private int width = -1;
		private int height = -1;
		private byte maxGrey = 0;
		private string comment = "Created by Mrak";
		private byte[] image;
		private string format = "P5";
		#endregion

		#region Свойства
		/// <summary>
		/// Размер изображения по горизонтали
		/// </summary>
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
				this.image = new byte[this.height * this.width];
			}
		}

		/// <summary>
		/// Размер изображения по вертикали
		/// </summary>
		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
				this.image = new byte[this.height * this.width];
			}
		}

		/// <summary>
		/// Максимальное значение градаций серого
		/// </summary>
		public byte MaxGrey 
		{
			get 
			{
				return this.maxGrey;
			}
			set
			{
				this.maxGrey = value;
			}
		}

		/// <summary>
		/// Комментарий к изображению
		/// </summary>
		public string Comment
		{
			get
			{
				return this.comment;
			}
			set
			{
				this.comment = value;
			}
		}

		/// <summary>
		/// Получить строку комментария для записи в файл.
		/// </summary>
		private string CommentToFile
		{
			get { return (this.comment != null && this.Comment.Length > 0 ? "#" + this.Comment.Replace("\n", "\n#") : ""); }
		}

		/// <summary>
		/// Получить байт изображения по координатам
		/// </summary>
		/// <param name="x">Горизонтальная координата</param>
		/// <param name="y">Вертикальная координата</param>
		public byte this[int x, int y]
		{
			get 
			{
				if (x < this.Width && x >= 0 && y < this.Height && y >= 0)
				{
					return image[y * this.width + x];
				}
				else
					return 0;
			}
			set
			{
				if (x < this.Width && x >= 0 && y < this.Height && y >= 0)
				{
					image[y * this.width + x] = value;
				}
			}
		}

		#endregion

		#region Конструкторы
		public PGM_Image(string filename)
		{
			this.LoadFromFile(filename);
		}

		public PGM_Image(PGM_Image sample)
		{
			this.height = sample.Height;
			this.width = sample.Width;
			this.maxGrey = sample.MaxGrey;
			this.image = new byte[height * width];
		}

		/// <summary>
		/// Создать пустое изображение с заданными параметрами
		/// </summary>
		/// <param name="width">Ширина</param>
		/// <param name="height">Высота</param>
		/// <param name="maxGrey">Максимальное значение градации серого</param>
		/// <param name="cacheSize">Размер кеша в памяти для хранения файла. Если &lt;0,
		/// выбирается автоматически под размер всего файла.</param>
		public PGM_Image(int width, int height, byte maxGrey)
		{ 
		}
		#endregion

		#region Методы работы с файлами
		/// <summary>
		/// Загрузить изображение из файла
		/// </summary>
		/// <param name="filename">Имя файла, в котором содержится PGM-изображение</param>
		public void LoadFromFile(string filename)
		{
			FileStream file = new FileStream(filename, FileMode.Open);

			BinaryReader br = new BinaryReader(file);
			string buf;

			//Считываем строку с описанием формата
			buf = ReadLine(br);
			this.format = buf;

			//Читаем комментарии
			buf = ReadLine(br);
			this.Comment = "";
			while (buf.Length == 0 || buf[0] == '#')
			{
				if (buf.Length > 0)
					this.Comment = this.Comment + buf.Remove(0, 1) + "\n";
				buf = ReadLine(br);
			}
			if (this.Comment.Length > 0)
				this.Comment = this.Comment.Remove(this.Comment.Length - 1);

			//Читаем размеры изображения (предположительно, они уже в buf)
			string[] separators = { " " };
			string[] size = buf.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			if (size != null && size.Length == 2)
			{
				this.width = int.Parse(size[0]);
				this.height = int.Parse(size[1]);
			}
			else
				throw new Exception("Не могу прочитать размеры изображения из файла.");
			
			//Читаем градации серого
			buf = ReadLine(br);
			this.MaxGrey = byte.Parse(buf);

			//Находим позицию начала данных вручную

			this.image = br.ReadBytes(this.width * this.height);
			br.Close();
		}

		/// <summary>
		/// Сохранить изображение в файл
		/// </summary>
		/// <param name="filename">Имя файла</param>
		public void SaveToFile(string filename)
		{
			int i;
			FileStream file = new FileStream(filename, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(file);
			string buf = this.ToString();

			for (i = 0; i < buf.Length; i++)
				bw.Write(buf[i]);
            //bw.Write(buf); - Этот вариант пихает в начало файла какой-то левый символ. Редиска.
            bw.Write(this.image);
			bw.Close();
		}

		public override string ToString()
		{
			string buf = "";
			buf = format + "\n" + this.CommentToFile + "\n" + this.Width + " " + this.Height
				+ "\n" + this.MaxGrey + "\n";
			return buf;
		}
		#endregion

		#region Вспомогательные методы
		/// <summary>
		/// Читает строку из потока до символа \n, не прибегая к кешированию содержимого потока.
		/// </summary>
		/// <param name="br">Из чего читаем.</param>
		/// <returns></returns>
		string ReadLine(BinaryReader br)
		{
			//Да, я в курсе, что это можно сделать при помощи StreamReader,
			//но он, паскуда, кеширует содержимое потока и нефигово сдвигает указатель
			//позиции, после чего выяснить, где собственно он закончил чтение
			//не представляется возможным.
			char c = 'a';
			string buf = "";
			c = br.ReadChar();
			while (c != '\n')
			{
				buf = buf + c;
				c = br.ReadChar();
			}
			return buf;
		}
		#endregion

		#region Методы работы с графикой

		public void Draw(Graphics g)
		{
			int i, j;
			//g.Clear(Color.Black);
			Pen gray = new Pen(Color.FromArgb(255, 255, 255, 255));
			for (i = 0; i < this.height - 1; i++)
				for (j = 0; j < this.width - 1; j++)
				{
					gray.Color = Color.FromArgb(255, this[j, i], this[j, i], this[j, i]);
					g.DrawLine(gray, j, i, j+1, i+1);
				}
		}

		#endregion
	}
}
