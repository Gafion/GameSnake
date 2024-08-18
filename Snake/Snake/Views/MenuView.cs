using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;
using Snake.Views;
using Snake.Controllers;
using Snake.Utilities;

namespace Snake.Views
{
    internal class MenuView
    {
        public static void DisplayInstructions()
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
        }
    }
}
