
using GitConfigManager;

if (args.Length == 0)
{
    Console.WriteLine("Usage: GM [command] [options]");
    return;
}

var databasePath = "users.db";
var userRepository = new SQLiteUserRepository(databasePath);
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