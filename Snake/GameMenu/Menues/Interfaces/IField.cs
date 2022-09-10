namespace GameMenu.Menues.Interfaces
{
    public interface IField
    {
        public int WindowHeight { get; }

        public int WindowWidth { get; }

        public int MenuRow { get; }

        public int MenuCol { get; }

        public void WindowResizer(int row, int col);
        void SetBackgroundColor(Color backGroundColor);
        void SetTextColor(Color textColor);
        void ResetColor();
    }
}
