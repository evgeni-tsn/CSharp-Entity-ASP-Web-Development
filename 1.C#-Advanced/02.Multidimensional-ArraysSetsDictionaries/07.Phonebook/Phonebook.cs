using System;
using System.Collections.Generic;
using System.Linq;

class Phonebook
{
    //Write a program that receives some info from the console about people and their phone numbers.
    //You are free to choose the manner in which the data is entered; each entry should have just one name and one number(both of them strings). 
    //After filling this simple phonebook, upon receiving the command "search", your program should be able to perform a search of a contact by name and print her details in format "{name} -> {number}". In case the contact isn't found, print "Contact {name} does not exist." 

    static void Main()
    {
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();

        string contactInformation = Console.ReadLine();
        string[] contactTokens;
        string contactName = String.Empty;
        string contactNumber = String.Empty;

        while (contactInformation != "search")
        { 
            contactTokens = contactInformation.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            contactName = contactTokens[0];
            contactNumber = contactTokens[1];
            if (!phonebook.ContainsKey(contactName))
            {
                phonebook[contactName] = new List<string>();
            }
            phonebook[contactName].Add(contactNumber);

            contactInformation = Console.ReadLine();
        }
        while (true)
        {
            string searchedName = Console.ReadLine();
            if (phonebook.ContainsKey(searchedName))
            {
                foreach (KeyValuePair<string, List<string>> kvp in phonebook)
                {
                    if (kvp.Key == searchedName)
                    {
                    Console.WriteLine("{0} -> {1}", kvp.Key, string.Join(" ",phonebook[searchedName]));
                    }
                }
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.",searchedName);
            }
        }
    }
}