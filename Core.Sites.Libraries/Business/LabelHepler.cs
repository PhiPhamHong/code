using Core.Extensions;
using Core.Web.WebBase;
using System.Collections.Generic;
using System.Linq;


namespace Core.Sites.Libraries.Business
{
    public class LabelHelper : IAjax
    {
        public void SendNewLabel(List<string> items)
        {
            try
            {
                var newLabels = items.Select(item =>
                {
                    var newItem = new QueueItem
                    {
                        Lexicon = item,
                        Value = item,
                        ForJs = true
                    };

                    var labelAttr = Const.Data.TryGet(newItem.Lexicon);
                    if (labelAttr != null) newItem.Value = labelAttr.Value;

                    return newItem;
                }).ToList();
                this.SetData("Labels", newLabels);
            }
            catch { }
        }
    }
    

    public class QueueItem
    {
        public string Lexicon { get; set; }
        public string Value { get; set; }
        public bool ForJs { get; set; }
    }
}
