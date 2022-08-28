using GameMenu.Core;
using GameMenu.Core.Interfaces;
using Snake.Core;
using Snake.Core.Interfaces;

IGameMenuEngine engine = new GameMenuEngine("");
ISnakeEngine snake = new SnakeEngine();

engine.Start();
snake.StartGame();
