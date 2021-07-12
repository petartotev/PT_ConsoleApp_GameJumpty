using GameJumpty.Game.Models.Constants;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameJumpty.Game.Core
{
    public static class MusicManager
    {
        private static readonly Random _random = new Random();

        public static bool IsMusicOn { get; set; } = true;

        public static (int[] Frequency, int[] Duration) GetRandomSong()
        {
            return _random.Next(1, 4) switch
            {
                1 => ConsoleElements.SongStarWars,
                2 => ConsoleElements.SongMissionImpossible,
                3 => ConsoleElements.SongMario,
                _ => ConsoleElements.SongStarWars
            };
        }

        public static async Task PlayMusicAsync((int[] Frequency, int[] Duration) song, params CancellationTokenSource[] sources)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    for (int i = 0; i < song.Frequency.Length; i++)
                    {
                        foreach (var source in sources)
                        {
                            if (source.Token.IsCancellationRequested)
                            {
                                return;
                            }
                        }
                        Console.Beep(song.Frequency[i], song.Duration[i]);
                    }
                }
            });
        }
    }
}
