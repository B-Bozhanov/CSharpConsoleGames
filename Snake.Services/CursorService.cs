namespace Snake.Services
{
    using Common;

    using Snake.Models;
    using Snake.Models.Models.Menues;
    using Snake.Services.Drowers;
    using Snake.Services.Interfaces;

    public class CursorService : ICursorService
    {
        private Coordinates cursorCoordinates;
        private readonly char cursorSymbol;

        public CursorService()
        {
            this.cursorSymbol = GlobalConstants.Menu.CursorSymbol;
            int row = GlobalConstants.Menu.CursorStartRow;
            int column = GlobalConstants.Menu.CursorStartColumn;
            this.cursorCoordinates = new Coordinates(row, column, this.cursorSymbol, Color.Yellow);
        }

        public Coordinates Move(IInputHandlerService inputHandler, IDrowerService drower, int menuesCount)
        {
            while (true)
            {
                var currentPressedKey = inputHandler.GetPressedKeyboardKey();

                int move = 0;
                if (currentPressedKey == KeyboardKey.Up) move = -1;
                if (currentPressedKey == KeyboardKey.Down) move = 1;
                if (currentPressedKey != KeyboardKey.None) drower.DrowEmpty(this.cursorCoordinates);
                if (currentPressedKey == KeyboardKey.Enter) break;

                this.cursorCoordinates.Row += move;

                if (this.cursorCoordinates.Row < GlobalConstants.Menu.CursorStartRow)
                {
                    this.cursorCoordinates.Row = GlobalConstants.Field.GameRows - menuesCount - 1;
                }
                else if (this.cursorCoordinates.Row > GlobalConstants.Field.GameRows - menuesCount - 1)
                {
                    this.cursorCoordinates.Row = GlobalConstants.Menu.StartRow;
                }
                drower.Drow(this.cursorCoordinates);
            }

            this.cursorCoordinates.Column = GlobalConstants.Menu.CursorReturnColumnValue;
            return this.cursorCoordinates;
        }
    }
}
