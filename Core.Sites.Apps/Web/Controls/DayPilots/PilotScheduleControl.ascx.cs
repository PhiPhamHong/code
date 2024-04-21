using Core.Attributes;
using Core.Extensions;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility;
using Core.Web.WebBase;
using System;
using System.Web.UI;
using System.Linq;
namespace Core.Sites.Apps.Web.Controls.DayPilots
{
    public partial class PilotScheduleControl : PortalModule<Empty>, IAjax
    {
        public PilotScheduleControl() => UseModuleTypeAction = false;

        protected TimeAttribute TimeLabel { set; get; }
        protected float ColDate { set; get; }

        protected override void OnInitData()
        {
            TimeLabel = EnumHelper<Time, TimeAttribute>.Inst.GetAttribute(TimeRange);
            ColDate = this.Query<float>("ColDate"); if (ColDate == 0) ColDate = 1.25f;

            if (ButtonTemplate != null)
            {
                var container = new BoxContentContainer();
                ButtonTemplate.InstantiateIn(container);
                plcButtons.Controls.Add(container);
                plcButtons.Controls.Cast<Control>().OfType<ControlBase>().ForEach(c => c.InitData());
            }
            if (InputTemplate != null)
            {
                var container = new BoxContentContainer();
                InputTemplate.InstantiateIn(container);
                plcInputs.Controls.Add(container);
                plcInputs.Controls.Cast<Control>().OfType<ControlBase>().ForEach(c => c.InitData());
            }
        }

        public bool StartTimeIsToDay { set; get; }
        public Time TimeRange { set; get; }
        public bool UseTime { set; get; }
        public bool ShowCompany { set; get; } = true;

        public DateTime? FromDate { set; get; }

        public enum Time : byte
        {
            [Time(Previous = "Tháng trước", Next = "Tháng tiếp")] Month = 0,
            [Time(Previous = "Tuần trước", Next = "Tuần tiếp")] Week = 1,
            [Time(Previous = "4 ngày trước", Next = "4 ngày tiếp")] FourDays = 2
        }
        public class TimeAttribute : FieldInfoAttribute
        {
            public string Previous { set; get; }
            public string Next { set; get; }
        }

        protected DateTime FromDateOrNow() => FromDate == null ? DateTime.Now : FromDate.Value;

        protected DateTime GetFromDate()
        {
            if (StartTimeIsToDay) return DateTime.Now;

            switch (TimeRange)
            {
                case Time.Month: return FromDateOrNow().StartMonth();
                case Time.Week: return FromDateOrNow().GetRangeDateInWeek().From;
                default: return FromDateOrNow();
            }
        }
        protected DateTime GetToDate()
        {
            if (StartTimeIsToDay) return DateTime.Now.AddDays(30);

            switch (TimeRange)
            {
                case Time.Month: return FromDateOrNow().EndMonth();
                case Time.Week: return FromDateOrNow().GetRangeDateInWeek().To;
                default: return FromDateOrNow().AddDays(4);
            }
        }

        [TemplateContainer(typeof(BoxContentContainer))]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate ButtonTemplate { set; get; }

        [TemplateContainer(typeof(BoxContentContainer))]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate InputTemplate { set; get; }

        public class BoxContentContainer : Control, INamingContainer
        {
            internal BoxContentContainer() { }
        }
    }
}