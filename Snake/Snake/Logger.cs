using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Logger
    {
        static readonly string logFilePath = "debug_log.txt";

        static Logger()
        {
            // Clear the log file at the start of the program
            File.WriteAllText(logFilePath, string.Empty);
        }

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to log file: " + ex.Message);
            }
        }
    }
}
