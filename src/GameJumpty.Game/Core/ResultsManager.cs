using GameJumpty.Game.Models;
using GameJumpty.Game.Models.Constants;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GameJumpty.Game.Core
{
    public static class ResultsManager
    {
        public static async Task ShowResultsAsync()
        {
            var resultsCurrent = await ReadResultsFromFileAsync();

            ConsolePrinter.PrintLine(string.Format(ConsoleElements.WonStatistics, resultsCurrent.Won.ToString("D4")), ConsoleColor.Green);
            ConsolePrinter.PrintLine(string.Format(ConsoleElements.LostStatistics, resultsCurrent.Lost.ToString("D4")), ConsoleColor.Red);

            Thread.Sleep(3000);
        }

        public static async Task ChangeResultsAsync(bool isWon)
        {
            var resultsCurrent = await ReadResultsFromFileAsync();

            if (isWon)
            {
                resultsCurrent.Won++;
            }
            else
            {
                resultsCurrent.Lost++;
            }

            await WriteResultsToFileAsync(resultsCurrent);
        }

        public static async Task<Result> ReadResultsFromFileAsync()
        {
            var path = GetFilePath();
            var text = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<Result>(text);
        }

        public static async Task WriteResultsToFileAsync(Result result)
        {
            var path = GetFilePath();
            var text = JsonConvert.SerializeObject(result);
            await File.WriteAllTextAsync(path, text);
        }

        private static string GetFilePath()
        {
            var pathCurrent = Environment.CurrentDirectory.Split("\\").Last();
            var directory = (pathCurrent == "win-x86" || pathCurrent == "publish") ? "../../../../../../res/" : "../../../../../res/";
            return directory += "Results.txt";
        }
    }
}
