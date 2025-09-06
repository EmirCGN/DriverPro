// DriverPro/Services/WindowsUpdateService.cs
using System.Collections.Generic;
using DriverPro.Models;

namespace DriverPro.Services
{
    public static class WindowsUpdateService
    {
        public static IEnumerable<DriverUpdate> FindDriverUpdates()
        {
            // Stub – hier später echte Windows Update/PNP-Quelle anbinden
            return new List<DriverUpdate>();
        }
    }
}
