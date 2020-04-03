using System;
using System.IO;
using WeatherApp.Common.Helpers;
using WeatherApp.Common.Model;

namespace WeatherApp.Core.Extensions
{
	/// <summary>
	/// Расширение для работы с хелпером конфигурации.
	/// </summary>
	public static class ConfigurationHelperExtensions
	{
		/// <summary>
		/// Получить конфигурацию проекта WeatherApp.Core.
		/// </summary>
		/// <param name="configurationHelper">Экземпляр конфигурационного хелпера.</param>
		/// <returns></returns>
		public static Configuration GetCoreConfiguration(this ConfigurationHelper configurationHelper)
		{
			var baseDirecory = AppDomain.CurrentDomain.BaseDirectory;
			var configurationFileName = Properties.Settings.Default.ConfigurationFileName;

			return configurationHelper.GetConfiguration(Path.Combine(baseDirecory, configurationFileName));
		}
	}
}
