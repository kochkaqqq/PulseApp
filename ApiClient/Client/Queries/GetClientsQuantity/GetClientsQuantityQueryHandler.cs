using MediatR;
using System.Text.Json;

namespace ApiClient.Client.Queries.GetClientsQuantity
{
	public class GetClientsQuantityQueryHandler : IRequestHandler<GetClientsQuantityQuery, int>
	{
		private readonly HttpClient _httpClient;

		public GetClientsQuantityQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> Handle(GetClientsQuantityQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/clients/GetQuantity", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<int>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		}
	}
}
