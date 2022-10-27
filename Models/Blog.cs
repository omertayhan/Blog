namespace Blog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool IsPublish { get; set; }


        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Users User { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
