using MockingDemo;

PersonService service = new PersonService("people.json");
PersonStatistics statistics = new PersonStatistics(service);

Console.WriteLine("Átlag életkor: {0}", statistics.GetAverageAge());