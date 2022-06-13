using System.Collections.Generic;

namespace Snake
{
    internal class MenuPositions
    {
        private readonly List<Coordinates> possitions;
        private readonly string[] elements;
        private readonly int row;
        private readonly int col;

        internal MenuPositions(string[] elements, int consoleRow, int consoleCol)
        {
            this.possitions = new List<Coordinates>();
            this.elements = elements;
            this.row = consoleRow;
            this.col = consoleCol;
        }

        internal int GetPositionIndex(Coordinates cursor)
        {
            for (int i = 0; i < possitions.Count; i++)
            {
                if (this.possitions[i].Row == cursor.Row &&
                    this.possitions[i].Col == cursor.Col)
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
                this.possitions.Add(new Coordinates(this.row + i, this.col));
            }
        }
    }
}
