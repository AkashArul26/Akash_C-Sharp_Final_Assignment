using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDetails
{
    public class VaccineDetail
    {
        public long Registernum { get; set; }
        public Vaccine Vaccine { get; set; }
        public DateTime Date { get; set; }
        public int Dosage { get; set; }
    }
    public enum Vaccine
    {
        CovidShield=1,
        Covaccine,
        Sputnik
    }
}
