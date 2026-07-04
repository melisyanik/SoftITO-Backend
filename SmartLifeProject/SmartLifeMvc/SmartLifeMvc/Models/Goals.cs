using SmartLifeMvc.Models;

public class Goal
{
    public int GoalId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public string? UserId { get; set; }

    public Users? User { get; set; }

    public ICollection<GoalProgress>? GoalProgresses { get; set; }
}