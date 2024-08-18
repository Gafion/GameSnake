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
    internal class GameView
    {
        public static ConsoleColor SnakeColor { get; set; } = ConsoleColor.White;
        public static ConsoleColor FoodColor { get; set; } = ConsoleColor.Red;

        public static void Render(Snake.Models.Snake snake, Snake.Models.Food food)
        {
            try
            {
                Console.Clear();

                // Render the snake
                foreach (var (x, y) in snake.Body)
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = SnakeColor;
                    Console.Write(" "); // Print a space with the snake's color
                    Console.ResetColor();
                }

                Console.SetCursorPosition(food.Position.x, food.Position.y);
                Console.BackgroundColor = FoodColor;
                Console.Write(" "); // Print a space with the food's color
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Render method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public static void DisplayMenu(MenuBuilder menu)
        {
            menu.DisplayMenu();
        }
    }
}
