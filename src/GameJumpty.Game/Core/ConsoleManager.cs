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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.BufferWidth = width;
            Console.WindowHeight = height;
            Console.BufferHeight = height;
        }
    }
}
