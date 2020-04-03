using System;

namespace WeatherApp.Common.Helpers
{
	/// <summary>
	/// Хелпер для уменьшения объема кода проверки входящих в метод парамтеров и выражений.
	/// </summary>
	public static class ArgumentCheckHelper
	{
		/// <summary>
		/// Проверяет, что ссылка на объект не пуста, иначе выбрасывает исключение.
		/// </summary>
		/// <param name="item">Ссылка на объект</param>
		/// <param name="errorMessage">Текст сообщения об ошибке</param>
		/// <exception cref="ArgumentException" />
		public static void NotNull(object item, string errorMessage)
		{
			if (item == null)
			{
				throw new ArgumentException(errorMessage);
			}
		}

		/// <summary>
		/// Логическое выражение должно возвращать True, иначе выбрасывает исключение.
		/// </summary>
		/// <param name="expressionResult">Логическое выражение</param>
		/// <param name="errorMessage">Текст сообщения об ошибке</param>
		/// <exception cref="ArgumentException" />
		public static void ExpressionShouldBeTrue(bool expressionResult, string errorMessage)
		{
			if (!expressionResult)
			{
				throw new ArgumentException(errorMessage);
			}
		}

		/// <summary>
		/// Логическое выражение должно возвращать False, иначе выбрасывает исключение.
		/// </summary>
		/// <param name="expressionResult">Логическое выражение</param>
		/// <param name="errorMessage">Текст сообщения об ошибке</param>
		/// <exception cref="ArgumentException" />
		public static void ExpressionShouldBeFalse(bool expressionResult, string errorMessage)
		{
			ExpressionShouldBeTrue(!expressionResult, errorMessage);
		}
	}
}
