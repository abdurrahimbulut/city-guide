namespace cityGuide.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    
    }
}