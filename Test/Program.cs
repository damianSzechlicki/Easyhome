using EasyHome.Data;
using EasyHome.Data.Repositories;
using EasyHome.Shared;
using EasyHome.Shared.MSF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var pathCharacter = @"C:\Users\dszechlicki\source\Workspace\Easyhome\Test\Files\Characters.csv";
            var pathTeam = @"C:\Users\dszechlicki\source\Workspace\Easyhome\Test\Files\Team.csv";

            await CreateCharacterFile(pathCharacter);
            await CreateTeamFile(pathTeam);
        }

        public static async Task CreateTeamFile(string path)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyHomeDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Easyhome;Trusted_Connection=True;MultipleActiveResultSets=true");
            var dbContext = new EasyHomeDbContext(optionsBuilder.Options);


            var characterRepository = new MSFTeamRepository(dbContext);
            var characters = await characterRepository.GetAll();
            var text = ToCsv<MSFTeam>(";", characters);

            using (var reader = new StreamWriter(path, false))
            {
                reader.Write(text);
            }
        }

        public static async Task CreateCharacterFile(string path)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyHomeDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Easyhome;Trusted_Connection=True;MultipleActiveResultSets=true");
            var dbContext = new EasyHomeDbContext(optionsBuilder.Options);


            var characterRepository = new MSFCharacterRepository(dbContext);
            var characters = await characterRepository.GetAll();
            var text = ToCsv<MSFCharacter>(";", characters);

            using (var reader = new StreamWriter(path, false))
            {
                reader.Write(text);
            }
        }

        public static string ToCsv<T>(string separator, IEnumerable<T> objectlist)
        {
            Type t = typeof(T);
            var fields = t.GetProperties();

            string header = String.Join(separator, fields.Select(f => f.Name).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
                csvdata.AppendLine(ToCsvFields(separator, fields, o));

            return csvdata.ToString();
        }

        public static string ToCsvFields(string separator, PropertyInfo[] fields, object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in fields)
            {
                if (linie.Length > 0)
                    linie.Append(separator);

                var x = f.GetValue(o);

                if (x != null)
                    linie.Append(x.ToString());
            }

            return linie.ToString();
        }

        public async Task ReadFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var optionsBuilder = new DbContextOptionsBuilder<EasyHomeDbContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Easyhome;Trusted_Connection=True;MultipleActiveResultSets=true");
                var dbContext = new EasyHomeDbContext(optionsBuilder.Options);


                var characterRepository = new MSFCharacterRepository(dbContext);
                var organizationRepository = new MSFCharacterOrganizationRepository(dbContext);
                var organizations = await organizationRepository.GetAll();

                var extraRepository = new MSFCharacterExtraRepository(dbContext);
                var extras = await extraRepository.GetAll();
                var characters = new List<MSFCharacter>();

                var rows = new List<List<string>>();
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine().Split(';').ToList());
                }
                for (int i = 1; i < rows.Count(); i++)
                {
                    var row = rows[i];

                    //Name;Power;Level;Star;Red Star;RS > S;Team number;Tier;Side ;Trait;Origin;Role;Team;Flavor;Basic;Special;Ulttimate;Passive
                    var character = new MSFCharacter
                    {
                        Name = row[0],
                        Power = string.IsNullOrEmpty(row[1]) ? 0 : Int32.Parse(row[1]),
                        Level = string.IsNullOrEmpty(row[2]) ? 0 : Int32.Parse(row[2]),
                        Star = string.IsNullOrEmpty(row[3]) ? 0 : Int32.Parse(row[3]),
                        RedStar = string.IsNullOrEmpty(row[4]) ? 0 : Int32.Parse(row[4]),
                        TeamID = string.IsNullOrEmpty(row[6]) ? 0 : Int32.Parse(row[6]),
                        Tier = Int32.Parse(row[7]),
                        Allegiance = Enum.Parse<MSFAllegiance>(row[8]),
                        Jurisdiction = Enum.Parse<MSFJurisdiction>(row[9]),
                        Origin = Enum.Parse<MSFOrigin>(row[10]),
                        Class = Enum.Parse<MSFCharacterClass>(row[11]),
                        Organizations = row[12],
                        Extras = row[13],
                        BasicSkill = Int32.Parse(row[14]),
                        SpecialSkill = Int32.Parse(row[15]),
                        PassiveSkill = Int32.Parse(row[17]),
                    };

                    if (string.IsNullOrEmpty(row[16]))
                    {
                        character.UltimateSkill = null;
                    }
                    else
                    {
                        character.UltimateSkill = Int32.Parse(row[16]);
                    }

                    character.Available = character.Level > 0;

                    var tmpOrganizations = character.Organizations.Split(',');

                    foreach (var item in tmpOrganizations)
                    {
                        if (!organizations.Any(o => o.Name == item.Trim()) && item != "")
                        {
                            Console.WriteLine(item);
                            var order = Console.ReadLine();

                            if (order == "y")
                            {
                                await organizationRepository.Create(new MSFCharacterOrganization
                                {
                                    Name = item.Trim(),
                                });
                            }
                        }
                    }

                    var tmpExtra = character.Extras.Split(',');

                    foreach (var item in tmpExtra)
                    {
                        if (!extras.Any(o => o.Name == item.Trim()) && item != "")
                        {

                        }
                    }

                    characters.Add(character);
                }

                foreach (var character in characters.OrderBy(x => x.Name))
                {
                    await characterRepository.Create(character);
                }
            }
        }
    }
}
