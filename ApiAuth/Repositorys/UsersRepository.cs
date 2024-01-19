public class UserRepository
{
    public static User Get(string username, string password)
    {
        var users = new List<User> {
        new () { Id = 1, Username = "Satoro", Password = "senha123", Role = "Special" },
        new () { Id = 2, Username = "Itadori", Password = "123senha", Role = "B"}
        };

        return users.FirstOrDefault(x => x.Username == username 
        && x.Password == password);
    }
}
