using MediatR;
using System.Net.Http.Json;
using System.Text.Json;
using ApiClient.Exceptions;
using Domain.DTO;

namespace ApiClient.Experience.Queries.GetExperinceList
{
	public class GetExperienceListQueryHandler : IRequestHandler<GetExperinceListQuery, Tuple<List<ExperienceListElementDTO>, int>>
	{
		private readonly HttpClient _httpClient;

		public GetExperienceListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Tuple<List<ExperienceListElementDTO>, int>> Handle(GetExperinceListQuery request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/experiences/GetList", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Tuple<List<ExperienceListElementDTO>, int>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(List<ExperienceListElementDTO>), json);
		}
	}
}
