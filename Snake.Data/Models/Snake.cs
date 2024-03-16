namespace Snake.Data.Models
{
    public class Snake
    {
        public int Id { get; set; }

        public int CurrentLength { get;}

        public Guid ApplicationUserId { get;}

        public ApplicationUser ApplicationUser { get; } = null!;
    }
}
