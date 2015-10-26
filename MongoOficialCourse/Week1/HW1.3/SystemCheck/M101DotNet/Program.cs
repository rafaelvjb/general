using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M101DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait(); //alterado no update
            //MainAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();
            Console.WriteLine("PressEnter");
            Console.ReadLine();
        }

        private static async Task MainAsync(string[] args)
        {

            /* .Net mongo driver class...
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");
            */


            /* .net Driver document representation   
            var doc = new BsonDocument { { "name", "Jones" } };

            doc.Add("age", 30);

            doc["profession"] = "hacker";

            var nestedArray = new BsonArray();
            nestedArray.Add(new BsonDocument("black", "red"));
            doc.Add("array", nestedArray);

            Console.WriteLine(doc);
            var doc = new BsonDocument { { "name", "Jones" } };
            */

            /* .Net Driver Poco representation 

            var conventionPack = new ConventionPack();
            conventionPack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camelCase",  conventionPack, t => true); // true is all the apply

            // comentado pois o conventiopack faz isso de maneira geral ou conforme funcao definida
            //BsonClassMap.RegisterClassMap<Person>(cm =>
            //{
            //    cm.AutoMap();
            //    cm.MapMember(x => x.Name).SetElementName("name");
            //});


            var person = new Person
            {
                Name = "Jones",
                Age = 30,
                Colors = new List<string>() { "red", "blue" },
                Pets = new List<Pet> { new Pet { Name = "pets21", Type = "dog" } },
                ExtraElements = new BsonDocument("anotherElement", "anotherValue")
            };

            using (var writer = new JsonWriter(Console.Out))
            {
                BsonSerializer.Serialize(writer, person);
            }

            */

            /*.net inserrtOne
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            //var coll = db.GetCollection<BsonDocument>("people");
            var coll = db.GetCollection<Person>("people");

            //var doc = new BsonDocument
            //{
            //    {"Name", "Smith" },
            //    {"Age", 30 },
            //    {"PRofession", "Hacker" }
            //};

            //var doc2 = new BsonDocument
            //{
            //    {"SomethingElse", true }
            //};
            ////await coll.InsertOneAsync(doc);
            //await coll.InsertManyAsync(new[] { doc, doc2 });

            var doc = new Person
            {
                Name = "Jones",
                Age = 32,
                Profession = "Hacker"
            };

            await coll.InsertOneAsync(doc);
            */


            /*  .net Driver, FInd  
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<BsonDocument>("people");

            var doc = new BsonDocument
            {
                {"Name", "Smith" },
                {"Age", 30 },
                {"PRofession", "Hacker" }
            };
            await coll.InsertOneAsync(doc);


            // to view the documents

            using (var cursor = await coll.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach(var document in cursor.Current)
                    {
                        Console.WriteLine(document);
                    }
                }
            }

            // or 

            var list = await coll.Find(new BsonDocument()).ToListAsync();
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            // or

            await coll.Find(new BsonDocument())
                .ForEachAsync(docs => Console.WriteLine(docs));

            */

            /* Find with filters and with generic type bsondocument
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<BsonDocument>("people");

            //var filter = new BsonDocument("Name", "Smith" );
            //var filter = new BsonDocument("Age", new BsonDocument("$lt", 30));
            //var filter = new BsonDocument("$and", new BsonArray{ 
            //    new BsonDocument("Age", new BsonDocument("$lt", 30)),
            //    new BsonDocument("Name", "Smith")
            //});

            //criou um gerador de filtros do tipo BsonDocument
            var builder = Builders<BsonDocument>.Filter;
            //utilizou o gerador de filtros para especificar um $lt
            //var filter = builder.Lt("Age", 30);
            //var filter = builder.And(builder.Lt("Age", 30),
            //                         builder.Eq("Name", "Jones"));
            //var filter = builder.Lt("Age", 30) & builder.Eq("Name", "Jones");
            var filter = builder.Lt("Age", 30) & !builder.Eq("Name", "Jones");

            var list = await coll.Find(filter).ToListAsync();
            // poderia ser feito também : 
            //var list = await coll.Find("{ Name : 'Smith' }").ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */

            /* Find with filters and using classes 

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<Person>("people");

            //criou um gerador de filtros do tipo BsonDocument
            var builder = Builders<Person>.Filter;
            var filter = builder.Lt(p => p.Age, 30) & !builder.Eq(p => p.Name, "Jones");

            var list = await coll.Find(filter).ToListAsync();

            // or 
            list = await coll.Find(x => x.Age < 30 & x.Name != "Jones")
                                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */


            /* Find with Skip, Limit and Sort using generic object


            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<BsonDocument>("people");

            var list = await coll.Find(new BsonDocument())
                // método Sort -> ordena o resultado pela prop. "Age"
                //.Sort("{Age:1}")
                //.Sort(new BsonDocument("Age", 1))
                .Sort(Builders<BsonDocument>.Sort.Ascending("Age") )
                .Skip(1) // pula o primeiro resultado 
                .Limit(10) //retorna um limite re 10 registros
                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            } */

            /* Find with Skip, Limit and Sort using classes

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<Person>("people");

            var list = await coll.Find(new BsonDocument())
                //.Sort(Builders<Person>.Sort.Ascending(x => x.Age))
                .SortBy(p => p.Age)
                .ThenByDescending( p => p.Name)
                .Skip(1) // pula o primeiro resultado 
                .Limit(10) //retorna um limite re 10 registros
                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */
            /* Find with Projections

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<Person>("people");

            var list = await coll.Find(new BsonDocument())
                //.Project(Builders<Person>.Projection.Include(p => p.Name).Exclude(p => p.Id))
                //.Project(p => p.Name ) // retorna apenas os nomes dentro de um array, sem identificar propriedade, 
                .Project(p => new { p.Name, CalcAge = p.Age + 20 }  )
                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */
            /* UpdateOne and UpdateMany

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll =  db.GetCollection<BsonDocument>("widgets");

            await db.DropCollectionAsync("widgets");
            var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("_id", i).Add("x", i));
            await coll.InsertManyAsync(docs);

            //var result = await coll.ReplaceOneAsync(
            //    new BsonDocument("_id", 5),
            //    new BsonDocument("_id", 5).Add("x" , 30));
            // the replace statement doesn't work with equals id 

            //var result = await coll.ReplaceOneAsync(
            //    new BsonDocument("_id", 5),
            //    new BsonDocument("_id", 5).Add("x", 30),
            //    new UpdateOptions(IsUpsert = true));
            //// the replace statement doesn't work with equals id 

            //var result = await coll.UpdateOneAsync(
            //    Builders<BsonDocument>.Filter.Eq("range" , 10),
            //    new BsonDocument("$inc", new BsonDocument("x", 30))
            //);



            var widget = db.GetCollection<Widgets>("widgets");
            var result = await widget.UpdateOneAsync(
                //Builders<Widgets>.Filter.Eq("range", 10),
                x => x.X > 5,
                Builders<Widgets>.Update.Inc(x => x.X, 10)
                .Set("Sobrenome",  "J")
            );


            await coll.Find(new BsonDocument())
                .ForEachAsync(p => Console.WriteLine(p));
                */

            /* delete

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<Widgets>("widgets");
            await db.DropCollectionAsync("widgets");

            var docs = Enumerable.Range(0, 10).Select(i => new Widgets() { Id = i, X = i });
            await coll.InsertManyAsync(docs);

            var result = await coll.DeleteManyAsync(w => w.X > 5);

            await coll.Find(new BsonDocument())
                .ForEachAsync(element => Console.WriteLine(element));
            */

            /* FindOneAndUpdate , FindOneAndReplace, FindOneAndDelete

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<Widgets>("widgets");
            await db.DropCollectionAsync("widgets");

            var docs = Enumerable.Range(0, 10).Select(i => new Widgets() { Id = i, X = i });
            await coll.InsertManyAsync(docs);

            //var result = await coll.FindOneAndUpdateAsync(
            //    w => w.X > 5,//filter
            //    Builders<Widgets>.Update.Inc(w => w.X, 10));

            //var result = await coll.FindOneAndUpdateAsync<Widgets>(
            //    w => w.X > 5,//filter
            //    Builders<Widgets>.Update.Inc(w => w.X, 10),
            //    new FindOneAndUpdateOptions<Widgets, Widgets>
            //    {
            //        ReturnDocument = ReturnDocument.After,
            //        Sort = Builders<Widgets>.Sort.Descending(w => w.X)
            //    }
            //    );

            //var result = await coll.FindOneAndReplaceAsync<Widgets>(
            //    w => w.X > 5,//filter
            //    new Widgets { Id = 22 , X = 22},
            //    new FindOneAndReplaceOptions<Widgets, Widgets>
            //    {
            //        ReturnDocument = ReturnDocument.After,
            //        Sort = Builders<Widgets>.Sort.Descending(w => w.X)
            //    }
            //    );

            //var result = await coll.FindOneAndDeleteAsync<Widgets>(
            //    w => w.X > 5,//filter
            //    new FindOneAndDeleteOptions<Widgets, Widgets>
            //    {
            //        Sort = Builders<Widgets>.Sort.Descending(w => w.X)
            //    }
            //    );

            await coll.Find(new BsonDocument())
                .ForEachAsync(element => Console.WriteLine(element.ToBsonDocument()));
            */

            /* BulkWrite faz varias operações no banco de uma só vez
           
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var coll = db.GetCollection<BsonDocument>("widgets");
            await db.DropCollectionAsync("widgets");

            var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("_id" , i ).Add( "x" , i ));
            await coll.InsertManyAsync(docs);

            var result = coll.BulkWriteAsync(new WriteModel<BsonDocument>[]
            {
                new DeleteOneModel<BsonDocument>("{x:5}"),
                new DeleteOneModel<BsonDocument>("{x:7}"),
                new UpdateManyModel<BsonDocument>("{x:{$lt: 7}}" , "{$inc:{x: 10}}"),

            }
            );

            await coll.Find(new BsonDocument())
               .ForEachAsync(element => Console.WriteLine(element.ToBsonDocument()));
 
            
            
            */
            //query de exemplo do HW 2.1
            //db.grades.aggregate({
            //    '$group': { '_id': '$student_id', 'average': { $avg: '$score' }  }}  
            //    , {'$sort' : {'average':-1 } }  
            //    , {'$limit' :1 });
            // resultado { "_id" : 164, "average" : 89.29771818263372 }



            //HW 2.2
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("students");

            //var coll = db.GetCollection<Grades>("grades");

            var coll = db.GetCollection<BsonDocument>("grades");
            //await db.DropCollectionAsync("grades");
            //Console.WriteLine("db drop....");
            //return;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Lte("score", 65) & builder.Eq("type", "exam");


            //Sort(new BsonDocument("Age", 1)
            //var builder1 = Builders<BsonDocument>.Filter;
            //var filter1 = builder1.Lte("score", 65) ;
            //Console.WriteLine("total:" + coll.CountAsync(new BsonDocument()).ToJson());
            //Console.ReadKey();

            //await coll.Find(new BsonDocument())
            //   .ForEachAsync(element => Console.WriteLine(element.ToBsonDocument()));

            //var list = await coll.Find(new BsonDocument())
            //    //.Sort(Builders<Person>.Sort.Ascending(x => x.Age))
            //    .SortBy(p => p.Age)
            //    .ThenByDescending(p => p.Name)
            //    .Skip(1) // pula o primeiro resultado 
            //    .Limit(10) //retorna um limite re 10 registros
            //    .ToListAsync();

            //var builder = Builders<Grades>.Filter;
            //var filter = builder.Lte(g => g.score, 65) & builder.Eq(g => g.type, "exam");
            var list = await coll.Find(new BsonDocument("type", "homework"))
                .Sort("{student_id : 1 , score: -1}")
                .ToListAsync();


            var last_student = string.Empty;
            var last_id = string.Empty;
            var last_obj = new BsonDocument();
            foreach (var student in list)
            {
                
                if (!string.IsNullOrEmpty(last_student))
                {
                    if (student[1].ToString() != last_student)
                    {
                        // remove o anterior
                        Console.WriteLine(String.Concat(last_student, " ", last_id));
                        await coll.FindOneAndDeleteAsync(last_obj);
                    }
                }
                last_obj = student;
                last_id = student[0].ToString();
                last_student = student[1].ToString();
            }
            await coll.FindOneAndDeleteAsync(last_obj);

            //var list = await coll.Find(new BsonDocument()).ToListAsync();
            //var list = await coll.Find("{type: 'exam', score : {$gte :65}}")
            //    .Sort(new BsonDocument("score", 1))
            //    .ToListAsync();

            await coll.Find(new BsonDocument())
                 .Sort("{'score' : -1 }")
                .Skip(100).Limit(1)
               .ForEachAsync(element => Console.WriteLine(element.ToBsonDocument()));

        }
    }


    class Grades
    {
        public ObjectId _id { get; set; }
        public string student_id { get; set; }
        public string type { get; set; }
        public double score { get; set; }
    }


    [BsonIgnoreExtraElements]
    class Widgets
    {
        public int Id { get; set; }
        public int X { get; set; }
    }


    class Person
    {
        public ObjectId Id { get; set; }
        // atributos feitos no construtor  [BsonElement("name")]
        public string Name { get; set; }
        //  [BsonRepresentation(BsonType.String)]
        public int Age { get; set; }
        public List<string> Colors { get; set; }
        public List<Pet> Pets { get; set; }
        public BsonDocument ExtraElements { get; set; }
        public string Profession { get; set; }

    }

    class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
