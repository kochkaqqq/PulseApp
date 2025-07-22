using MediatR;
using Domain.enums;

namespace ApiClient.Stats.GetHomePageStats
{
	public class GetHomePageStatsQuery : IRequest<Dictionary<StatType, int>>
	{
	}
}
