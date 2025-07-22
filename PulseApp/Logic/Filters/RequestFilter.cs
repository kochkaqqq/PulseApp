using Domain;
using Domain.enums;

namespace PulseApp.Logic.Filters
{
	public class RequestFilter
	{
		public Client? Client { get; set; }
		public string ReasonRequest { get; set; } = string.Empty;
		public string NecessaryFunds { get; set; } = string.Empty;
		public Manager? Manager { get; set; }
		public string InternalInfo { get; set; } = string.Empty;
		public Status Status { get; set; } = Status.None;
		public DoneWorkActType ActFile { get; set; } = DoneWorkActType.None;
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
	}
}
