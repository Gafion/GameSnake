namespace Snake
{
    internal class Program
    {
        public static ConsoleColor SnakeColor { get; set; } = ConsoleColor.White;
        public static ConsoleColor FoodColor { get; set; } = ConsoleColor.Red;
        public static int GameSpeed { get; set; } = 100; // Default game speed in milliseconds
        public enum GameSize
        {
            Small,
            Medium,
            Large
        }

        static readonly GameSize selectedSize = GameSize.Medium; // Default game size
        static void Main()
        {
            try
            {
                SetConsoleWindowSize(selectedSize);
                Console.CursorVisible = false;
                LaunchMenu.LaunchMenuRun();
            }
            catch (Exception ex)
            {
                Logger.Log("Error in Main method: " + ex.Message);
                Logger.Log(ex.StackTrace ?? string.Empty);
            }
        }

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
