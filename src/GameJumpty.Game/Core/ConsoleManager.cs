using System;
using System.Text;

namespace GameJumpty.Game.Core
{
    public static class ConsoleManager
    {
        public static void SetDefaultConsole(int width, int height)
        {
            Console.Title = "jumPTy";
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetWindowPosition(0, 0);
            Console.WindowWidth = width;
            Console.BufferWidth = width;
            Console.WindowHeight = height;
            Console.BufferHeight = height;
        }
    }
}
