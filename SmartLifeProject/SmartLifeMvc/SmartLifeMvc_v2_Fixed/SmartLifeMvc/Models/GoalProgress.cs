public class GoalProgress
{
    public int GoalProgressId { get; set; }

    public int GoalId { get; set; }

    public Goal? Goal { get; set; }

    public DateTime ProgressDate { get; set; }

    public int Percentage { get; set; }

    public string Note { get; set; }
}