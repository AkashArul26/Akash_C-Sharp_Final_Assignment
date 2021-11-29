using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeneficiaryDetails;
using VaccineDetails;

namespace ConsoleUI
{
    class Program
    {
        private static int getgender,getvaccine;
        private static long regNumber= 1000;
        private static Dictionary<long, Details> details = new Dictionary<long, Details>();
        private static List<VaccineDetail> vacDetail = new List<VaccineDetail>();
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter the required option: \n1.Beneficiary Registration \n2.Vaccination Menu\n3.Exit");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        BenificiaryRegistration();
                        break;
                    case 2:
                        Vaccination();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Enter a valid option.");
                        break;
                }
                do
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    Console.Write("Go to Main Menu (yes / no) : ");
                    choice = Console.ReadLine().ToLower();
                    if (choice != "yes" && choice != "no")
                    {
                        Console.WriteLine("Enter a valid option.");
                    }
                } while (choice != "yes" && choice != "no");
            } while (choice == "yes");
        }
        private static void BenificiaryRegistration()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("BENEFICIARY REGISTRATION");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            int i = 0;
            while(i<1)
            {
                regNumber = regNumber + 1;
                i++;
            }
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Phone Number : ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter the Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the Address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the Gender :\n1.Unknown\n2.Male\n3.Female\n4.Transgender");
            getgender = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your Register Number is {regNumber}");
            Details Detail = new Details()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Age = age,
                Address=address,
                Gender = (Gender)getgender,
                RegNumber = regNumber,
            };
            details.Add(regNumber, Detail);
        }
        private static int flag = 0;
        private static void Vaccination()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("BENEFICIARY VACCINATION");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.Write("Enter the Register Number : ");
            long regnumber = long.Parse(Console.ReadLine());
            string choice;
            
            foreach(KeyValuePair<long,Details> kvp in details)
            {
                if (regnumber == kvp.Value.RegNumber && kvp.Value.Age < 18)
                {
                    Console.WriteLine("Under Age!");
                    flag = 1;
                    break;
                }
                if (regnumber == kvp.Value.RegNumber)
                {
                    do
                    {
                        Console.WriteLine("Enter your choice:\n1.Take Vaccine\n2.Vaccination History\n3.Next Due Date\n4.Exit");
                        int option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                DateTime date = new DateTime();
                                if (kvp.Value.Dosage == 0)
                                {
                                    Console.WriteLine("Enter the Vaccine : \n1.COVID SHIELD\n2.COVACCINE\n3.SPUTNIK");
                                    getvaccine = int.Parse(Console.ReadLine());
                                    date = DateTime.Now;
                                    kvp.Value.Dosage = kvp.Value.Dosage + 1;
                                    kvp.Value.Vaccine = (Vaccine)getvaccine;
                                    VaccineDetail VacDetail = new VaccineDetail()
                                    {
                                        Vaccine = (Vaccine)getvaccine,
                                        Date = date,
                                        Dosage = kvp.Value.Dosage,
                                        Registernum = kvp.Key
                                    };
                                    vacDetail.Add(VacDetail);
                                    Console.WriteLine("You have completed the 1st Dose");
                                    flag = 1;
                                    break;
                                }
                                else if (kvp.Value.Dosage == 1)
                                {
                                    if (kvp.Value.Vaccine == (Vaccine)1)
                                    {
                                        kvp.Value.Dosage = kvp.Value.Dosage + 1;
                                        date = DateTime.Now;
                                        VaccineDetail VacDetail = new VaccineDetail()
                                        {
                                            Vaccine = (Vaccine)1,
                                            Date = date,
                                            Dosage = kvp.Value.Dosage,
                                            Registernum = kvp.Key
                                        };
                                        vacDetail.Add(VacDetail);
                                        Console.WriteLine("You have completed the 2nd Dose");
                                        flag = 1;
                                        break;
                                    }
                                    if (kvp.Value.Vaccine == (Vaccine)2)
                                    {
                                        kvp.Value.Dosage = kvp.Value.Dosage + 1;
                                        date = DateTime.Now;
                                        VaccineDetail VacDetail = new VaccineDetail()
                                        {
                                            Vaccine = (Vaccine)2,
                                            Date = date,
                                            Dosage = kvp.Value.Dosage,
                                            Registernum = kvp.Key
                                        };
                                        vacDetail.Add(VacDetail);
                                        Console.WriteLine("You have completed the 2nd Dose");
                                        flag = 1;
                                        break;
                                    }
                                    if (kvp.Value.Vaccine == (Vaccine)3)
                                    {
                                        kvp.Value.Dosage = kvp.Value.Dosage + 1;
                                        date = DateTime.Now;
                                        VaccineDetail VacDetail = new VaccineDetail()
                                        {
                                            Vaccine = (Vaccine)3,
                                            Date = date,
                                            Dosage = kvp.Value.Dosage,
                                            Registernum = kvp.Key
                                        };
                                        vacDetail.Add(VacDetail);
                                        Console.WriteLine("You have completed the 2nd Dose");
                                        flag = 1;
                                        break;
                                    }
                                }
                                break;
                            case 2:
                                VaccinationHistory(kvp.Key);
                                break;
                            case 3:
                                NextDue(kvp.Key);
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("Enter a valid option");
                                break;
                        }
                        do
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------------");
                            Console.WriteLine("Go to Vaccination Menu (yes / no) : ");
                            choice = Console.ReadLine();
                            if (choice != "yes" && choice != "no")
                            {
                                Console.WriteLine("Enter a valid option.");
                            }
                        } while (choice != "yes" && choice != "no");
                    } while (choice == "yes");
                }
            }
        }
        private static string GetGender()
        {
            switch(getgender)
            {
                case 1:
                    return "Unknown";
                case 2:
                    return "Male";
                case 3:
                    return "Female";
                case 4:
                    return "Transgender";
                default:
                    return "Enter valid detail";
            }
        }
        private static string GetVaccine()
        {
            switch(getvaccine)
            {
                case 1:
                    return "Covid Shield";
                case 2:
                    return "Covaccine";
                case 3:
                    return "sputnik";
                default:
                    return "vaccine not available";
            }
        }
        private static void VaccinationHistory(long regnumber)
        {
            foreach (VaccineDetail i in vacDetail)
            {
                if (regnumber == i.Registernum)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{i.Registernum} \nDose : {i.Dosage} \nVaccine : {i.Vaccine} \nDate : {i.Date}");
                }
            }
        }
        private static void NextDue(long regnumber)
        {
            foreach (VaccineDetail i in vacDetail)
            {
                if (regnumber == i.Registernum)
                {
                    if (i.Dosage == 2)
                    {
                        Console.WriteLine("You have completeled the vaccination course.");
                        break;
                    }
                    else 
                    {
                        Console.WriteLine($"Due date for next vaccine : {i.Date.AddDays(30)}");
                    }
                    break;
                }
            }
        }
    }
}
