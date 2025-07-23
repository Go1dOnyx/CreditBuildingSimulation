namespace CreditBuildingSimulation.Models
{
    public class Rewards
    {
        public Guid RewardID { get; set; }
        public Guid UserID { get; set; }
        public int Reward_Points { get; set; } //rewards go based on 10% per payment you make towars the loan. So 120 equals 12 points. 
        public int Score { get; set; } //Every 12 months you would make above 100 points which makes you tier 1 with new rewards unless you spent the points on lesser rewards
    }
}
