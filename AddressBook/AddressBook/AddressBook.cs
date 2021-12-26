using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AddressBook
{
   public class AddressBook
    {
        public Dictionary<string, List<Person>> persondic = new Dictionary<string, List<Person>>();
        List<Person> personlist1 = new List<Person>();
        List<Person> people = new List<Person>();
        public Dictionary<string, List<Person>> Create()//create new contact
        {
            List<Person> personlist = new List<Person>();
            Console.Write("Enter Address book name : ");
            string addressbkName = Console.ReadLine();
            Console.Write("Enter number of how many contacts you want to create : ");
            int countContact = int.Parse(Console.ReadLine());
            int i = 1;
            while (i <= countContact)
            {
                Person personobj = new Person();
                Console.WriteLine("\nEnter person {0} details ", i);
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
                bool duplicate = personlist.Any(x => x.fisrtName.Equals(personobj.fisrtName));
                if (duplicate == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact with same firstname already present in address book.Try to give another name");
                }
                else
                {
                    personlist.Add(personobj);
                    // personlist.OrderBy(x => x.fisrtName);
                    people.Add(personobj);
                    Console.WriteLine("\nContact created successfully");
                    Console.WriteLine("----------------------------------------------------------------------");
                    i++;
                }
            }

            persondic.Add(addressbkName, personlist);
            return persondic;
        }
        public void WriteToFile(Dictionary<string, List<Person>> persondic, string format)
        {
            String pathTxt = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.txt";
            String pathCsv = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.csv";
            string pathjson = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.json";
            if (format.Equals("txt"))
            {
                using (StreamWriter sr = File.AppendText(pathTxt))
                {
                    foreach (KeyValuePair<string, List<Person>> keyValuePair in persondic)
                    {
                        sr.WriteLine("Address Book Name : " + keyValuePair.Key);
                        sr.WriteLine("FirstName\tLastName\tAddressCity\tState\tPhone Number\tZip\tEmail");
                        foreach (var contact in keyValuePair.Value)
                        {
                            sr.WriteLine(contact.fisrtName + " " + contact.lastName + " " + contact.address + " " + contact.city + " " + contact.state + " " + contact.phoneNumber + " " + contact.zip + " " + contact.email);
                        }

                    }

                }
            }
            if (format.Equals("csv"))
            {
                using (FileStream fileStream = new FileStream(pathCsv, FileMode.Create, FileAccess.Write))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                using (CsvHelper.CsvWriter csvWriter = new CsvHelper.CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    // Write out the file headers
                    csvWriter.WriteField("fisrtName");
                    csvWriter.WriteField("lastName");
                    csvWriter.WriteField("address");
                    csvWriter.WriteField("city");
                    csvWriter.WriteField("state");
                    csvWriter.WriteField("phoneNumber");
                    csvWriter.WriteField("zip");
                    csvWriter.WriteField("email");
                    csvWriter.NextRecord();
                    foreach(KeyValuePair<string, List<Person>> keyValuePair in persondic)
                    {
                        foreach(var contact in keyValuePair.Value)
                        {
                            csvWriter.WriteField(contact.fisrtName);
                            csvWriter.WriteField(contact.lastName);
                            csvWriter.WriteField(contact.address);
                            csvWriter.WriteField(contact.city);
                            csvWriter.WriteField(contact.state);
                            csvWriter.WriteField(contact.phoneNumber);
                            csvWriter.WriteField(contact.zip);
                            csvWriter.WriteField(contact.email);
                            csvWriter.NextRecord();
                        }
                    }

                }
            }
            if (format.Equals("json"))
            {
                List<Person> people = new List<Person>();
                foreach(KeyValuePair<string,List<Person>> keyValue in persondic)
                {
                    foreach(var contact in keyValue.Value)
                    {
                        people.Add(contact);
                    }
                }
                string json = JsonConvert.SerializeObject(people.ToArray());

                //write string to file
                System.IO.File.WriteAllText(pathjson, json);

            }

        }
        public void ReadFromFile(string format)
        {
            String pathTxt = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.txt";
            String pathCsv = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.csv";
            string pathjson = @"C:\Dot Net\Day9Practice-AddressBook\AddressBook\AddressBook\PersonsData.json";

            if (format.Equals("txt"))
            {
                string[] data;
                data = File.ReadAllLines(pathTxt);
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
            }
            if (format.Equals("csv"))
            {
                using (var reader = new StreamReader(pathCsv))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Person>().ToList();
                    Console.WriteLine("Read data successfully from PersonsData.csv");
                    foreach (Person contact in records)
                    {
                        Console.Write("\t" + contact.fisrtName);
                        Console.Write("\t" + contact.lastName);
                        Console.Write("\t" + contact.address);
                        Console.Write("\t" + contact.city);
                        Console.Write("\t" + contact.state);
                        Console.Write("\t" + contact.phoneNumber);
                        Console.Write("\t" + contact.zip);
                        Console.Write("\t" + contact.email);
                        Console.WriteLine();
                    }
                }
            }
            if (format.Equals("json"))
            {
                string[] data;
                data = File.ReadAllLines(pathjson);
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void Show()
        {
            if (persondic.Count == 0)
            {
                Console.WriteLine("Your address book is empty");
            }
            else
                foreach (KeyValuePair<string, List<Person>> keyValue in persondic)
                {
                    Console.Write("Address Book name is : " + keyValue.Key);
                    foreach (var contact in keyValue.Value.OrderBy(x => x.zip))//showing items in list
                    {
                        Console.WriteLine("\nPerson details are :");
                        Console.WriteLine("\nFirstName : {0} \nLastName : {1} \nAddress : {2} \nCity : {3} \nState : {4} \nPhone Number : {5} \nZip : {6} \nEmail : {7}",
                      contact.fisrtName, contact.lastName, contact.address, contact.city, contact.state, contact.phoneNumber,
                       contact.zip, contact.email);
                        Console.WriteLine("----------------------------------------------------------------------");
                    }
                }
        }

        public void Edit()
        {
            Console.WriteLine("Enter FirstName of person which contact wants to edit");
            string firstName1 = Console.ReadLine();
            Person personobj = people.FirstOrDefault(x => x.fisrtName == firstName1);
            if (people.Contains(personobj))
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
            people.Add(person);
        }
        public void Delete()
        {
            Console.Write("Enter the first name of the person you want to remove : ");
            string firstName1 = Console.ReadLine();
            foreach (KeyValuePair<string, List<Person>> data in persondic)
            {
                foreach (Person contact in data.Value)
                {
                    if (contact.fisrtName == firstName1)
                    {
                        Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                            data.Value.Remove(contact);
                        Console.WriteLine("\nContact deleted successfully");
                        Console.WriteLine("----------------------------------------------------------------------");
                        return;
                    }

                }

            }
        }
        public void SearchByCity()
        {
            Console.Write("Enter City : ");
            string searchcity = Console.ReadLine();
            var result = people.FindAll(x => x.city.Equals(searchcity));
            var resultcount = people.Count(x => x.city.Equals(searchcity));
            Console.Write("Count of persons in City {0} is : {1}", searchcity, resultcount);
            foreach (var contact in result)
            {
                Console.WriteLine("\nPerson details are :");
                Console.WriteLine("\nFirstName : {0} \nLastName : {1} \nAddress : {2} \nCity : {3} \nState : {4} \nPhone Number : {5} \nZip : {6} \nEmail : {7}",
                contact.fisrtName, contact.lastName, contact.address, contact.city, contact.state, contact.phoneNumber,
               contact.zip, contact.email);
                Console.WriteLine("----------------------------------------------------------------------");
            }

        }
        public void SearchByState()
        {
            Console.Write("Enter State : ");
            string searchstate = Console.ReadLine();
            var result = people.FindAll(x => x.state.Equals(searchstate));
            var resultcount = people.Count(x => x.state.Equals(searchstate));
            Console.Write("Count of persons in State {0} is : {1}", searchstate, resultcount);
            foreach (var contact in result)
            {
                Console.WriteLine("\nPerson details are :");
                Console.WriteLine("\nFirstName : {0} \nLastName : {1} \nAddress : {2} \nCity : {3} \nState : {4} \nPhone Number : {5} \nZip : {6} \nEmail : {7}",
                contact.fisrtName, contact.lastName, contact.address, contact.city, contact.state, contact.phoneNumber,
               contact.zip, contact.email);
                Console.WriteLine("----------------------------------------------------------------------");
            }

        }

    }
}
