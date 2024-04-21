using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Core.DataBase.ADOProvider;
using Core.Business.Entities;
using Core.Utility;
using Core.Web.Extensions;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.DataBase.ADOProvider.Attributes;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class FormLanguage : PortalModule
    {
        public List<Language> Languages { private set; get; }
        protected int random = Singleton<Random>.Inst.Next(1, 10000);

        public string TypeControl { set; get; }

        protected override void OnInitData()
        {
            Languages = Language.Inst.GetAllToList().OrderBy(l => l.Stt).ToList();
            rpTabs.DoBind(Languages);
            rpContents.DoBind(Languages);
            UseModuleTypeAction = false;
        }

        public event Action<Language, PlaceHolder> BindItemLanguage;

        protected void rpContents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            BindItemLanguage(e.As<Language>(), e.Find<PlaceHolder>("plc"));
        }
    }

    public abstract class ManageModule<TEntity, TEntityLanguage, TKey, TKeyLanguage, TProvider, TControlEdit, TControlEditLanguage> : ManageModule<TEntity, TProvider>
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
        where TProvider : ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage>, new()
        where TControlEdit : PortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage>
        where TControlEditLanguage : PortalModule<TEntityLanguage>
    {
        sealed protected override void BeforeInitFormEdit(PortalModule<TEntity> form, TEntity t)
        {
            form.As<TControlEdit>().LoadFormLanguage<TEntity, TEntityLanguage, TKey, TKeyLanguage, TControlEditLanguage>();
            OnBeforeInitFormEdit(form);
        }

        protected virtual void OnBeforeInitFormEdit(PortalModule<TEntity> form) { }
        protected override ControlBase LoadControlEdit() => Control<TControlEdit>.Create();

        public abstract class ManageModuleProviderLanguage : ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage> { }
        public abstract class ManageModuleProviderLanguageAuto : ManageModuleProviderAuto<TEntity, TEntityLanguage, TKey, TKeyLanguage> { }
    }

    public abstract class FormEdit<TEntity, TEntityLanguage, TKey, TKeyLanguage, TProvider, TControlEditLanguage> : FormEdit<TEntity, TProvider>, IPortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage>
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
        where TProvider : ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage>, new()
        where TControlEditLanguage : PortalModule<TEntityLanguage>
    {
        sealed protected override void AfterInitFormEdit()
        {
            this.LoadFormLanguage<TEntity, TEntityLanguage, TKey, TKeyLanguage, TControlEditLanguage>();
            OnAfterInitFormEdit();
        }

        protected virtual void OnAfterInitFormEdit() { }

        public List<TEntityLanguage> EntityLanguages { set; get; }
    }

    public abstract class ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage> : ManageModuleProvider<TEntity, TKey>, IAjax
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {
        private static readonly Regex rex = new Regex("entity-language-([0-9]+)\\[([^/]+)\\]", RegexOptions.Compiled);

        protected virtual IDataBaseService GetDataBaseService(TEntity t)
        {
            if (t.Is<IModelDataBaseService>())
                return t.As<IModelDataBaseService>().GetDataBaseService();
            return null;
        }

        protected class StoreDataSave
        {
            public List<TEntityLanguage> EntityLanguages { set; get; }
            public int LanguageId { set; get; }
            public TEntityLanguage EntityLanguageDefault { set; get; }
        }

        private StoreDataSave DataSave { set; get; }
        sealed protected override void OnBeforeSave(TEntity t)
        {
            DataSave = new StoreDataSave { };
            DataSave.EntityLanguages = HttpContext.Current.Request.Params.Cast<string>()
                .Select(key => new { key, value = HttpContext.Current.Request.Params[key] })
                .Select(kv => new { match = rex.Match(kv.key), kv }).Where(mkv => mkv.match.Success)
                .Select(mkv => new { language = mkv.match.Groups[1].Value.To<int>(), key = mkv.match.Groups[2].Value, mkv.kv.value })
                .GroupBy(data => data.language).Select(g =>
                {
                    var values = g.ToDictionary(gi => gi.key, gi => (object)gi.value);
                    var entityLanguage = g.Key == PortalContext.DefaultLanguage ? Model<TEntityLanguage>.ParseWithValidate(values, true) : Model<TEntityLanguage>.Parse(values, false);

                    if (g.Key == PortalContext.DefaultLanguage) EntityWithEntityDefaultLanguage(t, entityLanguage);

                    if (entityLanguage is IAlias) entityLanguage.As<IAlias>().Alias = entityLanguage.As<IAlias>().NameForAlias.UnicodeFormat();

                    entityLanguage.LanguageId = g.Key;
                    Validate(t, entityLanguage, g.Key == PortalContext.DefaultLanguage);

                    return entityLanguage;
                }).ToList();

            DataSave.LanguageId = PortalContext.DefaultLanguage;
            DataSave.EntityLanguageDefault = DataSave.EntityLanguages.FirstOrDefault(el => el.LanguageId == DataSave.LanguageId);

            BeforeSave(t);
        }
        new protected virtual void BeforeSave(TEntity t) { }
        sealed protected override void Save(TEntity t, List<LogEntity> logEntities, IDataBaseService st)
        {
            SaveEntity(t, st);
            AfterSaveEntity(t, st, logEntities);

            // Tạo Alias nếu như bị rỗng
            DataSave.EntityLanguages.Where(e => e.LanguageId != DataSave.LanguageId).ForEach(el =>
            {
                // Cập nhật những thông tin nào bị trống bên ngôn ngữ khác thì lấy nội dung
                // theo ngôn ngữ mặc định
                el.Copy(DataSave.EntityLanguageDefault);

                if (el is IAlias && el.As<IAlias>().Alias.IsNull())
                    el.As<IAlias>().Alias = DataSave.EntityLanguageDefault.As<IAlias>().Alias + "-" + el.LanguageId;
            });

            // Tránh các alias bị trùng nhau theo các ngôn ngữ
            DataSave.EntityLanguages.OfType<IAlias>().GroupBy(el => el.Alias).ForEach(g =>
            {
                var els = g.ToList();
                if (els.Count > 1)
                    els.ForEach(el =>
                    {
                        if ((el as ILanguage).LanguageId != DataSave.LanguageId) el.Alias = $"{el.Alias}-{(el as ILanguage).LanguageId}";
                    });
            });
            DataSave.EntityLanguages.ForEach(el =>
            {
                el.Key = t.Key;
                SaveEntityLanguage(el, st);
            });

            this.SetData("EntityKey", t.Key);
        }

        protected virtual void EntityWithEntityDefaultLanguage(TEntity t, TEntityLanguage tl) { }
        protected virtual void SaveEntity(TEntity t, IDataBaseService service)
        {
            t.SetDataBaseService(service);
            t.Save();
        }
        protected virtual void SaveEntityLanguage(TEntityLanguage tl, IDataBaseService service)
        {
            tl.SetDataBaseService(service);
            tl.Save();
        }
        protected virtual void Validate(TEntity t, TEntityLanguage tl, bool languageDefault) { }
        protected virtual void AfterSaveEntity(TEntity t, IDataBaseService service, List<LogEntity> logEntities) { }

        new public abstract class Source<TDataSource> : ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage> where TDataSource : class, ISource, new()
        {
            sealed protected override ISource CreateDataSource()
            {
                var source = new TDataSource { };
                OnCreateDataSource(source);
                return source;
            }
            protected virtual void OnCreateDataSource(TDataSource source) { }
            new public TDataSource DataSource { protected set => base.DataSource = value; get => base.DataSource as TDataSource; }
        }
    }

    public class DataSourceAuto<TEntity, TEntityLanguage, TKey, TKeyLanguage> : DataSource<TEntity>.Module
                where TEntity : ModelBase, IModel<TKey>, new()
                where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {
        public int LanguageId { set; get; }
        public string KeySearch { set; get; }

        public override List<TEntity> GetEntities() => Language.SelectForModule(Singleton<TEntity>.Inst, Singleton<TEntityLanguage>.Inst, KeySearch, LanguageId, Start, Length, FieldOrder, Dir);
        public override int GetTotal() => Language.SelectForModuleCount(Singleton<TEntity>.Inst, Singleton<TEntityLanguage>.Inst, KeySearch, LanguageId);
    }

    public abstract class ManageModuleProviderAuto<TEntity, TEntityLanguage, TKey, TKeyLanguage> : ManageModuleProvider<TEntity, TEntityLanguage, TKey, TKeyLanguage>.Source<DataSourceAuto<TEntity, TEntityLanguage, TKey, TKeyLanguage>>
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {
        public int LanguageId { set; get; }
    }

    public static class PortalModuleLanguageExtension
    {
        public static void LoadFormLanguage<TEntity, TEntityLanguage, TKey, TKeyLanguage, TControlEditLanguage>(this IPortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage> form)
            where TEntity : ModelBase, IModel<TKey>, new()
            where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
            where TControlEditLanguage : PortalModule<TEntityLanguage>
        {
            form.SetData("EntityLanguages", form.EntityLanguages = Singleton<TEntityLanguage>.Inst.GetEntityLanguages(form.Entity.Key));

            (form as Control).FindAllChildrenByType<FormLanguage>().Select((formLanguage, i) =>
            {
                formLanguage.BindItemLanguage += (language, plc) =>
                {
                    var formEditLanguage = formLanguage.TypeControl.IsNull() ? Control<TControlEditLanguage>.Create() :
                        ControlBase.DoLoad(Type.GetType(formLanguage.TypeControl)) as PortalModule<TEntityLanguage>;
                    formEditLanguage.Entity = form.EntityLanguages.FirstOrDefault(el => el.LanguageId == language.LanguageId);
                    plc.Controls.Add(formEditLanguage);

                    if (i == 0)
                    {
                        plc.Controls.Add(new LiteralControl { Text = "<input type='hidden' name='KeyLanguage' />" });
                        form.SetData("Languages", formLanguage.Languages);
                    }
                    formEditLanguage.UseModuleTypeAction = false;
                    formEditLanguage.InitData();
                };

                formLanguage.InitData();
                return true;
            }).Count();
        }
    }
}