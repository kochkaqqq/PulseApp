using MediatR;
using ApiClient.Exceptions;
using Domain.DTO;
using System.Text.Json;

namespace ApiClient.Worker.Queries.GetWorkerDTOList
{
	public class GetWorkerDTOListQueryHandler : IRequestHandler<GetWorkerDTOListQuery, List<WorkerDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetWorkerDTOListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<WorkerDTO>> Handle(GetWorkerDTOListQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/workers/GetWorkerDTOList", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<WorkerDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(List<WorkerDTO>), json);
		}
	}
}
