namespace SmartLifeMvc.ViewModels
{
    public class GoalWithProgressVM
    {
        public int GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public int Progress { get; set; }
        public string Status { get; set; }
    }
}
