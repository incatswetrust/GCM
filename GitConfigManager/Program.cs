
using GitConfigManager;

if (args.Length == 0)
{
    Console.WriteLine("Usage: GitConfigManager [command] [options]");
    return;
}

var filePath = "users.txt";
if (!File.Exists(filePath))
    File.Create(filePath);
var userRepository = new FileUserRepository(filePath);
var commandFactory = new CommandFactory(userRepository);

try
{
    var command = commandFactory.CreateCommand(args);
    command.Execute();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}