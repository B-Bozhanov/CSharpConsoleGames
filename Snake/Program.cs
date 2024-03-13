using System.Diagnostics;
using System.Net.Http.Headers;

using Common;

using Snake;
using Snake.Drowers;

using static Common.GlobalConstants;

IField field = new ConsoleField(
    new Coordinates(Field.GameRows, Field.GameColumns)
    , Field.InfoWindowHeight
    , new Coordinates(Field.FieldRows, Field.FieldColumns));

var snake = new Snake.Snake(field, GlobalConstants.Snake.StartPossition);

var gameManager = new GameManager(
    new ConsoleDrower(), 
    field, 
    new ConsoleInputHandler(), 
    new Direction(), snake,
    new ScoreManager(), 
    new Food(field), 
    new Obstacle());

gameManager.Start();
