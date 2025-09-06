// DriverPro/Services/DriverStatsService.cs
using System.Linq;
using DriverPro.Services;

namespace DriverPro.Services
{
    public static class DriverStatsService
    {
        public static int PendingUpdatesCount()
            => WindowsUpdateService.FindDriverUpdates().Count();

        public static int TotalDriversCount()
            => 0; // Platzhalter bis echte Scan-Quelle angebunden ist

        public static int UpToDateCount()
            => TotalDriversCount() - PendingUpdatesCount();
    }
}
