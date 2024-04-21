using System.Text.RegularExpressions;
using Core.Extensions;
namespace Core.Utility
{   
    public enum Key
    {
        esc = 1,
        tab = 2,
        space = 3,
        @return = 4,
        backspace = 5,
        scroll = 6,
        capslock = 7,
        numlock = 8,
        pause = 9,
        insert = 10,
        home = 11,
        del = 12,
        end = 13,
        pageup = 14,
        pagedown = 15,
        left = 16,
        up = 17,
        right = 18,
        down = 19,
        f1 = 20,
        f2 = 21,
        f3 = 22,
        f4 = 23,
        f5 = 24,
        f6 = 25,
        f7 = 26,
        f8 = 27,
        f9 = 28,
        f10 = 29,
        f11 = 30,
        f12 = 31,
        N1 = 32,
        N2 = 33,
        N3 = 34,
        N4 = 35,
        N5 = 36,
        N6 = 37,
        N7 = 38,
        N8 = 39,
        N9 = 40,
        N0 = 41,
        a = 42,
        b = 43,
        c = 44,
        d = 45,
        e = 46,
        f = 47,
        g = 48,
        h = 49,
        i = 50,
        j = 51,
        k = 52,
        l = 53,
        m = 54,
        n = 55,
        o = 56,
        p = 57,
        q = 58,
        r = 59,
        s = 60,
        t = 61,
        u = 62,
        v = 63,
        w = 64,
        x = 65,
        y = 66,
        z = 67,

        Ctrl = 68,
        Shift = 69,
        Alt = 70
    }

    public static class KeyExtension
    {
        private static Regex regexReplaceNumber = new Regex("(N[0-9]+)");

        public static string GetString(this Key[] keys)
        {
            var dataKey = keys.JoinString(key => key, "_");
            dataKey = regexReplaceNumber.Replace(dataKey, match => match.Groups[1].Value.TrimStart('N'));
            return dataKey;
        }
    }
}
