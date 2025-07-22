using Domain.DTO;
using Domain.Filters;
using MediatR;

namespace ApiClient.Request.Queries.GetRequestList
{
	public class GetRequestListQuery : IRequest<Tuple<List<RequestListElementDTO>, int>>
	{
		public int Page { get; set; }
		public int PageEntitiesCount { get; set; }
		public RequestFilter RequestFilter { get; set; } = new();
	}
}
