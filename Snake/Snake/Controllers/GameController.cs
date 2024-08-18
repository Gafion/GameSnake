using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;


namespace Snake.Controllers
{
    public class GameController
    {
        public static int GameSpeed { get; set; } = 100; // Default game speed
        private Models.Snake _snake;
        private Models.Food _food;

        public GameController()
        {
            _snake = new Models.Snake(Console.WindowWidth / 2, Console.WindowHeight / 2); // Initial snake position
            _food = new Models.Food(20, 20); // Initial food position
        }

        public void HandleInput()
        {
            try
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            _snake.Direction = (0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            _snake.Direction = (0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            _snake.Direction = (-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            _snake.Direction = (1, 0);
                            break;
                        case ConsoleKey.Escape:
                            Logger.Log("Game paused.");
                            PauseMenu.PauseMenuRun(this);
                            break;
                    }
                    Logger.Log("Direction changed to: " + _snake.Direction);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error in HandleInput method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public void Update()
        {
            _snake.Move();
            if (_snake.Body[0] == _food.Position)
            {
                _snake.Grow();
                _food.Respawn(Console.WindowWidth, Console.WindowHeight, _snake.Body);
            }

            if (_snake.CheckCollisions(Console.WindowWidth, Console.WindowHeight))
            {
                // Handle collision (e.g., end game, reset game, etc.)
                Logger.Log("Game Over");
                // Game over logic should go here
            }
        }

        public void Render()
        {
            GameView.Render(_snake, _food);
        }

        public void RunGame()
        {
            try
            {
                // Reset game state
                _snake = new Models.Snake(Console.WindowWidth / 2, Console.WindowHeight / 2); // Reset snake position
                _food = new Models.Food(20, 20); // Reset food position

                MenuView.DisplayInstructions();

                Logger.Log("Game started.");
                Console.Clear();

                int maxX = Console.WindowWidth;
                int maxY = Console.WindowHeight;

                bool gameOver = false;

                while (!gameOver)
                {
                    try
                    {
                        Logger.Log("Game loop iteration started.");

                        
                        HandleInput();
                        Update();
                        Render();

                        Thread.Sleep(GameSpeed); // Use the game speed

                        Logger.Log("Game loop iteration ended.");
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("Error during game loop: " + ex.Message);
                        Logger.Log(ex.StackTrace ?? string.Empty);
                        gameOver = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Fatal error: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
            }
        }
    }
}
