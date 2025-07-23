namespace CreditBuildingSimulation.Models
{
    public class Admins
    {
        public Guid AdminID { get; set; }
        public string? Email { get; set; }
        public string? Password_Hash { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Admin_Role { get; set; } // (e.g., agent, manager, super admin)
        public DateTime Creation_Date { get; set; } //The time when the account has been created.
    }
}
