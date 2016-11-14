using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _2.UsersDatabase.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string emailString = (string) value;
            if (string.IsNullOrEmpty(emailString))
            {
                throw new ArgumentException("The email is not of string type.");
            }

            string regExpString = @"([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)";
            var regex = new Regex(regExpString);
            if (!regex.IsMatch(emailString))
            {
                return false;
            }

            return true;
        }
    }
}