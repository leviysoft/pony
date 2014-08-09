using System;

namespace Pony.Validation
{
    public class IntIsInRangeAttribute : PropertyValidationAttribute
    {
        private readonly int _lowerBound;
        private readonly int _upperBound;

        public IntIsInRangeAttribute(int lowerBound, int upperBound, string errorMessage) : base(errorMessage)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is int && (int) obj > _lowerBound && (int) obj < _upperBound;
        }
    }
}