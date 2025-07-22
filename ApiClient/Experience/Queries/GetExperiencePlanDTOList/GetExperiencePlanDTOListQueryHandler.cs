using Domain.DTO.Experiences;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Experience.Queries.GetExperiencePlanDTOList
{
	public class GetExperiencePlanDTOListQueryHandler : IRequestHandler<GetExperiencePlanDTOListQuery, List<ExperiencePlanDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetExperiencePlanDTOListQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ExperiencePlanDTO>> Handle(GetExperiencePlanDTOListQuery request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/experiences/GetPlanListDTO", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<List<ExperiencePlanDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new Exception();
		}
	}
}
