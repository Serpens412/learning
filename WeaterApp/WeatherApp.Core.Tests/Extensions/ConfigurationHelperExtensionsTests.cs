using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WeatherApp.Common.Helpers;
using WeatherApp.Core.Extensions;

namespace WeatherApp.Core.Tests.Extensions
{
	/// <summary>
	/// Тест для расширения хелпера конфигуратора.
	/// </summary>
	[TestClass]
	public class ConfigurationHelperExtensionsTests
	{
		/// <summary>
		/// Успешно десериализует файл тестовой конфигурации и проверяет, было ли записано в него что-либо. Корректность записи в конфигуратор проверяется тестом базового класса.
		/// </summary>
		[TestMethod]
		public virtual void GetCoreConfigurationSuccessTest()
		{
			var configurationHelper = new ConfigurationHelper();
			var configuration = configurationHelper.GetCoreConfiguration();

			Assert.IsNotNull(configuration.ApplicationConfiguration.NumberOfMinutesBeforeConfigurationUpdate);
			Assert.IsNotNull(configuration.ClientConfigurations);
			Assert.IsTrue(configuration.ClientConfigurations.Any());
		}
	}
}
