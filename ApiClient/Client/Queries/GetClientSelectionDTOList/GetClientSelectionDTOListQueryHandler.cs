using Domain.DTO.Clients;
using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Client.Queries.GetClientSelectionDTOList
{
	public class GetClientSelectionDTOListQueryHandler : IRequestHandler<GetClientSelectionDTOListQuery, List<ClientSelectionDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetClientSelectionDTOListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ClientSelectionDTO>> Handle(GetClientSelectionDTOListQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/clients/GetSelectionDTOList", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<List<ClientSelectionDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(List<ClientSelectionDTO>), json);
		}
	}
}
