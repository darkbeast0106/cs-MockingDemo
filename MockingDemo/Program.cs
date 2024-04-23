using MockingDemo;

PersonService service = new PersonService("perople.json");
PersonStatistics statistics = new PersonStatistics(service);

Console.WriteLine("Átlag életkor: {0}", statistics.GetAverageAge());