using Domain.DTO.Experiences;
using MediatR;

namespace ApiClient.Experience.Queries.GetExperiencePlanDTOList
{
	public class GetExperiencePlanDTOListQuery : IRequest<List<ExperiencePlanDTO>>
	{
		public DateTime Date { get; set; }
	}
}
