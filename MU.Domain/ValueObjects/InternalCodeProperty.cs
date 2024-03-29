﻿using System.Text.RegularExpressions;

namespace MU.Domain.ValueObjects
{
    public partial record InternalCodeProperty
    {
        private const string InitialCode = "P";
        private const int MinLengthName = 5;
        private const string PatternReplaceCharacters = "/(\\s)/g";
        private InternalCodeProperty(string code) => Value = code;

        public static explicit operator string(InternalCodeProperty codeInternal) => codeInternal.Value;
        public static InternalCodeProperty? Create(string nameProperty, int year)
        {
            if (String.IsNullOrEmpty(nameProperty) || year == 0 || year > DateTime.Now.Year || nameProperty.Length < MinLengthName)
            {
                return null;
            }

            string currentDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            return new InternalCodeProperty(String.Format("{0}-{1}-{2}-{3}", InitialCode, ReplaceCharactersRegex().Replace(nameProperty, "").Substring(0, MinLengthName).ToUpper(), year.ToString(), currentDate));
        }
        public static InternalCodeProperty? SetInternalCode(string internalCode)
        {
            return new InternalCodeProperty(internalCode);
        }
        public string Value { get; init; }
        private static Regex ReplaceCharactersRegex() => new Regex(PatternReplaceCharacters, RegexOptions.Compiled);
    }
}
