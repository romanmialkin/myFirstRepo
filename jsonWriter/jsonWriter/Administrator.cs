using System;
namespace jsonWriter
{
    public sealed class Administrator : Person
    {
        public int SubId { get; set; }
        public Administrator(int id, string lastName, string name, int subId,
            PersonType personType = PersonType.Administrator) : 
            base(id, lastName, name, personType)
        {
            SubId = subId;
        }
    }
}
