using MediatR;

namespace ApiClient.Request.Commands.RemoveRequestDocument
{
	public class RemoveRequestDocumentCommandHandler : IRequestHandler<RemoveRequestDocumentCommand>
	{
		private readonly HttpClient _httpClient;

		public RemoveRequestDocumentCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(RemoveRequestDocumentCommand request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.PutAsync($"/requests/RemoveDocument?requestId={request.RequestId}", null, cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
