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
    internal class Food(int startX, int startY)
    {
        public (int x, int y) Position { get; private set; } = (startX, startY);

        public void Respawn(int maxX, int maxY, List<(int x, int y)> snakeBody)
        {
            try
            {
                Random rand = new();
                (int x, int y) newPosition;

                do
                {
                    newPosition = (rand.Next(0, maxX), rand.Next(0, maxY));
                } while (snakeBody.Contains(newPosition));

                Position = newPosition;

                // Debugging output
                Logger.Log("Food respawned at: " + Position);
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Respawn method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }
    }
}
