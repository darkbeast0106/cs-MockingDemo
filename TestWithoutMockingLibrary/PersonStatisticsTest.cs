using MockingDemo;

namespace TestWithoutMockingLibrary
{
    public class PersonStatisticsTest
    {

        private PersonServiceMock _mockPersonService;
        private PersonStatistics _personStatistics;

        private class PersonServiceMock : IPersonService
        {
            public PersonServiceMock() { }

            public void AddPerson(Person person)
            {
                throw new NotImplementedException();
            }

            public void DeletePerson(int id)
            {
                throw new NotImplementedException();
            }

            public List<Person> GetAllPeople()
            {
                return new List<Person>
                {
                    new Person { Id = 1, Name = "John", Age = 30 },
                    new Person { Id = 2, Name = "Jane", Age = 25 },
                    new Person { Id = 3, Name = "Alice", Age = 35 }
                };
            }

            public void UpdatePerson(Person updatedPerson)
            {
                throw new NotImplementedException();
            }
        }
        [SetUp]
        public void Setup()
        {
            _mockPersonService = new PersonServiceMock();
            _personStatistics = new PersonStatistics(_mockPersonService);
        }


        [Test]
        public void GetAverageAge_PeopleAvailable_CalculatesAverageAge()
        {
            double averageAge = _personStatistics.GetAverageAge();

            Assert.That(averageAge, Is.EqualTo(30.0));
        }
    }
}