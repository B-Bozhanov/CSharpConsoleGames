namespace Snake.Helpers
{
    public interface IInputHandler
    {
        public KeyboardKey GetPressedKey(KeyboardKey currentKey);
    }
}