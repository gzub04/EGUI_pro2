using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class BlogEntry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ownerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Blog Content")]
        public string content { get; set; }
    }
}
