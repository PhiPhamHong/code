using System;
using System.Xml.Serialization;
using Core.Sites.Libraries.Business;
using Core.Forms;
using Core.Utility;
using Core.Utility.Xml;
namespace Core.Sites.ServerForms.Utilities
{
    public class FormServer : Messagable, ICenter
    {
        private Setting config = new Setting();
        public Setting Config
        {
            get { return config; }
        }

        public void ResetConfig()
        {
            Reset(web);
            Reset(form);
        }

        private void Reset(ICenter center)
        {
            if (center == null) return;

            center.IsDebug = config.IsDebug;
            center.IsNeedShowMessage = config.IsNeedShowMessage;
            center.NeedWriteLogError = config.NeedWriteLogError;
        }

        [Serializable, XmlRoot("root")]
        public class Setting : ConfigBase
        {
            [XmlElement] public string ServerName { set; get; }

            [XmlElement] public bool IsDebug { set; get; }
            [XmlElement] public bool IsNeedShowMessage { set; get; }
            [XmlElement] public bool NeedWriteLogError { set; get; }

            [XmlElement] public string WCFAddress { set; get; }
            [XmlElement] public int WCFPortHttp { set; get; }
            [XmlElement] public int WCFPortTcp { set; get; }

            [XmlElement] public string SignalRSelfHostIP { set; get; }
            [XmlElement] public int SignalRSelfHostPort { set; get; }
        }

        private FormCenter form = null;
        private WebCenter web = null;

        public void Start()
        {
            form = new FormCenter { Parent = this }; form.Start();
            web = new WebCenter { RunFromWeb = false }; web.Start();

            form.Message += msg => ShowMessage(msg);
            web.Message += msg => ShowMessage(msg);

            ResetConfig();
        }
        public void Stop()
        {
            if (form != null) form.Stop();
            if (web != null) web.Stop();
        }

        public bool IsDebug
        {
            get { return config.IsDebug; }
            set { config.IsDebug = value; }
        }
        public bool IsNeedShowMessage
        {
            get { return config.IsNeedShowMessage; }
            set { config.IsNeedShowMessage = value; }
        }
        public bool NeedWriteLogError
        {
            get { return config.NeedWriteLogError; }
            set { config.NeedWriteLogError = value; }
        }
    }
}