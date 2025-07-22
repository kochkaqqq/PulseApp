using MediatR;
using System.Net.Http.Json;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Request.Commands.CreateRequest
{
	public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Domain.Request>
	{
		private readonly HttpClient _httpClient;

		public CreateRequestCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Request> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/requests/AddRequest", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Domain.Request>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(Domain.Manager), json);
		}
	}
}
