using System.Collections.Generic;
using System;
using System.Threading;
using ClassLib_1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuFunctions.data = new List<City>();
            Menu menu = new Menu();
            ConsoleKeyInfo pressedKey;

            menu.AddElement(new Menu.MenuItem("Open cityes list", ConsoleColor.White, MenuFunctions.OpenCityesList));
            menu.AddElement(new Menu.MenuItem("Add new city", ConsoleColor.Green,MenuFunctions.CreateNewCity));
            menu.AddElement(new Menu.MenuItem("Delete city", ConsoleColor.Yellow, MenuFunctions.DeleteCity));

            while (true)
            {
                menu.Print();
                Thread.Sleep(16);
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.DownArrow)
                    menu.ChangeChosedElement(false);
                if (pressedKey.Key == ConsoleKey.UpArrow)
                    menu.ChangeChosedElement(true);
                if (pressedKey.Key == ConsoleKey.Enter)
                    menu.ChoseMenuItem();
            }
        }
    }
    public static class MenuFunctions
    {
        public static List<City> data;
        public static void OpenCityesList()
        {
            int i = 0;
            foreach (City city in data)
            {
                Console.WriteLine(i + " city index");
                Console.Write(city.ToString());
                i++;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void CreateNewCity()
        {
            City.CityDesc desc = new City.CityDesc();

            Console.Write("Enter city Region:");
            desc.Region = Console.ReadLine();

            Console.Write("Enter city Name:");
            desc.Name = Console.ReadLine();

            Console.Write("Enter city Mayor:");
            desc.Mayor = Console.ReadLine();

            Console.Write("Enter city Pollution:");
            desc.Pollution = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter city Crimes:");
            desc.Crimes = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter city ZonesNumber:");
            desc.ZonesNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter city Population:");
            desc.Population = Convert.ToInt32(Console.ReadLine());

            data.Add(new City(desc));
        }

        public static void DeleteCity()
        {
            Console.Write("Enter index of city for delete: ");
            int index = Convert.ToInt32(Console.ReadLine());
            data.RemoveAt(index);
        }
    }
}
