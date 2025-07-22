using MediatR;
using Domain.DTO;
using Domain.Filters;

namespace ApiClient.Client.Commands.GetClientList
{
	public class GetClientListQuery : IRequest<Tuple<List<ClientListElementDTO>, int>>
	{
		public int Page { get; set; }
		public int PageEntitiesCount { get; set; } = 25;
		public ClientFilter ClientFilter { get; set; } = new();
	}
}
