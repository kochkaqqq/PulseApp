using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApiClient.Exceptions;

namespace ApiClient.Request.Queries.GetRequest
{
	public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, Domain.Request>
	{
		private readonly HttpClient _httpClient;

		public GetRequestQueryHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Request> Handle(GetRequestQuery request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.GetAsync($"/requests/GetRequest?id={request.RequestId}", cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Domain.Request>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Domain.Request), json);
		}
	}
}
