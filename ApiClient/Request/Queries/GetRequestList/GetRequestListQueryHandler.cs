using ApiClient.Exceptions;
using Domain.DTO;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Request.Queries.GetRequestList
{
	public class GetRequestListQueryHandler : IRequestHandler<GetRequestListQuery, Tuple<List<RequestListElementDTO>, int>>
	{
		private readonly HttpClient _httpClient;

		public GetRequestListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Tuple<List<RequestListElementDTO>, int>> Handle(GetRequestListQuery request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/requests/GetList", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var jsonRes = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Tuple<List<RequestListElementDTO>, int>>(jsonRes, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(List<RequestListElementDTO>), jsonRes);
		}
	}
}
