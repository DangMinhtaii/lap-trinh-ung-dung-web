
namespace SLibModels.Constant
{
    /// <summary>
    /// Chứa các giá trị hằng được sử dụng trong cơ sở dữ liệu
    /// của hệ thống quản lý thư viện.
    /// Tên hằng tuân theo quy tắc TENBANG_TENCOT_TENGIATRI.
    /// </summary>
    public static class DatabaseConstant
    {
        #region BookCopies

        /// <summary>
        /// Giá trị tình trạng bản sao sách: mới.
        /// </summary>
        public const string BOOKCOPIES_COPYCONDITION_NEW = "New";

        /// <summary>
        /// Giá trị tình trạng bản sao sách: tốt.
        /// </summary>
        public const string BOOKCOPIES_COPYCONDITION_GOOD = "Good";

        /// <summary>
        /// Giá trị tình trạng bản sao sách: trung bình.
        /// </summary>
        public const string BOOKCOPIES_COPYCONDITION_FAIR = "Fair";

        /// <summary>
        /// Giá trị tình trạng bản sao sách: hư hỏng.
        /// </summary>
        public const string BOOKCOPIES_COPYCONDITION_DAMAGED = "Damaged";

        /// <summary>
        /// Trạng thái bản sao sách: có sẵn để cho mượn.
        /// </summary>
        public const string BOOKCOPIES_COPYSTATUS_AVAILABLE = "Available";

        /// <summary>
        /// Trạng thái bản sao sách: đang được mượn.
        /// </summary>
        public const string BOOKCOPIES_COPYSTATUS_ONLOAN = "OnLoan";

        /// <summary>
        /// Trạng thái bản sao sách: đã được đặt trước.
        /// </summary>
        public const string BOOKCOPIES_COPYSTATUS_RESERVED = "Reserved";

        /// <summary>
        /// Trạng thái bản sao sách: bị mất.
        /// </summary>
        public const string BOOKCOPIES_COPYSTATUS_LOST = "Lost";

        /// <summary>
        /// Trạng thái bản sao sách: đã ngừng sử dụng.
        /// </summary>
        public const string BOOKCOPIES_COPYSTATUS_WITHDRAWN = "Withdrawn";

        #endregion

        #region Members

        /// <summary>
        /// Trạng thái thành viên: đang hoạt động.
        /// </summary>
        public const string MEMBERS_MEMBERSTATUS_ACTIVE = "Active";

        /// <summary>
        /// Trạng thái thành viên: bị tạm khóa.
        /// </summary>
        public const string MEMBERS_MEMBERSTATUS_SUSPENDED = "Suspended";

        /// <summary>
        /// Trạng thái thành viên: hết hạn.
        /// </summary>
        public const string MEMBERS_MEMBERSTATUS_EXPIRED = "Expired";

        /// <summary>
        /// Trạng thái thành viên: đã đóng tài khoản.
        /// </summary>
        public const string MEMBERS_MEMBERSTATUS_CLOSED = "Closed";

        /// <summary>
        /// Giá trị giới tính: nam.
        /// </summary>
        public const string MEMBERS_GENDER_MALE = "Male";

        /// <summary>
        /// Giá trị giới tính: nữ.
        /// </summary>
        public const string MEMBERS_GENDER_FEMALE = "Female";

        /// <summary>
        /// Giá trị giới tính: khác.
        /// </summary>
        public const string MEMBERS_GENDER_OTHER = "Other";

        #endregion

        #region Loans

        /// <summary>
        /// Trạng thái phiếu mượn: đang hoạt động.
        /// </summary>
        public const string LOANS_LOANSTATUS_ACTIVE = "Active";

        /// <summary>
        /// Trạng thái phiếu mượn: đã hoàn thành.
        /// </summary>
        public const string LOANS_LOANSTATUS_COMPLETED = "Completed";

        /// <summary>
        /// Trạng thái phiếu mượn: đã hủy.
        /// </summary>
        public const string LOANS_LOANSTATUS_CANCELLED = "Cancelled";

        #endregion

        #region LoanItems

        /// <summary>
        /// Trạng thái chi tiết phiếu mượn: đang mượn.
        /// </summary>
        public const string LOANITEMS_ITEMSTATUS_BORROWED = "Borrowed";

        /// <summary>
        /// Trạng thái chi tiết phiếu mượn: đã trả.
        /// </summary>
        public const string LOANITEMS_ITEMSTATUS_RETURNED = "Returned";

        /// <summary>
        /// Trạng thái chi tiết phiếu mượn: bị mất.
        /// </summary>
        public const string LOANITEMS_ITEMSTATUS_LOST = "Lost";

        /// <summary>
        /// Tình trạng sách khi trả: mới.
        /// </summary>
        public const string LOANITEMS_RETURNCONDITION_NEW = "New";

        /// <summary>
        /// Tình trạng sách khi trả: tốt.
        /// </summary>
        public const string LOANITEMS_RETURNCONDITION_GOOD = "Good";

        /// <summary>
        /// Tình trạng sách khi trả: trung bình.
        /// </summary>
        public const string LOANITEMS_RETURNCONDITION_FAIR = "Fair";

        /// <summary>
        /// Tình trạng sách khi trả: hư hỏng.
        /// </summary>
        public const string LOANITEMS_RETURNCONDITION_DAMAGED = "Damaged";

        #endregion
    }
}
