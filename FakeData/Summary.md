# Summary

Creating fake data is really useful for...

- Unit, Integration, Functional Tests
    - Generate stub data and then explicitly set mock data for the system-under-test (sut).
    - FakeFactories make sharing the setup and creation of fakes easy.
    - [Fake vs. Stub vs. Mock.](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#lets-speak-the-same-language)
- Non-Production environments
    - Using a seed to generate the same data on non-persistent environments (like Dev)
    - Personas
        - Rusty Pipes created by Mike Allison for SOCMS.

Fake data library focus - [Bogus](https://github.com/bchavez/Bogus)

- Alternatives - `Tynamix.ObjectFiller`, `AutoFixture`
    - Each has their pluses and minuses
- Bogus is the only one that has the ability to create real-ish objects using fluent rule builder and have the properties be contextually related
    - Example: FirstName & LastName with FullName being derived from those two properties.
- Combine with the `AutoBogus` library for faster stubs without explicitly setting rules.
- `Bogus` has lots of API's that generate real-ish data so you don't have to:
   - Person
   - Address
   - Vehicle
   - Randomizer
       - Number
       - String
    - Date
    - [And on and on...](https://github.com/bchavez/Bogus#bogus-api-support)

        
    
