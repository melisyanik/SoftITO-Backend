namespace SmartLifeMvc.ViewModels.Api
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
