using MediatR;

namespace ApiClient.Report.Queries.GetReportListByExperience
{
	public class GetReportListByExperienceQuery : IRequest<List<Domain.Report>>
	{
		public int ExperinceId { get; set; }
	}
}
