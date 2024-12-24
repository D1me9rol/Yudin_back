namespace Yudin_back.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Member Member { get; set; }
        public Book Book { get; set; }

        public void MarkAsReturned()
        {
            ReturnDate = DateTime.Now;
        }

        public bool IsOverdue()
        {
            return (DateTime.Now - BorrowDate).Days > 30 && ReturnDate == null;
        }

        public int GetBorrowDuration()
        {
            return ReturnDate == null
                ? (DateTime.Now - BorrowDate).Days
                : (ReturnDate.Value - BorrowDate).Days;
        }

        public decimal CalculateFine()
        {
            if (!IsOverdue())
            {
                return 0;
            }
            int overdueDays = (DateTime.Now - BorrowDate).Days - 30;
            return overdueDays * 5; // Допустим, штраф — 5 единиц за день
        }

    }
}