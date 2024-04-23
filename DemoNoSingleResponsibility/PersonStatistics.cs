using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNoSOLID
{
    public class PersonStatistics
    {
        private List<Person> GetAllPeople()
        {
            using (StreamReader reader = new StreamReader("people.json"))
            {
                string json = reader.ReadToEnd();
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
                return people;
            }
        }

        public double GetAverageAge()
        {
            List<Person> people = this.GetAllPeople();
            if (people.Count == 0)
                return 0;

            double totalAge = people.Sum(p => p.Age);
            return totalAge / people.Count;
        }

        public int GetNumberOfStudents()
        {
            List<Person> people = this.GetAllPeople();
            return people.Count(p => p.IsStudent);
        }

        public Person GetPersonWithHighestScore()
        {
            List<Person> people = this.GetAllPeople();
            if (people.Count == 0)
                return null;

            return people.OrderByDescending(p => p.Score).FirstOrDefault();
        }

        public double GetAverageScoreOfStudents()
        {
            List<Person> people = this.GetAllPeople();
            if (people.Count == 0)
                return 0;

            List<Person> students = people.Where(p => p.IsStudent).ToList();
            if (students.Count == 0)
                return 0;

            double totalScore = students.Sum(p => p.Score);
            return totalScore / students.Count;
        }
    }
}
