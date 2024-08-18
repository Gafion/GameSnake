using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;

namespace Snake.Models
{
    internal static class GameSettings
    {
        public enum GameSize
        {
            Small,
            Medium,
            Large
        }

        public static readonly GameSize selectedSize = GameSize.Medium; // Default game size

        public static (int width, int height) SetGameSizeDimensions(GameSize size)
        {
            return size switch
            {
                GameSize.Small => (175, 50),
                GameSize.Medium => (175, 50),
                GameSize.Large => (175, 50),
                _ => (175, 50)
            };
        }

        public static void SetConsoleWindowSize(GameSize size)
        {
            var (width, height) = SetGameSizeDimensions(size);

            // Ensure the window size does not exceed the largest possible window size
            int windowWidth = Math.Min(width, Console.LargestWindowWidth);
            int windowHeight = Math.Min(height, Console.LargestWindowHeight);

            Console.SetWindowSize(windowWidth, windowHeight);
        }
    }
}
