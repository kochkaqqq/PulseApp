using Domain;
using Domain.enums;
using MediatR;

namespace ApiClient.Request.Commands.CreateRequest
{
	public class CreateRequestCommand : IRequest<Domain.Request>
	{
		public int ClientId { get; set; }
		public DateTime Date { get; set; }
		public string? ReasonRequest { get; set; }
		public string? NecessaryFunds { get; set; }
		public int ManagerId { get; set; }
		public string? InternalInfo { get; set; }
		public Status Status { get; set; }
		public string? ActFilePath { get; set; }
		public DoneWorkActType WorkResultType { get; set; } = DoneWorkActType.None;
		public Document? Document { get; set; }
		public List<Document>? Files { get; set; }
	}
}
