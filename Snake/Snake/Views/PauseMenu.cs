using Snake.Controllers;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Views
{
    internal class PauseMenu
    {
        public static void PauseMenuRun(GameController controller)
        {
            var menu = new MenuBuilder("Game Paused");

            menu.AddMenuItem("Resume Game", () =>
            {
                Logger.Log("Game resumed.");
                // Do nothing, just return to the game loop
            });
            menu.AddMenuItem("Restart Game", () =>
            {
                Logger.Log("Game restarted.");
                controller.RunGame();
            });
            menu.AddMenuItem("Options", () =>
            {
                Logger.Log("Options menu opened from pause menu.");
                OptionsMenu.OptionsMenuRun(() => PauseMenuRun(controller));
            });
            menu.AddMenuItem("Exit to Main Menu", () =>
            {
                Logger.Log("Exited to main menu from pause menu.");
                LaunchMenu.LaunchMenuRun(controller);
            });

            Logger.Log("Game paused.");
            menu.DisplayMenu();
        }
    }
}
