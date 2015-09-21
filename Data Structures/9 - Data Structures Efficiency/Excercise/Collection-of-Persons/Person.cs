using System;

public class Person : IComparable<Person>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public string NameTown
    {
        get
        {
            return Name + "_" + Town;
        }
    }

    public string MailDomain
    {
        get
        {
            return Email.Split('@')[1];
        }
    }


    public int CompareTo(Person other)
    {
        return Email.CompareTo(other.Email);
    }
}
