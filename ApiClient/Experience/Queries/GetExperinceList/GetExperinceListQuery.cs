using Domain.Filters;
using MediatR;
using Domain.DTO;

namespace ApiClient.Experience.Queries.GetExperinceList
{
	public class GetExperinceListQuery : IRequest<Tuple<List<ExperienceListElementDTO>, int>>
	{
		public int Page { get; set; }
		public ExperienceFilter ExperienceFilter { get; set; } = new();
	}
}
