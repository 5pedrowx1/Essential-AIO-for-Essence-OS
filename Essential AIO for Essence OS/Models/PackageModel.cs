using System.Drawing;

namespace Essential_AIO_for_Essence_OS.Models
{
    public class PackageModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string DownloadUrl64 { get; set; }
        public required string DonwloadUrl86 { get; set; }
        public required Image IconPath { get; set; }
        public required string Category { get; set; }
    }
}