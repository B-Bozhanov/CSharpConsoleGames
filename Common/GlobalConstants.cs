namespace Common
{
    public static class GlobalConstants
    {
        public static class Field
        {
            public const int Rows = 30;
            public const int Columns = 118;
            public const int InfoWindow = Rows / 8;
            public const int ConsoleRow = 1 + InfoWindow + 1 + Rows + 1;   // One is borders
            public const int ConsoleCol = 1 + Columns + 1;
        }

        public static class Snake
        {
            public const string Name = "Snake v1.0";
            public const int DefaultLength = 4;
            public const int StartPossition = Field.InfoWindow + 2;
        }
    }
}
