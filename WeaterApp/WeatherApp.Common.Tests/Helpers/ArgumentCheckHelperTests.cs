using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Common.Helpers;

namespace WeatherApp.Common.Tests.Helpers
{
	/// <summary>
	/// Тест хелпера для проверки аргументов.
	/// </summary>
	[TestClass]
	public class ArgumentCheckHelperTests
	{
		#region NotNull

		/// <summary>
		/// Должен выдать исключение, так как в параметрах передается Null.
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NotNullFailTest()
		{
			ArgumentCheckHelper.NotNull(null, string.Empty);
		}

		/// <summary>
		/// Должен выдать исключение, так как в параметрах передается пустая ссылка.
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NotNullWithEmptyReferenceFailTest()
		{
			var emptyReference = (object)null;
			ArgumentCheckHelper.NotNull(emptyReference, string.Empty);
		}

		/// <summary>
		/// Исключение не будет выброшено, так как переменная ссылается на объект.
		/// </summary>
		[TestMethod]
		public void NotNullSuccessTest()
		{
			var reference = new Object();
			ArgumentCheckHelper.NotNull(reference, string.Empty);
		}

		#endregion

		#region ExpressionShouldBeTrue

		/// <summary>
		/// Должен выбросить исключение, так как выражение неверно.
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ExpressionShouldBeTrueFailTest()
		{
			var wrongExpression = 5 < 2;
			ArgumentCheckHelper.ExpressionShouldBeTrue(wrongExpression, string.Empty);
		}

		/// <summary>
		/// Исключение не будет выброшено, так как выражение истинно.
		/// </summary>
		[TestMethod]
		public void ExpressionShouldBeTrueSuccessTest()
		{
			var trueExpression = 5 > 2;
			ArgumentCheckHelper.ExpressionShouldBeTrue(trueExpression, string.Empty);
		}

		#endregion

		#region ExpressionShouldBeFalse

		/// <summary>
		/// Должен выбросить исключение, так как выражение верно.
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ExpressionShouldBeFalseFailTest()
		{
			var trueExpression = 5 > 2;
			ArgumentCheckHelper.ExpressionShouldBeFalse(trueExpression, string.Empty);
		}

		/// <summary>
		/// Исключение не будет выброшено, так как выражение неверно.
		/// </summary>
		[TestMethod]
		public void ExpressionShouldBeFalseSuccessTest()
		{
			var wrongExpression = 5 < 2;
			ArgumentCheckHelper.ExpressionShouldBeFalse(wrongExpression, string.Empty);
		}

		#endregion
	}
}
