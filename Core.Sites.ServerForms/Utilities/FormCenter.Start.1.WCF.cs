using System;
using System.ServiceModel;
using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Forms;
using Core.Utility.WcfManager;
namespace Core.Sites.ServerForms.Utilities
{
    public partial class FormCenter
    {
        private Host wcfHost = null;

        [CenterStart(Stt = 1)]
        private void StartHostWcf()
        {
            wcfHost = ServiceManager.Inst.CreateHost<ServerFormService>(sif =>
            {
                sif.Ip = Parent.Config.WCFAddress;
                sif.HttpPort = Parent.Config.WCFPortHttp;
                sif.TcpPort = Parent.Config.WCFPortTcp;
            });
            wcfHost.ChangeState += (s, o) => ShowMessage("Server WCF đổi sang trạng thái " + wcfHost.State);
            wcfHost.Open();
        }

        [CenterStop]
        private void StopHostWcf()
        {
            if (wcfHost != null)
            {
                wcfHost.Close();
                wcfHost = null;
            }
        }

        [ServiceInfo("ServerFormService", HttpPort = 6362, TcpPort = 6363)]
        public partial class ServerFormService : ServiceBase, IServerFormService
        {
            public bool Ping() { return true; }
            public void ResetCompanyConfig(int companyId)
            {
                var config = CompanyConfig.Inst.GetByCompanyId(companyId);
                WebCenter.Instance.UpdateCompayConfig(config);
                Instance.ShowMessage("Đã cập nhật CompanyConfig cho " + companyId);
            }
            public void ResetCompanyConfigItem(int companyId)
            {
                var config = CompanyConfig.Inst.GetByCompanyId(companyId);
                WebCenter.Instance.UpdateCompayConfig(config);
                Instance.ShowMessage("Đã cập nhật Company.Config.Item cho " + companyId);
            }
            public void SendNotification(int notificationId)
            {
                WebCenter.Instance.SendNotification(notificationId);
                Instance.ShowMessage("Đã gửi thông báo " + notificationId);
            }
        }

        [ServiceContract(Name = "IServerFormService", SessionMode = SessionMode.Allowed)]
        public interface IServerFormService
        {
            [OperationContract] bool Ping();
            [OperationContract] void ResetCompanyConfig(int companyId);
            [OperationContract] void ResetCompanyConfigItem(int companyId);
            [OperationContract] void SendNotification(int notificationId);
        }
    }
}