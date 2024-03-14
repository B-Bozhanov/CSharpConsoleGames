using Microsoft.Extensions.DependencyInjection;

using Snake;
using Snake.Game;

var services = RegisterServices.Register();
var gameManager = services.GetService<GameManager>()!;

gameManager.Start();
