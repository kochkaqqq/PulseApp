using MediatR;

namespace ApiClient.Request.Commands.DeleteRequest
{
	public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand>
	{
		private readonly HttpClient _httpClient;

		public DeleteRequestCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.DeleteAsync($"/requests/DeleteRequest?id={request.RequestId}", cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
