namespace GitConfigManager.Models;

public class UserConfig
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserConfig(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
