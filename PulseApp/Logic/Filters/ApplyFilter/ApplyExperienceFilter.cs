using Domain;

namespace PulseApp.Logic.Filters.ApplyFilter
{
    public class ApplyExperienceFilter
    {
        public static List<object> Apply(List<Experience> experiences, ExperienceFilter filter)
        {
            if (filter == null)
                return experiences.Cast<object>().ToList();

            var res = experiences.Where(e =>
            {
                return (filter.WorkPlan == null || e.WorkPlan?.Contains(filter.WorkPlan, StringComparison.OrdinalIgnoreCase) == true) &&
                    (filter.DoneWork == null || e.DoneWork?.Contains(filter.DoneWork, StringComparison.OrdinalIgnoreCase) == true) &&
                    (filter.UsedMaterials == null || e.UsedMaterials?.Contains(filter.UsedMaterials, StringComparison.OrdinalIgnoreCase) == true) &&
                    (filter.RemainWork == null || e.RemainWork?.Contains(filter.RemainWork, StringComparison.OrdinalIgnoreCase) == true) &&
                    (filter.Garant == null || filter.Garant.Value == e.Garant) &&
                    (filter.IsWorkDone == null || filter.IsWorkDone.Value == e.IsWorkDone) &&
                    (filter.IsWorkPlaceClean == null || filter.IsWorkPlaceClean.Value == e.IsWorkPlaceClean) &&
                    (filter.IsTaskAccepted == null || filter.IsTaskAccepted.Value == e.IsTaskAccepted) &&
                    (filter.FromDate == null || filter.FromDate <= e.Date) &&
                    (filter.ToDate == null || filter.ToDate >= e.Date) &&
                    (filter.Client == null || (e.Request != null && e.Request.Client != null && filter.Client.ClientId == e.Request.Client.ClientId)) &&
                    (filter.MainWorker == null || filter.MainWorker.WorkerId < 1 || (e.MainWorker != null && filter.MainWorker.WorkerId == e.MainWorker.WorkerId)) &&
                    (filter.Request == null || (e.Request != null && e.Request.RequestId == filter.Request.RequestId));
            }).ToList();

            if (filter.Workers != null && filter.Workers.Count > 0)
            {
                res = res.Where(e =>
                {
                    if (e.Workers == null || e.Workers.Count == 0) return false;
                    foreach (var w in filter.Workers)
                        if (!e.Workers.Contains(w)) return false;
                    return true;
                }).ToList();
            }

            return res.Cast<object>().ToList();
        }
    }
}
