using System;
using System.Collections.Generic;
using System.IO;

class Student : IComparable<Student>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CompareTo(Student other)
    {
        int cmp = LastName.CompareTo(other.LastName);
        if(cmp == 0)
        {
            cmp = FirstName.CompareTo(other.FirstName);
        }

        return cmp;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}

class StudentsAndCourses
{
    private static SortedDictionary<string, SortedSet<Student>> courses = new SortedDictionary<string, SortedSet<Student>>();

    static void Main()
    {
        ReadData();
        PrintData();
    }

    private static void ReadData()
    {
        StreamReader s = new StreamReader("students.txt");

        using(s)
        {
            string line;
            while ((line = s.ReadLine()) != null)
            {
                string fName = line.Split('|')[0].Trim();
                string lName = line.Split('|')[1].Trim();
                string course = line.Split('|')[2].Trim();

                if (!courses.ContainsKey(course))
                {
                    courses[course] = new SortedSet<Student>();
                }
                courses[course].Add(new Student() { FirstName = fName, LastName = lName });
            }
        }
    }

    private static void PrintData()
    {
        foreach (var course in courses)
        {
            Console.Write(course.Key + ": ");
            Console.WriteLine(string.Join(", ", course.Value));
        }
    }
}

