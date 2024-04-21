using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;

using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;
using Core.DataBase.ADOProvider;
using Core.Extensions;
using System.Web.UI;

namespace Core.Sites.Libraries.Utilities.Sites
{
    public class PortalModule : ControlBase, IViPortalModule, IAjax
    {
        /// <summary>
        /// Khi chuyển trang Ajax => CoreQuery sẽ chứa tham số trên Url
        /// </summary>
        public NameValueCollection CoreQuery { set; get; }

        sealed public override void InitData()
        {
            OnInitData();
            if (UseModuleTypeAction)
            {
                this.SetData("ModuleTypeAction", ControlName);
                this.SetData("ModuleProject", GetType().BaseType.Assembly.FullName.Split(',')[0]);
            }
            Controls.Cast<Control>().OfType<ControlBase>().ForEach(c => c.InitData());
        }

        private bool useModuleTypeAction = true;
        public bool UseModuleTypeAction
        {
            get { return useModuleTypeAction; }
            set { useModuleTypeAction = value; }
        }

        protected virtual void OnInitData() { }

        public static HtmlBuilder<TEntity> NewBuilder<TEntity>() where TEntity : class, new()
        {
            return new HtmlBuilder<TEntity>(); 
        }

        private HtmlBuilder<Empty> builder = NewBuilder<Empty>();
        protected HtmlBuilder<Empty> Builder { get { return builder; } }
        public FormGroup<Empty> FormGroup { get { return builder.FormGroup; } }
        public Table<Empty> Table { get { return builder.Table; } }
        public Checkbox<Empty> Checkbox { get { return builder.Checkbox; } }
    }

    public class PortalModule<TEntity> : PortalModule where TEntity : class, new()
    {
        private HtmlBuilder<TEntity> builder = new HtmlBuilder<TEntity>();
        new protected HtmlBuilder<TEntity> Builder { get { return builder; } }
        new public FormGroup<TEntity> FormGroup { get { return builder.FormGroup; } }
        new public Table<TEntity> Table { get { return builder.Table; } }
        new public Checkbox<TEntity> Checkbox { get { return builder.Checkbox; } }
        public TEntity Entity { set; get; }
    }

    public abstract class PortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage> : PortalModule<TEntity>, IPortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage>
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {
        public List<TEntityLanguage> EntityLanguages { set; get; }
    }

    public interface IPortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage> : IAjax
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {
        List<TEntityLanguage> EntityLanguages { get; set; }
        TEntity Entity { get; }
    }

    public class HtmlBuilder<TEntity> where TEntity : class, new()
    {
        public FormGroup<TEntity> FormGroup { get { return new FormGroup<TEntity>(); } }
        public Table<TEntity> Table { get { return new Table<TEntity>(); } }
        public Checkbox<TEntity> Checkbox { get { return new Checkbox<TEntity>(); } }
        public Input<TEntity> Input { get { return new Input<TEntity>(); } }
        public DatePicker<TEntity> DatePicker { get { return new DatePicker<TEntity>(); } }

        public Input<TEntity, Input<TEntity>> NewInput(string style, string css = "")
        {
            return Input.Style(style).InputCss(css);
        }
    }

    public class Empty { }
}