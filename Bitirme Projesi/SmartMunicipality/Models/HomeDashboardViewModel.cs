using SmartMunicipality.MODEL;

namespace SmartMunicipality.Models
{
    public class HomeDashboardViewModel
    {
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        public List<Announcement> LatestNews { get; set; } = new List<Announcement>();

        public int TotalCitizens { get; set; }
        public int ResolvedComplaints { get; set; }
        public int PendingComplaints { get; set; }

        public List<HeatMapPoint> HeatMapPoints { get; set; } = new List<HeatMapPoint>();
    }

    public class HeatMapPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Intensity { get; set; }
        public string Title { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
