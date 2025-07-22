using MediatR;

namespace ApiClient.Report.Queries.DownloadReportMedia
{
	public class DownloadReportMediaQueryHandler : IRequestHandler<DownloadReportMediaQuery, string>
	{
		private readonly HttpClient _httpClient;

		public DownloadReportMediaQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> Handle(DownloadReportMediaQuery request, CancellationToken cancellationToken)
		{
			string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string _downloadFolder = Path.Combine(Path.GetDirectoryName(filePath), "files");
			Directory.CreateDirectory(_downloadFolder);

			try
			{
				// 1. Запрашиваем файл с сервера
				var response = await _httpClient.GetAsync($"/reports/GetMedia?fileId={request.FileName}");

				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Ошибка сервера: {response.StatusCode}");
				}

				// 2. Получаем имя файла из заголовков
				var contentDisposition = response.Content.Headers.ContentDisposition;
				var serverFileName = contentDisposition?.FileName ?? $"{request.FileName}.dat";

				// 3. Генерируем путь для сохранения
				var localFilePath = Path.Combine(_downloadFolder, serverFileName);

				// 4. Сохраняем файл
				using (var fileStream = new FileStream(localFilePath, FileMode.Create))
				{
					await response.Content.CopyToAsync(fileStream);
				}

				// 5. Возвращаем абсолютный путь
				return Path.GetFullPath(localFilePath);
			}
			catch (Exception ex)
			{
				throw new Exception($"Ошибка при скачивании файла: {ex.Message}", ex);
			}
		}
	}
}
