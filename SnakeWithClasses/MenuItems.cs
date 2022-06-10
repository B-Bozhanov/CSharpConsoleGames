using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MenuItems
    {
        private Dictionary<Coordinates, string> test;
        public string[] Elements { get; set; }
        public Coordinates[] Cords { get; set; }

        public MenuItems(string[] elements, Coordinates[] cords)
        {
            this.Elements = elements;
            this.Cords = cords;
            this.test = new Dictionary<Coordinates, string>();

            SetElements();
        }

        private void SetElements()
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                test.Add(Cords[i], Elements[i]);
            }
        }
        public void Print(int row, int col)
        {
            foreach (var item in test)
            {
                Visualizer.WriteOnConsole(item.Value, row, col, ConsoleColor.Yellow);
                row++;
            }
        }
    }
}
