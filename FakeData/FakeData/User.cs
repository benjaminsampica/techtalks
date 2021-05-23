namespace FakeData
{
    public record User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        // Bogus only recursively tranverses 2 deep (User -> Role -> Users). This can be customized.
        public Role Role { get; set; }
    }
}
