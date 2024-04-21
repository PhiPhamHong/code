using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Extensions;
using Core.Attributes;
using Core.Utility.Language;
using Core.Attributes.Validators;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class FormGroup<T> : Html<FormGroup<T>>, IFormGroup
    {
        #region properties
        private bool useCol = true; public FormGroup<T> UseCol(bool useCol) { return Chain(t => t.useCol = useCol); }
        private float col = 0; public FormGroup<T> Col(float col, bool useLabel = false)
        {
            if(useLabel)
            {
                inputCol = labelCol = 12;
            }

            return Chain(t => t.col = col);
        }
        private string colStyle = ""; public FormGroup<T> ColStyle(string colStyle) { return Chain(t => t.colStyle = colStyle); }

        private string css = ""; public FormGroup<T> Css(string css) { return Chain(t => t.css = css); }
        private float labelCol = 0; public FormGroup<T> LabelCol(float labelCol) { return Chain(t => t.labelCol = labelCol); }
        private bool labelHalfCol = false; public FormGroup<T> LabelHalfCol(bool labelHalfCol = true) { return Chain(t => t.labelHalfCol = labelHalfCol); }
        private string labelCss = "control-label"; public FormGroup<T> LabelCss(string labelCss) { return Chain(t => t.labelCss += " " + labelCss); }
        private string labelStyle = ""; public FormGroup<T> LabelStyle(string labelStyle) { return Chain(t => t.labelStyle += (labelStyle + ";")); }

        private string labelText = string.Empty; public FormGroup<T> LabelText(string labelText) { return Chain(t => t.labelText = labelText); }
        public FormGroup<T> LabelNull() { return LabelText(" "); }
        private float inputCol = 0; public FormGroup<T> InputCol(float inputCol) { return Chain(t => t.inputCol = inputCol); }
        private bool inputHalfCol = false; public FormGroup<T> InputHalfCol(bool inputHalfCol = true) { return Chain(t => t.inputHalfCol = inputHalfCol); }

        public FormGroup<T> HalfCol(bool label, bool input = false) { LabelHalfCol(label); return InputHalfCol(input); }

        public FormGroup<T> Col(float labelCol, float inputCol) { LabelCol(labelCol); return InputCol(inputCol); }
        public FormGroup<T> Col(float labelCol, float inputCol, string labelText = "")
        {
            LabelText(labelText);
            return Col(labelCol, inputCol);
        }
        public FormGroup<T> For<TMember>(Expression<Func<T, TMember>> expression, float labelCol, float inputCol, string css = "")
        {
            Field(expression);
            Col(labelCol, inputCol);
            return Css(css);
            //return For(expression, lc, ic, labelCol - lc >= 0.5, inputCol - ic >= 0.5, css);
        }
        public FormGroup<T> For<TMember>(Expression<Func<T, TMember>> expression, float col)
        {
            Field(expression);
            return Col(col);
        }

        private string inputCss = ""; public FormGroup<T> InputCss(string inputCss) { return Chain(t => t.inputCss += " " + inputCss); }
        private string inputStyle = ""; public FormGroup<T> InputStyle(string inputStyle) { return Chain(t => t.inputStyle += (inputStyle + ";")); }

        private LambdaExpression ex = null; public FormGroup<T> Field<TMember>(Expression<Func<T, TMember>> expression) { return Chain(t => t.ex = expression); }
        private bool noForm = false; public FormGroup<T> NoForm() { return Chain(t => t.noForm = true); }
        private bool? require = false; public FormGroup<T> Require(bool? require) { return Chain(t => t.require = require); }

        private List<IHtml> inputs = new List<IHtml>();
        public FormGroup<T> With<TInput>(Action<TInput> action = null) where TInput : IHtml, new()
        {
            return Chain(t => { BuildTInput(new TInput(), action); });
        }

        public FormGroup<T> With(string type)
        {
            return Chain(t => { BuildTInput(type.CreateInstance<IHtml>(), null); });
        }

        private void BuildTInput<TInput>(TInput tinput, Action<TInput> action = null) where TInput : IHtml
        {
            if (tinput is IInputBase<TInput>) tinput.As<IInputBase<TInput>>().Name(ex);
            if (tinput is IInoutWithFormGroup)
                tinput.As<IInoutWithFormGroup>().FormGroup = this;

            if (tinput is IInputWithFormGroupFireStart)
                tinput.As<IInputWithFormGroupFireStart>().StartWithParent();

            action?.Invoke(tinput);
            inputs.Add(tinput);
        }

        public FormGroup<T> Input(Action<InputInForm> action) { return Chain(t => { var tinput = new InputInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithInput(Action<InputInForm> action = null) { return Input(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        public FormGroup<T> Checkbox(Action<CheckboxInForm> action) { return Chain(t => { var tinput = new CheckboxInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithCheckbox(Action<CheckboxInForm> action = null) { return Checkbox(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        public FormGroup<T> DatePicker(Action<DatePickerInForm> action) { return Chain(t => { var tinput = new DatePickerInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithDatePicker(Action<DatePickerInForm> action = null) { return DatePicker(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        public FormGroup<T> TimePicker(Action<TimePickerÌnForm> action) { return Chain(t => { var tinput = new TimePickerÌnForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithTimePicker(Action<TimePickerÌnForm> action = null) { return TimePicker(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        public FormGroup<T> FileInput(Action<FileInputInForm> action) { return Chain(t => { var tinput = new FileInputInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithFileInput(Action<FileInputInForm> action = null) { return FileInput(ip => { ip.Name(ex); if (action != null) action(ip); }); }

        public FormGroup<T> DocInput(Action<DocInputInForm> action) { return Chain(t => { var tinput = new DocInputInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithDocInput(Action<DocInputInForm> action = null) { return DocInput(ip => { ip.Name(ex); if (action != null) action(ip); }); }

        public FormGroup<T> PriceInput(Action<PriceInputInForm> action) { return Chain(t => { var tinput = new PriceInputInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithPriceInput(Action<PriceInputInForm> action = null) { return PriceInput(ip => { ip.Name(ex); if (action != null) action(ip); }); }

        public FormGroup<T> MoneyInput(Action<MoneyInputInForm> action) { return Chain(t => { var tinput = new MoneyInputInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithMoneyInput(Action<MoneyInputInForm> action = null) { return MoneyInput(ip => { ip.Name(ex); if (action != null) action(ip); }); }

        public FormGroup<T> LatLngInput(Action<LatLngInputInForm> action = null) { return Chain(t => { var tinput = new LatLngInputInForm(); if (action != null) action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithColorPicker(Action<ColorPickerInForm> action = null) { return ColorPicker(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        public FormGroup<T> ColorPicker(Action<ColorPickerInForm> action = null) { return Chain(t => { var tinput = new ColorPickerInForm(); if (action != null) action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> NewFormGroup(Action<FormGroup<T>> action) { return Chain(t => { var formGroup = new FormGroup<T>(); action(formGroup); inputs.Add(formGroup); }); }

        public FormGroup<T> NumericInput(Action<InputNumericInForm> action) { return Chain(t => { var tinput = new InputNumericInForm(); action(tinput); t.inputs.Add(tinput); }); }
        public FormGroup<T> WithNumericInput(Action<InputNumericInForm> action = null) { return NumericInput(ip => { ip.Name(ex); if (action != null) action(ip); }); }
        #endregion

        private bool show = true;
        public FormGroup<T> Show(bool show) { return Chain(t => t.show = show); }
        public void SetShow(bool show) { this.show = show; }

        public override string ToString()
        {
            var html = new StringBuilder();

            if (ex != null)
            {
                var member = ex.GetMemberInfo();
                var field = member.GetAttribute<PropertyInfoAttribute>();
                if (labelText.IsNull())
                    labelText = field.IsNull() || field.Name.IsNull() ? member.Name : field.Name;

                if (require != null)
                {
                    var vra = member.GetAttribute<ValidatorRequireAttribute>();
                    if (vra != null) require = true;
                    else
                    {
                        var vdd = member.GetAttribute<ValidatorDenyValueAttribute>();
                        if (vdd != null) require = true;
                    }
                }
            }

            if (labelText.IsNotNull())
            {
                labelText = LanguageHelper.GetLabel(labelText);

                if (useCol)
                {
                    if (labelCol != 0 || (labelCol == 0 && labelHalfCol))
                    {
                        html.AppendFormat("<label class='{0} col-sm-{1}' style='{4}'>{2}{3}</label>",
                            labelCss,
                            labelCol.ToString().Replace(".", "-") + (labelHalfCol ? "-5" : "") + (col > 0 && labelCol == 12 ? "-none" : ""),
                            labelText,
                            require == true ? "<span style='color:red'> (*)</span>" : "",
                            labelStyle);
                    }
                }
                else
                {
                    html.AppendFormat("<label class='{0}' style='{3}'>{1}{2}</label>",
                        labelCss,
                        labelText,
                        require == true ? "<span style='color:red'> (*)</span>" : "",
                        labelStyle);
                }
                // else html.AppendFormat("<label class='{0}'>{1}</label>", labelCss, labelText);
            }

            if (useCol)
            {
                if (inputCol != 0 || (inputCol == 0 && inputHalfCol))
                {
                    html.AppendFormat("<div class='{0} col-sm-{1}' style='{2}'>",
                        inputCss,
                        inputCol.ToString().Replace(".", "-") + (inputHalfCol ? "-5" : "") + (col > 0 && inputCol == 12 ? "-none" : ""),
                        inputStyle);
                }
            }
            else
            {
                html.AppendFormat("<div class='{0}' style='{1}'>", inputCss, inputStyle);
            }

            html.Append(inputs.JoinString(ip => ip.ToString(), string.Empty));
            if (inputCol != 0 || (inputCol == 0 && inputHalfCol) || !useCol) html.Append("</div>");

            if (!noForm || !show) html.Append("</div>");

            var startHeader = new StringBuilder();
            if (!noForm)
            {
                startHeader.AppendFormat("<div class='{3} {0} {1} {2}' style='{4}'>",
                    col != 0 ? ("col-sm-" + col.ToString().Replace(".", "-")) : string.Empty,
                    css,
                    show ? string.Empty : "hide",
                    noForm ? string.Empty : "form-group",
                    colStyle
                    //string.Empty
                    );
            }
            else if (!show) startHeader.AppendFormat("<div class='{0}'>", show ? string.Empty : "hide");

            startHeader.Append(html);
            return startHeader.ToString();
        }

        void IFormGroup.SetInputStyle(string style) => inputStyle += style + ";";

        void IFormGroup.SetColStyle(string style) => colStyle += style + ";";

        bool IFormGroup.GetNoForm() => noForm;

        float IFormGroup.GetCol() => col;

        public class InputInForm : Input<T, InputInForm> { }
        public class CheckboxInForm : Checkbox<T, CheckboxInForm> { }
        public class DatePickerInForm : DatePicker<T, DatePickerInForm> { }
        public class TimePickerÌnForm : TimePicker<T, TimePickerÌnForm> { }
        public class FileInputInForm : FileInput<T, FileInputInForm> { }
        public class DocInputInForm : DocInput<T, DocInputInForm> { }

        public class LatLngInputInForm : LatLngInput<T, LatLngInputInForm> { }
        public class ColorPickerInForm : ColorPicker<T, ColorPickerInForm> { }
        public class PriceInputInForm : PriceInput<T, PriceInputInForm> { }
        public class MoneyInputInForm: MoneyInput<T, MoneyInputInForm> { }
        public class InputNumericInForm : InputNumeric<T, InputNumericInForm> { }
    }

    public interface IFormGroup
    {
        void SetShow(bool show);
        void SetInputStyle(string style);
        void SetColStyle(string style);

        bool GetNoForm();
        float GetCol();
    }

    public interface IInoutWithFormGroup
    {
        IFormGroup FormGroup { set; get; }
    }
    public interface IInputWithFormGroupFireStart : IInoutWithFormGroup
    {

        void StartWithParent();
    }

    public class FormGroup : FormGroup<ModelNone> { }
}
