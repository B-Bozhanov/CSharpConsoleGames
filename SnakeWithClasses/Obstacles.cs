using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Obstacles
    {
        private List<Coordinates> obstacles;
        public Obstacles()
        {
            var obstacles = new List<Coordinates>()
            {
                new Coordinates(6, 30),    // TODO: Fix coordinates abaut the consoleSize
                new Coordinates(15, 23),
                new Coordinates(25, 100),
                new Coordinates(17, 93),
            };
        }
    }
}
