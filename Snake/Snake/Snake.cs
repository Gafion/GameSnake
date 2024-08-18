using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake(int startX, int startY)
    {
        public List<(int x, int y)> Body { get; private set; } = [(startX, startY)];
        public (int x, int y) Direction { get; set; } = (0, 1);

        public void Move()
        {
            try
            {
                var (x, y) = Body[0];
                var newHead = (x + Direction.x, y + Direction.y);
                Body.Insert(0, newHead); // Add new head to the front

                // Remove the last segment if the snake didn't just grow
                if (Body.Count > 1 && Body[1] != newHead)
                {
                    Body.RemoveAt(Body.Count - 1);
                }

                // Debugging output
                Logger.Log("Snake moved to: " + newHead);
                PrintSnakeBody();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Move method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public void Grow()
        {
            try
            {
                var (x, y) = Body[^1];
                var newSegment = (x - Direction.x, y - Direction.y);
                Body.Add(newSegment); // Add a new segment at the correct position

                // Debugging output
                Logger.Log("Snake grew. New length: " + Body.Count);
                PrintSnakeBody();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Grow method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        private void PrintSnakeBody()
        {
            Logger.Log("Snake body:");
            foreach (var (x, y) in Body)
            {
                Logger.Log($"({x}, {y})");
            }
        }
    }
}
