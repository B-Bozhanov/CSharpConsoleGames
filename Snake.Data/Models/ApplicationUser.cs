namespace Snake.Data.Models
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }

        public int HightScore { get; set; }

        public int CurrentScore { get; set; }

        public int CurrentLevel { get; set; }

        public int MaxLevel { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastSignIn { get; set; }

        public bool IsDeactivated { get; set; }

        public int SnakeId { get; set; }

        public Snake Snake { get; set; } = null!;
    }
}
