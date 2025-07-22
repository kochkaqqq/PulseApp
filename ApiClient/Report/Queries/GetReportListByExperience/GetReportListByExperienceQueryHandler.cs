using MediatR;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Report.Queries.GetReportListByExperience
{
	public class GetReportListByExperienceQueryHandler : IRequestHandler<GetReportListByExperienceQuery, List<Domain.Report>>
	{
		private readonly HttpClient _httpClient;

		public GetReportListByExperienceQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Domain.Report>> Handle(GetReportListByExperienceQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync($"/reports/GetReportListByExperience?ExperienceId={request.ExperinceId}", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<List<Domain.Report>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(List<Domain.Report>), json);
		}
	}
}
