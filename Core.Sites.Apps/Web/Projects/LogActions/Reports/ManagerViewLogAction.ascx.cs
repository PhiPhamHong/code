using Core.Sites.Apps.Web.InputMappers;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using Core.Business.Entities.Log;
using System;
using System.Collections.Generic;


namespace Core.Sites.Apps.Web.Projects.LogActions.Reports
{
    [Script(Src = "Web/Projects/LogActions/Reports/js/ManagerViewLogAction.js")]
    [Script(Src = "Web/Projects/LogActions/Reports/js/FromViewLogActionDetail.js", Index = 1)]
    [Module]
    public partial class ManagerViewLogAction : ManageModule<Log, ManagerViewLogAction.ModuleProvider>
    {
        public class ModuleProvider : ManageModuleProvider<Log>.Source<Log.DataSource> { }
    }
}