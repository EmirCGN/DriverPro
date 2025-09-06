// OpenDriverUpdater/Models/DashboardStats.cs
namespace OpenDriverUpdater.Models
{
    public sealed class DashboardStats
    {
        public int TotalDrivers { get; set; }
        public int UpToDate { get; set; }
        public int UpdatesAvailable { get; set; }
        public int Updating { get; set; }
        public string SystemProtection { get; set; } = "Optimal";
        public int PerformancePercent { get; set; } = 98;
        public string LastCheckLabel { get; set; } = "Heute";
    }
}
