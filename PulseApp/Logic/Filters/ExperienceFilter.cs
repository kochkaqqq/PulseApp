using Domain;

namespace PulseApp.Logic.Filters
{
    public class ExperienceFilter
    {
		public Client? Client { get; set; }
		public Request? Request { get; set; }
		public Worker? MainWorker { get; set; }
		public List<Worker>? Workers { get; set; }
		public DateTime? FromDate { get; set; } = null;
		public DateTime? ToDate { get; set; } = null;
		public bool? Garant { get; set; } = null;
		public string? WorkPlan { get; set; } = "";
		public string? DoneWork { get; set; } = "";
		public string? UsedMaterials { get; set; } = "";
		public bool? IsWorkDone { get; set; } = null;
		public string? RemainWork { get; set; } = "";
		public bool? IsWorkPlaceClean { get; set; } = null;
		public bool? IsTaskAccepted { get; set; } = null;
	}
}
