using GitConfigManager.Models;

namespace GitConfigManager;

public interface IUserRepository
{
    UserConfig GetUserById(string id);
    void AddUser(UserConfig user);
    void RemoveUser(string id);
    IEnumerable<UserConfig> GetAllUsers();
}
