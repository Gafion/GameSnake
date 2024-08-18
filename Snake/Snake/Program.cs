using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;

namespace Snake
{
    internal class Program
    {
        
        static void Main()
        {
            Console.CursorVisible = false;
            GameSettings.SetConsoleWindowSize(GameSettings.selectedSize);
            try
            {
                var controller = new GameController();

                LaunchMenu.LaunchMenuRun(controller);
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Main method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
            }
        }
    }
}
