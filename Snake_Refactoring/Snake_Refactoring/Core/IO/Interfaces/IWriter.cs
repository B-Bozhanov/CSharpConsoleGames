using SnakeProject.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject.Core.IO.Interfaces
{
    internal interface IWriter
    {
        void DrowingInfoWindow();
        void DrowingGameInfo(int score, int level);
        void DrowingLevelWalls(int row, int infoWindow, int col);
        void DrowingSnake(ISnake snake);
        void DrowingMenu(string[] items, int row, int col);
        void DrowingCursor(char item, Coordinates position);
        void FoodDrowing(char symbol, Coordinates food);
        void GameOver(int score);
    }
}
