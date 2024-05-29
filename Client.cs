using System.Security.Cryptography;

namespace LAB8;

public class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Client(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}