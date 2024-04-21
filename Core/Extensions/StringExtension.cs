using Core.Utility;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Text;
using System.Collections.Generic;
using System.Web;
using Core.Utility.Language;
using System.Configuration;

namespace Core.Extensions
{
    public static class StringExtension
    {
        private const string HarmlessTags = "</?(?i:script|embed|object|frameset|frame|iframe|meta|link|style)(.|\\n)*?>";
        private const string VietnamChars = "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";
        private const string EnglishChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";
        
        private static readonly Regex RegexBetweenTags = new Regex(@">(?! )\s+", RegexOptions.Compiled);
        private static readonly Regex RegexLineBreaks = new Regex(@"([\n\s])+?(?<= {2,})<", RegexOptions.Compiled);
        private const string RexNumeric = @"^[0-9]\d*\.?[0]*$";
        private const string RexValidEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private const string RexValidVietNamPhoneNumber = @"([0|+84][1|2|3|4|5|6|7|8|9])+([0-9]{8})\b";
        private const string RegexStrongPasswordCertificate = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}";

        public static string DoTrim(this string str) { return (str ?? string.Empty).Trim(); }
        public static List<T> SplitTo<T>(this string str)
        {
            if (str.IsNull()) return new List<T> { };
            return str.Split(',').Select(t => t.To<T>()).ToList();
        }
        public static object CreateInstance(this string str) { return Activator.CreateInstance(Type.GetType(str)); }
        public static T CreateInstance<T>(this string str, bool hasbuild = false) where T : class
        {
            if (hasbuild)
            {
                var strs = str.Split(',');
                str = "{0}.{1},{0}".Frmat(strs[0], strs[1]);
            }
            return str.CreateInstance().As<T>();
        }
        public static object CreateInstance(this string str, bool hasbuild)
        {
            if (hasbuild)
            {
                var strs = str.Split(',');
                str = "{0}.{1},{0}".Frmat(strs[0], strs[1]);
            }
            return str.CreateInstance();
        }
        public static string Frmat(this string str, params object[] @params) { return string.Format(str, @params); }
        public static bool IsNull(this string str) { return string.IsNullOrEmpty(str); }
        public static bool IsNotNull(this string str) { return !string.IsNullOrEmpty(str); }
        public static string WhenEmpty(this string str, Func<string> action) { return str.IsNull() ? action() : str; }
        public static string WhenEmpty(this string str, string whenEmpty) { return str.WhenEmpty(() => whenEmpty); }

        public static string Encryt(this string str)
        {
            var encrypt = Keygend.Inst.AbcXyz(str);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{encrypt.T1}@{encrypt.T2}"));
        }

        public static string Decrypt(this string str)
        {
            if (str == null) return string.Empty;
            str = Encoding.UTF8.GetString(Convert.FromBase64String(str));
            var data = str.Split('@');
            return data.Length == 2 ? Keygend.Inst.Zyxcba(data[0], data[1]) : string.Empty;
        }

