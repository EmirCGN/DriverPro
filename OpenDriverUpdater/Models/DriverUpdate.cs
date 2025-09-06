// DriverPro/Models/DriverUpdate.cs
namespace DriverPro.Models
{
    public sealed class DriverUpdate
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Vendor { get; set; }
        public string Category { get; set; }
        public string DownloadUrl { get; set; }
        public double SizeMb { get; set; }
    }
}
