using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingDemo
{
    public class PersonService : IPersonService
    {
        private readonly string _filePath;

        public PersonService(string filePath)
        {
            _filePath = filePath;
        }

        public List<Person> GetAllPeople()
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
                return people;
            }
        }

        public void AddPerson(Person person)
        {
            List<Person> people = GetAllPeople();
            int maxId = 0;
            foreach (var p in people)
            {
                if (p.Id > maxId)
                    maxId = p.Id;
            }
            person.Id = maxId + 1;
            people.Add(person);
            WritePeople(people);
        }

        private void WritePeople(List<Person> people)
        {
            string json = JsonConvert.SerializeObject(people, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.Write(json);
            }
        }

        public void UpdatePerson(Person updatedPerson)
        {
            List<Person> people = GetAllPeople();
            int index = people.FindIndex(p => p.Id == updatedPerson.Id);
            if (index == -1)
            {
                throw new InvalidOperationException("Person not found.");
            }
            people[index] = updatedPerson;
            WritePeople(people);
        }

        public void DeletePerson(int id)
        {
            List<Person> people = GetAllPeople();
            people.RemoveAll(p => p.Id == id);
            WritePeople(people);
        }
    }
}
