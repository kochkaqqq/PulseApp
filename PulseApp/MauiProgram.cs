using ApiClient.Client.Queries.GetClientList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PulseApp.Logic.Servicies;

namespace PulseApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Configuration.AddJsonFile("UserConfig.json");

			builder.Services.AddMauiBlazorWebView();
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientListQueryHandler).Assembly));

			builder.Services.AddSingleton(builder.Configuration);
			builder.Services.AddSingleton<NotificationService>();
			builder.Services.AddSingleton<LoadingService>();
			builder.Services.AddScoped(sp =>
			{
				var client = new HttpClient(new HttpClientHandler() { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true })
				{
					BaseAddress = new Uri(builder.Configuration.GetSection("ApiConfig")["BaseAddress"] ?? throw new Exception("Base address not set"))
				};
				client.DefaultRequestHeaders.Add("ApiKey", builder.Configuration.GetSection("Manager")["ApiKey"] ?? throw new Exception("Api Key not set"));
				return client;
			});

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
