using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Worker.Commands.DeleteWorker
{
	public class DeleteWorkerCommand : IRequest
	{
		public int Id { get; set; }
	}
}
