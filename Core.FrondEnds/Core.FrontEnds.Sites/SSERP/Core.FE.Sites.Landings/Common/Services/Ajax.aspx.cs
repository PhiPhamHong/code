﻿using Core.Web.WebBase;
using Core.Extensions;
namespace Core.FE.Sites.Landings.Common.Services
{
    public partial class Ajax : PageAjax
    {
        protected override string GetAssemblyOfMethod()
        {
            var n = base.GetAssemblyOfMethod();
            return n.IsNull() ? "Core.FE.Sites.Landings" : n;
        }
    }
}