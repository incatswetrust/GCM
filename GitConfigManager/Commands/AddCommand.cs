using GitConfigManager.Models;

namespace GitConfigManager;

public class AddCommand : ICommand
{
    private readonly IUserRepository _userRepository;
    private readonly string _id;
    private readonly string _name;
    private readonly string _email;

    public AddCommand(IUserRepository userRepository, string id, string name, string email)
    {
        _userRepository = userRepository;
        _id = id;
        _name = name;
        _email = email;
    }

    public void Execute()
    {
        var user = new UserConfig(_id, _name, _email);
        _userRepository.AddUser(user);
        Console.WriteLine($"User {_name} <{_email}> added with ID {_id}.");
    }
}
