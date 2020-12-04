using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventCodeConsole.FourthDay
{
    class StrictPassportValidator : IPassportValidator
    {
        private readonly string[] mandatoryFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        private readonly Dictionary<string, Func<string, bool>> validators;
        private readonly string heightPattern = @"^(\d+)(in|cm)$";
        private readonly string hairColorPattern = @"^#[0-9|a-f]{6}$";
        private readonly string passportIdpattern = @"^[0-9]{9}$";
        private readonly string[] allowedEyeColours = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public StrictPassportValidator()
        {
            this.validators = new Dictionary<string, Func<string, bool>>
            {
                { "byr", this.IsByrValid },
                { "iyr", this.IsiyrValid },
                { "eyr", this.IseyrValid },
                { "hgt", this.IshgtValid },
                { "hcl", this.IshclValid },
                { "ecl", this.IseclValid },
                { "pid", this.IspidValid }
            };
        }

        public bool IsValid(PassportInfo passport)
        {
            foreach (var fieldName in this.mandatoryFields)
            {
                var fieldValue = this.GetValueField(passport, fieldName);
                if (string.IsNullOrWhiteSpace(fieldValue)) { return false; }

                if (this.validators.TryGetValue(fieldName, out var validator)
                    && !validator(fieldValue))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsByrValid(string fieldValue) => this.IsValidYear(fieldValue, 1920, 2002);
        private bool IsiyrValid(string fieldValue) => this.IsValidYear(fieldValue, 2010, 2020);
        private bool IseyrValid(string fieldValue) => this.IsValidYear(fieldValue, 2020, 2030);
        private bool IshgtValid(string fieldValue)
        {
            var result = Regex.Match(fieldValue, this.heightPattern);

            if (!result.Success) { return false; }

            var heightValue = result.Groups[1].Value;

            if (result.Groups[2].Value == "in")
            {
                return this.IsValidNumber(heightValue, 59, 76);
            }
            return this.IsValidNumber(heightValue, 150, 193);
        }
        private bool IshclValid(string fieldValue) => Regex.Match(fieldValue, this.hairColorPattern).Success;
        private bool IseclValid(string fieldValue) => this.allowedEyeColours.Contains(fieldValue);
        private bool IspidValid(string fieldValue) => Regex.Match(fieldValue, this.passportIdpattern).Success;

        private bool IsValidYear(string fieldValue, int yearFrom, int yearTo)
        {
            if (fieldValue.Length != 4) { return false; }
            return this.IsValidNumber(fieldValue, yearFrom, yearTo);
        }

        private bool IsValidNumber(string fieldValue, int from, int to)
        {
            if (int.TryParse(fieldValue, out int result))
            {
                if (result >= from && result <= to) { return true; }
            }
            return false;
        }

        private string GetValueField(PassportInfo passport, string fieldName)
        {
            return passport.Fields.FirstOrDefault(field => field.Key == fieldName)?.Value;
        }
    }
}