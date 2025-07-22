using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Worker.Queries.GetWorkers
{
	public class GetWorkersQuery : IRequest<List<Domain.Worker>>
	{
	}
}
