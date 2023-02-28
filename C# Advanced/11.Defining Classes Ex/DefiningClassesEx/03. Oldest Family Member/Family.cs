using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people = new List<Person>();
        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person person)
        {
            People.Add(person);
        }
        public void GetOldestMember()
        {
            int oldestAge = 0;
            string oldestName = "";
            foreach (var member in people)
            {
                if (member.Age > oldestAge)
                {
                    oldestAge = member.Age;
                    oldestName = member.Name;
                }
            }
            Console.WriteLine(oldestName + " " + oldestAge);
        }
    }
}
