using System;
namespace jsonWriter
{
    public enum SpecialistType
    {
        Doctor,
        Diagnostician,
        Nurse
    }

    public class Specialist : Person
    {
        public int SubId { get; set; }
        public SpecialistType SpecialistType { get; set; }
        public string RoomNumber { get; set; }

        public Specialist(int id, string lastName,
            string name, int subId, SpecialistType specialistType, 
            string roomNumber, PersonType personType = PersonType.Specialist) 
            : base(id, lastName, name, personType)
        {
            SubId = subId;
            SpecialistType = specialistType;
            RoomNumber = roomNumber;
        }
        public override string ToString()
        {
            return $@"{Id} {SpecialistType} {LastName} {Name}";
        }

    }
}
