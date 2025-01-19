using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem : Ex04.Menus.Interfaces.IMenuItem
    {
        public string Title { get; }
        public Action ExecuteAction { get; set; }
        public List<IMenuItem> SubItems { get; private set; }
        public bool HasSubItems => SubItems.Count > 0;
       

        public MenuItem(string title, Action executeAction = null)
        {
            Title = title;
            ExecuteAction = executeAction;
            SubItems = new List<IMenuItem>();
        }

        public void Execute()
        {
            if (ExecuteAction != null)
            {
                ExecuteAction.Invoke();
            }
            else
            {
                Console.WriteLine($"Executing menu: {Title}");
            }
        }
    }
}
