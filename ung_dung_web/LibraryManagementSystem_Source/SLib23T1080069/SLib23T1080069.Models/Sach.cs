
namespace SLib23T1080069.Models
{
    public class Sach
    {
        public int BookId { get; set; }

        public string ISBN { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Subtitle { get; set; }

        public int PublisherId { get; set; }

        public int? LanguageId { get; set; }

        public short? PublicationYear { get; set; }

        public string? Edition { get; set; }

        public string? Description { get; set; }

        public int? PageCount { get; set; }

        public string? CoverImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
