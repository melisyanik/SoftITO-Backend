namespace PetCareTrackerMVC.Models
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PetId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Veterinarian { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string Status { get; set; } = "Bekliyor";
        public string? PetName { get; set; }
    }
}
