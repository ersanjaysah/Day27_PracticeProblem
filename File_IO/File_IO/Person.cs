using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string Address;
        public long PhoneNumber;

        public string Result()
        {
            return " Name is: " + FirstName + " " + LastName + "\n Address: " + Address + "\n Phone: " + PhoneNumber;
        }
    }

    public class AddressBook
    {

        public List<Person> person = new List<Person>(); //creating list
        public AddressBook()  //Address Book method
        {
            string json = File.ReadAllText(@"E:\BridgeLabzAssignment\Day27_Problems\File_IO\File_IO\File.json");
            if (json.Length > 0)
            {
                person = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            else
                person = new List<Person>();
        }

        public void Display()  //Display Method
        {
            if (person.Count == 0)
            {
                Console.WriteLine("Please add Some Contact list First");
            }
            Console.WriteLine("Welcome to Program");
            foreach (Person per in person)
            {
                Console.WriteLine(per.Result());
            }
        }

        public void addPerson(Person p)  //Adding Contact list method
        {
            person.Add(p);
            string jsonData = JsonConvert.SerializeObject(person);
            File.WriteAllText(@"E:\BridgeLabzAssignment\Day27_Problems\File_IO\File_IO\File.json", jsonData);
        }
    }
}
