using System.ComponentModel.DataAnnotations;

namespace SocialManagement.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }    

        public string Content { get; set; } 

        public string ImageUrl { get; set; }  

        public string Tag { get; set; }       

        public string AuthorName { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}