        public static string EncryptPassword(this string str) { return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5"); }

        public static string TrimXss(this string html)
        {
            var value = Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
            value = Regex.Replace(value, @"<[^>]+>|&nbsp;", string.Empty);
            value = Regex.Replace(value, @"\s{2,}", " ");
            return value.DoTrim().SingleSpacedTrim();
        }

        private static string SingleSpacedTrim(this string inString)
        {
            var sb = new StringBuilder();
            bool inBlanks = false;
            foreach (char c in inString)
            {
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                    case ' ':
                        if (!inBlanks)
                        {
                            inBlanks = true;
                            sb.Append(' ');
                        }
                        continue;
                    default:
                        inBlanks = false;
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString().Trim();
        }
        public static string SubWord(this string words, int totalWord)
        {
            return string.Join(" ", words.Split(' ').Take(totalWord).ToArray());
        }

        public static string UnicodeFormatSMS (this string s)
        {
            string retVal = string.Empty;
            int pos;
            for (int i = 0; i < s.Length; i++)
            {
                pos = VietnamChars.IndexOf(s[i].ToString());
                if (pos >= 0) retVal += EnglishChars[pos]; 
                else retVal += s[i];
            }
            return retVal;
        }
        public static string UnicodeFormat(this string s)
        {
            string retVal = string.Empty;
            int pos;
            for (int i = 0; i < s.Length; i++)
            {
                pos = VietnamChars.IndexOf(s[i].ToString());
                if (pos >= 0) retVal += EnglishChars[pos];
                else retVal += s[i];
            }
            string temp = retVal;
            for (int i = 0; i < retVal.Length; i++)
            {
                pos = Convert.ToInt32(retVal[i]);
                if (!((pos >= 97 && pos <= 122) || (pos >= 65 && pos <= 90) || (pos >= 48 && pos <= 57) || pos == 32))
                    temp = temp.Replace(retVal[i].ToString(), "");
            }
            temp = temp.Replace(" ", "-");
            while (temp.EndsWith("-"))
                temp = temp.Substring(0, temp.Length - 1);

            while (temp.IndexOf("--") >= 0)
                temp = temp.Replace("--", "-");

            retVal = temp;
            retVal = retVal.Replace("\"", string.Empty);
            retVal = retVal.Replace("'", string.Empty);
            return retVal.ToLower();
        }
        public static int LastIndexOf(this byte[] bytes, int end, string pattern)
        {
            int total;
            int current = total = pattern.Length - 1;

            for (var i = end - 1; i >= 0; i--)
            {
                if (bytes[i] == pattern[current])
                {
                    current--;
                    if (current == -1) return i;
                }
                else current = total;
            }
            return -1;
        }
        public static Guid ToGuid(this string str)
        {
            try { return new Guid(str); }
            catch { return Guid.Empty; }
        }
        public static List<string> SubToWords(this string str, int length)
        {
            var list = new List<string>();

            while(str.Length >= length)
            {
                list.Add(str.Substring(0, length));
                str = str.Substring(length, str.Length - length);
            }

            if(str.Length != 0)
            {
                if (list.Count == 0) list.Add(str);
                else list[list.Count - 1] += str;
            }
            return list;
        }
        public static string GetOnlyDigital(this string str)
        {
            return Regex.Replace(str, @"[^\d]", string.Empty);
        }
        public static string FormatNumberFirstZezo(this int number, string fix)
        {
            if (number == 0) return string.Empty;
            return (number >= 10 ? number.ToString() : $"0{number}") + fix;
        }
        public static string AddZezo(this int number)
        {
            return number >= 10 ? number.ToString() : $"0{number.ToString()}";
        }
        public static string BuildString(this string seperator, params string[] values)
        {
            return values.Where(v => v.IsNotNull()).JoinString(s => s, seperator);
        }
        public static string ReadTo(this string content, string sFrom, string sTo = "")
        {
            var indexFrom = content.IndexOf(sFrom);
            if (sTo.IsNotNull())
            {
                var indexTo = content.IndexOf(sTo);
                if (indexTo < 0) return string.Empty;
                return content.Substring(indexFrom + sFrom.Length, indexTo - indexFrom - sFrom.Length);
            }
            return content.Substring(indexFrom + sFrom.Length, content.Length - indexFrom - sFrom.Length);
        }
        public static string MapServer(this string url)
        {
            return HttpContext.Current.Server.MapPath(url);
        }
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: return null;
                case "": return input;
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        public static string FirstCharToLower(this string input)
        {
            switch (input)
            {
                case null: return null;
                case "": return input;
                default: return input.First().ToString().ToLower() + input.Substring(1);
            }
        }
        public static string Translate(this string lexicon)
        {
            return LanguageHelper.GetLabel(lexicon);
        }
        public static string GetSetting(this string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Loại bỏ các yếu tố gây hại Cross-Site Scripting (XSS)
        /// </summary>
        /// <param name="html">Chuỗi HTML</param>
        /// <param name="allowHarmlessTags">True: chỉ loại bỏ các thẻ Html nguy hiểm; False: Xóa tất cả các thẻ Html</param>
        /// <returns></returns>
        public static string TrimXss(this string html, bool allowHarmlessTags = true)
        {
            if (string.IsNullOrEmpty(html)) return string.Empty;
            if (allowHarmlessTags) return Regex.Replace(html, HarmlessTags, string.Empty);
            return Regex.Replace(html, "<[^>]*>", string.Empty);
        }

        /// <summary>
        /// Kiểm tra 1 chuỗi string có phải là Numeric
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNumber(this string val)
        {
            return val.IsNotNull() && Regex.IsMatch(val.Trim(), RexNumeric);
        }

        /// <summary>
        /// Remove 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(this string html)
        {
            html = RegexBetweenTags.Replace(html, ">");
            html = RegexLineBreaks.Replace(html, "<");
            return html.Trim();
        }

        /// <summary>
        /// Check email address is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            return email.IsNotNull() && Regex.IsMatch(email.Trim(), RexValidEmail);
        }

        /// <summary>
        /// Checks to be sure a phone number contains 10 digits as per VietNam phone numbers.  
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidVietNamPhoneNumber(this string phone)
        {
            if (phone.IsNull()) return false;
            var cleaned = phone.RemoveNonNumeric();
            var isValidLength = cleaned.Length == 10 || cleaned.Length == 11;
            return Regex.IsMatch(phone, RexValidVietNamPhoneNumber) && isValidLength;
        }

        /// <summary>
        /// At least one lower case letter, upper case letter, special character, one number, 8 characters length
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(this string pwd)
        {
            if (pwd.IsNull()) return false;
            return Regex.IsMatch(pwd, RegexStrongPasswordCertificate);
        }

        /// <summary>
        /// Removes all non numeric characters from a string
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", string.Empty);
        }

        public static string ToCamelCase(this string str)
        {
            return $"{str.Substring(0, 1).ToLowerInvariant()}{(str.Length > 1 ? str.Substring(1, str.Length - 1) : string.Empty)}";
        }
    }
}