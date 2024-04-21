using System.Web;
using System.IO;
using System.Reflection;
using System.Text;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities;
using Core.Reflectors;
using Core.Utility;
using Core.Web.WebBase;
using Core.Web.Extensions;
using Core.Extensions;
using System.Collections.Generic;
using Core.Business.Entities;

namespace Core.Sites.Apps.Services
{
    public partial class Ajax : PageAjax
    {
        FileResult fileResult = null; 
        FileDownloadAttribute fd = null;

        protected override void BeforeRequest(List<AjaxRequestConditionAttribute> conditions)
        {
            PortalContext.IsAjax = true;
            var path = Request.Query<string>("path");
            if (path.IsNotNull()) PortalContext.CurrentPage = PortalContext.Page.GetPage(path, PortalContext.SessionType);
            if (conditions.Count == 0 && !PortalContext.Session.IsLoging) throw new NotAuthenException();
        }
        protected override void EndCallMethod(MethodInfo method, object result)
        {
            fd = ReflectMethodInfo<FileDownloadAttribute>.Inst[method];
            if (fd != null) fileResult = result as FileResult;
        }
        protected override void OnWriteResponse()
        {
            if (fd == null) base.OnWriteResponse();
            else
            {
                Response.ContentEncoding = Encoding.Unicode;
                var mimeInfo = EnumHelper<MimeType, MimeTypeInfoAttribute>.Inst.GetAttribute(fd.MimeType);
                Response.ContentType = mimeInfo.Type;
                using (var memStream = new MemoryStream())
                {
                    fileResult.Stream.CopyTo(memStream);
                    Response.BinaryWrite(memStream.ToArray());
                    try { fileResult.Stream.Dispose(); }
                    catch { }
                    finally { if (fileResult.End != null) fileResult.End(); }
                }
                Response.SetCookie(new HttpCookie("fileDownload", "true") { Path = "/" });
                Response.AddHeader("content-disposition", string.Format("attachment; filename = {0}", fileResult.FileName + "." + mimeInfo.Name));
            }
        }
        protected override void EndRequest()
        {
            if (PortalContext.Session.IsLoging) PortalContext.Session.ExtendTimeCookie();
        }

        protected override void OnValidateParam(object obj)
        {
            if (obj == null) return;
            if(obj.Is<ICompanyNeedValidate>())            
                obj.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(obj.As<ICompanyNeedValidate>().CompanyId);
        }
    }
}