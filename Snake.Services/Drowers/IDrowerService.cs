namespace Snake.Services.Drowers
{
    using Snake.Models;
    using Snake.Models.Models.Menues;

    public interface IDrowerService
    {
        public void DrowInfoWindow(Coordinates startPossition, Color infoWindowColor = Color.DarkGray);

        public void DrowWalls(Coordinates startPossition, Color wallsColor = Color.DarkGray);

        public void Drow(IEnumerable<Coordinates> collection);

        public void DrowInfoWindowData(int score, int level, Color color = Color.White);

        public void DrowGameOver(int score, int level, Color color);

        /// <summary>
        /// Drow empty string on this coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        public void DrowEmpty(Coordinates coordinates, Color color = Color.Black);

        public void Drow(IEnumerable<IMenu> menues);

        public void Drow(Coordinates coordinates);
    }
}
