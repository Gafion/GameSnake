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
            try
            {
                GameSettings.SetConsoleWindowSize(GameSettings.selectedSize);
                Console.CursorVisible = false;

                var snake = new Models.Snake(Console.WindowWidth / 2, Console.WindowHeight / 2);
                var food = new Food(10, 10);
                var view = new GameView();
                var controller = new GameController(snake, food);

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
