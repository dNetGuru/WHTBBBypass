using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

/* •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
   | Code is published under terms mentioned on the project's page (on http://www.codeplex.com/WHTBBBypass) under MIT Licence       |
   •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
   •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
   | Copyright (c) 2008 Farzad E. (dNetGuru)                                                                                        |
   |                                                                                                                                |
   | Permission is hereby granted, free of charge, to any person obtaining a copy of this software and                              |
   | associated documentation files (the "Software"), to deal in the Software without restriction, including                        |
   | without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell                        |
   | copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the                       |
   | following conditions:                                                                                                          |
   |                                                                                                                                |
   | The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. |
   |                                                                                                                                |
   | THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED                  |
   | TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL                  |
   | THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF                  |
   | CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER                       |
   | DEALINGS IN THE SOFTWARE.                                                                                                      |
   •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
   •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
   | Keep in mind that this is the initial release and is not meant to readable and/or user friendly, running this code without any |
   | modifications just updates my brother's account (while my own is closed) as a proof of concept.                                |
   •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•  */

// ReSharper disable LocalVariableHidesMember 
// ReSharper disable ParameterHidesMember
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace mTestConsole
{
    partial class Program
    {
        private const string _____ = "game.playfish.com";
        private const char ______ = ' ';
        private const int ____I = 0x40A;
        private static int I_____ = 0x265;

        private const bool ___I__ = true;
        private static readonly int[] I_I = new[] { 0xFF, 0xFF, 0xFF, 0xFF };
        private static readonly int[] I__I = new[] { 650, 655, 660, 665 };

        private static readonly Random I__I_I_ = new Random((int)DateTime.Now.Ticks);

        static int I__ = 0x26C;
        static int I____ = 0x272;
        static int I___ = 0x26F;
        static int I_ = 0x269;

        static readonly Action ___I = () => Console.Write("\x7b\x30:x\x7d\00", ___);

        private static byte[] __I_(this byte[] _I_, int ___I, int _I, int __, int __I)
        { return _I_._______(_(___I), _(_I), _(__), _(__I), _(__ + __I + _I + ___I)); }

        private static void Main(string[] I__I__)
        {
            int __I_II; if (I__I__ == null || I__I__.Length == 0 || !int.TryParse(I__I__[0], out __I_II)) { ___I_I_(); return; }
            I__I[0x2] = I__I_I_.Next(__I_II / 6, __I_II / 3); I__I[0x1] = I__I_I_.Next(__I_II / 6, __I_II / 3);
            I__I[0x3] = I__I_I_.Next(__I_II / 6, __I_II / 3); I__I[0x0] = __I_II - _I_I_(I__I); _I__();
            if (!___I__) _(_____, ___.__I_(I_I[0], I_I[1], I_I[0x2], I_I[3]));
            _(_____, ____.__I_(I__I[0], I__I[0x1], I__I[2], I__I[0x3]));
            Console.Read();
        }

        private static int _I_I_(int[] I__I)
        { int _ = 0x0; for (int __ = 1; __ < I__I.Length; __++) _ += I__I[__]; return _; }

        private static byte[] _______(this byte[] _, byte[] __, byte[] ____I, byte[] ___I, byte[] _I, byte[] __I)
        {
            _[I____ + 1] = _I[0x1]; _[I___] = ___I[0x0]; _[I___ + 1] = ___I[0x1];
            _[I__] = ____I[0x0]; _[I_] = __[0x0]; _[I_____] = __I[0x0]; _[I____] = _I[0x0];
            _[I_ + 1] = __[0x1]; _[I__ + 1] = ____I[0x1]; _[I_____ + 1] = __I[0x1]; return _;
        }

        private static void ___I_I_()
        {
            Console.Write("\x55\x73\x61\x67\x65\x20\x3a\x20{0}\x20[\x62\x72\x61\x69\x6e\x53\x69\x7a\x65]",
                Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName));
        }
        private static int __(this byte[] _, byte[] __)
        { for (int ___ = 0; ___ < _.Length - 2; ___++)if (_[___] == __[0x0] && _[___ + 1] == __[0x1]) return ___; return 0xFF; }

        private static Byte[] _(int __)
        {
            int _; if (!__I(__, 0xF0000000)) _ = 28;
            else if ((__ & 0xFE00000) != 0) _ = 21;
            else if (!__I(__, 2080768)) _ = 14; else _ = (__ & 0x3F80) != 0 ? 7 : 0;
            byte[] ___I = new byte[_ / 7 + 1];
            while (_ > 0) { ___I[_ / 7 - 1] = (byte)(__ >> _ | 128); _ = _ - 7; }
            ___I[___I.Length - 1] = (byte)(__ & 0x7F);
            return ___I;
        }

        private static void _(string ___, byte[] ____)
        {
            var _ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _.Connect(___, 80); _.Send(____); var __ = new byte[____I]; _.Receive(__); _I__I_I_();
        }

        private static void _I__()
        {
            if (!___I__) return; I_____ = ____.__(new byte[] { 0x8c, 0x38 });
            I__ = ____.__(new byte[] { 0x83, 0x03 }); I____ = ____.__(new byte[] { 0x82, 0x55 });
            I___ = ____.__(new byte[] { 0x83, 0x40 }); I_ = ____.__(new byte[] { 0x83, 0x20 });
        }

        private static bool __I(int __, uint _) { return !Equals(__ & _, 0); }

        private static void __(params int[] __)
        { for (int ___ = 0; ___ < __.Length; ___++) { foreach (var ____ in _(__[___])) Console.Write("\x7b\x30:x\x7d", ____); Console.Write(______); } }
    }
}