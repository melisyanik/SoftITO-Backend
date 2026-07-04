namespace PetCareTracker.Api.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int TotalPets { get; set; }
        public int TotalVaccinations { get; set; }
        public int TotalAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int UpcomingVaccinations { get; set; }
        public int UpcomingAppointments { get; set; }
    }
}
