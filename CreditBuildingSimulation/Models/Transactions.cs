namespace CreditBuildingSimulation.Models
{
    public class Transactions
    {
        public Guid TransactionID { get; set; }
        public Guid RepaymentID { get; set; }
        public Guid LoanID { get; set; }
        public string? Company_Name { get; set; }
        public string? Company_Address { get; set; }
        public string? Payment_Description { get; set; }
        public DateTime Payment_Date { get; set; }
    }
}
