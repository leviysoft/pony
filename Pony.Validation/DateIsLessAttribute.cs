using System;

namespace Pony.Validation
{
    public class DateIsLessAttribute : PropertyValidationAttribute
    {
        private readonly DateTime _upperBound;

        public DateIsLessAttribute(DateTime upperBound, string errorMessage) : base(errorMessage)
        {
            _upperBound = upperBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is DateTime && (DateTime) obj < _upperBound;
        }
    }
}