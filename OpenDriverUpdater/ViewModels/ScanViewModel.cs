// OpenDriverUpdater/ViewModels/ScanViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenDriverUpdater.Helpers;
using DriverPro.Models;
using OpenDriverUpdater.Models;

namespace OpenDriverUpdater.ViewModels
{
    public sealed class ScanViewModel : ObservableObject
    {
        private bool _isScanning;
        public bool IsScanning { get => _isScanning; set => Set(ref _isScanning, value); }

        private int _progress;
        public int Progress { get => _progress; set => Set(ref _progress, value); }

        private string _statusText = "Scannen Sie Ihr System nach veralteten Treibern und verfügbaren Updates.";
        public string StatusText { get => _statusText; set => Set(ref _statusText, value); }

        private bool _showResults;
        public bool ShowResults { get => _showResults; set => Set(ref _showResults, value); }

        public ObservableCollection<DriverItem> Drivers { get; } = new ObservableCollection<DriverItem>();

        public RelayCommand StartScanCommand { get; }
        public RelayCommand ResetCommand { get; }
        public RelayCommand<DriverItem> UpdateOneCommand { get; }
        public RelayCommand UpdateAllCommand { get; }

        public ScanViewModel()
        {
            StartScanCommand = new RelayCommand(async () => await StartScanAsync(), () => !IsScanning);
            ResetCommand = new RelayCommand(Reset);
            UpdateOneCommand = new RelayCommand<DriverItem>(async d => await UpdateDriverAsync(d), d => d != null && d.HasUpdate);
            UpdateAllCommand = new RelayCommand(async () => await UpdateAllAsync(), () => Drivers.Count > 0);
        }

        private void Reset()
        {
            IsScanning = false;
            Progress = 0;
            ShowResults = false;
            StatusText = "Scannen Sie Ihr System nach veralteten Treibern und verfügbaren Updates.";
            Drivers.Clear();
        }

        public async Task StartScanAsync()
        {
            if (IsScanning) return;

            Reset();

            IsScanning = true;
            StatusText = "System wird gescannt...";
            CommandManager.InvalidateRequerySuggested();

            // Demo-Progress (ersetzbar durch echte Erkennung)
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(45);   // simuliert Arbeit
                Progress = i;
            }

            // Demo-Daten (ersetzbar durch echte Ergebnisse)
            Drivers.Add(new DriverItem
            {
                Initials = "N",
                Name = "NVIDIA GeForce RTX 4070",
                Vendor = "NVIDIA",
                Category = "Grafikkarte",
                CurrentVersion = "531.41",
                LatestVersion = "537.13",
                SizeMb = 945.2,
                LastUpdated = DateTime.Parse("2024-03-15")
            });

            Drivers.Add(new DriverItem
            {
                Initials = "R",
                Name = "Realtek High Definition Audio",
                Vendor = "Realtek",
                Category = "Audio",
                CurrentVersion = "6.0.9404.1",
                LatestVersion = "6.0.9404.1",
                SizeMb = 42.6,
                LastUpdated = DateTime.Parse("2024-03-12")
            });

            Drivers.Add(new DriverItem
            {
                Initials = "I",
                Name = "Intel Wi-Fi 6 AX201",
                Vendor = "Intel",
                Category = "Netzwerk",
                CurrentVersion = "22.120.0.4",
                LatestVersion = "22.140.1.2",
                SizeMb = 72.8,
                LastUpdated = DateTime.Parse("2024-03-08")
            });

            Drivers.Add(new DriverItem
            {
                Initials = "A",
                Name = "AMD Chipset Drivers",
                Vendor = "AMD",
                Category = "Chipsatz",
                CurrentVersion = "4.03.03.431",
                LatestVersion = "4.03.03.431",
                SizeMb = 55.4,
                LastUpdated = DateTime.Parse("2024-03-20")
            });

            Drivers.Add(new DriverItem
            {
                Initials = "L",
                Name = "Logitech Gaming Mouse",
                Vendor = "Logitech",
                Category = "Eingabe",
                CurrentVersion = "8.96.108",
                LatestVersion = "9.02.65",
                SizeMb = 158.5,
                LastUpdated = DateTime.Parse("2024-03-05")
            });

            IsScanning = false;
            ShowResults = true;
            StatusText = "Scan abgeschlossen.";
            CommandManager.InvalidateRequerySuggested();
        }

        private async Task UpdateDriverAsync(DriverItem d)
        {
            if (d == null || !d.HasUpdate) return;

            // Demo-Update
            StatusText = "Treiber wird aktualisiert: " + d.Name;
            await Task.Delay(700);
            d.CurrentVersion = d.LatestVersion;

            StatusText = "Scan abgeschlossen.";
            CommandManager.InvalidateRequerySuggested();
        }

        private async Task UpdateAllAsync()
        {
            foreach (var d in Drivers)
            {
                if (d.HasUpdate)
                    await UpdateDriverAsync(d);
            }
        }
    }
}
