using System.ComponentModel.DataAnnotations.Schema;

namespace Snake.Data.Models
{
    public class Score
    {
        public int Id { get; set; }

        public int BestScore { get; set; }

        public DateTime OnDate { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

    }
}