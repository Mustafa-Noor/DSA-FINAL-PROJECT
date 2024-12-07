using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchmakingPlatform
{
    class Validations
    {
        public static bool ValidateContactPattern(string contact) // checks the contact no pattern
        {
            string pattern = @"^\d{11}$"; // Pattern for 11 digits in sequence
            return Regex.IsMatch(contact, pattern);

        }
        public static bool ValidateEmailPattern(string email) // checks the email pattern
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
        public static bool CheckingPasswordLength(string sen) // checks the length of password
        {
            if (sen.Length != 6)
            {
                return false;
            }
            return true;
        }

        public static bool CheckingForSpace(string sen) // checks for space in the string
        {
            for (int x = 0; x < sen.Length; x++)
            {
                if (sen[x] == ' ')
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckforEmpty(string sen) // check the empty string
        {
            if (sen == "")
            {
                return true;
            }

            return false;
        }


        public static bool CheckForInteger(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsAtLeast18YearsOld(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            // Adjust age if the birthday hasn't occurred yet this year
            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age >= 18;
        }



    }
}
