namespace PetCareTracker.Api.DTOs.Dashboard
{
    public class UpcomingVaccinationDto
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public int DaysLeft { get; set; }
    }
}