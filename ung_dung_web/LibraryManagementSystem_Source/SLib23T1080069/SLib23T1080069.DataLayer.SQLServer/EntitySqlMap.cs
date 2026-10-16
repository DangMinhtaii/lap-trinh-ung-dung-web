
using SLib.Models.Entities;

namespace SLib.DataLayer.SQLServer
{
    /// <summary>
    /// Chứa thông tin SQL tương ứng với từng Entity.
    /// </summary>
    public class EntitySqlMap
    {
        /// <summary>Tên bảng trong cơ sở dữ liệu.</summary>
        public required string TableName { get; init; }

        /// <summary>Tên cột khóa chính.</summary>
        public required string IdColumn { get; init; }

        /// <summary>Câu SQL lấy toàn bộ bản ghi.</summary>
        public required string ListSql { get; init; }

        /// <summary>Câu SQL lấy một bản ghi theo ID.</summary>
        public required string GetSql { get; init; }

        /// <summary>Câu SQL thêm bản ghi.</summary>
        public required string AddSql { get; init; }

        /// <summary>Câu SQL cập nhật bản ghi.</summary>
        public required string UpdateSql { get; init; }

        /// <summary>Câu SQL xóa bản ghi.</summary>
        public required string DeleteSql { get; init; }

        /// <summary>Câu SQL kiểm tra bản ghi có được tham chiếu hay không.</summary>
        public required string InUseSql { get; init; }

