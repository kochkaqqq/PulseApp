using Domain;

namespace PulseApp.Logic.Filters.ApplyFilter
{
	public static class ApplyClientFilter
	{
		public static List<object> Apply(List<Client> clients, ClientFilter filter)
		{
			if (filter == null)
				return clients.Cast<object>().ToList();

			var res = clients.Where(c =>
				c.Name?.Contains(filter.Name, StringComparison.OrdinalIgnoreCase) == true &&
				c.Address.Contains(filter.Address, StringComparison.OrdinalIgnoreCase) &&
				c.Contact.Contains(filter.Contact, StringComparison.OrdinalIgnoreCase) &&
				c.EMail.Contains(filter.EMail, StringComparison.OrdinalIgnoreCase) &&
				c.Phone.Contains(filter.Phone, StringComparison.OrdinalIgnoreCase) &&
				(filter.FromDate == null || c.CreatedDate >= filter.FromDate) && 
				(filter.ToDate == null || c.CreatedDate <= filter.ToDate)
			);

			return res.Cast<object>().ToList();
		}
	}
}
