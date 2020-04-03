namespace WeatherApp.Common.Model
{
	/// <summary>
	/// Конфигурация приложения.
	/// </summary>
	public class ApplicationConfiguration
	{
		/// <summary>
		/// Количество минут между обновлением данных конфигурации.
		/// </summary>
		public int NumberOfMinutesBeforeConfigurationUpdate { get; set; }
	}
}
