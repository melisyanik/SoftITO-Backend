namespace PetCareTracker.Api.DTOs.Dashboard
{
    public class PetReportDto
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Weight { get; set; }

        public string OwnerName { get; set; }

        public string VaccineName { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }

        public DateTime? AppointmentDate { get; set; }
        public string Veterinarian { get; set; }
        public string Status { get; set; }
    }
}
