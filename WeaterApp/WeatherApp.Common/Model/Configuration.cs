namespace WeatherApp.Common.Model
{
	/// <summary>
	/// Конфигурация.
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// Конфигурация приложения.
		/// </summary>
		public ApplicationConfiguration ApplicationConfiguration { get; set; }

		/// <summary>
		/// Конфигурация клиентов, получающих погоду через API.
		/// </summary>
		public ClientConfiguration[] ClientConfigurations { get; set; }
	}
}
