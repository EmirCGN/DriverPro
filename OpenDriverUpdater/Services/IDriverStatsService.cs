// OpenDriverUpdater/Services/IDriverStatsService.cs
using System.Threading;
using System.Threading.Tasks;
using OpenDriverUpdater.Models;

namespace OpenDriverUpdater.Services
{
    public interface IDriverStatsService
    {
        Task<DashboardStats> GetStatsAsync(CancellationToken ct);
    }
}
