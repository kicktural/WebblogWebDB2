namespace WebblogWebDB2.Models
{
    public class ArticleTag
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public  Article article { get; set; }
        public int TagId { get; set; }
        public Tag tag { get; set; }
    }
}
