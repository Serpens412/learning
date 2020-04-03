namespace WeatherApp.Common.Model
{
	/// <summary>
	/// Конфигурация клиента, получающего погоду через API.
	/// </summary>
	public class ClientConfiguration
	{
		/// <summary>
		/// Название сервиса, предоставляющего API.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Адрес API.
		/// </summary>
		public string Url { get; set; }
		
		/// <summary>
		/// Токен для подписания запроса к API.
		/// </summary>
		public string Token { get; set; }
	}
}
