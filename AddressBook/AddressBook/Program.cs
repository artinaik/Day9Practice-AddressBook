using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddressBook
{
    class Program:AddressBook
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to Address Book program");
            char ans;
            do
            {
                Console.WriteLine("1)Add Contact   2)Show Contact   3)Edit Contact   4)Delete Contact    5)Write to file   6)Read from file  7)Search Contact");
                Console.Write("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        program.Create();
                        break;
                    case 2:
                        program.Show();
                        break;
                    case 3:
                        program.Edit();
                        break;
                    case 4:
                        program.Delete();
                        break;
                    case 5:
                        Console.Write("Enter file format for writing : ");
                        string format = Console.ReadLine();
                        program.WriteToFile(program.persondic,format);
                        Console.WriteLine("Address book written to file successfully");
                        break;
                    case 6:
                        Console.Write("Enter file format for reading : ");
                        string format1 = Console.ReadLine();
                        Console.WriteLine("Reading Person's data from file");
                        program.ReadFromFile(format1);
                        break;
                    case 7:
                        Console.WriteLine("1)Search by city     2)Search by state");
                        Console.Write("Enter your choice for search person : ");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                program.SearchByCity();
                                break;
                            case 2:
                                program.SearchByState();
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                        break;
                }
                Console.Write("Want to Continue(Y/N) : ");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'Y' || ans == 'y');

            Console.ReadKey();
        }

    }
}
