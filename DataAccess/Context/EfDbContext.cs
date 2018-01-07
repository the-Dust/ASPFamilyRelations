using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EfDbContext")
        {

        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<RelationName> RelationNames { get; set; }
    }

    public class EfDbInitializer : DropCreateDatabaseAlways<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            context.RelationNames.AddRange(new List<RelationName> {
                new RelationName { Name = "Муж/жена", MirrorName="Муж/жена" },
                new RelationName { Name = "Брат/сестра", MirrorName="Брат/сестра" },
                new RelationName { Name = "Отец/мать", MirrorName="Сын/дочь" },
                new RelationName { Name = "Сын/дочь", MirrorName="Отец/мать" },
                new RelationName { Name = "Дедушка/бабушка", MirrorName="Внук/внучка" },
                new RelationName { Name = "Внук/внучка", MirrorName="Дедушка/бабушка" }
            });

            context.SaveChanges();

            context.Persons.AddRange(new List<Person> {
                new Person { Name = "Иван", Patronymic = "Петрович", Surname = "Чижиков",
                    BirthDate = new DateTime(1970, 10, 10), Country = "Россия", City = "Самара", Street = "Ленина" },
                new Person { Name = "Варвара", Patronymic = "Леонидовна", Surname = "Чижикова",
                    BirthDate = new DateTime(1971, 11, 10), Country = "Россия", City = "Самара", Street = "Ленина" },
                new Person { Name = "Степан", Patronymic = "Иванович", Surname = "Чижиков",
                    BirthDate = new DateTime(1992, 02, 01), Country = "Россия", City = "Самара", Street = "Ленина" },
                new Person { Name = "Дарья", Patronymic = "Ивановна", Surname = "Чижикова",
                    BirthDate = new DateTime(1994, 03, 03), Country = "Россия", City = "Самара", Street = "Ленина" },
                new Person { Name = "Петр", Patronymic = "Кузмич", Surname = "Чижиков",
                    BirthDate = new DateTime(1930, 05, 10), Country = "Россия", City = "Самара", Street = "Промышленности" },
                new Person { Name = "Светлана", Patronymic = "Афанасьевна", Surname = "Чижикова",
                    BirthDate = new DateTime(1935, 10, 10), Country = "Россия", City = "Самара", Street = "Промышленности" },
                new Person { Name = "Леонид", Patronymic = "Дмитриевич", Surname = "Скворцов",
                    BirthDate = new DateTime(1933, 10, 10), Country = "Россия", City = "Самара", Street = "Демократическая" },
                new Person { Name = "Ирина", Patronymic = "Александровна", Surname = "Скворцова",
                    BirthDate = new DateTime(1934, 10, 10), Country = "Россия", City = "Самара", Street = "Демократическая" }
            });

            context.SaveChanges();

            context.Relations.AddRange(new List<Relation> {
                new Relation { SourceId = 1, TargetId = 2, RelationNameId = 1},
                new Relation { SourceId = 1, TargetId = 3, RelationNameId = 3},
                new Relation { SourceId = 1, TargetId = 4, RelationNameId = 3},
                new Relation { SourceId = 1, TargetId = 5, RelationNameId = 4},
                new Relation { SourceId = 1, TargetId = 6, RelationNameId = 4},

                new Relation { SourceId = 2, TargetId = 1, RelationNameId = 1},
                new Relation { SourceId = 2, TargetId = 3, RelationNameId = 3},
                new Relation { SourceId = 2, TargetId = 4, RelationNameId = 3},
                new Relation { SourceId = 2, TargetId = 7, RelationNameId = 4},
                new Relation { SourceId = 2, TargetId = 8, RelationNameId = 4},

                new Relation { SourceId = 3, TargetId = 1, RelationNameId = 4},
                new Relation { SourceId = 3, TargetId = 2, RelationNameId = 4},
                new Relation { SourceId = 3, TargetId = 4, RelationNameId = 2},
                new Relation { SourceId = 3, TargetId = 5, RelationNameId = 6},
                new Relation { SourceId = 3, TargetId = 6, RelationNameId = 6},
                new Relation { SourceId = 3, TargetId = 7, RelationNameId = 6},
                new Relation { SourceId = 3, TargetId = 8, RelationNameId = 6},

                new Relation { SourceId = 4, TargetId = 1, RelationNameId = 4},
                new Relation { SourceId = 4, TargetId = 2, RelationNameId = 4},
                new Relation { SourceId = 4, TargetId = 3, RelationNameId = 2},
                new Relation { SourceId = 4, TargetId = 5, RelationNameId = 6},
                new Relation { SourceId = 4, TargetId = 6, RelationNameId = 6},
                new Relation { SourceId = 4, TargetId = 7, RelationNameId = 6},
                new Relation { SourceId = 4, TargetId = 8, RelationNameId = 6},

                new Relation { SourceId = 5, TargetId = 1, RelationNameId = 3},
                new Relation { SourceId = 5, TargetId = 3, RelationNameId = 5},
                new Relation { SourceId = 5, TargetId = 4, RelationNameId = 5},
                new Relation { SourceId = 5, TargetId = 6, RelationNameId = 1},

                new Relation { SourceId = 6, TargetId = 1, RelationNameId = 3},
                new Relation { SourceId = 6, TargetId = 3, RelationNameId = 5},
                new Relation { SourceId = 6, TargetId = 4, RelationNameId = 5},
                new Relation { SourceId = 6, TargetId = 5, RelationNameId = 1},

                new Relation { SourceId = 7, TargetId = 2, RelationNameId = 3},
                new Relation { SourceId = 7, TargetId = 3, RelationNameId = 5},
                new Relation { SourceId = 7, TargetId = 4, RelationNameId = 5},
                new Relation { SourceId = 7, TargetId = 8, RelationNameId = 1},

                new Relation { SourceId = 8, TargetId = 2, RelationNameId = 3},
                new Relation { SourceId = 8, TargetId = 3, RelationNameId = 5},
                new Relation { SourceId = 8, TargetId = 4, RelationNameId = 5},
                new Relation { SourceId = 8, TargetId = 7, RelationNameId = 1}
            });

            context.SaveChanges();

        }
    }



}
