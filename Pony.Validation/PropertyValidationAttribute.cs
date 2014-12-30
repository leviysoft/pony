using System;

namespace Pony.Validation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        public readonly string ErrorMessage;

        protected PropertyValidationAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public abstract Func<object, bool> GetValidator();
    }
}