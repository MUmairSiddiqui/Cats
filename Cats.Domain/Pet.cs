using Cats.Domain.Enum;

namespace Cats.Domain
{
    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
    }
}
