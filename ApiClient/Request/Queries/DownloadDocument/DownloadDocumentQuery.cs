using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Request.Queries.DownloadDocument
{
	public class DownloadDocumentQuery : IRequest<Document>
	{
		public int DocumentId { get; set; }
	}
}
