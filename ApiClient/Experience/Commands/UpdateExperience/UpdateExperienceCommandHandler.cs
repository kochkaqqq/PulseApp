using ApiClient.Exceptions;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Experience.Commands.UpdateExperience
{
	public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, Domain.Experience>
	{
		private readonly HttpClient _httpClient;

		public UpdateExperienceCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Experience> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PutAsync("/experiences/UpdateExperience", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<Domain.Experience>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? 
				throw new DeserializeException(nameof(Domain.Experience), json);
		}
	}
}
