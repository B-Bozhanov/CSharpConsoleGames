namespace Common
{
    public static class GlobalConstants
    {
        public static class Field
        {
            public const int GameRows = 20;
            public const int GameColumns = 80;
            public const int InfoWindowHeight = 2;
            public const int FieldRows = 1 + InfoWindowHeight + 1 + GameRows;   // One is borders
            public const int FieldColumns = GameColumns;

            public static class InfoWindow
            {
                public const char InfoWindowLeftEdge = '╔';
                public const char InfoWindowRightEdge = '╗';
                public const char WallBottomLeftEdge = '╚';
                public const char WallBottomRightEdge = '╝';
                public const char InfoWindowHorizontalLine = '═';
                public const char InfoWindowBottomLeftEdge = '╠';
                public const char InfoWindowBottomRightEdge = '╣';
                public const char VerticalLine = '║';
                public const char EmptySymbol = ' ';
            }

            public static class InfoWindowData
            {
                public const int ScoreRowCoordinate = 1;
                public const int ScoreColumnCoordinate = 1;
                public const int LevelRowCoordinate = 2;
                public const int LevelColumnCoordinate = 1;
                public const string ScoreMessage = "Score: {0}";
                public const string LevelMessage = "Level: {0}";
                public const string GameOverScoreMessage = "Game over!{0} Your Score is: {1} at Level: {2}";
            }
        }

        public static class Menu
        {
            public const int StartRow = Field.GameRows / 2;
            public const int StartColumn = Field.GameColumns / 2 - 5;
            public const int CursorDistannce = 2;
            public const int CursorStartRow = StartRow;
            public const int CursorStartColumn = StartColumn - CursorDistannce;
            public const int CursorReturnColumnValue = CursorStartColumn + CursorDistannce;
            public const char CursorSymbol = '*';

            public const string MenuAssemblyName = "Snake.Menu";
            public const string StartMenuTypeName = "Login";
        }

        public static class Snake
        {
            public const string BodySymbol = "●";
            public const int DefaultLength = 3;
            public const int DefaultSpeed = 200;
            public const string HeadLeft = "<";
            public const string HeadRight = ">";
            public const string HeadUp = "^";
            public const string HeadDown = "V";
            public const string FoodSymbol = "@";
            public const char ObstacleSymbol = (char) 9760;
            public const int FirstObstaclesCount = 3;
            public const string Name = "Snake v1.0";
            public const int StartPossition = Field.InfoWindowHeight + 2;
            public const int ObstaclesAppearLevel = 5;
            public const int WallsAppearLevel = 10;
        }

        public static class Exceptions
        {
            public static class Menu
            {
                public const string AssemblyNotFound = "The assembly is not found";
                public const string TypeNotFound = "The type is not found";
                public const string NamespaceNotFound = "There is no namespace";
            }
        }
    }
}
