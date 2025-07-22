using Domain.DTO.Requests;
using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Request.Queries.GetRequestSelectionList
{
	public class GetRequestSelectionListQueryHandler : IRequestHandler<GetRequestSelectionListQuery, List<RequestSelectionDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetRequestSelectionListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<RequestSelectionDTO>> Handle(GetRequestSelectionListQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync("/requests/GetSelectionList", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<RequestSelectionDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(List<RequestSelectionDTO>), json);
		}
	}
}
