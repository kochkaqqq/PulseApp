using MediatR;
using System.Net.Http.Json;
using System.Text.Json;
using ApiClient.Exceptions;

namespace ApiClient.Request.Commands.UpdateRequest
{
	public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Domain.Request>
	{
		private readonly HttpClient _httpClient;

		public UpdateRequestCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Request> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PutAsync("/requests/UpdateRequest", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Domain.Request>(json, new JsonSerializerOptions() {  PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Domain.Request), json);
		}
	}
}
