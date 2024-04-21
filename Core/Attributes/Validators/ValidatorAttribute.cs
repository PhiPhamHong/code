using System;
using System.Collections.Generic;
namespace Core.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidatorAttribute : Attribute
    {
        public int Stt { set; get; }

        private object value;
        protected object Value
        {
            get { return value; }
        }
        
        private string fieldName = string.Empty;
        protected string FieldName
        {
            get { return fieldName; }
        }

        public Type ObjectType { set; get; }
        
        public Dictionary<string, object> Data { set; get; }

        public void SetData(object value, string fieldName)
        {
            this.value = value;
            this.fieldName = fieldName;
        }
        public abstract bool Validate();
        public abstract string GetMessage();
    }

    public enum ValidatorStatus
    {
        Valid = 0,
        InValid = 1
    }

    public class ValidatorMessage
    {
        public ValidatorStatus Status { set; get; }
        public string Message {set;get;}
        public string FieldName { set; get; }        

        public bool IsValid
        {
            get
            {
                return Status == ValidatorStatus.Valid;
            }
        }

        public static ValidatorMessage GetDefault()
        {
            return new ValidatorMessage { Status = ValidatorStatus.Valid, Message = "Validated" };
        }
    }

    public class ValidatorException : Exception
    {
        private ValidatorMessage validatorMessage = null;
        public ValidatorMessage ValidatorMessage
        {
            get { return validatorMessage; }            
        }

        public ValidatorException(ValidatorMessage validatorMessage) : base(validatorMessage.Message)
        {
            this.validatorMessage = validatorMessage;
        }

        public ValidatorException(string fieldName, string message) : base(message)
        {
            validatorMessage = new ValidatorMessage 
            {
                FieldName = fieldName,
                Message = message,
                Status = ValidatorStatus.InValid
            };
        }
    }
}