using CoordinateSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace CoordinateSystemUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TTestsTest and is intended
    ///to contain all TTestsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TTestsTest
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
		///Тест на пересечение луча и отрезка
		///</summary>
		[TestMethod()]
		public void TTests_IsRayCrossingSegmentTest()
		{
			PointF begin = new PointF(1, 3);
			PointF vector = new PointF(1, -2);
			TRay ray = new TRay(begin, vector);
			TSegment segment;
			PointF cp;
			PointF cpExpected;
			bool expected;
			bool actual;

			segment = new TSegment(-2, 4, 2, 6);
			cpExpected = new PointF(0, 5);
			expected = false;
			actual = TTests.IsCrossing(ray, segment, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(1, 1, 4, 1);
			cpExpected = new PointF(2, 1);
			expected = true;
			actual = TTests.IsCrossing(ray, segment, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(0, 5, 2, 1);
			cpExpected = new PointF(float.NaN, float.NaN);
			expected = false;
			actual = TTests.IsCrossing(ray, segment, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!float.IsNaN(cp.X) || !float.IsNaN(cp.Y))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(2, -3, 3, -1);
			cpExpected = new PointF(3, -1);
			expected = true;
			actual = TTests.IsCrossing(ray, segment, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(6, 1, 3, -1);
			cpExpected = new PointF(3, -1);
			expected = true;
			actual = TTests.IsCrossing(ray, segment, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}
		}

		/// <summary>
		///Тест на пересечение двух отрезков
		///</summary>
		[TestMethod()]
		public void TTests_IsSegmentCrossingSegmentTest()
		{
			PointF A = new PointF(2, 4);
			PointF B = new PointF(7, 4);
			PointF C = new PointF(1, 6);
			PointF D = new PointF(3, 2);
			PointF E = new PointF(10, 6);
			PointF F = new PointF(6, 6);
			PointF G = new PointF(3, 0);
			PointF H = new PointF(6, 4);
			PointF I = new PointF(10, 4);
			PointF J = new PointF(5, 2);
			PointF J1 = new PointF(4, 4);
			PointF K = new PointF(8, 2);
			PointF L = new PointF(1, 2);
			PointF L1 = new PointF(0, 4);
			PointF M = new PointF(2, 0);
			PointF N = new PointF(7, -2);
			PointF O = new PointF(5, 4);
			PointF NaN = new PointF(float.NaN, float.NaN);
		
			TSegment target = new TSegment(A, B);
			TSegment segment;
			PointF cpActual;
			PointF cpExpected;
			bool expected;
			bool actual;

			//Отрезок пересекает заданный в одном из его концов
			segment = new TSegment(C, D);
			expected = true;
			cpExpected = A;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);

			//Отрезки соприкасаются концами
			segment = new TSegment(E, B);
			expected = true;
			cpExpected = B;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);

			//Отрезок пересекает заданный. Общий случай.
			segment = new TSegment(F, G);
			expected = true;
			cpExpected = O;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);

			//Отрезки частично совпадают
			segment = new TSegment(H, I);
			expected = false;
			//cpExpected = NaN;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			//if (!float.IsNaN(cpActual.X) || !float.IsNaN(cpActual.X))
			//	Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);

			//Отрезки параллельны
			segment = new TSegment(J, K);
			expected = false;
			//cpExpected = new PointF(float.PositiveInfinity, float.PositiveInfinity);
			actual = TTests.IsCrossing(segment, target, out cpActual);
			//Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);
			
			//Отрезки не пересекаются, но пересекаются продолжающие их прямые
			segment = new TSegment(L, M);
			expected = false;
			cpExpected = L1;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);

			//Отрезок не пересекает целевой, но прямая, его продолжающая, пересекает.
			segment = new TSegment(N, J);
			expected = false;
			cpExpected = J1;
			actual = TTests.IsCrossing(segment, target, out cpActual);
			Assert.AreEqual(cpExpected, cpActual);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///Тест на пересечение прямой и отрезка
		///</summary>
		[TestMethod()]
		public void TTests_IsSegmentCrossingStraightLineTest()
		{
			PointF pt1 = new PointF(1, 3);
			PointF pt2 = new PointF(2, 1);
			TLineStraight straightline = new TLineStraight(pt1, pt2);
			TSegment segment;
			PointF cp;
			PointF cpExpected;
			bool expected;
			bool actual;

			segment = new TSegment(-2, 4, 2, 6);
			cpExpected = new PointF(0, 5);
			expected = true;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(1, 1, 4, 1);
			cpExpected = new PointF(2, 1);
			expected = true;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(0, 5, 2, 1);
			cpExpected = new PointF(float.NaN, float.NaN);
			expected = false;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!float.IsNaN(cp.X) || !float.IsNaN(cp.Y))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(2, -3, 3, -1);
			cpExpected = new PointF(3, -1);
			expected = true;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(6, 1, 3, -1);
			cpExpected = new PointF(3, -1);
			expected = true;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(-1, 2, 1, -2);
			cpExpected = new PointF(float.NegativeInfinity, float.PositiveInfinity);
			expected = false;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!float.IsInfinity(cp.X) || !float.IsInfinity(cp.Y))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			segment = new TSegment(2, 2, 5, 2);
			cpExpected = new PointF((float)1.5, 2);
			expected = false;
			actual = TTests.IsCrossing(segment, straightline, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и отрезок " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}
		}

		/// <summary>
		///Тест на пересечение луча и прямой
		///</summary>
		[TestMethod()]
		public void TTests_IsRayCrossingLineTest()
		{
			PointF begin = new PointF(1, 3);
			PointF vector = new PointF(1, -2);
			TRay target = new TRay(begin, vector);
			TLineStraight line;
			PointF cp;
			PointF cpExpected;
			bool expected;
			bool actual;

			//Пересечения не будет. Однако прямая пересекается с продолжением луча, а значит точка пересечения имеется.
			line = new TLineStraight(-2, 4, 2, 6);
			cpExpected = new PointF(0, 5);
			expected = false;
			actual = TTests.IsCrossing(target, line, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и луч " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			//Пересечения не будет. Прямая совпадает с лучом.
			line = new TLineStraight(0, 5, 1, 3);
			cpExpected = new PointF(float.NaN, float.NaN);
			expected = false;
			actual = TTests.IsCrossing(target, line, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и луч " + (expected ? "" : "не ") + "пересекаются.");
			if (!float.IsNaN(cp.X) || !float.IsNaN(cp.Y))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			//Пересечения не будет. Прямая параллельна лучу.
			line = new TLineStraight(2, 5, 4, 1);
			cpExpected = new PointF(float.PositiveInfinity, float.NegativeInfinity);
			expected = false;
			actual = TTests.IsCrossing(target, line, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и луч " + (expected ? "" : "не ") + "пересекаются.");
			if (!float.IsInfinity(cp.X) || !float.IsInfinity(cp.Y))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}

			//Ожидается пересечение.
			line = new TLineStraight(-1, 0, 5, 2);
			cpExpected = new PointF(2, 1);
			expected = true;
			actual = TTests.IsCrossing(target, line, out cp);
			Assert.AreEqual(expected, actual, "Ожидалось, что линия и луч " + (expected ? "" : "не ") + "пересекаются.");
			if (!cp.Equals(cpExpected))
			{
				Assert.Fail("Ожидалась точка пересечения {0}; Получена {1}", cpExpected, cp);
			}
		}

		/// <summary>
		///Тест на пересечение прямой и окружности
		///</summary>
		[TestMethod()]
		public void TTests_IsCircleCrossingLineTest()
		{
			PointF center = new PointF(3, 8);
			float radius = 5;
			TCircle circle = new TCircle(center, radius);

			//Прямая пересекает окружность в двух точках
			TLineStraight line = new TLineStraight(1, 2, 5, 4);
			PointF[] cp;
			PointF[] cpExpected = new PointF[2];
			cpExpected[0] = new PointF(7, 5);
			cpExpected[1] = new PointF(3, 3);
			bool expected = true;
			bool actual;
			actual = TTests.IsCrossing(circle, line, out cp);
			if (!(TConstants.IsEqualPointF(cp[0], cpExpected[0]) && TConstants.IsEqualPointF(cp[1], cpExpected[1]))
				&& !(TConstants.IsEqualPointF(cp[1], cpExpected[0]) && TConstants.IsEqualPointF(cp[0], cpExpected[1])))
			{
				Assert.Fail("Ожидаемые точки пересечения: {0}; {1}; Полученные точки: {2}; {3}", cpExpected[0], cpExpected[1], cp[0], cp[1]);
			}
			Assert.AreEqual(expected, actual, "Эта окружность " + (expected ? "" : "не ") + "должна пересекать прямую");

			//Прямая через центр окружности
			center = new PointF(0, 0);
			radius = 5;
			circle = new TCircle(center, radius);
			line = new TLineStraight(0, 0, 4, -3);
			cpExpected = new PointF[2];
			cpExpected[0] = new PointF(-4, 3);
			cpExpected[1] = new PointF(4, -3);
			expected = true;
			actual = TTests.IsCrossing(circle, line, out cp);
			if (!(TConstants.IsEqualPointF(cp[0], cpExpected[0]) && TConstants.IsEqualPointF(cp[1], cpExpected[1]))
				&& !(TConstants.IsEqualPointF(cp[1], cpExpected[0]) && TConstants.IsEqualPointF(cp[0], cpExpected[1])))
			{
				Assert.Fail("Ожидаемые точки пересечения: {0}; {1}; Полученные точки: {2}; {3}", cpExpected[0], cpExpected[1], cp[0], cp[1]);
			}
			Assert.AreEqual(expected, actual, "Эта окружность " + (expected ? "" : "не ") + "должна пересекать прямую");

			//Прямая по касательной к окружности
			center = new PointF(0, 0);
			radius = 5;
			circle = new TCircle(center, radius);
			line = new TLineStraight(7, 1, 4, -3);
			cpExpected = new PointF[1];
			cpExpected[0] = new PointF(4, -3);
			expected = true;
			actual = TTests.IsCrossing(circle, line, out cp);
			if (cp == null || cp.Length != 1)
			{
				Assert.Fail("Ожидалась ровно одна точка пересечения. Получено " + (cp == null ? "ни одной." : cp.Length.ToString()));
			}
			if (!TConstants.IsEqualPointF(cp[0], cpExpected[0]))
			{
				Assert.Fail("Ожидаемая точка пересечения: {0}; Полученная точка: {1};", cpExpected[0], cp[0]);
			}
			Assert.AreEqual(expected, actual, "Эта окружность " + (expected ? "" : "не ") + "должна пересекать прямую");

			//Прямая не пересекает окружность
			center = new PointF(0, 0);
			radius = 5;
			circle = new TCircle(center, radius);
			line = new TLineStraight(7, 1, 4, -4);
			cpExpected = new PointF[1];
			expected = false;
			actual = TTests.IsCrossing(circle, line, out cp);
			if (cp != null)
			{
				Assert.Fail("Ожидалась, что точек пересечения нет. Получено " + cp.Length.ToString() + " точек пересечения.");
			}
			Assert.AreEqual(expected, actual, "Эта окружность " + (expected ? "" : "не ") + "должна пересекать прямую");
		}

		/// <summary>
		/// Тест получения наименьшего общего кратного
		///</summary>
		[TestMethod()]
		public void TTests_NOKTest()
		{
			float f1 = 15F;
			float f2 = 20F;
			float expected = 60F;
			float actual;
			actual = TTests.NOK(f1, f2);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест получения наибольшего общего делителя
		///</summary>
		[TestMethod()]
		public void TTests_NODTest()
		{
			float f1 = 120F;
			float f2 = 130F;
			float expected = 10F;
			float actual;

			f1 = 120F;
			f2 = 130F;
			expected = 10F;
			actual = TTests.NOD(f1, f2);
			Assert.AreEqual(expected, actual);

			f1 = 121F;
			f2 = 130F;
			expected = 1F;
			actual = TTests.NOD(f1, f2);
			Assert.AreEqual(expected, actual);

			f1 = 120.1F;
			f2 = 130F;
			expected = float.NaN;
			actual = TTests.NOD(f1, f2);
			Assert.AreEqual(expected, actual);

			f1 = 1F;
			f2 = 3180.043F;
			expected = float.NaN;
			actual = TTests.NOD(f1, f2);
			Assert.AreEqual(expected, actual);
		}
	}
}
