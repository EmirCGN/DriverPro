// DriverPro/Models/DriverItem.cs
using System;

namespace DriverPro.Models
{
    public class DriverItem
    {
        public string Name { get; set; }            // z. B. "NVIDIA GeForce RTX 4070"
        public string Vendor { get; set; }          // z. B. "NVIDIA"
        public string Category { get; set; }        // z. B. "Grafikkarte"
        public string CurrentVersion { get; set; }  // z. B. "531.41"
        public string LatestVersion { get; set; }   // z. B. "537.13"
        public double SizeMb { get; set; }          // z. B. 945.2
        public DateTime LastUpdated { get; set; }   // z. B. 15.03.2024
        public bool HasUpdate { get; set; }         // true = Update verfügbar

        // Für die Initialen im Kreis (z. B. "N" für NVIDIA, "R" für Realtek)
        public string Initials
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Name))
                    return Name.Substring(0, 1).ToUpper();
                return "?";
            }
        }
    }
}
