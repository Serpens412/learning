using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WeatherApp.Common.Model;

namespace WeatherApp.Common.Helpers.Tests
{
	/// <summary>
	/// Тест конфигурационного хелпера.
	/// </summary>
	[TestClass]
	public class ConfigurationHelperTests
	{
		/// <summary>
		/// Объект конфигурации, с которым будет сравниваться результат работы хелпера.
		/// </summary>
		private Configuration _configurationForAssert;

		/// <summary>
		/// Путь к конфигурационному файлу и его название.
		/// </summary>
		private string _pathToTestConfigurationFile;

		#region Создание и удаление тестовых данных.

		/// <summary>
		/// Создает объект с тестовой конфигурацией и сериализует его в JSON файл.
		/// </summary>
		[TestInitialize]
		public void CreateJsonConfigurationFile()
		{
			_configurationForAssert = new Configuration();
			
			_configurationForAssert.ApplicationConfiguration = new ApplicationConfiguration()
			{
				NumberOfMinutesBeforeConfigurationUpdate = 5
			};
			
			_configurationForAssert.ClientConfigurations = new[]
			{
				new ClientConfiguration
				{
					Name = "TestName",
					Token = "abcdefg1234567890",
					Url = @"https:\\simpleapiurl.com\api"
				},
				new ClientConfiguration
				{
					Name = "AnotherTestName",
					Token = "1234567890abcdefg",
					Url = @"https:\\anothersimpleapiurl.com\api"
				},
			};

			var testDataFolderName = "TestData";
			var configurationFileName = "appsettings.json";

			Directory.CreateDirectory(testDataFolderName);
			var json = JsonConvert.SerializeObject(_configurationForAssert);

			_pathToTestConfigurationFile = Path.Combine(Directory.GetCurrentDirectory(), testDataFolderName, configurationFileName);
			
			using (FileStream fileStream = File.Create(_pathToTestConfigurationFile))
			{
				var configurationInBytes = System.Text.Encoding.Default.GetBytes(json);
				fileStream.Write(configurationInBytes, 0, configurationInBytes.Length);
			}
		}

		/// <summary>
		/// Удаляет папку с тестовыми данными, передварительно очищая ее.
		/// </summary>
		[TestCleanup]
		public void DeleteTestFilesAndFolders()
		{
			var testFilesDirectoryPath = Path.GetDirectoryName(_pathToTestConfigurationFile);
			var filesInTestDirectory = Directory.GetFiles(testFilesDirectoryPath);
			
			foreach(var pathToFile in filesInTestDirectory)
			{
				File.Delete(pathToFile);
			}

			Directory.Delete(testFilesDirectoryPath);
		}

		#endregion

		/// <summary>
		/// Успешно десериализует файл тестовой конфигурации и сравнивает его с объектом из теста.
		/// </summary>
		[TestMethod]
		public virtual void GetConfigurationSuccessTest()
		{
			var configurationHelper = new ConfigurationHelper();
			var configuration = configurationHelper.GetConfiguration(_pathToTestConfigurationFile);

			Assert.AreEqual(_configurationForAssert.ApplicationConfiguration.NumberOfMinutesBeforeConfigurationUpdate, configuration.ApplicationConfiguration.NumberOfMinutesBeforeConfigurationUpdate);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.Count(), configuration.ClientConfigurations.Count());
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.First().Name, configuration.ClientConfigurations.First().Name);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.First().Token, configuration.ClientConfigurations.First().Token);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.First().Url, configuration.ClientConfigurations.First().Url);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.Last().Name, configuration.ClientConfigurations.Last().Name);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.Last().Token, configuration.ClientConfigurations.Last().Token);
			Assert.AreEqual(_configurationForAssert.ClientConfigurations.Last().Url, configuration.ClientConfigurations.Last().Url);
		}
	}
}
