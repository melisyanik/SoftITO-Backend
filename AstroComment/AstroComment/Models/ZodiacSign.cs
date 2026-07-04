namespace AstroComment.Models
{
    public class ZodiacSign
    {
        public int ZodiacId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Element { get; set; }
    }
}
