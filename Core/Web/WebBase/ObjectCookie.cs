using System;
using System.Web;
using System.Web.Security;
using Core.Extensions;
using Core.Utility;

namespace Core.Web.WebBase
{
    public abstract class ObjectCookie
    {
        protected virtual string Key { get { return GetType().FullName; } }
        private ICompressor compressor = null;
        public ObjectCookie()
        {
            compressor = CreateCompressor();
            try { compressor.Decompress(ReadValue).Deserialize(this); }
            catch { }
            OnLoad();
        }
        protected virtual ICompressor CreateCompressor()
        {
            return Singleton<CompressorBase64>.Inst;
        }
        protected virtual string ReadValue
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies[Key];
                string value = string.Empty;
                if (!(cookie.IsNull() || cookie.Value.IsNull()))
                    value = cookie.Value;
                return value;
            }
        }
        protected virtual void OnLoad() { }
        public void WriteCookie()
        {
            try
            {
                var value = compressor.Compress(this.Serialize());
                WriteValue(value);
            }
            catch { WriteValue(string.Empty); }
        }
        protected virtual void WriteValue(string value)
        {
            var cookie = new HttpCookie(Key);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddDays(1);
            FormsAuthentication.SetAuthCookie(cookie.Value, true);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
    }
}