using Cats.Domain.Enum;
using System.Collections.Generic;

namespace Cats.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
