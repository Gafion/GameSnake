using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;

namespace Snake.Views
{
    internal class MenuBuilder(string menuTitle)
    {
        private readonly List<(string option, Action action, string feedbackMessage)> _menuItems = [];
        private static readonly Dictionary<char, string[]> LargeLetters;
        static MenuBuilder()
        {
            LargeLetters = new Dictionary<char, string[]>
            {
                { 'A', new[] { "    0    ", "   0 0   ", "  0   0  ", " 0     0 ", "0       0", "000000000", "0       0", "0       0", "0       0", "0       0" } },
                { 'B', new[] { "0000000  ", "0      0 ", "0      0 ", "0      0 ", "0000000  ", "0      0 ", "0      0 ", "0      0 ", "0      0 ", "0000000  " } },
                { 'C', new[] { "  00000  ", " 0     0 ", "0        ", "0        ", "0        ", "0        ", "0        ", "0        ", " 0     0 ", "  00000  " } },
                { 'D', new[] { "000000   ", "0     0  ", "0      0 ", "0      0 ", "0      0 ", "0      0 ", "0      0 ", "0      0 ", "0     0  ", "000000   " } },
                { 'E', new[] { "00000000 ", "0        ", "0        ", "0        ", "0000000  ", "0        ", "0        ", "0        ", "0        ", "00000000 " } },
                { 'F', new[] { "00000000 ", "0        ", "0        ", "0        ", "0000000  ", "0        ", "0        ", "0        ", "0        ", "0        " } },
                { 'G', new[] { "  000000 ", " 0       ", "0        ", "0        ", "0    0000", "0       0", "0       0", "0       0", " 0     0 ", "  00000  " } },
                { 'H', new[] { "0       0", "0       0", "0       0", "0       0", "000000000", "0       0", "0       0", "0       0", "0       0", "0       0" } },
                { 'I', new[] { "000000000", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "000000000" } },
                { 'J', new[] { "000000000", "      0  ", "      0  ", "      0  ", "      0  ", "      0  ", "      0  ", "0     0  ", " 0   0   ", "  000    " } },
                { 'K', new[] { "0      0 ", "0     0  ", "0    0   ", "0   0    ", "0  0     ", "000      ", "0  0     ", "0   0    ", "0    0   ", "0     0  " } },
                { 'L', new[] { "0        ", "0        ", "0        ", "0        ", "0        ", "0        ", "0        ", "0        ", "0        ", "000000000" } },
                { 'M', new[] { "0       0", "00     00", "0 0   0 0", "0  0 0  0", "0   0   0", "0       0", "0       0", "0       0", "0       0", "0       0" } },
                { 'N', new[] { "0       0", "00      0", "0 0     0", "0  0    0", "0   0   0", "0    0  0", "0     0 0", "0      00", "0       0", "0       0" } },
                { 'O', new[] { "  00000  ", " 0     0 ", "0       0", "0       0", "0       0", "0       0", "0       0", "0       0", " 0     0 ", "  00000  " } },
                { 'P', new[] { "0000000  ", "0      0 ", "0      0 ", "0      0 ", "0000000  ", "0        ", "0        ", "0        ", "0        ", "0        " } },
                { 'Q', new[] { "  00000  ", " 0     0 ", "0       0", "0       0", "0       0", "0       0", "0     0 0", "0      00", " 0     0 ", "  0000 0 " } },
                { 'R', new[] { "0000000  ", "0      0 ", "0      0 ", "0      0 ", "0000000  ", "0  0     ", "0   0    ", "0    0   ", "0     0  ", "0      0 " } },
                { 'S', new[] { "  00000  ", " 0       ", "0        ", "0        ", " 000000  ", "       0 ", "        0", "        0", " 0     0 ", "  00000  " } },
                { 'T', new[] { "000000000", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    " } },
                { 'U', new[] { "0       0", "0       0", "0       0", "0       0", "0       0", "0       0", "0       0", "0       0", " 0     0 ", "  00000  " } },
                { 'V', new[] { "0       0", "0       0", "0       0", "0       0", "0       0", "0       0", " 0     0 ", "  0   0  ", "   0 0   ", "    0    " } },
                { 'W', new[] { "0       0", "0       0", "0       0", "0       0", "0       0", "0   0   0", "0  0 0  0", "0 0   0 0", "00     00", "0       0" } },
                { 'X', new[] { "0       0", " 0     0 ", "  0   0  ", "   0 0   ", "    0    ", "   0 0   ", "  0   0  ", " 0     0 ", "0       0", "0       0" } },
                { 'Y', new[] { "0       0", " 0     0 ", "  0   0  ", "   0 0   ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    ", "    0    " } },
                { 'Z', new[] { "000000000", "       0 ", "      0  ", "     0   ", "    0    ", "   0     ", "  0      ", " 0       ", "0        ", "000000000" } },
                { ' ', new[] { "         ", "         ", "         ", "         ", "         ", "         ", "         ", "         ", "         ", "         " } },
            };
        }

        public void AddMenuItem(string option, Action action, string feedbackMessage = "")
        {
            _menuItems.Add((option, action, feedbackMessage));
        }

        public void DisplayMenu()
        {
            string feedbackMessage = string.Empty;

            while (true)
            {
                Console.Clear();
                PrintLargeTitle(menuTitle);

                int totalMenuHeight = _menuItems.Count + 1;
                int topPadding = (Console.WindowHeight - totalMenuHeight) / 2;

                // Calculate the position for the feedback message
                int feedbackPosition = topPadding - 10; // Adjust here to move the message up or down

                if (!string.IsNullOrEmpty(feedbackMessage))
                {
                    int feedbackPadding = (Console.WindowWidth - feedbackMessage.Length) / 2;
                    Console.SetCursorPosition(feedbackPadding, feedbackPosition);
                    Console.WriteLine(feedbackMessage);
                }

                Console.SetCursorPosition(0, topPadding);

                for (int i = 0; i < _menuItems.Count; i++)
                {
                    string itemText = $"{i + 1}. {_menuItems[i].option}";
                    int leftPadding = (Console.WindowWidth - itemText.Length) / 2;
                    Console.SetCursorPosition(leftPadding, Console.CursorTop);
                    Console.WriteLine(itemText);
                }

                string exitText = "Q. Exit";
                int exitPadding = (Console.WindowWidth - exitText.Length) / 2;
                Console.SetCursorPosition(exitPadding, Console.CursorTop);
                Console.WriteLine(exitText);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    return;
                }

                if (int.TryParse(keyInfo.KeyChar.ToString(), out int choice) && choice > 0 && choice <= _menuItems.Count)
                {
                    _menuItems[choice - 1].action();
                    feedbackMessage = _menuItems[choice - 1].feedbackMessage;
                }
                else
                {
                    feedbackMessage = "Invalid selection. Please try again.";
                }
            }
        }

        private static void PrintLargeTitle(string title)
        {
            var lines = new List<string[]>();

            // Collect all lines for each character in the title
            foreach (char c in title.ToUpper())
            {
                if (LargeLetters.TryGetValue(c, out string[]? letterLines))
                {
                    lines.Add(letterLines);
                }
            }

            // Print eachline of the large letters horizontally
            for (int i = 0; i < 10; i++)
            {
                var lineBuilder = new StringBuilder();
                foreach (var line in lines)
                {
                    lineBuilder.Append(line[i]);
                    lineBuilder.Append(' '); // Add space between letters
                }

                string finalLine = lineBuilder.ToString();
                int leftPadding = (Console.WindowWidth - finalLine.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);

                // Print each character with a conditional background color
                foreach (char c in finalLine)
                {
                    if (c == '0')
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write(" ");
                    Console.ResetColor();

                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public void DisplayInstructions()
        {
            Console.Clear();
            PrintLargeTitle("How to Play!");

            int totalMenuHeight = _menuItems.Count + 1;
            int topPadding = (Console.WindowHeight - totalMenuHeight) / 2;

            Console.SetCursorPosition(0, topPadding);

            var instructions = new List<string>
            {
                "Use the arrow keys to move the snake.",
                "Eat the food to grow.",
                "Don't run into the walls or yourself!",
                "",
                "Press any key to start the game."
            };

            foreach (var line in instructions)
            {
                int leftPadding = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.ReadKey(true);
        }

        

        

        
    }
}

