using ApiClient.Exceptions;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiClient.Experience.Commands.CreateExperience
{
	public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, Domain.Experience>
	{
		private readonly HttpClient _httpClient;

		public CreateExperienceCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Domain.Experience> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
		{
			var content = JsonContent.Create(request);

			var res = await _httpClient.PostAsync("/experiences/AddExperience", content, cancellationToken);

			res.EnsureSuccessStatusCode();

			var json = await res.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<Domain.Experience>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
				throw new DeserializeException(nameof(Domain.Experience), json);
		}
	}
}
