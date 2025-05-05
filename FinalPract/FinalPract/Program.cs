using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPract
{
    internal class Program
    {
        static List<Final> finals = new List<Final>();
        static string filepath = "finals.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Animals App");

            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("Welcome to the Animals App");
                Console.WriteLine("Please enter A to add a new Animal");
                Console.WriteLine("Please enter U to update an Animal by ID");
                Console.WriteLine("Please enter D to delete an Animal by ID");
                Console.WriteLine("Please enter V to view all Animals");
                Console.WriteLine("Please enter E to exit App");
                Console.Write("Your Choice: ");
                string choice = Console.ReadLine().ToUpper();

                if(choice == "A")
                {

                }else if(choice == "U")
                {
                    
                }else if(choice == "D") { 

                }else if(choice == "V")
                {

                }else if(choice == "E")
                {
                    exit = true;
                    return;
                }

            }
        }


    }
}
