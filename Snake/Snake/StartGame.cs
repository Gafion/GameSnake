using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class StartGame
    {
        public static void Run()
        {
            try
            {
                var menu = new MenuBuilder("Snake Game");
                menu.DisplayInstructions();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Run method, before running game." + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
            }

            try
            {
                Logger.Log("Game started.");
                Console.Clear();

                int maxX = Console.WindowWidth;
                int maxY = Console.WindowHeight;

                Snake snake = new(maxX / 2, maxY / 2);
                Food food = new(10, 10);

                bool gameOver = false;

                while (!gameOver)
                {
                    try
                    {
                        Logger.Log("Game loop iteration started.");

                        Logic.HandleInput(snake);
                        snake.Move();

                        if (snake.Body[0] == food.Position)
                        {
                            Logger.Log("Food eaten.");
                            snake.Grow();
                            food.Respawn(maxX, maxY, snake.Body);
                            Logger.Log("Food eaten. New food position: " + food.Position);
                        }

                        gameOver = Logic.CheckCollisions(snake, maxX, maxY);

                        Logic.Render(snake, food);

                        Thread.Sleep(Program.GameSpeed); // Use the game speed

                        Logger.Log("Game loop iteration ended.");
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("Error during game loop: " + ex.Message);
                        Logger.Log(ex.StackTrace ?? string.Empty);
                        gameOver = true;
                    }
                }
                Logger.Log("Game Over!");
            }
            catch (Exception ex)
            {
                Logger.Log("Fatal error: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
            }
        }
    }
}
