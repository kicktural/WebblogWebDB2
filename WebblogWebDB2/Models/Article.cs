namespace WebblogWebDB2.Models
{
    public class Article : BaseEntitiy
    {
        public  string Title { get; set; }
        public string Context { get; set; }
        public int ViewCount { get; set; }       
        public string UserId { get; set; }
        public User user { get; set; }
        public string  SeoUrl { get; set; }
        public string  PhotoUrl { get; set; }
    }
}
