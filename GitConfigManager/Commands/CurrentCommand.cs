namespace GitConfigManager.Models;

using System;
using System.Diagnostics;

public class CurrentCommand : ICommand
{
    public void Execute()
    {
        var currentName = RunGitCommand("git config --global user.name");
        var currentEmail = RunGitCommand("git config --global user.email");

        Console.WriteLine($"Current Git User:");
        Console.WriteLine($"Name: {currentName}");
        Console.WriteLine($"Email: {currentEmail}");
    }

    private string RunGitCommand(string command)
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

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Error: {error}");
                return string.Empty;
            }

            return output.Trim();
        }
    }
}
