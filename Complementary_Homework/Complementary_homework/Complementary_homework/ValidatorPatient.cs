using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complementary_homework
{
    public static class ValidatorPatient
    {
        public static bool IsNameValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
        public static bool IsAgeValid(string age, out int ageValue) 
        {
            if (!int.TryParse(age, out ageValue))
                return false;
            return ageValue > 0 && ageValue < 120;
            }
        public static bool IsDiagnosisValid(string diagnosis)
        {
            return !string.IsNullOrWhiteSpace(diagnosis);
        }
        public static bool IsAddressValid(string address)
        {
            return !string.IsNullOrWhiteSpace(address);
        }
        public static bool IsBloodTypeValid(string blood)
        {
            string[] validTypes = { "O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-" };
            return validTypes.Contains(blood.ToUpper());
        }
    }
}
