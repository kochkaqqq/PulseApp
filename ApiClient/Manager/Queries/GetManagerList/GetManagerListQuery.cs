using Domain.DTO;
using MediatR;

namespace ApiClient.Manager.Queries.GetManagerList
{
	public class GetManagerListQuery : IRequest<List<ManagerDTO>>
	{
	}
}
