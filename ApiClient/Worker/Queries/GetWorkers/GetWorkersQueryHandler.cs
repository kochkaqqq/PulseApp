using MediatR;
using System.Text.Json;

namespace ApiClient.Worker.Queries.GetWorkers
{
	public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, List<Domain.Worker>>
	{
		private readonly HttpClient _httpClient;

		public GetWorkersQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Domain.Worker>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.PostAsync("/workers/GetList", null, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<Domain.Worker>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? throw new Exception();
		}
	}
}
