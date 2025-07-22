using System.Text.Json;

namespace PulseApp.Settings
{
	public class Settings
	{
		public static AppSettings GetSettings()
		{
			var curDir = AppDomain.CurrentDomain.BaseDirectory;
			var path = curDir + "/Settings/appsettings.json";
			var jsonString = File.ReadAllText(path);

			return JsonSerializer.Deserialize<AppSettings>(jsonString) ?? new AppSettings();
		}

		public static void WriteSettings(AppSettings settings)
		{

		}
	}
}
