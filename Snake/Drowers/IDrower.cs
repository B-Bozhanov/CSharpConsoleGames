namespace Snake.Drowers
{
    public interface IDrower
    {
        public void DrowInfoWindow(Coordinates startPossition, Color infoWindowColor = Color.DarkGray);

        public void DrowWalls(Coordinates startPossition, Color wallsColor = Color.DarkGray);

        public void Drow(string text, Coordinates coordinatesToDrow, Color color = Color.Black);

        /// <summary>
        /// Drow empty string on this coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        public void Drow(Coordinates coordinates);
    }
}
