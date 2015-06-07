using CoordinateSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CoordinateSystemUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TPolygonTest and is intended
    ///to contain all TPolygonTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TPolygonTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///Тест на принадлежность точки сторонам полигона
		///</summary>
		[TestMethod()]
		public void TPolygon_PointIsOnFigureTest()
		{
			float[] xy = { 1, 1, 5, 3, 3, 6, 1, 3 };
			TPolygon target = new TPolygon(-1, 3, xy);
			PointF point;
			bool expected;
			bool actual;

			point = new PointF(2, 3);	//A
			expected = false;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(3, 2);	//B
			expected = true;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(1, 6);	//C
			expected = false;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(3, 1);	//D
			expected = false;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(-1, 1);	//E
			expected = false;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(-2, 3);	//F
			expected = false;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(0, 3);	//G
			expected = true;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(2, (float)4.5);	//H
			expected = true;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");

			point = new PointF(-1, 3);	//I
			expected = true;
			actual = target.PointIsOnFigure(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит сторонам полигона");
		}

		/// <summary>
		///Тест на принадлежность точки полигону в целом
		///</summary>
		[TestMethod()]
		public void TPolygon_PointIsInsideTest()
		{
			float[] xy = { 1, 1, 5, 3, 3, 6, 1, 3 };
			TPolygon target = new TPolygon(-1, 3, xy);
			PointF point;
			bool expected;
			bool actual;

			point = new PointF(2, 3);
			expected = true;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(3, 2);
			expected = true;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(1, 6);
			expected = false;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(3, 1);
			expected = false;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(-1, 1);
			expected = false;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(-2, 3);
			expected = false;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(0, 3);
			expected = true;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");

			point = new PointF(2, (float)4.5);
			expected = true;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual, "Ожидалось, что точка " + point + (expected ? " " : " не ") + "принадлежит полигону");
		}

		/// <summary>
		///A test for TPolygon Constructor
		///</summary>
		[TestMethod()]
		public void TPolygon_ConstructorTest()
		{
			float[] xy = { 1, 1, 5, 3, 3, 6, 1, 3 };
			TPolygon target = new TPolygon(-1, 3, xy);

			target = new TPolygon(-1, 3, 1, 1, 5, 3, 3, 6, 1, 3, 0);

			Assert.Inconclusive("Данный тест предназначен исключительно для режима DEBUG");
		}
	}
}
