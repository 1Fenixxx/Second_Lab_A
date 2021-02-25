using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLib_1
{
    public class City
    {
        public struct CityDesc
        {
            public string Region;
            public string Name;
            public string Mayor;
            public double Pollution;
            public int Crimes;
            public int ZonesNumber;
            public int Population;
        }
        public City(string Region, string Name, string Mayor, double Pollution, int Crimes, int ZonesNumber, int Population)
        {
            Description = new CityDesc
            {
                Region = Region,
                Name = Name,
                Mayor = Mayor,
                Pollution = Pollution,
                Crimes = Crimes,
                ZonesNumber = ZonesNumber,
                Population = Population
            };
        }
        public City(CityDesc CityDescription)
        {
            this.Description = CityDescription;
        }

        public override string ToString()
        {
            string output = string.Empty;

            output += "   Region: " + Description.Region + '\n';
            output += "     Name: " + Description.Name + '\n';
            output += "    Mayor: " + Description.Mayor + '\n';
            output += "  Pollution: " + Description.Pollution + '\n';
            output += "     Crimes: " + Description.Crimes + '\n';
            output += "ZonesNumber: " + Description.ZonesNumber + '\n';
            output += " Population: " + Description.Population + '\n';

            return output;
        }

        public void SetCityDescription(CityDesc desc)
        {
            Description = desc;
        }

        public CityDesc Description { get; private set; }
    }


    //don`t using in primitive programming style (that`s primitive too)
    public class Menu
    {
        //inner MenuItem class for menu items in menu
        public class MenuItem
        {
            public MenuItem(string Title, WorkFunction function)
            {
                this.Title = Title;
                this.WorkMethod = function;
            }
            public MenuItem(string Title, ConsoleColor TextColor, WorkFunction function)
            {
                this.Title = Title;
                this.Color = TextColor;
                this.WorkMethod = function;
            }

            public delegate void WorkFunction();

            public void Print()
            {
                Console.ForegroundColor = this.Color;
                Console.WriteLine(this.Title);
                Console.ResetColor();
            }

            public string Title { get; set; }
            public WorkFunction WorkMethod { get; private set; }
            public ConsoleColor Color { get; private set; }
        }

        private static int counter = 0;

        public Menu()
        {
            this.AddElement(new MenuItem("Exit", ConsoleColor.Red, exitMenuItemDefaultFunction));
        }

        //new menuitem adding method
        public void AddElement(params MenuItem[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                string newTitle = counter + " " + elements[i].Title;
                elements[i].Title = newTitle;
                menuItemsList.Add(elements[i]);
                counter++;
            }
        }

        //Menu printing method
        public void Print()
        {
            Console.Clear();
            foreach (MenuItem menuItem in menuItemsList)
            {
                menuItem.Print();
            }
            Console.WriteLine("Chosed menuitem: " + this.ChosedElementIndex);
        }

        //using for call chosed menu item work function
        public void ChoseMenuItem()
        {
            menuItemsList[ChosedElementIndex].WorkMethod();
        }

        //using for changing ChosedElementIndex prophety. True for index++ and False for index--
        public void ChangeChosedElement(bool up_down)
        {
            if (!up_down)
            {
                if (ChosedElementIndex + 1 < menuItemsList.Count)
                    ChosedElementIndex++;
            }
            else
            {
                if (ChosedElementIndex - 1 >= 0)
                    ChosedElementIndex--;
            }
        }

        //index of the chosed element in menu
        public int ChosedElementIndex { get; private set; }

        //MenuItems list, using for store menu elements
        private List<MenuItem> menuItemsList = new List<MenuItem>();

        //default function for "Exit" item in menu
        private void exitMenuItemDefaultFunction()
        {
            Console.Write("EXIT");
            for (int i = 0; i < 4; i++)
            {
                Console.Write('.');
            }
            Environment.Exit(0);
        }
    }
}
