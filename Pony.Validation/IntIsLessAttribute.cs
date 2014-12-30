using System;

namespace Pony.Validation
{
    public class IntIsLessAttribute : PropertyValidationAttribute
    {
        private readonly int _upperBound;

        public IntIsLessAttribute(int upperBound, string errorMessage) : base(errorMessage)
        {
            _upperBound = upperBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is int && (int) obj < _upperBound;
        }
    }
}