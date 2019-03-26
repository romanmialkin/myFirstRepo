using System;
namespace jsonWriter
{
    public class Client : Person
    {
        public string InsuranceName { get; set; }
        public DateTime VisitDate { get; set; }
        public string CompanyName { get; set; }
        public string Rank { get; set; }
        public int SubId { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Client(int id, string lastName,
            string name, string insName, string compName, string rank,
            DateTime visDate, int subId, int age, DateTime birthDate,
            PersonType personType = PersonType.Client) : 
            base(id, lastName, name, personType)
        {
            InsuranceName = insName;
            CompanyName = compName;
            Rank = rank;
            SubId = subId;
            VisitDate = visDate;
            Age = age;
            DateOfBirth = birthDate;
        }
    }
}
