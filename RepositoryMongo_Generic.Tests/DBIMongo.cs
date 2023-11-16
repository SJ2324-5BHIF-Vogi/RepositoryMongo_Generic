using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMongo_Generic.Tests
{
    public class DBIMongo
    {
        [Fact]
        public async Task AddClass1Async()
        {
            MongoDbSettings mongoDbSettings = new MongoDbSettings();
            //user:pw@host
            mongoDbSettings.ConnectionString = "mongodb://root:1234@localhost:27017";
            mongoDbSettings.DatabaseName = "mongodb";

            MongoRepository<Class> _classRepository = new MongoRepository<Class>(mongoDbSettings);
            //_classRepository.DeleteManyAsync(c => c.Name.Equals("2021/22 5BHIF"));
            //Class1

            Class class1 = new Class();
            class1.Name = "2021/22 5BHIF";


            Pruefung p1 = new Pruefung();
            p1.Schueler = "Max Mustermann";
            
            Fach f1 = new Fach();
            f1.Diplomarbeit = new Diplomarbeit() { Lehrer = "GT" };
            f1.AngMath = new AngMath();
            f1.Deutsch = new Deutsch();
            f1.Englisch = new Englisch();
            f1.Fachtheorie = new Fachtheorie() {muedlich = false, fach = "POS1" };
            f1.Schwerpunktfach = new Schwerpunktfach() { muedlich = true, Fach = "DBI", Lehrer = "HIK" };
            f1.Wahlpunktfach = new Wahlpunktfach();
            
            p1.Fach = f1;

            Pruefung[] pa = new Pruefung[2];
            pa[0] = p1;
            //class1.Pruefung = pa1;
            
            //_classRepository.InsertOneAsync(class1);

            //Prüf2


            Pruefung p2 = new Pruefung();
            p2.Schueler = "David Ankenbrand";

            Fach f2 = new Fach();
            f2.Diplomarbeit = new Diplomarbeit() { Lehrer = "OM" };
            f2.AngMath = new AngMath();
            f2.Deutsch = new Deutsch();
            f2.Englisch = new Englisch();
            f2.Fachtheorie = new Fachtheorie() { Lehrer = "SRM", muedlich = false, fach = "POS1", Note = 5 };
            f2.Schwerpunktfach = new Schwerpunktfach() { muedlich = true, Fach = "SYP1", Lehrer = "HY" };
            f2.Wahlpunktfach = new Wahlpunktfach() { Fach = "NVS1", Lehrer = "CO", muedlich = true };

            p2.Fach = f2;

            pa[1] = p2;
            class1.Pruefung = pa;

            await _classRepository.InsertOneAsync(class1);




            var test = await _classRepository.FindOneAsync(c => c.Name.Equals("2021/22 5BHIF"));

            //Assert.NotNull(people);
            Assert.NotNull(test);


        }
    }

    [BsonCollection("class")]
    public class Class : Document
    {
        public string Name { get; set; }
        public Pruefung[] Pruefung { get; set; } 
    }

    public class Pruefung : Document
    {
        public string Schueler { get; set; }
        public Fach Fach { get; set; }
    }

    public class Fach : Document
    {
        public Diplomarbeit Diplomarbeit { get; set; }
        public AngMath AngMath { get; set; }
        public Englisch Englisch { get; set; }
        public Deutsch Deutsch { get; set; }
        public Fachtheorie Fachtheorie { get; set; }
        public Schwerpunktfach Schwerpunktfach { get; set; }
        public Wahlpunktfach Wahlpunktfach { get; set; }
    }
    public class Diplomarbeit : Document
    {
        public string Lehrer { get; set; }
    }

    public class AngMath : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Englisch : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Deutsch : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Fachtheorie : Document
    {
        public string Lehrer { get; set; }
        public string fach { get; set; }
        public int Note { get; set; }
        public bool muedlich { get; set; }

    }

    public class Schwerpunktfach : Document
    {
        public string Lehrer { get; set; }
        public string Fach { get; set; }
        public bool muedlich { get; set; }
    }

    public class Wahlpunktfach : Document
    {
        public string Lehrer { get; set; }
        public string Fach { get; set; }
        public bool muedlich { get; set; }
    }

}
