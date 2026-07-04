namespace PetCareTracker.Api.DTOs.Pets
{
    public class PetDto
    {
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public decimal? Weight { get; set; }
    }
}
