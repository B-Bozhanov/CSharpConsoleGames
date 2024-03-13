namespace Snake.Drowers
{
    using System.Text;

    using static Common.GlobalConstants;
    using static Common.GlobalConstants.Field;

    public abstract class DrowerBase
    {
        public static string GetInfoWindow()
        {
            var infoWindowString = new StringBuilder();
            var middleLine = new StringBuilder();
            var horizontalLine = new string(InfoWindow.InfoWindowHorizontalLine, FieldColumns - 2);

            infoWindowString.Append(InfoWindow.InfoWindowLeftEdge);
            infoWindowString.Append(horizontalLine);
            infoWindowString.Append(InfoWindow.InfoWindowRightEdge);

            for (int i = 0; i < InfoWindowHeight; i++)
            {
                middleLine.Append(InfoWindow.VerticalLine);
                middleLine.Append(new string(InfoWindow.EmptySymbol, FieldColumns - 2));
                middleLine.Append(InfoWindow.VerticalLine);
            }

            infoWindowString.Append(middleLine.ToString().TrimEnd());
            infoWindowString.Append(InfoWindow.InfoWindowBottomLeftEdge);
            infoWindowString.Append(horizontalLine);
            infoWindowString.Append(InfoWindow.InfoWindowBottomRightEdge);

            return infoWindowString.ToString().Trim();
        }

        public static string GetWalls()
        {
            var walls = new StringBuilder();

            for (int i = 0; i <= GameRows -1 ; i++)
            {
                walls.Append(InfoWindow.VerticalLine);
                walls.Append(new string(InfoWindow.EmptySymbol, FieldColumns - 2));
                walls.Append(InfoWindow.VerticalLine);
            }

            walls.Append(InfoWindow.WallBottomLeftEdge);
            walls.Append(new string(InfoWindow.InfoWindowHorizontalLine, FieldColumns - 2));
            walls.Append(InfoWindow.WallBottomRightEdge);

            return walls.ToString().Trim();
        }
    }
}
