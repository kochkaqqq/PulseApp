using Domain.DTO.Experiences;
using MediatR;

namespace ApiClient.Experience.Queries.GetExperienceGantDTOByDate
{
	public class GetExperienceGantDTOByDateQuery : IRequest<List<ExperienceGantDTO>>
	{
		public DateTime Date { get; set; }
	}
}
