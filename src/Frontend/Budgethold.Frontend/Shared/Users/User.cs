namespace Budgethold.Frontend.Shared.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public long Expires { get; set; }
}
