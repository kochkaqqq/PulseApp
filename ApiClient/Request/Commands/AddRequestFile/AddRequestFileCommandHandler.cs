using Domain;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Request.Commands.AddRequestFile
{
	public class AddRequestFileCommandHandler : IRequestHandler<AddRequestFileCommand, Document>
	{
		private readonly HttpClient _httpClient;

		public AddRequestFileCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Document> Handle(AddRequestFileCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PutAsync("/requests/AddFile", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Document>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? throw new Exception();
		}
	}
}
