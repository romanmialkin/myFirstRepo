using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace jsonWriter
{
    public enum PersonType
    {
        Client,
        Administrator,
        Specialist
    }


    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public PersonType PersonType { get; set; }

        protected Person(int id, string lastName,
            string name, PersonType personType)
        {
            PersonType = personType;
            Id = id;
            LastName = lastName;
            Name = name;
        }

        public static Person GetPersonById(int id, List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (id == person.Id)
                    return person;
            }
            return null;
        }
    }
}
