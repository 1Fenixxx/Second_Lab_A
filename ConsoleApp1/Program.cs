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

            paramInput("Region", ref desc.Region);
            paramInput("Name", ref desc.Name);
            paramInput("Mayor", ref desc.Mayor);
            paramInput("Pollution", ref desc.Pollution);
            paramInput("Crimes", ref desc.Crimes);
            paramInput("Zones Count", ref desc.ZonesNumber);
            paramInput("Population", ref desc.Population);

            data.Add(new City(desc));
        }
        private static void paramInput(string paramName, ref string variable)
        {
            try
            {
                Console.Write("Enter city " + paramName + ":");
                variable = Console.ReadLine();
            }
            catch { }
        }
        private static void paramInput(string paramName, ref double variable)
        {
            try
            {
                Console.Write("Enter device " + paramName + ":");
                variable = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                ErrorLogger.Error(paramName);
                paramInput(paramName, ref variable);
            }
        }
        private static void paramInput(string paramName, ref int variable)
        {
            try
            {
                Console.Write("Enter city " + paramName + ":");
                variable = Convert.ToInt32(Console.ReadLine());
            }
            catch 
            {
                ErrorLogger.Error(paramName);
                paramInput(paramName, ref variable);
            }
        }
        public static void DeleteCity()
        {
            Console.Write("Enter index of city for delete: ");
            int index = Convert.ToInt32(Console.ReadLine());
            data.RemoveAt(index);
        }
    }
}
