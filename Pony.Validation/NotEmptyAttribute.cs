using System;

namespace Pony.Validation
{
    public class NotEmptyAttribute : PropertyValidationAttribute
    {
        public NotEmptyAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => !string.IsNullOrEmpty(obj as string);
        }
    }
}
