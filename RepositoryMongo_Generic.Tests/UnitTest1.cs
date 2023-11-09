namespace RepositoryMongo_Generic.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_for_How_To_Use()
        {
            MongoDbSettings mongoDbSettings = new MongoDbSettings();
                                                         //user:pw@host
            mongoDbSettings.ConnectionString = "mongodb://root:1234@localhost:27017";
            mongoDbSettings.DatabaseName = "mongodb";

            MongoRepository<Person> _peopleRepository = new MongoRepository<Person>(mongoDbSettings);

            var person = new Person()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            _peopleRepository.InsertOneAsync(person);




            //
            var people = _peopleRepository.FilterBy(
           filter => filter.FirstName != "test",
           projection => projection.FirstName
            );

            var test = _peopleRepository.FindOne(p => p.FirstName == person.FirstName);

            Assert.NotNull(people);
            Assert.NotNull(test);
            
        }
    }

    [BsonCollection("people")]
    public class Person : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}