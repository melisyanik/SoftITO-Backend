namespace SmartLifeMvc.ViewModels.Api
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
