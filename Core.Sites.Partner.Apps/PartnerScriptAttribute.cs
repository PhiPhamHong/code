using Core.Extensions;
using Core.Sites.Libraries.Utilities.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Sites.Partner.Apps
{
    public partial class PartnerScriptAttribute : ScriptAttribute
    {
        public override string Src
        {
            get { return base.Src; }

            set
            {
                if (value.IsNull()) base.Src = string.Empty;
                else base.Src = "/Web/Core.Sites.Partner.Apps" + value;
            }
        }
    }
}