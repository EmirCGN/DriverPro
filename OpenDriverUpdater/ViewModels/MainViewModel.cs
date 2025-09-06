// DriverPro/ViewModels/MainViewModel.cs
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using DriverPro.Helpers;
using DriverPro.Views;
using OpenDriverUpdater.Helpers;
using OpenDriverUpdater.ViewModels;
using OpenDriverUpdater.Views;

namespace DriverPro.ViewModels
{
    public enum NavPage { Dashboard, Scan, Downloads, Security, Performance, Settings, Theme, About }

    public sealed class MainViewModel : ObservableObject
    {
        private UserControl _content;
        public UserControl Content { get => _content; set => Set(ref _content, value); }

        private NavPage _selectedPage = NavPage.Dashboard;
        public NavPage SelectedPage
        {
            get => _selectedPage;
            set { Set(ref _selectedPage, value); Navigate(value); }
        }

        public RelayCommand GoDashboard { get; }
        public RelayCommand GoScan { get; }
        public RelayCommand GoDownloads { get; }
        public RelayCommand GoSecurity { get; }
        public RelayCommand GoPerformance { get; }
        public RelayCommand GoSettings { get; }
        public RelayCommand ToggleTheme { get; }
        public RelayCommand GoAbout { get; }

        private bool _isDark = true;

        public MainViewModel()
        {
            GoDashboard = new RelayCommand(() => SelectedPage = NavPage.Dashboard);
            GoScan = new RelayCommand(() => SelectedPage = NavPage.Scan);
            GoDownloads = new RelayCommand(() => SelectedPage = NavPage.Downloads);
            GoSecurity = new RelayCommand(() => SelectedPage = NavPage.Security);
            GoPerformance = new RelayCommand(() => SelectedPage = NavPage.Performance);
            GoSettings = new RelayCommand(() => SelectedPage = NavPage.Settings);
            ToggleTheme = new RelayCommand(() => ApplyTheme(_isDark = !_isDark));
            GoAbout = new RelayCommand(() => SelectedPage = NavPage.About);

            ApplyTheme(_isDark);
            Navigate(NavPage.Dashboard);
        }

        private void Navigate(NavPage page)
        {
            switch (page)
            {
                case NavPage.Dashboard:
                    Content = new DashboardView { DataContext = new DashboardViewModel() };
                    break;
                case NavPage.Scan:
                    Content = new ScanView { DataContext = new ScanViewModel() };
                    break;
                default:
                    Content = new DashboardView { DataContext = new DashboardViewModel() };
                    break;
            }
        }

        private static SolidColorBrush B(object c) => new SolidColorBrush((System.Windows.Media.Color)c);
        private void ApplyTheme(bool dark)
        {
            var r = Application.Current.Resources;
            r["Bg"] = B(r[dark ? "Bg-D" : "Bg-L"]);
            r["Panel"] = B(r[dark ? "Panel-D" : "Panel-L"]);
            r["Card"] = B(r[dark ? "Card-D" : "Card-L"]);
            r["CardSoft"] = B(r[dark ? "CardSoft-D" : "CardSoft-L"]);
            r["Stroke"] = B(r[dark ? "Stroke-D" : "Stroke-L"]);
            r["Fg"] = B(r[dark ? "Fg-D" : "Fg-L"]);
            r["FgSub"] = B(r[dark ? "FgSub-D" : "FgSub-L"]);
        }
    }
}
