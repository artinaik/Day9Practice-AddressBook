using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddressBook
{
    class Program
    {
        Person personobj = new Person();
        List<Person> personlist = new List<Person>();
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to Address Book program");
            program.Create();
            Console.ReadKey();
        }
        public void Create()//create new contact
        {
            Console.WriteLine("\nEnter person details ");
            Console.Write("\nEnter First Name : ");
            personobj.fisrtName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            personobj.lastName = Console.ReadLine();
            Console.Write("Enter Address : ");
            personobj.address = Console.ReadLine();
            Console.Write("Enter City : ");
            personobj.city = Console.ReadLine();
            Console.Write("Enter State : ");
            personobj.state = Console.ReadLine();
            Console.Write("Enter phone number : ");
            personobj.phoneNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Zip : ");
            personobj.zip = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Email : ");
            personobj.email = Console.ReadLine();
            personlist.Add(personobj);
            Console.WriteLine("Contact created successfully");
        }

    }
}
