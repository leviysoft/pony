using System;
using System.Text.RegularExpressions;

namespace Pony.Validation
{
    public class MatchesRegexAttribute : PropertyValidationAttribute
    {
        private readonly Regex _regex;

        public MatchesRegexAttribute(string regex, string errorMessage) : base(errorMessage)
        {
            _regex = new Regex(regex);
        }

        public override Func<object, bool> GetValidator()
        {
            return obj => obj is string && _regex.IsMatch(obj as string);
        }
    }
}