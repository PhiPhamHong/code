using System;
using System.Web.UI;

namespace Core.FE.Shop.Jewelries.Services
{
    public partial class FeError : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception == null) return;

            while (exception.InnerException != null)
                exception = exception.InnerException;

            try
            {
                ltrMessage.Text = exception.Message;
            }
            catch (Exception ex)
            {
                ltrMessage.Text = ex.Message;
            }
        }
    }
}