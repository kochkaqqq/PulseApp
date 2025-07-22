using Domain.DTO.Experiences;
using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Experience.Queries.GetExperienceGantDTOByDate
{
	public class GetExperienceGantDTOByDateQueryHandler : IRequestHandler<GetExperienceGantDTOByDateQuery, List<ExperienceGantDTO>>
	{
		private readonly HttpClient _httpClient;

		public GetExperienceGantDTOByDateQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ExperienceGantDTO>> Handle(GetExperienceGantDTOByDateQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync($"/experiences/GetExperienceGantDTOList?day={request.Date.Day}&month={request.Date.Month}&year={request.Date.Year}", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<ExperienceGantDTO>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(List<ExperienceGantDTO>), json);
		}
	}
}
