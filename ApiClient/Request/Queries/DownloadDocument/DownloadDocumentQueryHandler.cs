using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient.Request.Queries.DownloadDocument
{
	public class DownloadDocumentQueryHandler : IRequestHandler<DownloadDocumentQuery, Document>
	{
		private readonly HttpClient _httpClient;

		public DownloadDocumentQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Document> Handle(DownloadDocumentQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync($"/documents/GetDocument?documentId={request.DocumentId}", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Document>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) 
				?? throw new Exception();
		}
	}
}
