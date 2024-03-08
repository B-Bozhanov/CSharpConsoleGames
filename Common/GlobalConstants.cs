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

        public static class Snake
        {
            public const char BodySymbol = '●';
            public const int DefaultLength = 3;
            public const int DefaultSpeed = 1;
            public const char HeadLeft = '<';
            public const char HeadRight = '>';
            public const char HeadUp = '^';
            public const char HeadDown = 'V';
            public const char FoodSymbol = '@';
            public const string Name = "Snake v1.0";
            public const int StartPossition = Field.InfoWindowHeight + 2;
        }
    }
}
