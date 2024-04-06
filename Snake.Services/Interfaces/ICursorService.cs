namespace Snake.Services.Interfaces
{
    using Snake.Models;
    using Snake.Models.Models.Menues;
    using Snake.Services.Drowers;

    public interface ICursorService
    {
        public Coordinates Move(IInputHandlerService inputHandler, IDrowerService drower, int menuesCount);
    }
}
