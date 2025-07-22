using Domain.enums;
using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Stats.GetHomePageStats
{
	public class GetHomePageStatsQueryHandler : IRequestHandler<GetHomePageStatsQuery, Dictionary<StatType, int>>
	{
		private readonly HttpClient _httpClient;

		public GetHomePageStatsQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Dictionary<StatType, int>> Handle(GetHomePageStatsQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/stats/HomePage", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Dictionary<StatType, int>>(json, new JsonSerializerOptions() {  PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Dictionary<StatType, int>), json);
		}
	}
}
