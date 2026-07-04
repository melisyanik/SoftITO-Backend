namespace PetCareTracker.Api.DTOs.Dashboard
{
    public class UpcomingAppointmentDto
    {
        public string PetName { get; set; }
        public string Veterinarian { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public int DaysLeft { get; set; }
    }
}