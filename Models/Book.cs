namespace Yudin_back.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }

        public List<Borrowing> Borrowings { get; set; } = new();

        public string GetDescription()
        {
            return $"{Title} ({Author}, {Year})";
        }

        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }

    }
}