namespace GitConfigManager;

using System;
using System.Diagnostics;

public class SignCommand : ICommand
{
    private readonly IUserRepository _userRepository;
    private readonly string _id;

    public SignCommand(IUserRepository userRepository, string id)
    {
        _userRepository = userRepository;
        _id = id;
    }

    public void Execute()
    {
        var user = _userRepository.GetUserById(_id);
        if (user == null)
        {
            Console.WriteLine($"User with ID {_id} not found.");
            return;
        }

        RunGitCommand($"git config --global user.name \"{user.Name}\"");
        RunGitCommand($"git config --global user.email \"{user.Email}\"");

        Console.WriteLine($"Signed as {user.Name} <{user.Email}>");
    }

    private void RunGitCommand(string command)
    {
        var processInfo = new ProcessStartInfo("bash", $"-c \"{command}\"")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = Process.Start(processInfo))
        {
            process.WaitForExit();
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(output))
                Console.WriteLine(output);
            if (!string.IsNullOrEmpty(error))
                Console.WriteLine($"Error: {error}");
        }
    }
}