        /// <summary>
        /// Lấy cấu hình SQL theo kiểu Entity.
        /// </summary>
        public static EntitySqlMap For<T>() where T : class
        {
            if (typeof(T) == typeof(Author))
            {
                return new EntitySqlMap
                {
                    TableName = "Authors",
                    IdColumn = "AuthorId",
                    ListSql = "SELECT * FROM Authors",
                    GetSql = "SELECT * FROM Authors WHERE AuthorId = @Id",
                    AddSql = """
                        INSERT INTO Authors
                            (AuthorName, Biography, BirthDate, DeathDate, IsActive)
                        VALUES
                            (@AuthorName, @Biography, @BirthDate, @DeathDate, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE Authors
                        SET AuthorName = @AuthorName,
                            Biography = @Biography,
                            BirthDate = @BirthDate,
                            DeathDate = @DeathDate,
                            IsActive = @IsActive
                        WHERE AuthorId = @AuthorId
                        """,
                    DeleteSql = "DELETE FROM Authors WHERE AuthorId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN EXISTS
                        (SELECT 1 FROM BookAuthors WHERE AuthorId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            if (typeof(T) == typeof(Publisher))
            {
                return new EntitySqlMap
                {
                    TableName = "Publishers",
                    IdColumn = "PublisherId",
                    ListSql = "SELECT * FROM Publishers",
                    GetSql = "SELECT * FROM Publishers WHERE PublisherId = @Id",
                    AddSql = """
                        INSERT INTO Publishers
                            (PublisherName, Address, Phone, Email, Website, IsActive)
                        VALUES
                            (@PublisherName, @Address, @Phone, @Email, @Website, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE Publishers
                        SET PublisherName = @PublisherName,
                            Address = @Address,
                            Phone = @Phone,
                            Email = @Email,
                            Website = @Website,
                            IsActive = @IsActive
                        WHERE PublisherId = @PublisherId
                        """,
                    DeleteSql = "DELETE FROM Publishers WHERE PublisherId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN EXISTS
                        (SELECT 1 FROM Books WHERE PublisherId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            if (typeof(T) == typeof(Language))
            {
                return new EntitySqlMap
                {
                    TableName = "Languages",
                    IdColumn = "LanguageId",
                    ListSql = "SELECT * FROM Languages",
                    GetSql = "SELECT * FROM Languages WHERE LanguageId = @Id",
                    AddSql = """
                        INSERT INTO Languages
                            (LanguageCode, LanguageName, IsActive)
                        VALUES (@LanguageCode, @LanguageName, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE Languages
                        SET LanguageCode = @LanguageCode,
                            LanguageName = @LanguageName,
                            IsActive = @IsActive
                        WHERE LanguageId = @LanguageId
                        """,
                    DeleteSql = "DELETE FROM Languages WHERE LanguageId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN EXISTS
                        (SELECT 1 FROM Books WHERE LanguageId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            if (typeof(T) == typeof(Category))
            {
                return new EntitySqlMap
                {
                    TableName = "Categories",
                    IdColumn = "CategoryId",
                    ListSql = "SELECT * FROM Categories",
                    GetSql = "SELECT * FROM Categories WHERE CategoryId = @Id",
                    AddSql = """
                        INSERT INTO Categories
                            (CategoryName, ParentCategoryId, Description, IsActive)
                        VALUES
                            (@CategoryName, @ParentCategoryId, @Description, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE Categories
                        SET CategoryName = @CategoryName,
                            ParentCategoryId = @ParentCategoryId,
                            Description = @Description,
                            IsActive = @IsActive
                        WHERE CategoryId = @CategoryId
                        """,
                    DeleteSql = "DELETE FROM Categories WHERE CategoryId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN
                            EXISTS (SELECT 1 FROM BookCategories WHERE CategoryId = @Id)
                            OR EXISTS (SELECT 1 FROM Categories WHERE ParentCategoryId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            if (typeof(T) == typeof(MemberType))
            {
                return new EntitySqlMap
                {
                    TableName = "MemberTypes",
                    IdColumn = "MemberTypeId",
                    ListSql = "SELECT * FROM MemberTypes",
                    GetSql = "SELECT * FROM MemberTypes WHERE MemberTypeId = @Id",
                    AddSql = """
                        INSERT INTO MemberTypes
                            (TypeName, MaxActiveLoans, LoanPeriodDays, MaxRenewals, IsActive)
                        VALUES
                            (@TypeName, @MaxActiveLoans, @LoanPeriodDays, @MaxRenewals, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE MemberTypes
                        SET TypeName = @TypeName,
                            MaxActiveLoans = @MaxActiveLoans,
                            LoanPeriodDays = @LoanPeriodDays,
                            MaxRenewals = @MaxRenewals,
                            IsActive = @IsActive
                        WHERE MemberTypeId = @MemberTypeId
                        """,
                    DeleteSql = "DELETE FROM MemberTypes WHERE MemberTypeId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN EXISTS
                        (SELECT 1 FROM Members WHERE MemberTypeId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            if (typeof(T) == typeof(Book))
            {
                return new EntitySqlMap
                {
                    TableName = "Books",
                    IdColumn = "BookId",
                    ListSql = "SELECT * FROM Books ORDER BY Title",
                    GetSql = "SELECT * FROM Books WHERE BookId = @Id",
                    AddSql = """
                        INSERT INTO Books
                            (ISBN, Title, Subtitle, PublisherId, LanguageId,
                             PublicationYear, Edition, Description, PageCount,
                             CoverImagePath, IsActive)
                        VALUES
                            (@ISBN, @Title, @Subtitle, @PublisherId, @LanguageId,
                             @PublicationYear, @Edition, @Description, @PageCount,
                             @CoverImagePath, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() AS int);
                        """,
                    UpdateSql = """
                        UPDATE Books
                        SET ISBN = @ISBN,
                            Title = @Title,
                            Subtitle = @Subtitle,
                            PublisherId = @PublisherId,
                            LanguageId = @LanguageId,
                            PublicationYear = @PublicationYear,
                            Edition = @Edition,
                            Description = @Description,
                            PageCount = @PageCount,
                            CoverImagePath = @CoverImagePath,
                            IsActive = @IsActive,
                            UpdatedAt = SYSDATETIME()
                        WHERE BookId = @BookId
                        """,
                    DeleteSql = "DELETE FROM Books WHERE BookId = @Id",
                    InUseSql = """
                        SELECT CASE WHEN
                            EXISTS (SELECT 1 FROM BookAuthors WHERE BookId = @Id)
                            OR EXISTS (SELECT 1 FROM BookCategories WHERE BookId = @Id)
                            OR EXISTS (SELECT 1 FROM BookCopies WHERE BookId = @Id)
                        THEN 1 ELSE 0 END
                        """
                };
            }

            throw new NotSupportedException(
                $"Entity {typeof(T).Name} chưa được cấu hình.");
        }
    }
}
