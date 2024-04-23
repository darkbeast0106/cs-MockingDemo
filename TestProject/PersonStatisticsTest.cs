using MockingDemo;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PersonStatisticsTest
    {
        private Mock<IPersonService> _mockPersonService;
        private PersonStatistics _personStatistics;

        [SetUp]
        public void Setup()
        {
            _mockPersonService = new Mock<IPersonService>();
            _personStatistics = new PersonStatistics(_mockPersonService.Object);
        }


        [Test]
        public void GetAverageAge_NoPeople_ReturnsZero()
        {
            // Arrange
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(new List<Person>());

            // Act
            double averageAge = _personStatistics.GetAverageAge();

            // Assert
            Assert.That(averageAge, Is.EqualTo(0));
        }

        [Test]
        public void GetAverageAge_PeopleAvailable_CalculatesAverageAge()
        {
            // Arrange
            List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "John", Age = 30 },
            new Person { Id = 2, Name = "Jane", Age = 25 },
            new Person { Id = 3, Name = "Alice", Age = 35 }
        };
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(people);

            // Act
            double averageAge = _personStatistics.GetAverageAge();

            // Assert
            Assert.That(averageAge, Is.EqualTo(30.0));
        }

        [Test]
        public void GetNumberOfStudents_NoStudents_ReturnsZero()
        {
            // Arrange
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(new List<Person>());

            // Act
            int numberOfStudents = _personStatistics.GetNumberOfStudents();

            // Assert
            Assert.That(numberOfStudents, Is.EqualTo(0));
        }

        [Test]
        public void GetNumberOfStudents_StudentsAvailable_CalculatesNumberOfStudents()
        {
            // Arrange
            List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "John", IsStudent = true },
            new Person { Id = 2, Name = "Jane", IsStudent = false },
            new Person { Id = 3, Name = "Alice", IsStudent = true }
        };
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(people);

            // Act
            int numberOfStudents = _personStatistics.GetNumberOfStudents();

            // Assert
            Assert.That(numberOfStudents, Is.EqualTo(2));
        }

        [Test]
        public void GetPersonWithHighestScore_NoPeople_ReturnsNull()
        {
            // Arrange
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(new List<Person>());

            // Act
            Person person = _personStatistics.GetPersonWithHighestScore();

            // Assert
            Assert.That(person, Is.Null);
        }

        [Test]
        public void GetPersonWithHighestScore_PeopleAvailable_ReturnsPersonWithHighestScore()
        {
            // Arrange
            List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "John", Score = 85 },
            new Person { Id = 2, Name = "Jane", Score = 92 },
            new Person { Id = 3, Name = "Alice", Score = 78 }
        };
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(people);

            // Act
            Person person = _personStatistics.GetPersonWithHighestScore();

            // Assert
            Assert.That(person, Is.Not.Null);
            Assert.That(person.Score, Is.EqualTo(92));
        }

        [Test]
        public void GetAverageScoreOfStudents_NoStudents_ReturnsZero()
        {
            // Arrange
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(new List<Person>());

            // Act
            double averageScore = _personStatistics.GetAverageScoreOfStudents();

            // Assert
            Assert.That(averageScore, Is.EqualTo(0));
        }

        [Test]
        public void GetAverageScoreOfStudents_StudentsAvailable_CalculatesAverageScore()
        {
            // Arrange
            List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "John", IsStudent = true, Score = 85 },
            new Person { Id = 2, Name = "Jane", IsStudent = false, Score = 92 },
            new Person { Id = 3, Name = "Alice", IsStudent = true, Score = 78 }
        };
            _mockPersonService.Setup(m => m.GetAllPeople()).Returns(people);

            // Act
            double averageScore = _personStatistics.GetAverageScoreOfStudents();

            // Assert
            Assert.That(averageScore, Is.EqualTo(81.5));
        }
    }
}
