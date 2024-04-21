using System;
using System.Reflection;
using Core.Extensions;
using Newtonsoft.Json;

namespace Core.Attributes
{
    /// <summary>
    /// ClassInfoAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassInfoAttribute : Attribute
    {
        /// <summary>
        /// Type của class có Attribute ClassInfo
        /// </summary>
        [JsonIgnore] public Type Type { set; get; }

        private string typeName = string.Empty;
        [JsonIgnore]
        public string TypeName
        {
            get
            {
                if (typeName.IsNull()) typeName = Type.FullName + "," + AssemblyName;
                return typeName;
            }
        }

        private string assemblyName = string.Empty;
        [JsonIgnore]
        public string AssemblyName
        {
            get
            {
                if (assemblyName.IsNull()) assemblyName = Assembly.FullName.Split(',')[0];
                return assemblyName;
            }
        }

        private Assembly assembly = null;
        [JsonIgnore]
        public Assembly Assembly
        {
            get
            {
                if (assembly == null) assembly = Type.Assembly;
                return assembly;
            }
        }

        [JsonIgnore] public override object TypeId => base.TypeId;
    }
}
