using Entities.Interfaces;
using System;

namespace Common.Helpers
{
    public static class EmailValidations
    {
        /// <summary>
        /// Function to normalize an email
        /// </summary>
        public static string NormalizeEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
