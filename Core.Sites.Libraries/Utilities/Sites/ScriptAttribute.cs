using System;
using System.Linq;
using System.Collections.Generic;
using Core.Utility;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Utilities.Sites
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ScriptAttribute : Attribute
    {
        private string src = string.Empty;
        public int Index { set; get; }
        public virtual string Src
        {
            get { return src; }
            set
            {
                if(value.IsNotNull()) src = value + "?v=" + AppSetting.VerJs;
                else src = string.Empty;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ScriptExtendAttribute : Attribute
    {
        public Type Type { set; get; }
    }
    public class ReflectTypeListScriptAttribute : DictionaryCacheBase<Type, List<ScriptAttribute>, ReflectTypeListScriptAttribute>
    {
        protected override List<ScriptAttribute> GetValueForDic(Type key)
        {
            return key.GetCustomAttributes(typeof(ScriptAttribute), true).Cast<ScriptAttribute>().OrderBy(s => s.Index).ToList();
        }
    }
    public class ReflectTypeListScriptExtendAttribute : DictionaryCacheBase<Type, List<ScriptExtendAttribute>, ReflectTypeListScriptExtendAttribute>
    {
        protected override List<ScriptExtendAttribute> GetValueForDic(Type key)
        {
            return key.GetCustomAttributes(typeof(ScriptExtendAttribute), true).Cast<ScriptExtendAttribute>().ToList();
        }
    }
    public class ScriptItem
    {
        public int Index { set; get; }
        public string Src { set; get; }

        public static implicit operator ScriptItem(ScriptAttribute s)
        {
            return new ScriptItem { Index = s.Index, Src = s.Src };
        }
    }
    public static class ScriptAttributeExtension
    {
        public static List<ScriptItem> GetScriptItems(this List<ScriptAttribute> sa)
        {
            return sa.Select<ScriptAttribute, ScriptItem>(s => s).ToList();
        }

        public static List<ScriptItem> GetScriptItems(this List<ScriptAttribute> sa, Type[] typeExtendScripts)
        {
            if (typeExtendScripts == null || typeExtendScripts.Length == 0) return sa.GetScriptItems().Where(s => s.Src.IsNotNull()).ToList();
            return sa.GetScriptItems().Concat(typeExtendScripts.SelectMany(t => ReflectTypeListScriptAttribute.Inst[t].GetScriptItems()))
                .Where(s => s.Src.IsNotNull())
                .GroupBy(s => s.Src)
                .Select(g => g.First())
                .ToList();
        }
    }

    public class ScriptBySessionTypeAttribute : ScriptAttribute
    {
        public SessionType SessionType { set; get; }
        public override string Src
        {
            get { return PortalContext.SessionType == SessionType ? base.Src : string.Empty; }
            set { base.Src = value; }
        }
    }
}
