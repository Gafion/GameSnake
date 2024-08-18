using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class LaunchMenu
    {
        public static void LaunchMenuRun()
        {
            var menu = new MenuBuilder("Welcome to Snake");
            menu.AddMenuItem("Start Game", StartGame.Run);
            menu.AddMenuItem("Options", OptionsMenu.OptionsMenuRun);
            menu.DisplayMenu();
        }
    }
}
