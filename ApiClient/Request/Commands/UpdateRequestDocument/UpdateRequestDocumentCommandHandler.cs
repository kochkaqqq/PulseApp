using MediatR;
using System.Net.Http.Json;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Request.Commands.UpdateRequestDocument
{
	public class UpdateRequestDocumentCommandHandler : IRequestHandler<UpdateRequestDocumentCommand, Domain.Request>
	{
		private readonly HttpClient _httpClient;

		public UpdateRequestDocumentCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Request> Handle(UpdateRequestDocumentCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/requests/UpdateRequestDocument", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Domain.Request>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(Domain.Request), json);
		}
	}
}
