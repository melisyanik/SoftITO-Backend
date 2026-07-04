namespace AstroComment.ViewModels
{
    public class HoroscopeVM
    {
        public int HoroscopeId { get; set; }
        public int ZodiacId { get; set; }
        public string Content { get; set; }
        public DateTime HoroscopeDate { get; set; }

        public string ZodiacName { get; set; }
    }
}
