using System;
using Core.Extensions;
namespace Core.Business.Entities.Log
{
    public class FieldConverterAttribute : Attribute
    {
        public Type Type { set; get; }
    }
}