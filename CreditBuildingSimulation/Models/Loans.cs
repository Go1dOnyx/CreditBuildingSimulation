namespace CreditBuildingSimulation.Models
{
    public class Loans
    {
        public Guid LoanID { get; set; }
        public Guid UserID { get; set; }
        public decimal Loan_Amount { get; set; } 
        public decimal Amount_Paid { get; set; } //How much has been paid
        public decimal Amount_Due { get; set; } //Can either be how much per month or how much is left to pay?
        public string? Loan_Status { get; set; } // (e.g., active, closed, frozen)
        public decimal Interest {  get; set; }
        public int Loan_Term { get; set; } // (e.g., in months)
        public string? Loan_Type { get; set; } // (e.g., bi weekly, weekly, monthly)
        public DateTime Start_Date { get; set; } //When the loan will be active
        public DateTime End_Date { get; set; } //When the loan be completed
        public DateTime Creation_Date { get; set; } //When the loan has been filed to be approved. 
    }
}
