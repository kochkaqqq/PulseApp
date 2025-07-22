using Domain.DTO.Clients;
using MediatR;

namespace ApiClient.Client.Queries.GetClientSelectionDTOList
{
	public class GetClientSelectionDTOListQuery : IRequest<List<ClientSelectionDTO>>
	{
	}
}
