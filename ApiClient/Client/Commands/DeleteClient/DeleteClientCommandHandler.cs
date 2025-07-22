
using MediatR;

namespace ApiClient.Client.Commands.DeleteClient
{
	public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
	{
		private readonly HttpClient _httpClient;

		public DeleteClientCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.DeleteAsync("/clients/DeleteClient?id=" + request.ClientId, cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
