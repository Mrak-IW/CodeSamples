using CoordinateSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CoordinateSystemUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TCircleTest and is intended
    ///to contain all TCircleTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TCircleTest
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
		public void TCircle_PointIsOnFigureTest()
		{
			Assert.Inconclusive("Verify the correctness of this test method.");
			PointF center = new PointF(); // TODO: Initialize to an appropriate value
			float radius = 0F; // TODO: Initialize to an appropriate value
			TCircle target = new TCircle(center, radius); // TODO: Initialize to an appropriate value
			PointF pt = new PointF(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for PointIsInside
		///</summary>
		[TestMethod()]
		public void TCircle_PointIsInsideTest()
		{
			Assert.Inconclusive("Verify the correctness of this test method.");
			PointF center = new PointF(); // TODO: Initialize to an appropriate value
			float radius = 0F; // TODO: Initialize to an appropriate value
			TCircle target = new TCircle(center, radius); // TODO: Initialize to an appropriate value
			PointF point = new PointF(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.PointIsInside(point);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест на получение расстояния от точки до окружности.
		///</summary>
		[TestMethod()]
		public void TCircle_GetDistanceTest()
		{
			PointF center = new PointF(3, 3);
			float radius = 4F;
			TCircle target = new TCircle(center, radius);
			
			PointF pt;
			float expected;
			float actual;

			//A
			pt = new PointF(3, 9);
			expected = 2F;
			actual = target.GetDistance(pt);
			Assert.AreEqual(expected, actual);

			//B
			pt = new PointF(3, -2);
			expected = 1F;
			actual = target.GetDistance(pt);
			Assert.AreEqual(expected, actual);

			//C
			pt = new PointF(5, 3);
			expected = -2F;
			actual = target.GetDistance(pt);
			Assert.AreEqual(expected, actual);

			//D
			pt = new PointF(-1, 3);
			expected = 0F;
			actual = target.GetDistance(pt);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест на получение точки на окружности, ближайшей к заданной точке.
		///</summary>
		[TestMethod()]
		public void TCircle_GetNearestPointTest()
		{
			PointF center = new PointF(3, 3);
			float radius = 4F;
			TCircle target = new TCircle(center, radius);

			PointF pt;
			PointF expected;
			PointF actual;

			//A
			pt = new PointF(3, 9);
			expected = new PointF(3, 7);
			actual = target.GetNearestPoint(pt);
			Assert.AreEqual(expected, actual);

			//B
			pt = new PointF(3, -2);
			expected = new PointF(3, -1);
			actual = target.GetNearestPoint(pt);
			Assert.AreEqual(expected, actual);

			//C
			pt = new PointF(5, 3);
			expected = new PointF(7, 3);
			actual = target.GetNearestPoint(pt);
			Assert.AreEqual(expected, actual);

			//D
			pt = new PointF(-1, 3);
			expected = new PointF(-1, 3);
			actual = target.GetNearestPoint(pt);
			Assert.AreEqual(expected, actual);
		}
	}
}
