namespace GameMenu
{
    using SnakeProject.Models.Field.Interfaces;
    using SnakeProject.Models.Field;
    using SnakeProject.Utilites;
    using SnakeProject;

    IField field = new Field(new Coordinates(30, 120));
    IGameMenuEngine newGame = new GameMenu(field);
    newGame.StartGame();
}
