using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Cats.Common;
using Cats.Services;
using Cats.Services.Interfaces;
using Cats.Domain;
using System.Collections.Generic;
using Cats.Domain.Enum;

namespace Cats
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddConfigServices()
                .AddCommonServices()
                .AddServices()
                .BuildServiceProvider();
                        
            var personService = serviceProvider.GetService<IPersonService>();
            
            Console.WriteLine("Getting People data from the service...");
            var result = await personService.GetPeopleAsync();
            Console.WriteLine("People data obtained.");

            if (!result.IsSuccess)
            {
                Console.WriteLine("Getting people failed");
                return;
            }

            //we got the data, we can use it however we want.
            Write(result.Value);
        }

        static void Write(IEnumerable<Person> people)
        {
            if (people == null)
                throw new ArgumentNullException("People is null");

            var genderData = people
                .GroupBy(person => person.Gender);

            foreach (var group in genderData)
            {
                Console.WriteLine(group.Key);
                foreach (var person in group
                    .AsEnumerable()
                    .Where(p => p.Pets != null))
                {
                    foreach (var pet in person.Pets
                        .Where(p => p.Type == PetType.Cat)
                        .OrderBy(p => p.Name))
                        Console.WriteLine($"- {pet.Name}");
                }
            }
        }
    }
}
