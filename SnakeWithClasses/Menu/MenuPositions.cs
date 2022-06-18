using System.Collections.Generic;

namespace Snake
{
    internal class MenuPositions 
    {
        private readonly List<Coordinates> menuCoords;
        private readonly string[] elements;
        private readonly int row;
        private readonly int col;

        internal MenuPositions(string[] elements, int row, int col)
        {
            this.menuCoords = new List<Coordinates>();
            this.elements = elements;
            this.row = row;
            this.col = col;
        }
        internal int GetPositionIndex(Coordinates cursor)
        {
            for (int i = 0; i < menuCoords.Count; i++)
            {
                if (this.menuCoords[i].Row == cursor.Row &&
                    this.menuCoords[i].Col == cursor.Col)
                {
                    return i;
                }
            }
            return -1;
        }
        internal void SetPositions()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.menuCoords.Add(new Coordinates(this.row + i, this.col));
            }
        }
    }
}
