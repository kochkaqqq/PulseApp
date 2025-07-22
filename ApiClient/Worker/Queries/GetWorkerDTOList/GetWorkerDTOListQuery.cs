using MediatR;
using Domain.DTO;

namespace ApiClient.Worker.Queries.GetWorkerDTOList
{
	public class GetWorkerDTOListQuery : IRequest<List<WorkerDTO>>
	{

	}
}
