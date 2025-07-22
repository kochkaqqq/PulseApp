using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Experience.Queries.GetExperience
{
	public class GetExperienceQueryHandle : IRequestHandler<GetExperienceQuery, Domain.Experience>
	{
		private readonly HttpClient _httpClient;

		public GetExperienceQueryHandle(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Experience> Handle(GetExperienceQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync($"/experiences/GetExperience?id={request.ExperienceId}", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Domain.Experience>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Domain.Experience), json);
		}
	}
}
