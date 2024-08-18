using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class OptionsMenu
    {
        public static void OptionsMenuRun()
        {
            var menu = new MenuBuilder("Options Menu");
            menu.AddMenuItem("Change Arena Size", ChangeArenaSize);
            menu.AddMenuItem("Change Snake Color", ChangeSnakeColor);
            menu.AddMenuItem("Change Food Color", ChangeFoodColor);
            menu.AddMenuItem("Change Game Speed", ChangeGameSpeed);
            menu.DisplayMenu();
        }

        static void ChangeArenaSize()
        {
            var menu = new MenuBuilder("Arena Size");
            menu.AddMenuItem("Small", () => Program.SetConsoleWindowSize(Program.GameSize.Small));
            menu.AddMenuItem("Medium", () => Program.SetConsoleWindowSize(Program.GameSize.Medium));
            menu.AddMenuItem("Large", () => Program.SetConsoleWindowSize(Program.GameSize.Large));
            menu.DisplayMenu();
        }

        static void ChangeSnakeColor()
        {
            var menu = new MenuBuilder("Snake Color");
            menu.AddMenuItem("Red", () => Program.SnakeColor = ConsoleColor.Red);
            menu.AddMenuItem("Green", () => Program.SnakeColor = ConsoleColor.Green);
            menu.AddMenuItem("Blue", () => Program.SnakeColor = ConsoleColor.Blue);
            menu.AddMenuItem("Yellow", () => Program.SnakeColor = ConsoleColor.Yellow);
            menu.AddMenuItem("White", () => Program.SnakeColor = ConsoleColor.White);
            menu.DisplayMenu();
        }

        static void ChangeFoodColor()
        {
            var menu = new MenuBuilder("Food Color");
            menu.AddMenuItem("Red", () => Program.FoodColor = ConsoleColor.Red);
            menu.AddMenuItem("Green", () => Program.FoodColor = ConsoleColor.Green);
            menu.AddMenuItem("Blue", () => Program.FoodColor = ConsoleColor.Blue);
            menu.AddMenuItem("Yellow", () => Program.FoodColor = ConsoleColor.Yellow);
            menu.AddMenuItem("White", () => Program.FoodColor = ConsoleColor.White);
            menu.DisplayMenu();
        }

        static void ChangeGameSpeed()
        {
            var menu = new MenuBuilder("Game Speed");
            menu.AddMenuItem("Slow", () => Program.GameSpeed = 200);
            menu.AddMenuItem("Medium", () => Program.GameSpeed = 100);
            menu.AddMenuItem("Fast", () => Program.GameSpeed = 50);
            menu.DisplayMenu();
        }
    }
}
