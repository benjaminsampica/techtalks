using AutoBogus;
using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeData
{
    public class SeedDataService
    {
        public async Task<IEnumerable<User>> SeedAsync()
        {
            // Set a static seed to get the same data every time. Great for seeding random data for development environments.
            // Personas!
            Randomizer.Seed = new Random(123123);

            var users = AutoFaker.Generate<User>(5);

            // Save to database, etc.

            return users;
        }
    }
}
