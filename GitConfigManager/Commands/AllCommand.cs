namespace GitConfigManager.Commands;

using System;
using System.Linq;

public class AllCommand : ICommand
{
    private readonly IUserRepository _userRepository;

    public AllCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute()
    {
        var users = _userRepository.GetAllUsers().ToList();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }

        Console.WriteLine("Registered users:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
        }
    }
}
