using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Request.Commands.RemoveRequestFile
{
	public class RemoveRequestFileCommandHandler : IRequestHandler<RemoveRequestFileCommand>
	{
		private readonly HttpClient _httpClient;

		public RemoveRequestFileCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(RemoveRequestFileCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PutAsync("/requests/RemoveFile", content, cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
