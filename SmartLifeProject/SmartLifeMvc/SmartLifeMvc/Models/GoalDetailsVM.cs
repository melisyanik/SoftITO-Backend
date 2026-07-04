using SmartLifeMvc.Models;

namespace SmartLifeMvc.ViewModels
{
    public class GoalDetailsVM
    {
        public Goal Goal { get; set; }
        public List<GoalProgress> ProgressList { get; set; }

        public int LatestProgress => ProgressList?
            .OrderByDescending(x => x.ProgressDate)
            .FirstOrDefault()?.Percentage ?? 0;

        public string Status
        {
            get
            {
                var progress = LatestProgress;

                if (progress >= 100)
                    return "Done";
                else if (progress > 0)
                    return "In Progress";
                else
                    return "Active";
            }
        }
    }
}