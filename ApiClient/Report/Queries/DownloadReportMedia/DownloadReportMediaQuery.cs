using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Report.Queries.DownloadReportMedia
{
	public class DownloadReportMediaQuery : IRequest<string>
	{
		public string FileName { get; set; }
	}
}
