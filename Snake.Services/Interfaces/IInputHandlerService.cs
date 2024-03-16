namespace Snake.Services.Interfaces
{
    using Snake.Models;

    public interface IInputHandlerService
    {
        public KeyboardKey GetPressedKeyboardKey(KeyboardKey currentKey);
    }
}