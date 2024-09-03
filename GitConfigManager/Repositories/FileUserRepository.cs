using GitConfigManager.Models;

namespace GitConfigManager;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileUserRepository : IUserRepository
{
    private readonly string _filePath;

    public FileUserRepository(string filePath)
    {
        _filePath = filePath;
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Dispose();
        }
    }

    public UserConfig GetUserById(string id)
    {
        var users = GetAllUsers();
        return users.FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(UserConfig user)
    {
        var users = GetAllUsers().ToList();
        users.Add(user);
        SaveUsers(users);
    }

    public void RemoveUser(string id)
    {
        var users = GetAllUsers().Where(u => u.Id != id).ToList();
        SaveUsers(users);
    }

    public IEnumerable<UserConfig> GetAllUsers()
    {
        var lines = File.ReadAllLines(_filePath);
        return lines.Select(line =>
        {
            var parts = line.Split(':');
            return new UserConfig(parts[0], parts[1], parts[2]);
        });
    }

    private void SaveUsers(IEnumerable<UserConfig> users)
    {
        var lines = users.Select(u => $"{u.Id}:{u.Name}:{u.Email}");
        File.WriteAllLines(_filePath, lines);
    }
}
