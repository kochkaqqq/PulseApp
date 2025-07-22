using MediatR;

namespace ApiClient.Client.Commands.DeleteClient
{
	public class DeleteClientCommand : IRequest
	{
		public int ClientId { get; set; }
	}
}
