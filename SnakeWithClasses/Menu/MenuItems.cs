using System;
using System.Collections.Generic;

namespace Snake
{
    internal class MenuItems
    {
        private List<Coordinates> coordinates;
        private string[] elements;

        public MenuItems(string[] elements, int row, int col)
        {
            this.elements = elements;
           this.coordinates = new List<Coordinates>();
            for (int i = 0; i < elements.Length; i++)
            {
                Visualizer.DrowingMenu(elements[i], row + i, col); // TODO: Move this from here
                coordinates.Add(new Coordinates(row + i, col));
            }
        }

        public string[] Elements { get => this.elements; }

        public int GetElement(Coordinates cursorPossition)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (this.coordinates[i].Row == cursorPossition.Row && this.coordinates[i].Col == cursorPossition.Col + 2)
                {
                    return i;
                }
            }

            throw new Exception();
        }
    }
}
