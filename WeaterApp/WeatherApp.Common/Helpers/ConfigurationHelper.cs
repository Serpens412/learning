using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using WeatherApp.Common.Model;

namespace WeatherApp.Common.Helpers
{
	/// <summary>
	/// Хелпер для работы с конфигурацией.
	/// </summary>
	public class ConfigurationHelper
	{
		/// <summary>
		/// Singletone-объект конфигуратора.
		/// </summary>
		private static Configuration _configuration;

		/// <summary>
		/// Количество минут, которое должно пройти с момента последнего обновления, чтобы данные в объекте конфигуратора.
		/// </summary>
		private static int _numberOfMinutesBeforeConfigurationUpdate;

		/// <summary>
		/// Дата последнего обновления данных объекта-конфигуратора.
		/// </summary>
		private static DateTime _lastConfiguratioUpdateDate;

		/// <summary>
		/// Получить данные конфигурации сборки.
		/// </summary>
		/// <returns>Сериализованные в модель данные конфигурации.</returns>
		public Configuration GetConfiguration(string pathToConfigurationFile)
		{
			ArgumentCheckHelper.ExpressionShouldBeTrue(!string.IsNullOrEmpty(pathToConfigurationFile), "Путь к файлу конфигурации не может быть пустым.");
			ArgumentCheckHelper.ExpressionShouldBeTrue(File.Exists(pathToConfigurationFile), $"По указанному пути отсутствует файл конфигурации: {pathToConfigurationFile}");

			if (DateTime.Now > _lastConfiguratioUpdateDate.AddMinutes(_numberOfMinutesBeforeConfigurationUpdate))
			{
				var configurationInJson = File.ReadAllText(pathToConfigurationFile, Encoding.UTF8);
				
				_configuration = JsonConvert.DeserializeObject<Configuration>(configurationInJson);

				_lastConfiguratioUpdateDate = DateTime.Now;
				_numberOfMinutesBeforeConfigurationUpdate = _configuration.ApplicationConfiguration.NumberOfMinutesBeforeConfigurationUpdate;
			}

			return _configuration;
		}
	}
}
