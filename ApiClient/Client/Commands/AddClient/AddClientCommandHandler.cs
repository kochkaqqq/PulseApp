using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApiClient.Exceptions;

namespace ApiClient.Client.Commands.AddClient
{
	public class AddClientCommandHandler : IRequestHandler<AddClientCommand, Domain.Client>
	{
		private readonly HttpClient _httpClient;

		public AddClientCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Client> Handle(AddClientCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/clients/AddClient", content, cancellationToken);

			var jsonRes = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Domain.Client>(jsonRes, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Domain.Client), jsonRes);
		}
	}
}
