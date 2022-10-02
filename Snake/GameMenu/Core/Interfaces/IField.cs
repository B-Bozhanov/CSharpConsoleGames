using GameMenu.Menues;
using GameMenu.Utilities;

namespace GameMenu.Core.Interfaces
{
    public interface IField
    {
        public int WindowHeight { get; }

        public int WindowWidth { get; }

        public static Coordinates MenuStartPossition { get; }

        public void WindowResizer(int row, int col);

        void SetBackgroundColor(Color backGroundColor);

        void SetTextColor(Color textColor);

        void ResetColor();
    }
}
