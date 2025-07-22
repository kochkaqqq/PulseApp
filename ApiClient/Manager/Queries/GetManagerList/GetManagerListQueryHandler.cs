using Domain.DTO;
using MediatR;
using ApiClient.Exceptions;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient.Manager.Queries.GetManagerList
{
	public class GetManagerListQueryHandler : IRequestHandler<GetManagerListQuery, List<ManagerDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetManagerListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ManagerDTO>> Handle(GetManagerListQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/managers/GetList", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<ManagerDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(List<ManagerDTO>), json);
		}
	}
}
