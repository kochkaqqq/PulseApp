using MediatR;

namespace ApiClient.Experience.Commands.DeleteExperience
{
	public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand>
	{
		private readonly HttpClient _httpClient;

		public DeleteExperienceCommandHandler(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
		{
			var res = await _httpClient.DeleteAsync($"/experiences/DeleteExperience?id={request.ExperienceId}", cancellationToken);

			res.EnsureSuccessStatusCode();
		}
	}
}
