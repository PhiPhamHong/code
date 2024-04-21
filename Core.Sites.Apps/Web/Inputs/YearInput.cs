using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataBase.ADOProvider;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class YearInput : SelectModel<YearInput.Year, YearInput>
    {
        public YearInput()
        {
            DisableSearch(true);
        }

        protected override List<Year> GetData()
        {
            return Enumerable.Range(2017, DateTime.Today.Year - 2014).Select(i => new Year { Value = i, Text = "" + i }).ToList();
        }

        public class Year : ModelBase
        {
            [DataValueField] public int Value { set; get; }
            [DataTextField] public string Text { set; get; }
        }
    }
}