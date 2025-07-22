using MediatR;

namespace ApiClient.Client.Queries.GetClient
{
	public class GetClientQuery : IRequest<Domain.Client>
	{
		public int ClientId { get; set; }
	}
}
