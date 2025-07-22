using Domain;

namespace PulseApp.Logic.Filters.ApplyFilter
{
    public static class ApplyRequestFilter
    {
        public static List<object> Apply(this List<Request> requests, RequestFilter filter)
        {
            if (filter == null)
                return requests.Cast<object>().ToList();

            var tmp = requests;

            var res = requests.Where(r =>
                (filter.Client == null || r.Client.ClientId == filter.Client.ClientId) &&
                (filter.ReasonRequest == string.Empty || r.ReasonRequest.Contains(filter.ReasonRequest, StringComparison.OrdinalIgnoreCase)) &&
                (filter.NecessaryFunds == string.Empty || r.NecessaryFunds.Contains(filter.NecessaryFunds, StringComparison.OrdinalIgnoreCase)) &&
                (filter.Manager == null || r.Manager.ManagerId == filter.Manager.ManagerId) &&
                (filter.InternalInfo == string.Empty || r.InternalInfo.Contains(filter.InternalInfo, StringComparison.OrdinalIgnoreCase)) &&
                (filter.Status == Domain.enums.Status.None || r.Status == filter.Status) && 
                (filter.ActFile == Domain.enums.DoneWorkActType.None || r.WorkResultType == filter.ActFile) &&
                (filter.FromDate == null || r.Date >= filter.FromDate) && 
                (filter.ToDate == null || r.Date <= filter.ToDate) 
            );

            return res.Cast<object>().ToList();
        }
    }
}
