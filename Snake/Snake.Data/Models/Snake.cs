namespace Snake.Data.Models
{
    public class Snake
    {
        public int Id { get; set; }

        public int Length { get; set; }

        public Color Colors { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
