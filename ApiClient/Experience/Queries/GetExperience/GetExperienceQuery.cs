using MediatR;

namespace ApiClient.Experience.Queries.GetExperience
{
	public class GetExperienceQuery : IRequest<Domain.Experience>
	{
		public int ExperienceId { get; set; }
	}
}
