using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using Core.Attributes;
using Core.Extensions;
using Core.Business.Entities;
using Core.Sites.Libraries.Business;
namespace Core.Sites.Libraries.Utilities.Sites
{
    public class DashBoardConfig<TConfig> : DashBoard<TConfig>, IDashBoardConfig where TConfig : class, new()
    {
        public List<XmlAttribute> GetConfig()
        {
            var xml = new XmlDocument();
            if (Config.Is<ICompanyNeedValidate>())
                Config.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(Config.As<ICompanyNeedValidate>().CompanyId);

            return Config.GetType().GetListPairPropertyListAttribute<PropertyInfoAttribute>().Select(p =>
            {
                var att = xml.CreateAttribute(p.T1.Name);
                if (p.T1.PropertyType.IsEnum)
                {
                    var typeEnum = Enum.GetUnderlyingType(p.T1.PropertyType);
                    if (typeEnum == typeof(byte)) att.Value = ((byte)p.T1.GetValue(Config)).To<string>();
                    else att.Value = ((int)p.T1.GetValue(Config)).To<string>();
                }
                else att.Value = p.T1.GetValue(Config).To<string>();
                return att;
            }).ToList();
        }
    }

    public interface IDashBoardConfig : IDashBoard
    {
        List<XmlAttribute> GetConfig();
    }

    public class DashBoardTypeAttribute : FieldInfoAttribute
    {
        public Type TypeModule { set; get; }
    }
}
