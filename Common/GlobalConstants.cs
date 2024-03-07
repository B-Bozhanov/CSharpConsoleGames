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
        }

        public static class Snake
        {
            public const string Name = "Snake v1.0";
            public const int DefaultLength = 3;
            public const int DefaultSpeed = 1;
            public const string Food = "";
            public const int StartPossition = Field.InfoWindowHeight + 2;
        }
    }
}
