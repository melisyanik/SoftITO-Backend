namespace SmartMunicipality.Models
{
    public class ComplaintViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? CategoryName { get; set; }
        public string? StatusName { get; set; }
    }

    public class CreateComplaintViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
