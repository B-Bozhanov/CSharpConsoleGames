namespace SnakeProject.Models.Field
{
    using Utilites;
    using Models.Field.Interfaces;

    public class Field : GameField
    {
        public Field(Coordinates fieldSize) 
            : base(fieldSize)
        {
        }
    }
}
