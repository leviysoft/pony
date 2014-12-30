using System;

namespace Pony.Validation
{
    public class DateIsGreaterAttribute : PropertyValidationAttribute
    {
        private readonly DateTime _lowerBound;

        public DateIsGreaterAttribute(DateTime lowerBound, string errorMessage) : base(errorMessage)
        {
            _lowerBound = lowerBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is DateTime && (DateTime) obj > _lowerBound;
        }
    }
}