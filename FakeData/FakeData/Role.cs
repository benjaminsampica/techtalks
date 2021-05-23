using System.Collections.Generic;

namespace FakeData
{

    public record Role
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
