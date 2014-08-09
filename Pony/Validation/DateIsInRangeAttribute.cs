using System;

namespace Pony.Validation
{
    public class DateIsInRangeAttribute : PropertyValidationAttribute
    {
        private readonly DateTime _lowerBound;
        private readonly DateTime _upperBound;

        public DateIsInRangeAttribute(DateTime lowerBound, DateTime upperBound, string errorMessage) : base(errorMessage)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is DateTime && (DateTime) obj < _upperBound && (DateTime) obj > _lowerBound;
        }
    }
}