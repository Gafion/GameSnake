using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Logic
    {
        public static void HandleInput(Snake snake)
        {
            try
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Direction = (0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = (0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = (-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = (1, 0);
                            break;
                    }
                    Logger.Log("Direction changed to: " + snake.Direction);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error in HandleInput method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public static void Render(Snake snake, Food food)
        {
            try
            {
                Console.Clear();
                foreach (var segment in snake.Body)
                {
                    Console.SetCursorPosition(segment.x, segment.y);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }

                Console.SetCursorPosition(food.Position.x, food.Position.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Render method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }

        }

        public static bool CheckCollisions(Snake snake, int maxX, int maxY)
        {
            try
            {
                var head = snake.Body[0];

                // Check wall collision
                if (head.x < 0 || head.x >= maxX || head.y < 0 || head.y >= maxY)
                {
                    Logger.Log("Collision with wall detected.");
                    return true;
                }

                // Check self collision
                for (int i = 1; i < snake.Body.Count; i++)
                {
                    if (snake.Body[i] == head)
                    {
                        Logger.Log("Collision with self detected.");
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("Error in CheckCollisions method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }
    }
}
