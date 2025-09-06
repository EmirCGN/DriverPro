using System;
using System.Collections.Generic;
using System.Management;

namespace OpenDriverUpdater.Services
{
    public sealed class DeviceInfoService
    {
        public sealed class DeviceInfo
        {
            public string DeviceName { get; set; }
            public string Manufacturer { get; set; }
            public string DriverVersion { get; set; }
            public DateTime? DriverDate { get; set; }
            public string HardwareId { get; set; }
        }

        public IEnumerable<DeviceInfo> GetInstalledDrivers()
        {
            using (var s = new ManagementObjectSearcher("SELECT DeviceName, Manufacturer, DriverVersion, DriverDate, HardwareID FROM Win32_PnPSignedDriver"))
            {
                foreach (ManagementObject mo in s.Get())
                {
                    DateTime? date = null;
                    try
                    {
                        if (mo["DriverDate"] is string wmiDate)
                            date = ManagementDateTimeConverter.ToDateTime(wmiDate);
                    }
                    catch { /* ignore */ }

                    string hw = "";
                    try
                    {
                        if (mo["HardwareID"] is Array arr && arr.Length > 0 && arr.GetValue(0) is string s0)
                            hw = s0;
                    }
                    catch { /* ignore */ }

                    yield return new DeviceInfo
                    {
                        DeviceName = (mo["DeviceName"] as string) ?? "",
                        Manufacturer = (mo["Manufacturer"] as string) ?? "",
                        DriverVersion = (mo["DriverVersion"] as string) ?? "",
                        DriverDate = date,
                        HardwareId = hw
                    };
                }
            }
        }
    }
}
