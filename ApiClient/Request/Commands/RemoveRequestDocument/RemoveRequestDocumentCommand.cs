using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Request.Commands.RemoveRequestDocument
{
	public class RemoveRequestDocumentCommand : IRequest
	{
		public int RequestId { get; set; }
	}
}
