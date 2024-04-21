using Core.FrontEnds.Libraries.Portal.Configs;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.FrontEnds.Libraries.Portal
{
    /// <summary>
    /// Interface định nghĩa phương thức tìm chuỗi tham số từ đường link ảo
    /// Ví dụ
    /// url: /the-thao-the-gioi-ronaldo.htm => chuyenmuc=the-thao-the-gioi&nhanvat=ronaldo
    /// Tùy từng engine mà tìm được query như ý
    /// </summary>
    public interface IUrlEngine
    {
        void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural);
    }

    public abstract class UrlEngineRegex : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var rs = Regexes.Select((regex, index) => new { regex, index, match = regex.Match(urlVitural) }).FirstOrDefault(i => i.match.Success);
            if (rs == null) return;
            result.Query = GetQueryFromRegex(rs.regex, rs.match, rs.index);
        }

        protected abstract List<Regex> Regexes { get; }
        protected abstract string GetQueryFromRegex(Regex regex, Match match, int index);
    }
}
