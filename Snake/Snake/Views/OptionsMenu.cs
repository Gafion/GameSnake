using System;
using Snake.Models;
using Snake.Controllers;

namespace Snake.Views
{
    internal class OptionsMenu
    {
        public static void OptionsMenuRun(Action? previousMenuCallback = null)
        {
            var menu = new MenuBuilder("Options Menu");

            menu.AddMenuItem("Change Arena Size", () => ChangeArenaSize(() => OptionsMenuRun(previousMenuCallback)));
            menu.AddMenuItem("Change Snake Color", () => ChangeSnakeColor(() => OptionsMenuRun(previousMenuCallback)));
            menu.AddMenuItem("Change Food Color", () => ChangeFoodColor(() => OptionsMenuRun(previousMenuCallback)));
            menu.AddMenuItem("Change Game Speed", () => ChangeGameSpeed(() => OptionsMenuRun(previousMenuCallback)));
            menu.AddMenuItem("Back to Main Menu", previousMenuCallback ?? (() => { }));

            menu.DisplayMenu();
        }

        static void ChangeArenaSize(Action? previousMenuCallback)
        {
            var menu = new MenuBuilder("Arena Size");

            menu.AddMenuItem("Small", () => GameSettings.SetConsoleWindowSize(GameSettings.GameSize.Small));
            menu.AddMenuItem("Medium", () => GameSettings.SetConsoleWindowSize(GameSettings.GameSize.Medium));
            menu.AddMenuItem("Large", () => GameSettings.SetConsoleWindowSize(GameSettings.GameSize.Large));
            menu.AddMenuItem("Back to Main Menu", previousMenuCallback ?? (() => { }));

            menu.DisplayMenu();
        }

        static void ChangeSnakeColor(Action? previousMenuCallback)
        {
            var menu = new MenuBuilder("Snake Color");

            menu.AddMenuItem("Red", () => GameView.SnakeColor = ConsoleColor.Red);
            menu.AddMenuItem("Green", () => GameView.SnakeColor = ConsoleColor.Green);
            menu.AddMenuItem("Blue", () => GameView.SnakeColor = ConsoleColor.Blue);
            menu.AddMenuItem("Yellow", () => GameView.SnakeColor = ConsoleColor.Yellow);
            menu.AddMenuItem("White", () => GameView.SnakeColor = ConsoleColor.White);
            menu.AddMenuItem("Back to Options Menu", previousMenuCallback ?? (() => { }));

            menu.DisplayMenu();
        }

        static void ChangeFoodColor(Action? previousMenuCallback)
        {
            var menu = new MenuBuilder("Food Color");

            menu.AddMenuItem("Red", () => GameView.FoodColor = ConsoleColor.Red);
            menu.AddMenuItem("Green", () => GameView.FoodColor = ConsoleColor.Green);
            menu.AddMenuItem("Blue", () => GameView.FoodColor = ConsoleColor.Blue);
            menu.AddMenuItem("Yellow", () => GameView.FoodColor = ConsoleColor.Yellow);
            menu.AddMenuItem("White", () => GameView.FoodColor = ConsoleColor.White);
            menu.AddMenuItem("Back to Options Menu", previousMenuCallback ?? (() => { }));

            menu.DisplayMenu();
        }

        static void ChangeGameSpeed(Action? previousMenuCallback)
        {
            var menu = new MenuBuilder("Game Speed");

            menu.AddMenuItem("Slow", () => GameController.GameSpeed = 200);
            menu.AddMenuItem("Medium", () => GameController.GameSpeed = 100);
            menu.AddMenuItem("Fast", () => GameController.GameSpeed = 50);
            menu.AddMenuItem("Back to Options Menu", previousMenuCallback ?? (() => { }));

            menu.DisplayMenu();
        }
    }
}
