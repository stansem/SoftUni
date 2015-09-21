using System;
using System.Collections.Generic;

class PhoneBook
{
    static Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();

    static void Main()
    {
        Input();
        ExecuteCommands();
    }

    static void Input()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string name = line.Split('-')[0];
            string phone = line.Split('-')[1];

            if (!phonebook.ContainsKey(name))
            {
                phonebook.Add(name, new List<string>());
            }
            phonebook[name].Add(phone);
        }
    }

    static void ExecuteCommands()
    {
        string line;
        while((line = Console.ReadLine()) != "END")
        {
            if(phonebook.ContainsKey(line))
            {
                Console.WriteLine("{0} -> {1}", line, string.Join("; ", phonebook[line]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", line);
            }
        }
    }
}
