using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;

namespace Snake.Views
{
    internal class LaunchMenu
    {
        public static void LaunchMenuRun(GameController controller)
        {
            var menu = new MenuBuilder("Welcome to Snake");

            // Use a lambda expression to call RunGame on the controller instance
            menu.AddMenuItem("Start Game", () =>
            {
                Logger.Log("Start Game selected.");
                controller.RunGame();
            });
            menu.AddMenuItem("Options", () =>
            {
                Logger.Log("Options menu opened from launch menu.");
                OptionsMenu.OptionsMenuRun(() => LaunchMenuRun(controller));
            });
            menu.AddMenuItem("Exit", () =>
            {
                Logger.Log("Exit selected.");
                Environment.Exit(0);
            });

            menu.DisplayMenu();
        }
    }
}
