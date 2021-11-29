using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineDetails;

namespace BeneficiaryDetails
{
    public class Details
    {
        private long _regNumber;
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int Dosage { get; set; }
        public Vaccine Vaccine { get; set; }
        public long RegNumber
        {
            get
            {
                return _regNumber;
            }
            set
            {
                _regNumber = value;
            }
        }

    }
    public enum Gender
    {
        Unknown=1,
        Male,
        Female,
        Transgender
    }
}
