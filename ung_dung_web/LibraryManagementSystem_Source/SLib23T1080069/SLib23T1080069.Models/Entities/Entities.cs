namespace SLib.Models.Entities
{
    /// <summary>
    /// Đại diện cho tác giả trong hệ thống thư viện.
    /// </summary>
    public class Author
    {
        /// <summary>Mã định danh tác giả.</summary>
        public int AuthorId { get; set; }

        /// <summary>Tên tác giả.</summary>
        public string AuthorName { get; set; } = string.Empty;

        /// <summary>Tiểu sử tác giả.</summary>
        public string? Biography { get; set; }

        /// <summary>Ngày sinh của tác giả.</summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>Ngày mất của tác giả.</summary>
        public DateTime? DeathDate { get; set; }

        /// <summary>Trạng thái hoạt động của tác giả.</summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Đại diện cho nhà xuất bản.
    /// </summary>
    public class Publisher
    {
        /// <summary>Mã định danh nhà xuất bản.</summary>
        public int PublisherId { get; set; }

        /// <summary>Tên nhà xuất bản.</summary>
        public string PublisherName { get; set; } = string.Empty;

        /// <summary>Địa chỉ nhà xuất bản.</summary>
        public string? Address { get; set; }

        /// <summary>Số điện thoại liên hệ.</summary>
        public string? Phone { get; set; }

        /// <summary>Email liên hệ.</summary>
        public string? Email { get; set; }

        /// <summary>Website nhà xuất bản.</summary>
        public string? Website { get; set; }

        /// <summary>Trạng thái hoạt động.</summary>
        public bool IsActive { get; set; } = true;

        /// <summary>Thời điểm tạo bản ghi.</summary>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Đại diện cho ngôn ngữ của sách.
    /// </summary>
    public class Language
    {
        /// <summary>Mã định danh ngôn ngữ.</summary>
        public int LanguageId { get; set; }

        /// <summary>Mã ngôn ngữ, ví dụ vi hoặc en.</summary>
        public string LanguageCode { get; set; } = string.Empty;

        /// <summary>Tên ngôn ngữ.</summary>
        public string LanguageName { get; set; } = string.Empty;

        /// <summary>Trạng thái hoạt động.</summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Đại diện cho thể loại sách.
    /// </summary>
    public class Category
    {
        /// <summary>Mã định danh thể loại.</summary>
        public int CategoryId { get; set; }

        /// <summary>Tên thể loại.</summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>Mã thể loại cha, null nếu không có.</summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>Mô tả thể loại.</summary>
        public string? Description { get; set; }

        /// <summary>Trạng thái hoạt động.</summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Đại diện cho loại thành viên thư viện.
    /// </summary>
    public class MemberType
    {
        /// <summary>Mã định danh loại thành viên.</summary>
        public int MemberTypeId { get; set; }

        /// <summary>Tên loại thành viên.</summary>
        public string TypeName { get; set; } = string.Empty;

        /// <summary>Số sách tối đa được mượn cùng lúc.</summary>
        public int MaxActiveLoans { get; set; } = 3;

        /// <summary>Số ngày được phép mượn sách.</summary>
        public int LoanPeriodDays { get; set; } = 14;

        /// <summary>Số lần gia hạn tối đa.</summary>
        public int MaxRenewals { get; set; }

        /// <summary>Trạng thái hoạt động.</summary>
        public bool IsActive { get; set; } = true;
    }
    public class Book
    {
        public int BookId { get; set; }
        public string? ISBN { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public int? PublisherId { get; set; }
        public int? LanguageId { get; set; }
        public short? PublicationYear { get; set; }
        public string? Edition { get; set; }
        public string? Description { get; set; }
        public int? PageCount { get; set; }
        public string? CoverImagePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}