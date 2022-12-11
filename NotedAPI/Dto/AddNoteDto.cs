using NotedAPI.Models;

namespace NotedAPI.Dto
{
    public class AddNoteDto
    {
        public string Text { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
