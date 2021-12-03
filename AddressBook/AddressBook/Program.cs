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
        List<Person> personlist1 = new List<Person>();
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to Address Book program");
            char ans;
            do
            {
                Console.WriteLine("1)Add Contact   2)Show Contact   3)Edit Contact");
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

                }
                Console.Write("Want to Continue(Y/N) : ");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'Y' || ans=='y');
                      
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
            Console.WriteLine("\nContact created successfully");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        public void Show()
        {
            if (personlist.Count == 0)
            {
                Console.Write("Your address book is empty.Press 1 to add new contact : ");
                Console.ReadKey();
                Create();
            }
            else
            foreach (Person details in personlist)//showing items in list
            {
                Console.WriteLine("Person details are :");
                Console.WriteLine("\nFirstName : {0} \nLastName : {1} \nAddress : {2} \nCity : {3} \nState : {4} \nPhone Number : {5} \nZip : {6} \nEmail : {7}",
                    details.fisrtName, details.lastName, details.address, details.city, details.state, details.phoneNumber,
                     details.zip, details.email);
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
        public void Edit()
        {
            Console.WriteLine("Enter FirstName of person which contact wants to edit");
            string newName = Console.ReadLine();
            char ans;
            if(newName==personobj.fisrtName)
            {
                //do
                //{
            
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

                //    Console.Write("Want to Continue(Y/N) : ");
                //    ans = Convert.ToChar(Console.ReadLine());
                //} while (ans == 'Y' || ans == 'y');
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

    }
}
