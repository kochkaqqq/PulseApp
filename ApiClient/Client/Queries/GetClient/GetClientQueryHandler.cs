using ApiClient.Exceptions;
using MediatR;
using System.Text.Json;

namespace ApiClient.Client.Queries.GetClient
{
	public class GetClientQueryHandler : IRequestHandler<GetClientQuery, Domain.Client>
	{
		private readonly HttpClient _httpClient;

		public GetClientQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Client> Handle(GetClientQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/clients/GetClient?id=" + request.ClientId, cancellationToken);

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
