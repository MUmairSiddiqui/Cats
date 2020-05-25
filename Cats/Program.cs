using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Cats.Common;
using Cats.Services;
using Cats.Domain;
using System.Collections.Generic;
using Cats.Domain.Enum;
using Cats.Domain.Services;

namespace Cats
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddConfigServices()
                .AddCommonServices()
                .AddServices()
                .AddLogging()
                .BuildServiceProvider();
                        
            var personService = serviceProvider.GetService<IPersonService>();
            
            Console.WriteLine("Getting People data from the service...");
            var result = personService.GetPeopleAsync()
                .GetAwaiter()
                .GetResult();
            Console.WriteLine("People data obtained.");
            Console.WriteLine("Writing pet names.");
            Console.WriteLine();

            if (!result.IsSuccess)
            {
                Console.WriteLine("Getting people failed. Press any key to exit");
                Console.ReadKey();
                return;
            }

            //we got the data, we can use it however we want.
            Write(result.Value);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void Write(IEnumerable<Person> people)
        {
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
