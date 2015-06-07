using CoordinateSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CoordinateSystemUnitTest
{
    
    
    /// <summary>
    ///This is a test class for TRayTest and is intended
    ///to contain all TRayTest Unit Tests
    ///</summary>
	[TestClass()]
	public class TRayTest
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
		public void TRay_PointIsOnFigureTest()
		{
			PointF begin = new PointF(1, 3);
			PointF vector = new PointF(1, -2);
			TRay target = new TRay(begin, vector);

			PointF pt = new PointF(2, 1);
			bool expected = true;
			bool actual;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual, "Ожидается, что точка " + pt + (expected ? " " : " не ") + "принадлежит лучу.");

			pt = new PointF(0, 5);
			expected = false;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual, "Ожидается, что точка " + pt + (expected ? " " : " не ") + "принадлежит лучу.");

			pt = new PointF(4, 1);
			expected = false;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual, "Ожидается, что точка " + pt + (expected ? " " : " не ") + "принадлежит лучу.");

			pt = new PointF(2, 5);
			expected = false;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual, "Ожидается, что точка " + pt + (expected ? " " : " не ") + "принадлежит лучу.");

			pt = new PointF(-2, 4);
			expected = false;
			actual = target.PointIsOnFigure(pt);
			Assert.AreEqual(expected, actual, "Ожидается, что точка " + pt + (expected ? " " : " не ") + "принадлежит лучу.");
		}
	}
}
