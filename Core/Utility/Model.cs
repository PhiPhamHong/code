using System.Collections.Generic;
using Core.Extensions;
using System.Collections.Specialized;
using System;
using System.Linq;
using System.Data;
using Core.Attributes.Validators;
namespace Core.Utility
{
    public class Model<T> where T : new()
    {
        public static T Parse(Dictionary<string, object> dicValues, bool ignoreCase) { return New(t => t.Parse(dicValues, ignoreCase)); }
        public static T ParseWithValidate(Dictionary<string, object> dicValues, bool validateFullProperties) => New(t => { var vm = t.Validate(dicValues, validateFullProperties); if (!vm.IsValid) throw new ValidatorException(vm); t.Parse(dicValues, false); });
        public static T ParseWithValidate(NameValueCollection values, bool validateFullProperties) => ParseWithValidate(values.ToDic(), validateFullProperties);
        public static T Parse(NameValueCollection values, bool ignoreCase) { return New(t => t.Parse(values, ignoreCase)); }
        public static T Parse(DataRow dr, bool ignoreCase) { return New(t => t.Parse(dr, ignoreCase)); }
        public static List<T> ParseToList(DataTable table, bool ignoreCase, Action<T> action = null) { return Cast(table, ignoreCase, action).ToList(); }
        public static IEnumerable<T> Cast(DataTable table, bool ignoreCase, Action<T> action = null)
        {
            return table.AsEnumerable().Select(dr => { var t = Parse(dr, ignoreCase); if (action != null) action(t); return t; });
        }
        public static T New(Action<T> func = null) { T t = new T(); if (func != null) func(t); return t; }
    }
}
