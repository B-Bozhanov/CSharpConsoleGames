using System;
using System.Collections.Generic;

namespace Snake
{
    internal class MenuPositions
    {
        private readonly List<Coordinates> possitions;
        private readonly int row;
        private readonly int col;

        public MenuPositions(string[] elements, int consoleRow, int consoleCol)
        {
            this.possitions = new List<Coordinates>();
            this.Elements = elements;
            this.row = consoleRow;
            this.col = consoleCol;
        }

        public string[] Elements { get; private set; }

        public int GetPositionIndex(Coordinates cursor)
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
        public void SetPositions()
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                possitions.Add(new Coordinates(row + i, col));
            }
        }
    }
}
