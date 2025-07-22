using MediatR;

namespace ApiClient.Request.Commands.DeleteRequest
{
	public class DeleteRequestCommand : IRequest
	{
		public int RequestId { get; set; }
	}
}
