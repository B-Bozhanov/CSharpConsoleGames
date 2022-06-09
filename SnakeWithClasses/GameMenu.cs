using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameMenu
    {
        private readonly string[] mainMenuOptions;



        private GameMenu()
        {
            this.mainMenuOptions = new string[]
            { 
               "New Game",
               "Dificult",
               "Settings",
               "Exit"
            };
        }


        public static void MainMenu(Field field)
        {
            while (true)
            {
                //Visualizer.WriteOnConsole();
            }
        }
    }
}
