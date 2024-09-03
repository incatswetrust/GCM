using GitConfigManager.Commands;
using GitConfigManager.Models;
namespace GitConfigManager;

public class CommandFactory
{
    private readonly IUserRepository _userRepository;

    public CommandFactory(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ICommand CreateCommand(string[] args)
    {
        if (args.Length == 0) throw new ArgumentException("No command specified.");

        var command = args[0];
        switch (command)
        {
            case "sign":
                if (args.Length < 2) throw new ArgumentException("ID is required for sign command.");
                return new SignCommand(_userRepository, args[1]);
            case "add":
                if (args.Length < 4) throw new ArgumentException("ID, Name, and Email are required for add command.");
                return new AddCommand(_userRepository, args[1], args[2], args[3]);
            case "remove":
                if (args.Length < 2) throw new ArgumentException("ID is required for remove command.");
                return new RemoveCommand(_userRepository, args[1]);
            case "current":
                return new CurrentCommand();
            case "all":
                return new AllCommand(_userRepository);
            default:
                throw new ArgumentException($"Unknown command: {command}");
        }
    }
}
