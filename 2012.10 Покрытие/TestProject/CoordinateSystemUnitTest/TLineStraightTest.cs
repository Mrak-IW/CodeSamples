using CoordinateSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System;

namespace CoordinateSystemUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TLineStraightTest and is intended
    ///to contain all TLineStraightTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TLineStraightTest
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
		///A test for PointIsOnFigure
		///</summary>
		[TestMethod()]
		public void TLineStraight_PointIsOnFigureTest()
		{
			Assert.Inconclusive("Verify the correctness of this test method.");
			TSegment segment = null; // TODO: Initialize to an appropriate value
			TLineStraight target = new TLineStraight(segment); // TODO: Initialize to an appropriate value
			PointF pt = new PointF(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///Тест для создания линии по двум точкам, заданным объектами PointF
		///</summary>
		[TestMethod()]
		public void TLineStraight_ConstructorTest()
		{
			//Вертикальная линия
			float buf;
			PointF pt1 = new PointF(2, 0);
			PointF pt2 = new PointF(2, -4);
			TLineStraight target = new TLineStraight(pt1, pt2);
			Assert.AreEqual(0, target.B, "Множитель при Y не соответствует ожиданиям.");
			buf = target.GetX(10);
			Assert.AreEqual(2, buf, "X не равен ожидаемому результату");
			//Assert.Inconclusive("TODO: Implement code to verify target");

			//Линия под 45 градусов
			pt1 = new PointF(0, 0);
			pt2 = new PointF(10, 10);
			target = new TLineStraight(pt1, pt2);
			buf = target.A / target.B;
			Assert.AreEqual(-1, buf, "В прямой под 45 градусов, коэфициенты при X и Y должны быть одинаковы по модулю, но противоположны по знаку. A = " + target.A + "; B = " + target.B + "; C = " + target.C);

			//Горизонтальная линия
			pt1 = new PointF(0, 0);
			pt2 = new PointF(10, 0);
			target = new TLineStraight(pt1, pt2);
			Assert.AreEqual(0, target.A, "Множитель при X не соответствует ожиданиям.");
			buf = target.GetY(10);
			Assert.AreEqual(0, buf, "Y не равен ожидаемому результату");
		}

		/// <summary>
		///Тест на получение перпендикуляра к прямой из заданной точки
		///</summary>
		[TestMethod()]
		public void TLineStraight_GetPerpendicularTest()
		{
			TLineStraight target;
			PointF point;
			TLineStraight expected;
			TLineStraight actual;
			float coef;	//Здесь будут соотношения коэфициентов уравнений прямой и перпендикуляра

			//Общий случай
			target = new TLineStraight(1, 0, 4, 2);
			point = new PointF(2, 5);
			expected = new TLineStraight(2, 5, 4, 2);
			actual = target.GetPerpendicular(point);
			coef = actual.A / expected.A;
			if (!float.IsNaN(coef))
			{
				Assert.AreEqual(expected.B, actual.B / coef, "Отношения соответствующих коэфициентов должны быть одинаковыми");
			}
			else
			{
				coef = actual.B / expected.B;
			}
			Assert.AreEqual(expected.C, actual.C / coef, "Отношения соответствующих коэфициентов должны быть одинаковыми");

			//Прямая горихзонтальна
			target = new TLineStraight(0, 2, 4, 2);
			point = new PointF(2, 5);
			expected = new TLineStraight(2, 5, 2, 0);
			actual = target.GetPerpendicular(point);
			coef = actual.A / expected.A;
			if (!float.IsNaN(coef))
			{
				Assert.AreEqual(expected.B, actual.B / coef , "Отношения соответствующих коэфициентов должны быть одинаковыми");
			}
			else
			{
				coef = actual.B / expected.B;
			}
			Assert.AreEqual(expected.C, actual.C / coef, "Отношения соответствующих коэфициентов должны быть одинаковыми");

			//Прямая вертикальна
			target = new TLineStraight(4, 0, 4, 2);
			point = new PointF(2, 5);
			expected = new TLineStraight(2, 5, 4, 5);
			actual = target.GetPerpendicular(point);
			coef = actual.A / expected.A;
			if (!float.IsNaN(coef))
			{
				Assert.AreEqual(expected.B, actual.B / coef, "Отношения соответствующих коэфициентов должны быть одинаковыми");
			}
			else
			{
				coef = actual.B / expected.B;
			}
			Assert.AreEqual(expected.C, actual.C / coef, "Отношения соответствующих коэфициентов должны быть одинаковыми");
		}

		/// <summary>
		/// Тест на определение точки на прямой, ближайшей к заданной точке.
		///</summary>
		[TestMethod()]
		public void TLineStraight_GetNearestPointTest()
		{
			TLineStraight target;
			PointF point;
			PointF expected;
			PointF actual;

			//Общий случай
			target = new TLineStraight(1, 0, 4, 2);
			point = new PointF(2, 5);
			expected = new PointF(4, 2);
			actual = target.GetNearestPoint(point);
			Assert.AreEqual(expected, actual);

			//Прямая горизонтальна
			target = new TLineStraight(0, 2, 4, 2);
			point = new PointF(2, 5);
			expected = new PointF(2, 2);
			actual = target.GetNearestPoint(point);
			Assert.AreEqual(expected, actual);

			//Прямая вертикальна
			target = new TLineStraight(4, 0, 4, 2);
			point = new PointF(2, 5);
			expected = new PointF(4, 5);
			actual = target.GetNearestPoint(point);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест на определение расстояния от прямой до точки
		///</summary>
		[TestMethod()]
		public void TLineStraight_GetDistanceTest()
		{
			TLineStraight target;
			PointF point;
			float expected;
			float actual;

			//Общий случай
			target = new TLineStraight(1, 0, 4, 2);
			point = new PointF(2, 5);
			expected = (float)Math.Sqrt(4 + 9);
			actual = target.GetDistance(point);
			Assert.AreEqual(expected, actual);

			//Прямая горизонтальна
			target = new TLineStraight(0, 2, 4, 2);
			point = new PointF(2, 5);
			expected = 3;
			actual = target.GetDistance(point);
			Assert.AreEqual(expected, actual);

			//Прямая вертикальна
			target = new TLineStraight(4, 0, 4, 2);
			point = new PointF(2, 5);
			expected = 2;
			actual = target.GetDistance(point);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetPerpendicular
		///</summary>
		[TestMethod()]
		public void GetPerpendicularTest1()
		{
			TLineStraight target;
			PointF point;
			PointF actualCross;
			PointF expectedCross;
			TLineStraight perp;

			//Общий случай
			target = new TLineStraight(1, 0, 4, 2);
			point = new PointF(2, 5);
			expectedCross = new PointF(4, 2);
			perp = target.GetPerpendicular(point);
			TTests.IsCrossing(target, perp, out actualCross);
			Assert.AreEqual(expectedCross, actualCross);

			//Прямая горизонтальна
			target = new TLineStraight(0, 2, 4, 2);
			point = new PointF(2, 5);
			expectedCross = new PointF(2, 2);
			perp = target.GetPerpendicular(point);
			TTests.IsCrossing(target, perp, out actualCross);
			Assert.AreEqual(expectedCross, actualCross);

			//Прямая вертикальна
			target = new TLineStraight(4, 0, 4, 2);
			point = new PointF(2, 5);
			expectedCross = new PointF(4, 5);
			perp = target.GetPerpendicular(point);
			TTests.IsCrossing(target, perp, out actualCross);
			Assert.AreEqual(expectedCross, actualCross);

			//Точка находится на прямой
			target = new TLineStraight(1, 0, 4, 2);
			point = new PointF(4, 2);
			expectedCross = new PointF(4, 2);
			perp = target.GetPerpendicular(point);
			TTests.IsCrossing(target, perp, out actualCross);
			Assert.AreEqual(expectedCross, actualCross);
		}
	}
}
