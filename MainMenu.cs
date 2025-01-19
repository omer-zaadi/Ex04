using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly List<IMenuItem> r_MenuItems = new();

        public void AddMenuItem(IMenuItem menuItem)
        {
            r_MenuItems.Add(menuItem);
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("** Delegates Main Menu **");
                Console.WriteLine("--------------------");

                for (int i = 0; i < r_MenuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {r_MenuItems[i].Title}");
                }

                Console.WriteLine("0. Exit");
                Console.Write("Please enter your choice (1-2 or 0 to exit):");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= r_MenuItems.Count)
                {
                    if (choice == 0)
                    {
                        break;
                    }

                    var selectedItem = r_MenuItems[choice - 1];
                    if (selectedItem.HasSubItems)
                    {
                        ShowSubMenu(selectedItem);
                    }
                    else
                    {
                        selectedItem.Execute();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
        }

        private void ShowSubMenu(IMenuItem menuItem)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"** {menuItem.Title} **");
                Console.WriteLine("--------------------");

                for (int i = 0; i < menuItem.SubItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuItem.SubItems[i].Title}");
                }

                Console.WriteLine("0. Back");
                Console.Write("Please enter your choice (1-2 or 0 to go back):");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= menuItem.SubItems.Count)
                {
                    if (choice == 0)
                    {
                        return; // חזרה לתפריט העליון
                    }

                    var selectedItem = menuItem.SubItems[choice - 1];
                    if (selectedItem.HasSubItems)
                    {
                        ShowSubMenu(selectedItem); // כניסה לתת תפריט נוסף
                    }
                    else
                    {
                        selectedItem.Execute(); // הרצת הפעולה הסופית
                        Console.ReadKey(); // מחכים ללחיצה לפני חזרה לתפריט המשני
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
        }



        /* private void ShowSubMenu(IMenuItem menuItem)
         {
             Console.Clear();
             Console.WriteLine($"** {menuItem.Title} **");
             Console.WriteLine("--------------------");

             for (int i = 0; i < menuItem.SubItems.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {menuItem.SubItems[i].Title}");
             }

             Console.WriteLine("0. Back");
             Console.Write("Please enter your choice (1-2 or 0 to go back):");

             if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= menuItem.SubItems.Count)
             {
                 if (choice == 0)
                 {
                     return;
                 }

                 var selectedItem = menuItem.SubItems[choice - 1];
                 if (selectedItem.HasSubItems)
                 {
                     ShowSubMenu(selectedItem);
                 }
                 else
                 {
                     selectedItem.Execute();
                 }
             }
             else
             {
                 Console.WriteLine("Invalid choice, please try again.");
             }
         }*/
    }
}
