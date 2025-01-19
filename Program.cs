using System;
using Ex04.Menus.Events;

class Program
{
    static void Main()
    {
        var mainMenu = new MainMenu();

        var lettersAndVersionMenu = new MenuItem("Letters and Version");
        //lettersAndVersionMenu.SubItems.Add(new MenuItem("Show Version", () => Console.WriteLine("App Version: 25.1.4.5480")));
        lettersAndVersionMenu.SubItems.Add(new MenuItem("Show Version", () =>
        {
            Console.WriteLine("App Version: 25.1.4.5480");
        }));
        lettersAndVersionMenu.SubItems.Add(new MenuItem("Count Lowercase Letters", () =>
        {
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();
            int lowercaseCount = input.Count(char.IsLower);
            Console.WriteLine($"There are {lowercaseCount} lowercase letters.");
        }));

        var dateTimeMenu = new MenuItem("Show Current Date/Time");
        
        dateTimeMenu.SubItems.Add(new MenuItem("Show Current Time", () =>
        {
            Console.WriteLine($"Current Time: {DateTime.Now:HH:mm:ss}");
        }));
       
        dateTimeMenu.SubItems.Add(new MenuItem("Show Current Date", () =>
        {
            Console.WriteLine($"Current Date: {DateTime.Now:dd/MM/yyyy}");
        }));



        mainMenu.AddMenuItem(lettersAndVersionMenu);
        mainMenu.AddMenuItem(dateTimeMenu);

        mainMenu.Show();
    }
}
