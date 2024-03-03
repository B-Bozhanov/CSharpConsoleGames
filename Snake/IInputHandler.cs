namespace Snake
{
    public interface IInputHandler
    {
        public KeyboardKey GetPressedKeyboardKey(KeyboardKey currentKey);
    }
}