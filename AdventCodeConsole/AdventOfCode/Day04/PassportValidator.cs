using System.Linq;

namespace AdventOfCode.Day04
{
    class PassportValidator: IPassportValidator
    {
        private readonly string[] mandatoryFields = new string[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public bool IsValid(PassportInfo passport)
        {
            var isValid = this.mandatoryFields.FirstOrDefault(field => !this.ContainsField(passport, field)) == null;

            return isValid;
        }

        private bool ContainsField(PassportInfo passport, string fieldName)
        {
            return passport.Fields.FirstOrDefault(field => field.Key == fieldName) != null;
        }
    }
}