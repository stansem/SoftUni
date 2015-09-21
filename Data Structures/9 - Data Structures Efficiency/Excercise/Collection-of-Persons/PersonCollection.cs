using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    Dictionary<string, Person> mailDict;
    Dictionary<string, SortedSet<Person>> mailDomainDict;
    Dictionary<string, SortedSet<Person>> nameTownDict;
    OrderedDictionary<int, SortedSet<Person>> ageRangeDict;
    Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> townAgeRangeDict;

    public PersonCollection()
    {
        mailDict = new Dictionary<string, Person>();
        mailDomainDict = new Dictionary<string,SortedSet<Person>>();
        nameTownDict = new Dictionary<string,SortedSet<Person>>();
        ageRangeDict = new OrderedDictionary<int,SortedSet<Person>>();
        townAgeRangeDict = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        Person p = new Person() { Email = email, Name = name, Age = age, Town = town };

        if(!mailDict.ContainsKey(email))
        {
            mailDict.Add(email, p);

            mailDomainDict.AppendValueToKey(p.MailDomain, p);

            nameTownDict.AppendValueToKey(p.NameTown, p);

            ageRangeDict.AppendValueToKey(age, p);

            townAgeRangeDict.EnsureKeyExists(town);
            OrderedDictionary<int, SortedSet<Person>> townAgeRangeMultiDict = townAgeRangeDict[town];
            townAgeRangeMultiDict.AppendValueToKey(age, p);

            return true;
        }

        return false;
    }

    public int Count
    {
        get
        {
            return mailDict.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person p;
        if(mailDict.TryGetValue(email, out p))
        {
            return p;
        }

        return null;
    }

    public bool DeletePerson(string email)
    {
        Person p = FindPerson(email);

        if(p != null)
        {
            mailDict.Remove(email);
            mailDomainDict[p.MailDomain].Remove(p);
            nameTownDict[p.NameTown].Remove(p);
            ageRangeDict[p.Age].Remove(p);
            townAgeRangeDict[p.Town][p.Age].Remove(p);

            return true;
        }

        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return mailDomainDict.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return nameTownDict.GetValuesForKey(name + "_" + town);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var range = ageRangeDict.Range(startAge, true, endAge, true);

        foreach(var set in range)
        {
            foreach(var p in set.Value)
            {
                yield return p;
            }
        }

    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        OrderedDictionary<int, SortedSet<Person>> dict;

        if (townAgeRangeDict.TryGetValue(town, out dict))
        {
            var range = dict.Range(startAge, true, endAge, true);

            foreach (var set in range)
            {
                foreach (var p in set.Value)
                {
                    yield return p;
                }
            }
        }

        yield break;
    }
}
