namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddRangeShouldThrowException()
        {
            Person[] people = new Person[17];
            Assert.Throws<ArgumentException>(() =>
            {
                var database = new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void ConstructorShouldCreateDatabase()
        {
            Person[] people = new Person[3];
            people[0] = new Person(0, "Ivan");
            people[1] = new Person(1, "Gosho");
            people[2] = new Person(2, "Pesho");

            var database = new Database(people);

            Type db = typeof(Database);
            FieldInfo databasePeople = db.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "persons");
            var databaseInst = Activator.CreateInstance(db, new object[] { people.ToArray() });
            Person[] rawlData = (Person[])databasePeople.GetValue(databaseInst);
            Person[] expectedData = people.ToArray();
            List<Person> actualData = rawlData.Where(p => p != null).ToList();
            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void AddShouldThrowExceptionForExistingUsername()
        {
            Person[] people = new Person[3];
            people[0] = new Person(0, "Ivan");
            people[1] = new Person(1, "Gosho");
            people[2] = new Person(2, "Pesho");
            Person personToAdd = new Person(12, "Ivan");
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToAdd);
            }, "There is already user with this username!");
        }
        [Test]
        public void AddShouldThrowExceptionForExistingID()
        {
            Person[] people = new Person[3];
            people[0] = new Person(0, "Ivan");
            people[1] = new Person(1, "Gosho");
            people[2] = new Person(2, "Pesho");
            Person personToAdd = new Person(1, "Mite");
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToAdd);
            }, "There is already user with this Id!");
        }
        [Test]
        public void AddShouldAddElementAtTheLastIndex()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            var database = new Database(people.ToArray());
            Person personToAdd = new Person(3, "Mite");
            database.Add(personToAdd);
            people.Add(personToAdd);
            Type db = typeof(Database);
            FieldInfo databasePeople = db.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "persons");
            var databaseInst = Activator.CreateInstance(db, new object[] { people.ToArray() });
            Person[] rawlData = (Person[])databasePeople.GetValue(databaseInst);
            Person[] expectedData = people.ToArray();
            List<Person> actualData = rawlData.Where(p=>p!=null).ToList();
            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void FindByUsernameShouldThrowNullArgumentException()
        {
            string name = "";
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            var database = new Database(people.ToArray());

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            }, "Username parameter is null!");
        }
        [Test]
        public void FindByUsernameShouldThrowInvalidOperationException()
        {
            string name = "Mite";
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            var database = new Database(people.ToArray());

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(name);
            }, "No user is present by this username!");
        }
        [Test]
        public void FindByUsernameShouldReturnPersonByGivenName()
        {
            string name = "Mite";
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            people.Add(new Person(3, "Mite"));
            var database = new Database(people.ToArray());

            Person foundPerson = database.FindByUsername(name);
            Assert.AreEqual(people[3], foundPerson);
        }
        [Test]
        public void FindByIdThrowInvalidOperationException()
        {
            long id = 3;
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            var database = new Database(people.ToArray());

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(id);
            }, "No user is present by this ID!");
        }
        [Test]
        public void FindByIdThrowArgumentOutOfRangeException()
        {
            long id = -3;
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            var database = new Database(people.ToArray());

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            }, "Id should be a positive number!");
        }
        [Test]
        public void FindByIDhouldReturnPersonByGivenId()
        {
            long id = 3;
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            people.Add(new Person(3, "Mite"));
            var database = new Database(people.ToArray());

            Person foundPerson = database.FindById(id);
            Assert.AreEqual(people[3], foundPerson);
        }
        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowException()
        {
            Person[] people = new Person[0];
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void RemoveShouldRemoveTheLasrElement()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(0, "Ivan"));
            people.Add(new Person(1, "Gosho"));
            people.Add(new Person(2, "Pesho"));
            people.Add(new Person(3, "Mite"));
            var database = new Database(people.ToArray());
            people.RemoveAt(people.Count - 1);
            database.Remove();

            Type db = typeof(Database);
            FieldInfo databasePeople = db.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == "persons");
            var databaseInst = Activator.CreateInstance(db, new object[] { people.ToArray() });
            Person[] rawlData = (Person[])databasePeople.GetValue(databaseInst);
            Person[] expectedData = people.ToArray();
            List<Person> actualData = new List<Person>();
            for (int i = 0; i < expectedData.Length; i++)
            {
                actualData.Add(rawlData[i]);
            }
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}