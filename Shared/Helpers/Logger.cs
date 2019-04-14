﻿#region LICENSE
/*
    Sora - A Modular Bancho written in C#
    Copyright (C) 2019 Robin A. P.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Colorful;
using Console = Colorful.Console;

namespace Shared.Helpers
{
    public static class Logger
    {        
        public static void Log(params object[] msg) => Debug(msg);
        
        public static object Locker = new object();

        private static void PrintColorized(string Prefix, Color PrefixColor, bool exit, IEnumerable<object> msg)
        {
            new Thread(() =>
            {
                Color color = PrefixColor;

                lock (Locker)
                {
                    string m = msg.Aggregate(string.Empty, (current, x) => current + " " + x);
                    Console.WriteFormatted(Prefix, color);

                    color = Color.White;
                    foreach (string x in Regex.Split(m, @"\%(.*?)\%"))
                    {
                        if (!x.StartsWith('#') || !IsHex(x.TrimStart('#')) || x.Length != 7)
                        {
                            Console.WriteFormatted(x, color);
                            continue;
                        }

                        color = Color.FromArgb(int.Parse(x.Replace("#", "").ToUpper().Trim(), NumberStyles.HexNumber));
                    }

                    Console.WriteLine();
                }

                if (exit)
                    Environment.Exit(1);
            }).Start();
        }

        public static void Debug(params object[] msg)
            #if DEBUG
            => PrintColorized("[DEBUG]", Color.FromArgb(0xCECECE), false, msg);
            #else
            { }
            #endif
            

        public static void Info(params object[] msg)
            => PrintColorized("[INFO]", Color.FromArgb(0x37B6FF), false, msg);

        public static void Warn(params object[] msg)
            => PrintColorized("[WARNING]", Color.FromArgb(0xFFDA38), false, msg);

        public static void Err(params object[] msg)
            => PrintColorized("[ERROR]", Color.FromArgb(0xFF4C4C), false, msg);

        public static void Fatal(params object[] msg)
            => PrintColorized("[FATAL]", Color.FromArgb(0x910000), true, msg);

        private static bool IsHex(IEnumerable<char> chars) =>
            chars.Select(c => c >= '0' && c <= '9' || c >= 'a' && c <= 'f' || c >= 'A' && c <= 'F')
                 .All(isHex => isHex);
    }
}