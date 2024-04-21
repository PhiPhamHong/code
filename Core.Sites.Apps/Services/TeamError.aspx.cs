using System;
using System.Web.UI;
namespace Core.Sites.Apps.Services
{
    public partial class TeamError : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            while (exception.InnerException != null)
                exception = exception.InnerException;

            try
            {
                ltrMessage.Text = exception.Message;
            }
            catch(Exception ex)
            {
                ltrMessage.Text = ex.Message;
            }
        }
    }
}