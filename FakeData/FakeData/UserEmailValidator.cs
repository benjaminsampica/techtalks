namespace FakeData
{
    public class UserEmailValidator
    {
        public static bool IsValidEmail(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Email);
        }
    }
}
