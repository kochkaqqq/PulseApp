using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Request.Commands.RemoveRequestFile
{
	public class RemoveRequestFileCommand : IRequest
	{
		public int RequestId { get; set; }
		public int DocumentId { get; set; }
	}
}
