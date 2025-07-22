using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Worker.Commands.DeleteWorker
{
	public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand>
	{
		private readonly HttpClient _httpClient;

		public DeleteWorkerCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.DeleteAsync($"/workers/DeleteWorker?id={request.Id}", cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
