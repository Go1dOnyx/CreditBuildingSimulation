namespace CreditBuildingSimulation.Models
{
    public class Repayments
    {
        public Guid RepaymentID { get; set; }
        public Guid LoanID { get; set; }
        public decimal Payment_Amount { get; set; }
        public DateTime Payment_Date { get; set; } //When the amount had been paid
        public string? Payment_Status { get; set; } // (e.g., processing, completed/successful, failed/denied)
    }
}
