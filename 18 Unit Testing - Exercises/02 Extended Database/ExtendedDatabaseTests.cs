namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] persons;
        [SetUp]
        public void Setup()
        {
            persons = new Person[]
            {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),
                new Person(16,"Ivan Ivan"),
            };
        }

        [Test]
        public void Test_ClassPersonNameAndID()
        {
            long expectID = 4445865458569444444;
            string expectUserName = "Valchan Balkanov";

            Person person = new Person(expectID, expectUserName);

            long actuallyID = person.Id;
            string actuallyUserName = person.UserName;
            Assert.AreEqual(expectID, actuallyID);
            Assert.AreEqual(expectUserName, actuallyUserName);

        }

        [Test]
        public void Test_ValidDatabaseEnrollmentThroughConstructor()
        {
            int expectCount = persons.Length;

            Database database = new Database(persons);
            int actuallyCount = database.Count;

            Assert.AreEqual(expectCount, actuallyCount);
        }
        [Test]
        public void Test_ArgumentExceptionArrayGreaterThan16()
        {
            persons = new Person[]
            {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),
                new Person(16,"Ivan Ivan"),
                new Person(16,"Ivan Ivan Ivan"),
            };
            Assert.Throws<ArgumentException>(() => new Database(persons), "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void Test_DataBaseCount()
        {

            int expectCount = persons.Length;

            Database database = new Database(persons);
            int actuallyCount = database.Count;

            Assert.AreEqual(expectCount, actuallyCount);

        }
        [Test]
        public void Test_AddNewPersonDatabase()
        {
            persons = new Person[]
         {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),
               
         };

            Database database = new Database(persons);

            var person = new Person(16, "Ivan Ivan");
            database.Add(person);

            var expectPerson = person;
            var actualPerson = database.FindByUsername(person.UserName);

            Assert.AreEqual(expectPerson, actualPerson);
        }
        [Test]
        public void Test_InvalidOperationExceptionArrayCapacity16()
        {
            persons = new Person[]
        {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),
                new Person(16,"Ivan Ivan")
        };

            Database database = new Database(persons);

            var person = new Person(17, "Ivan I Ivan");
            Assert.Throws<InvalidOperationException>(() => database.Add(person), "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Test_InvalidOperationExceptioExistingUsername()
        {
            persons = new Person[]
       {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),
               
       };

            Database database = new Database(persons);

            var person = new Person(17, "Ivan V");

            Assert.Throws<InvalidOperationException>(()=>database.Add(person), "There is already user with this username!");
        }
        [Test]
        public void Test_InvalidOperationExceptioExistingID()
        {
            persons = new Person[]
       {
                new Person(1,"Ivan"),
                new Person(2,"Ivan I"),
                new Person(3,"Ivan A"),
                new Person(4,"Ivan B"),
                new Person(5,"Ivan C"),
                new Person(6,"Ivan D"),
                new Person(7,"Ivan G"),
                new Person(8,"Ivan E"),
                new Person(9,"Ivan O"),
                new Person(10,"Ivan F"),
                new Person(11,"Ivan H"),
                new Person(12,"Ivan K"),
                new Person(13,"Ivan L"),
                new Person(14,"Ivan M"),
                new Person(15,"Ivan V"),

       };

            Database database = new Database(persons);

            var person = new Person(15, "Ivan Vo");

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "There is already user with this Id!");
        }
        [Test]
        public void Test_RemuvePersonDeleteLastPersonDatabase()
        {
            Database database= new Database(persons);
            database.Remove();
            int expectCount = persons.Length - 1;
            int actuallyCount = database.Count;

            Assert.AreEqual(expectCount, actuallyCount);

        }
        [Test]
        public void  Test_ReturnPersonByName()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            string name = expectPerson.UserName;
            Database database = new Database(expectPerson);
            Person actuallyPerson=database.FindByUsername(name);
            Assert.AreEqual(expectPerson, actuallyPerson);
             
        }
        [Test]
        public void Test_ArgumentNullExceptionReturnPersonByNameNull()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            string name = null;
            Database database = new Database(expectPerson);
            Assert.Throws<ArgumentNullException>(()=>database.FindByUsername(name), "Username parameter is null!");
        }
        [Test]
        public void Test_InvalidOperationExceptionSearchByNonexistentName()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            string name = "Ivan";
            Database database = new Database(expectPerson);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(name), "No user is present by this username!");
        }
        [Test]
        public void Test_ReturnPersonByID()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            long id = expectPerson.Id;
            Database database = new Database(expectPerson);
            Person actuallyPerson = database.FindById(id);
            Assert.AreEqual(expectPerson, actuallyPerson);

        }
        [Test]
        public void Test_ArgumentOutOfRangeExceptionReturnPersonByNegatyvID()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            long id = -253456;
            Database database = new Database(expectPerson);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id), "Id should be a positive number!");
        }
        [Test]
        public void Test_InvalidOperationExceptionReturnPersonByNonexistentID()
        {
            var expectPerson = new Person(16, "Ivan Ivan");
            long id = 253456;
            Database database = new Database(expectPerson);

            Assert.Throws<InvalidOperationException>(() => database.FindById(id), "No user is present by this ID!");
        }


    }
}