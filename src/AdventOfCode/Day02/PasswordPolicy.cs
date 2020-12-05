using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day02
{
    public class PasswordPolicyFirst : PasswordPolicy
    {
        public override bool IsPasswordValid(string password)
        {
            var pattern = $"({this.Letter})";
            var result = Regex.Matches(password, pattern);
            return this.FirstNumber <= result.Count && this.SecondNumber >= result.Count;
        }
    }

    public class PasswordPolicySecond : PasswordPolicy
    {
        public override bool IsPasswordValid(string password)
        {
            var charAtFirstIsLetter = password[this.FirstNumber - 1].ToString() == this.Letter;
            var charAtSecondIsLetter = password[this.SecondNumber - 1].ToString() == this.Letter;

            var result = charAtFirstIsLetter != charAtSecondIsLetter;
            return result;
        }
    }

    public abstract class PasswordPolicy
    {
        public void Initialize(string info)
        {
            var data = info.Split(' ');
            this.Letter = data[1];
            var occursInfo = data[0].Split('-');
            this.FirstNumber = Convert.ToInt32(occursInfo[0]);
            this.SecondNumber = Convert.ToInt32(occursInfo[1]);
        }

        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public string Letter { get; private set; }

        public abstract bool IsPasswordValid(string password);
    }
}
