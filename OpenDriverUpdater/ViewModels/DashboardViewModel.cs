// OpenDriverUpdater/ViewModels/DashboardViewModel.cs
using OpenDriverUpdater.Helpers;

namespace OpenDriverUpdater.ViewModels
{
    public sealed class DashboardViewModel : ObservableObject
    {
        private string _systemProtection = "Optimal";
        public string SystemProtection { get => _systemProtection; set => Set(ref _systemProtection, value); }

        private int _performancePercent = 98;
        public int PerformancePercent { get => _performancePercent; set => Set(ref _performancePercent, value); }

        private string _lastCheck = "Heute";
        public string LastCheck { get => _lastCheck; set => Set(ref _lastCheck, value); }

        private int _totalDrivers = 0;
        public int TotalDrivers { get => _totalDrivers; set => Set(ref _totalDrivers, value); }

        private int _upToDate = 0;
        public int UpToDate { get => _upToDate; set => Set(ref _upToDate, value); }

        private int _updatesAvailable = 0;
        public int UpdatesAvailable { get => _updatesAvailable; set => Set(ref _updatesAvailable, value); }

        private int _updating = 0;
        public int Updating { get => _updating; set => Set(ref _updating, value); }

        public RelayCommand FullScanCommand { get; } = new RelayCommand(() => { });
        public RelayCommand InstallAllCommand { get; } = new RelayCommand(() => { });
    }
}
