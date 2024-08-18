using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public List<(int x, int y)> Body { get; private set; }
        public (int x, int y) Direction { get; set; }

        public Snake(int startX, int startY)
        {
            Body = [(startX, startY)];
            Direction = (0, 1);
        }

        public void Move()
        {
            try
            {
                var head = Body[0];
                var newHead = (head.x + Direction.x, head.y + Direction.y);
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
                var tail = Body[Body.Count - 1];
                var newSegment = (tail.x - Direction.x, tail.y - Direction.y);
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
            foreach (var segment in Body)
            {
                Logger.Log($"({segment.x}, {segment.y})");
            }
        }
    }
}
