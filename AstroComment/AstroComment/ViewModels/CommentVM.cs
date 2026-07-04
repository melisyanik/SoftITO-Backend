namespace AstroComment.ViewModels
{
    public class CommentVM
    {
        public int CommentId { get; set; }

        public string Username { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ReplyText { get; set; }

        public DateTime? ReplyDate { get; set; }

        public string ZodiacName { get; set; }
    }
}
