using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _2.UsersDatabase.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordAttribute : ValidationAttribute
    {
        private readonly int _passMinLen;
        private readonly int _passMaxLen;

        public PasswordAttribute(int passwordMinLen = 0, int passwordMaxLen = 30)
        {
            this._passMinLen = passwordMinLen;
            this._passMaxLen = passwordMaxLen;
        }

        public bool ShouldContainLowercase { get; set; }
        public bool ShouldContainUppercase { get; set; }
        public bool ShouldContainDigit { get; set; }
        public bool ShouldContainSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            string passAsString = value as string;

            if (string.IsNullOrEmpty(passAsString))
            {
                throw new ArgumentException("Property must be type string!");
            }

            if (passAsString.Length < this._passMinLen | passAsString.Length > this._passMaxLen)
            {
                return false;
            }

            if (this.ShouldContainDigit && !this.ContainsDigit(passAsString))
            {
                return false;
            }

            if (this.ShouldContainUppercase && !this.ContainsUppercase(passAsString))
            {
                return false;
            }
            if (this.ShouldContainLowercase && !this.ContainsLowercase(passAsString))
            {
                return false;
            }

            if (this.ShouldContainSpecialSymbol && !this.ContainsSpecialSymbol(passAsString))
            {
                return false;
            }
            return true;
        }

        private bool ContainsSpecialSymbol(string passAsString)
        {
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
            foreach (char c in passAsString)
            {
                if (specialSymbols.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsLowercase(string passAsString)
        {
            if (passAsString.Count(char.IsLower) != 0)
            {
                return true;
            }

            return false;
        }

        private bool ContainsUppercase(string passAsString)
        {
            if (passAsString.Count(char.IsUpper) != 0)
            {
                return true;
            }

            return false;
        }

        private bool ContainsDigit(string passAsString)
        {
            if (passAsString.Count(char.IsDigit) != 0)
            {
                return true;
            }

            return false;
        }
    }
}