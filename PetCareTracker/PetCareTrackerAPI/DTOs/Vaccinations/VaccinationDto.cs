namespace PetCareTracker.Api.DTOs.Vaccinations
{
    public class VaccinationDto
    {
        public int VaccinationId { get; set; }
        public int PetId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string Notes { get; set; }
    }
}