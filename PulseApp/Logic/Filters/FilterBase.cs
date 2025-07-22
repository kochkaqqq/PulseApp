namespace PulseApp.Logic.Filters
{
    public class FilterBase
    {
        public Domain.Filters.ClientFilter? ClientFilter { get; set; } = new();
        public Domain.Filters.RequestFilter? RequestFilter { get; set; } = new();
        public Domain.Filters.ExperienceFilter? ExperienceFilter { get; set; } = new();
    }
}
