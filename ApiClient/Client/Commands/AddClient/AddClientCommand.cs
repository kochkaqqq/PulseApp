using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Client.Commands.AddClient
{
	public class AddClientCommand : IRequest<Domain.Client>
	{
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string Contact { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}
}
