namespace AuthorBooksAPI.Application.DTO
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string BookNumber { get; set; }
        public int PublishedYear { get; set; }
        public List<int> AuthorIds { get; set; } = new();
    }
}
