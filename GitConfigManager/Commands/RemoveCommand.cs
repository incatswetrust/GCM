namespace GitConfigManager;

public class RemoveCommand : ICommand
{
    private readonly IUserRepository _userRepository;
    private readonly string _id;

    public RemoveCommand(IUserRepository userRepository, string id)
    {
        _userRepository = userRepository;
        _id = id;
    }

    public void Execute()
    {
        _userRepository.RemoveUser(_id);
        Console.WriteLine($"User with ID {_id} removed.");
    }
}
