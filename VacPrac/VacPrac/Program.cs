using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacPrac
{
   
    internal class Program
    {
        static List<Vac> vac = new List<Vac>();

        static string filepath = "vac.txt";
        static void Main(string[] args)
        {
            Console.Write("\n Welcome to Vac app\n");
            Console.Write("Press A to add new Animal");
            Console.Write("Press M to mark animal as vaccinated");
            Console.Write("Press V to view All Animal");
            Console.Write("Press E to exit app");

            bool exit = false;

            while (!exit) { 
               string choice = Console.ReadLine().ToUpper();

                if (choice == "A")
                {

                }else if(choice == "M")
                {

                }else if(choice == "V")
                {

                }else if(choice == "E")
                {
                    exit = true;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            }
        }
    }
}
