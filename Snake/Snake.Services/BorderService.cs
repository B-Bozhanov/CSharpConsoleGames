namespace Snake.Services
{
    using System.Text;

    using Snake.Models.Menu.Core.Interfaces;

    public class BorderService : IBorderService
    {

        private const char TopLeftEdge = '╔';
        private const char TopRightEdge = '╗';
        private const char MiddleHorizontalLine = '═';
        private const char MiddleVerticalLine = '║';
        private const char MiddleLeftEdge = '╠';
        private const char MiddleRightEdge = '╣';
        private const char BottomLeftEdge = '╚';
        private const char BottomRightEdge = '╝';
        private const char Empty = ' ';

        private IField field;

        public BorderService(IField field)
        {
            this.field = field;
        }

        public string GetInfoWindow()
        {
            var infoWindow = new StringBuilder();

            string line = null!;
            line += TopLeftEdge;
            line += new string(MiddleHorizontalLine, field.InfoWindow.Col - 2);
            line += TopRightEdge;
            infoWindow.AppendLine(line);

            for (int i = 0; i < field.InfoWindow.Row; i++)
            {
                string middleLine = null!;
                middleLine += MiddleVerticalLine;
                middleLine += new string(Empty, field.InfoWindow.Col - 2);
                middleLine += MiddleVerticalLine;
                infoWindow.AppendLine(middleLine);
            }

            string endLine = null!;
            endLine += MiddleLeftEdge;
            endLine += new string(MiddleHorizontalLine, field.InfoWindow.Col - 2);
            endLine += MiddleRightEdge;
            infoWindow.AppendLine(endLine);

            return infoWindow.ToString().Trim();
        }

        public string GetWalls()
        {
            var walls = new StringBuilder();

            for (int i = 5; i < field.WindowHeight; i++)
            {
                string middleLine = null!;
                middleLine += MiddleVerticalLine;
                middleLine += new string(Empty, field.InfoWindow.Col - 2);
                middleLine += MiddleVerticalLine;
                walls.AppendLine(middleLine);
            }

            string endLine = null!;
            endLine += BottomLeftEdge;
            endLine += new string(MiddleHorizontalLine, field.InfoWindow.Col - 2);
            endLine += BottomRightEdge;
            walls.AppendLine(endLine);

            return walls.ToString().Trim();
        }
    }
}
