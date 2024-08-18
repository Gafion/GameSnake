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
            menu.AddMenuItem("Start Game", () => controller.RunGame());
            menu.AddMenuItem("Options", OptionsMenu.OptionsMenuRun);
            menu.DisplayMenu();
        }
    }
}
