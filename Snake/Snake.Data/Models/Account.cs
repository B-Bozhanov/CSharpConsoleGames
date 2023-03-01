namespace Snake.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Account
    {
        public Account()
        {
            this.Scores = new HashSet<Score>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public DateTime LastBlockedTime { get; set; }

        public DateTime ExpiredBlockTime { get; set; }

        public DateTime CreatedTime { get; set; }

        public int SnakeId { get; set; }

        public Snake Snake { get; set; }

        public int SettingsId { get; set; }

        public Settings Settings { get; set; }

        public ICollection<Score> Scores { get; set; }
    }
}
