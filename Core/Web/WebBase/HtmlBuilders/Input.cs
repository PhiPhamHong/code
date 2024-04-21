using System.Collections.Generic;
using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class Input<T, TChain> : InputBase<T, TChain> where TChain : Input<T, TChain>
    {
        #region property
        private string inputType = "text"; public TChain InputType(string inputType) { return Chain(t => t.inputType = inputType); }
        public TChain TypePassword() { return Chain(t => t.inputType = "password"); }

        private int cols = 0;
        private int rows = 0;
        public TChain TypeTextArea(int cols = 0, int rows = 0) { return Chain(t => { t.inputType = "textarea"; t.cols = cols; t.rows = rows; }); }
        public TChain TypeEditor(int cols = 0, int rows = 0) { return Chain(t => { t.inputType = "editor"; t.cols = cols; t.rows = rows; }); }

        private object text = string.Empty; public TChain Text(object text) { return Chain(t => t.text = text); }
        public TChain Format(FormatInput format) { return Chain(t => t.Data("format", format)); }
        public TChain IsNumeric() { return Format(FormatInput.Numeric); }

        protected string inputSize = "input-sm"; public TChain InputSize(string inputSize) { return Chain(t => t.inputSize = inputSize); }
        protected int? size = null; public TChain Size(int? size) { return Chain(t => t.size = size); }

        protected string icon = ""; public TChain Icon(string icon) { return Chain(t => t.icon = icon); }

        private int? maxLength = null;
        public TChain MaxLength(int? maxLength)
        {
            return Chain(t => t.maxLength = maxLength);
        }
        #endregion

        public override string ToString()
        {
            Init();

            var html = new StringBuilder();
            var end = string.Empty;
            switch(inputType)
            {
                case "textarea":
                case "editor":
                    html.Append("<textarea ");
                    if (cols != 0) html.AppendFormat("cols = '{0}' ", cols);
                    if (rows != 0) html.AppendFormat("rows = '{0}' ", rows);
                    html.AppendFormat("data-text-area-type = '{0}' ", inputType);

                    if (style.IsNotNull()) html.AppendFormat("style='{0}' ", style);

                    end = ">{0}</textarea>".Frmat(text);
                    break;
                default:

                    if(icon.IsNotNull())
                    {
                        html.Append("<div class='input-group'>");
                    }

                    html.AppendFormat("<input autocomplete='off' type='{0}' ", inputType);
                    if (text.IsNotNull()) html.AppendFormat("value='{0}' ", text);
                    if (style.IsNotNull()) html.AppendFormat("style='{0}' ", style);

                    if(icon.IsNotNull())
                    {
                        end = "/>";
                        end += "<div class=\"input-group-addon\">";
                        end += "<i class='" + icon + "'></i>";
                        end += "</div>";
                        end += "</div>";
                    }

                    else end = "/>";
                    break;
            }

            html.AppendFormat("class = '{0} {1}' ", inputCss, inputSize);

            if (maxLength > 0) html.AppendFormat("maxlength='{0}' ", maxLength);

            if (!enable) html.Append("readonly='readonly' ");
            if (size != null && size != 0) html.AppendFormat("maxlength='{0}' size='0' ", size);

            // if (style.IsNotNull()) html.AppendFormat("style='{0}'", style);
            html.Append(GetDataAttribute());

            if (name.IsNotNull()) html.AppendFormat("name = '{0}' ", name);
            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);

            html.Append(end);
            return html.ToString();
        }

        public enum FormatInput
        {
            Numeric
        }
    }

    public class InputNumeric<T, TChain> : Input<T, TChain> where TChain : InputNumeric<T, TChain>
    {
        #region Properties
        private string groupSeparator = ",";
        public TChain GroupSeparator(string groupSeparator) { return Chain(t => t.groupSeparator = groupSeparator); }

        private bool greedy = false;
        public TChain Greedy(bool greedy) { return Chain(t => t.greedy = greedy); }

        private int? digits = null;
        public TChain Digits(int? digits) { return Chain(t => t.digits = digits); }

        private bool digitsOptional = true;
        public TChain DigitsOptional(bool digitsOptional) { return Chain(t => t.digitsOptional = digitsOptional); }

        private bool enforceDigitsOnBlur = false;
        public TChain EnforceDigitsOnBlur(bool enforceDigitsOnBlur) { return Chain(t => t.enforceDigitsOnBlur = enforceDigitsOnBlur); }

        private string radixPoint = ".";
        public TChain RadixPoint(string radixPoint) { return Chain(t => t.radixPoint = radixPoint); }

        private int groupSize = 3;
        public TChain GroupSize(int groupSize) { return Chain(t => t.groupSize = groupSize); }

        private bool autoGroup = true;
        public TChain AutoGroup(bool autoGroup) { return Chain(t => t.autoGroup = autoGroup); }

        private bool allowMinus = true;
        public TChain AllowMinus(bool allowMinus) { return Chain(t => t.allowMinus = allowMinus); }

        private int? integerDigits = null;
        public TChain IntegerDigits(int? integerDigits) { return Chain(t => t.integerDigits = integerDigits); }

        private bool integerOptional = true;
        public TChain IntegerOptional(bool integerOptional) { return Chain(t => t.integerOptional = integerOptional); }

        private string prefix = string.Empty;
        public TChain Prefix(string prefix) { return Chain(t => t.prefix = prefix); }

        private string suffix = string.Empty;
        public TChain Suffix(string suffix) { return Chain(t => t.suffix = suffix); }

        private bool rightAlign = true;
        public TChain RightAlign(bool rightAlign) { return Chain(t => t.rightAlign = rightAlign); }

        private bool decimalProtect = true;
        public TChain DecimalProtect(bool decimalProtect) { return Chain(t => t.decimalProtect = decimalProtect); }

        private int? min = null;
        public TChain Min(int? min) { return Chain(t => t.min = min); }

        private int? max = null;
        public TChain Max(int? max) { return Chain(t => t.max = max); }

        private int step = 1;
        public TChain Step(int step) { return Chain(t => t.step = step); }

        private bool insertMode = true;
        public TChain InsertMode(bool insertMode) { return Chain(t => t.insertMode = insertMode); }

        private bool autoUnmask = false;
        public TChain AutoUnmask(bool autoUnmask) { return Chain(t => t.autoUnmask = autoUnmask); }

        private bool unmaskAsNumber = false;
        public TChain UnmaskAsNumber(bool unmaskAsNumber) { return Chain(t => t.unmaskAsNumber = unmaskAsNumber); }
        #endregion

        public override string ToString()
        {
            IsNumeric();

            var propertiesInputNumeric = PropertiesInputMaskNumeric().JoinString(s => s);
            Data("inputmask", propertiesInputNumeric);

            return base.ToString();
        }

        private IEnumerable<string> PropertiesInputMaskNumeric()
        {
            yield return "'alias':'numeric'";

            if (greedy) yield return "'greedy': true";

            if (digits == null) yield return "'digits':'*'";
            else yield return "'digits':" + digits;

            if (digitsOptional == false) yield return "'digitsOptional': false";
            if (enforceDigitsOnBlur) yield return "'enforceDigitsOnBlur': true";
            if (radixPoint != ".") yield return "'radixPoint':'" + radixPoint + "'";
            if (groupSize != 3) yield return "'groupSize': " + groupSize;
            if(groupSeparator.IsNotNull()) yield return "'groupSeparator':'" + groupSeparator + "'";
            if (autoGroup) yield return "'autoGroup':true";
            if (allowMinus == false) yield return "'allowMinus':false";
            if (integerDigits == null) yield return "'integerDigits':'+'";
            else yield return "'integerDigits':" + integerDigits;

            if (integerOptional == false) yield return "'integerOptional':false";
            if (prefix.IsNotNull()) yield return "'prefix': '" + prefix + "'";
            if (suffix.IsNotNull()) yield return "'suffix': '" + suffix + "'";

            if (rightAlign == false) yield return "'rightAlign':false";
            if (decimalProtect == false) yield return "'decimalProtect':false";

            if (min != null) yield return "'min': " + min;
            if (max != null) yield return "'max': " + max;

            if (step != 1) yield return "'step':" + step;

            if (insertMode == false) yield return "'insertMode':false";
            if (autoUnmask) yield return "'autoUnmask': true";
            if (unmaskAsNumber) yield return "'unmaskAsNumber':true";
        }
    }

    public interface IInputMaxLength
    {
        void MaxLength(int? maxLength);
    }

    public class Input<T> : Input<T, Input<T>>, IInputMaxLength
    {
        void IInputMaxLength.MaxLength(int? maxLength)
        {
            Chain(t => t.MaxLength(maxLength));
        }
    }

    public class InputNumeric<T> : InputNumeric<T, InputNumeric<T>>
    {

    }
}
