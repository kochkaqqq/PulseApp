using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Client.Commands.UpdateClient
{
	public class UpdateClientCommand : IRequest<Domain.Client>
	{
		public int ClientId { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; } 
		public string? Contact { get; set; }
		public string? Phone { get; set; } 
		public string? Email { get; set; }
	}
}
