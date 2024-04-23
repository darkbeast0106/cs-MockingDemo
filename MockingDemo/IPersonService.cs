
namespace MockingDemo
{
    public interface IPersonService
    {
        void AddPerson(Person person);
        void DeletePerson(int id);
        List<Person> GetAllPeople();
        void UpdatePerson(Person updatedPerson);
    }
}