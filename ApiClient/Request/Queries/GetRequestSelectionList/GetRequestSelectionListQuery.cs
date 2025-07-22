using Domain.DTO.Requests;
using MediatR;

namespace ApiClient.Request.Queries.GetRequestSelectionList
{
	public class GetRequestSelectionListQuery : IRequest<List<RequestSelectionDTO>>
	{

	}
}
