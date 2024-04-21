using Core.Business.Entities.CRM;
using Core.Web.WebBase;
using System;
using System.Web;

namespace Core.FE.MobileShop.Projects.Web.Tools
{
    public class UserLogin : IAjax
    {
        public void Register(string resname, string resaddress, string resphone, string resmail, string resusername, string respassword)
        {
            Customer cus = new Customer();
            cus.CompanyId = 1;
            cus.Code = "WEB-RES-" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
            cus.TeleSaleId = 4;
            cus.Name = resname;
            cus.Phone = resphone;
            cus.PartnerId = 1;
            cus.Address = resaddress;
            cus.Email = resmail;
            cus.ShopName = cus.Target = "";
            cus.UserIdCallId = 4;
            cus.MemberName = resusername;
            cus.Password = respassword;
            cus.Status = Customer.CusStatus.New;
            cus.ControlDataStatus = true;
            cus.CreatedByUserId = 4;
            cus.CreatedDate = DateTime.Now;
            cus.UpdatedByUserId = 4;
            cus.UpdatedDate = DateTime.Now;
            cus.Insert();
        }

        public void Login(string username, string password)
        {
            var customer = Customer.GetByUserName(username, password);
            var KQ = 0;
            if(customer != null)
            {
                HttpContext.Current.Session["UserName"] = customer.MemberName;
                HttpContext.Current.Session["Data"] = customer;
                KQ = 1;
            }
            this.SetData("KQ", KQ);
        }

        public void Logout()
        {
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["Data"] = null;
            this.SetData("KQ", 1);
        }
    }
}