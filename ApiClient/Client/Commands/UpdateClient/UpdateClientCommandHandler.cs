using ApiClient.Exceptions;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Client.Commands.UpdateClient
{
	public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Domain.Client>
	{
		private readonly HttpClient _httpClient;

		public UpdateClientCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PutAsync("/clients/UpdateClient", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var jsonRes = await res.Content.ReadAsStringAsync(cancellationToken);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			return JsonSerializer.Deserialize<Domain.Client>(jsonRes, options) ?? throw new DeserializeException(nameof(Domain.Client), jsonRes);
		}
	}
}
