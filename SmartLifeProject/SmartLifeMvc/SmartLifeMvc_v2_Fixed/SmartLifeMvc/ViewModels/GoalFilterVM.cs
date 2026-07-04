namespace SmartLifeMvc.ViewModels
{
    public class GoalFilterVM
    {
        public string SearchText { get; set; }
        public string Status { get; set; }
        public List<GoalWithProgressVM> Goals { get; set; }
    }
}
