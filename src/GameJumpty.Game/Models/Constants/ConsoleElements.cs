﻿namespace GameJumpty.Game.Models.Constants
{
    public static class ConsoleElements
    {
        private static readonly string[] Block = new string[]
        {
            "┌────┬┐",
            "│    ││",
            "│    ││",
            "│    ││",
            "│    ││",
            "│    ││",
            "└────┴┘"
        };

        private static readonly string[] Cactus = new string[]
        {
            "  ╭╮   ",
            "  ┤├ ╭╮",
            "  ┤├ ┤├",
            "╭╮┤└┴┘├",
            "┤└┘ ┬┬┘",
            "└┬┐ ├  ",
            "  ┤ ├  "
        };

        private static readonly string[] Snake = new string[]
        {
            " ╭────╮",
            " │ XX │",
            "╭╰──╮ │",
            "  ╭─╯ │",
            "  │ ╭─╯",
            "  │ ╰──╮",
            "  ╰────┘"
        };

        private static readonly string[] Snail = new string[]
        {
            " O╮O╮ ",
            "╭┘└┘│ ",
            "╰──╮╰─╮",
            "╭────╮│",
            "│╭──╮││",
            "│╰───╯│",
            "╰─────╯"
        };

        private static readonly string[] Camel = new string[]
        {
            "╭─o    ",
            "╰╮│    ",
            " ││╭╮╭╮",
            " │╰╯╰╯│",
            " │╭──╮│",
            " ││  ││",
            " ││  ││"
        };

        private static readonly string[] Gas = new string[]
        {
            "╭─────╮",
            "│╭GAS╮│",
            "│╰───╯│",
            "│   █││",
            "│   │││",
            "│   │││",
            "│   ╰╯│"
        };

        private static readonly string[] DarthVader = new string[]
        {
            "║╭───╮ ",
            "║│OO │ ",
            "║<=> ╰╮",
            "║│  │││",
            "OO  O││",
            "╰┤┤┤│┘│",
            "╭┘╭┘│─╰"
        };

        static ConsoleElements()
        {
            Obstacles = new string[][] { Block, Cactus, Camel, DarthVader, Gas, Snake, Snail };
        }

        public static string[][] Obstacles { get; }

        public static readonly string[] CharacterIdle = new string[]
        {
            "  ┏┳┓  ",
            "  ┗┳┛  ",
            "  ┏╋┓  ",
            "  ┃┃┃  ",
            "  ┗┃┛  ",
            "  ┏╇┓  ",
            "  ┃ ┃  "
        };

        public static readonly string[] CharacterJump = new string[]
            {
            "  ┏┳┛  ",
            "  ┗┳┛  ",
            " ┗━╋━┓ ",
            "   ┃   ",
            "┏━━╇━━┛"
            };

        public const string On = " on";
        public const string Off = "off";

        public const string Sky1 = "  ╰─╯╰────╯╰──╯╰────────╯╰─────╯╰───╯╰╯╰───╯╰───╯╰─────╯╰─╯╰─╯";
        public const string Sky2 = "  ╰──╯╰────╯╰──╯╰────────╯╰─────╯╰───╯╰╯╰───╯╰───╯╰─────╯╰─╯╰╯";

        public const string Grass1 = "  ┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━";
        public const string Grass2 = "  ━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷━┷";

        public const string Result = "  ░░░░░░░░░░░░░░░░░░░░░░ Result | {0} ░░░░░░░░░░░░░░░░░░░░░";

        public const string Ground = "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";

        public const string Menu =
            "\r\n" +
            MenuBackground +
            "  ░░░░░░░░░░░░░░░░░░░░                {0} ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░ ┌────────────────┐ ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░ │      │  jumPTy │ ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░ │      ├┘        │ ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░ │     └┤         │ ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░ └┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┘ ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░  Space │ PLAY      ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░      R │ RESULTS   ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░    Esc │ EXIT      ░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░                    ░░░░░░░░░░░░░░░░░░░░\r\n" +
            MenuBackground;

        public const string Lost =
            "\r\n" +
            MenuBackground +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░ [{0}] ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            MenuBackground;

        public const string Won =
            "\r\n" +
            MenuBackground +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░ WON! ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            MenuBackground;

        public const string WonStatistics =
            "\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░ {0} ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░";

        public const string LostStatistics =
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░ {0} ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n";

        public const string MenuBackground =
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\r\n" +
            "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ";
    }
}
