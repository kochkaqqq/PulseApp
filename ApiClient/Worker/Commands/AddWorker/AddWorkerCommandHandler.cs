using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient.Worker.Commands.AddWorker
{
	public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand, Domain.Worker>
	{
		private readonly HttpClient _httpClient;

		public AddWorkerCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Worker> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/workers/AddWorker", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Domain.Worker>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
				?? throw new Exception();
		}
	}
}
