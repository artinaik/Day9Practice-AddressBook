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
        List<Person> personlist = new List<Person>();
        List<Person> personlist1 = new List<Person>();
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to Address Book program");
            char ans;
            do
            {
                Console.WriteLine("1)Add Contact   2)Show Contact   3)Edit Contact   4)Delete Contact");
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
                }
                Console.Write("Want to Continue(Y/N) : ");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'Y' || ans=='y');
                      
            Console.ReadKey();
        }
        public void Create()//create new contact
        {
            Person personobj = new Person();
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
            Console.WriteLine("\nContact created successfully");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        public void Show()
        {
           // Create();
            if (personlist.Count == 0)
            {
                Console.WriteLine("Your address book is empty");
            }
            else
            foreach (var contact in personlist)//showing items in list
            {
                Console.WriteLine("Person details are :");
                    Console.WriteLine("\nFirstName : {0} \nLastName : {1} \nAddress : {2} \nCity : {3} \nState : {4} \nPhone Number : {5} \nZip : {6} \nEmail : {7}",
                  contact.fisrtName, contact.lastName, contact.address, contact.city, contact.state, contact.phoneNumber,
                   contact.zip, contact.email);
                    Console.WriteLine("----------------------------------------------------------------------");
            }
        }

        public void Edit()
        {
            
            Console.WriteLine("Enter FirstName of person which contact wants to edit");
            string firstName1 = Console.ReadLine();
            Person personobj = personlist.FirstOrDefault(x => x.fisrtName == firstName1);
            if (personlist.Contains(personobj))
            {
                Console.WriteLine("1)FirstName 2)LastName 3)Address 4)City 5)State 6)Phone Number 7)Zip 8)Email");
                Console.Write("Enter number from above list which you wants to edit :");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter First Name : ");
                        personobj.fisrtName = Console.ReadLine();

                        break;
                    case 2:
                        Console.Write("Enter Last Name : ");
                        personobj.lastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Address : ");
                        personobj.address = Console.ReadLine();
                        EditContact(personobj);
                        break;
                    case 4:
                        Console.Write("Enter City : ");
                        personobj.city = Console.ReadLine();
                        EditContact(personobj);
                        break;
                    case 5:
                        Console.Write("Enter State : ");
                        personobj.state = Console.ReadLine();
                        EditContact(personobj);
                        break;
                    case 6:
                        Console.Write("Enter phone number : ");
                        personobj.phoneNumber = Convert.ToDouble(Console.ReadLine());
                        EditContact(personobj);
                        break;
                    case 7:
                        Console.Write("Enter Zip : ");
                        personobj.zip = Convert.ToDouble(Console.ReadLine());
                        EditContact(personobj);
                        break;
                    case 8:
                        Console.Write("Enter Email : ");
                        personobj.email = Console.ReadLine();
                        EditContact(personobj);
                        break;
                    default:
                        Console.WriteLine("Please enter valid numbers");
                        break;
                }
                Console.WriteLine("\nContact Updated successfully");
                Console.WriteLine("----------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }
        public void EditContact(Person person)
        {
            personlist1.Add(person);
        }
        public void Delete()
        {
            Console.Write("Enter the first name of the person you want to remove : ");
            string firstName1 = Console.ReadLine();
            Person person = personlist.FirstOrDefault(x => x.fisrtName== firstName1);
            if (person == null)
            {
                Console.WriteLine("That person could not be found.");
            }
            else 
            {
                Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                    personlist.Remove(person);
                Console.WriteLine("\nContact deleted successfully");
                Console.WriteLine("----------------------------------------------------------------------");
                return;
            }
        }

    }
}
