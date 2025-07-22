using MediatR;

namespace ApiClient.Experience.Commands.DeleteExperience
{
	public class DeleteExperienceCommand : IRequest
	{
		public int ExperienceId { get; set; }
	}
}
