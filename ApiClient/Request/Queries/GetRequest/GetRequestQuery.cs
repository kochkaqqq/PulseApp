using Domain;
using MediatR;

namespace ApiClient.Request.Queries.GetRequest
{
	public class GetRequestQuery : IRequest<Domain.Request>
	{
		public int RequestId { get; set; }
	}
}
