using System;
using System.Collections.Generic;
using System.IO;

class Concert
{
    public string Name { get; set; }
    public string Venue { get; set; }
    public DateTime Date { get; set; }

    public Concert(string name, string venue, DateTime date)
    {
        Name = name;
        Venue = venue;
        Date = date;
    }
    public void Display()
    {
        Console.WriteLine($"{Name} Attribute {Venue} DateOnly {Date.ToString("MM/dd/yy HH:mm")}");
    }
}