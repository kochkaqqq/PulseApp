using ApiClient.Client.Commands.GetClientList;
using ApiClient.Exceptions;
using Domain.DTO;
using Domain.Filters;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Client.Queries.GetClientList
{
	public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, Tuple<List<ClientListElementDTO>, int>>
	{
		private readonly HttpClient _httpClient;

		public GetClientListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Tuple<List<ClientListElementDTO>, int>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/clients/GetList", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var jsonRes = await res.Content.ReadAsStringAsync(cancellationToken);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true 
			};

			return JsonSerializer.Deserialize<Tuple<List<ClientListElementDTO>, int>>(jsonRes, options) ?? 
				throw new DeserializeException(nameof(List<ClientListElementDTO>), jsonRes);
		}
	}
}
