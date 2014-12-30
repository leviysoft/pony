using System;

namespace Pony.Validation
{
    public class IntIsGreaterAttribute : PropertyValidationAttribute
    {
        private readonly int _lowerBound;

        public IntIsGreaterAttribute(int lowerBound, string errorMessage) : base(errorMessage)
        {
            _lowerBound = lowerBound;
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is int && (int) obj > _lowerBound;
        }
    }
}