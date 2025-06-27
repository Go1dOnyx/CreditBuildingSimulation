namespace CreditBuildingSimulation.Models
{
    public class Users
    {
        public Guid UserID { get; set; }
        public string? Email { get; set; }
        public string? Password_Hash { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public decimal User_Income { get; set; } //From here below, we will use a separate API to get information and dedicated classes. This is just for testing
        public int Credit_Score { get; set; } 
        public DateTime Creation_Date {  get; set; } //Time when account has been created
    }
}
