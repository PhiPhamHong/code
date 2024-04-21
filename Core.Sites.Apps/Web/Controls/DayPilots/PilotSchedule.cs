using System;
using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility.DayPilot;
using Core.Web.WebBase;
namespace Core.Sites.Apps.Web.Controls.DayPilots
{
    [Script(Src = "/Web/Controls/DayPilots/js/PilotSchedule.js")]
    public abstract class PilotSchedule<TResource, TEvent, TEventParam> : PortalModule<TEvent>, IAjax
        where TResource : DPResource
        where TEvent : EventItem, new()
        where TEventParam : PilotScheduleEventParam, new()
    {
        protected abstract List<TResource> GetResources(TEventParam @param);

        public void ChangeDate() => this.ParseParamTo<ChangeDateRequest>(true).DoRequest();
        public class ChangeDateRequest : IAjax
        {
            public DateTime StartTime { set; get; }
            public DateTime EndTime { set; get; }
            public PilotScheduleControl.Time TimeRange { set; get; }
            public bool Up { set; get; }

            public void DoRequest()
            {
                if (!Up)
                {
                    switch (TimeRange)
                    {
                        case PilotScheduleControl.Time.Month:
                            StartTime = StartTime.AddMonths(Up ? 1 : -1);
                            if (EndTime.AddDays(1).Day == 1) EndTime = EndTime.AddDays(1).AddMonths(-1).AddDays(-1);
                            else EndTime = EndTime.AddMonths(-1);
                            break;
                        case PilotScheduleControl.Time.Week:
                            StartTime = StartTime.AddDays(-7);
                            EndTime = EndTime.AddDays(-7);
                            break;
                        case PilotScheduleControl.Time.FourDays:
                            StartTime = StartTime.AddDays(-4);
                            EndTime = EndTime.AddDays(-4);
                            break;
                    }
                }
                else
                {
                    switch (TimeRange)
                    {
                        case PilotScheduleControl.Time.Month:
                            StartTime = StartTime.AddMonths(Up ? 1 : -1);
                            if (EndTime.AddDays(1).Day == 1) EndTime = EndTime.AddDays(1).AddMonths(1).AddDays(-1);
                            else EndTime = EndTime.AddMonths(1);
                            break;
                        case PilotScheduleControl.Time.Week:
                            StartTime = StartTime.AddDays(7);
                            EndTime = EndTime.AddDays(7);
                            break;
                        case PilotScheduleControl.Time.FourDays:
                            StartTime = StartTime.AddDays(4);
                            EndTime = EndTime.AddDays(4);
                            break;
                    }
                }

                this.SetData("Search", this);
            }
        }

        public void GetEvent()
        {
            var @param = this.ParseParamTo<TEventParam>(true);
            if (param.StartTime != null) param.StartTime = param.StartTime.Value.Date;
            if (param.EndTime != null) param.EndTime = param.EndTime.Value.Date.AddDays(1).AddSeconds(-1);

            @param.CompanyId = PortalContext.CurrentUser.GetCompanyId(@param.CompanyId);
            this.SetData("Resources", GetResources(@param));
            this.SetData("Events", GetEvent(@param));
        }
        protected abstract List<TEvent> GetEvent(TEventParam @param);
    }

    public class PilotScheduleEventParam
    {
        public int CompanyId { set; get; }
        public DateTime? StartTime { set; get; }
        public DateTime? EndTime { set; get; }
    }
}