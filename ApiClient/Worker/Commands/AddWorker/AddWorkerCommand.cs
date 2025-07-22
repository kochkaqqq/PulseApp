using MediatR;

namespace ApiClient.Worker.Commands.AddWorker
{
	public class AddWorkerCommand : IRequest<Domain.Worker>
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int ShiftSalary { get; set; }
		public int HourSalary { get; set; }
	}
}
