namespace NotedAPI.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
