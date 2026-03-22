using ContactesClassEstructurada;
using System;
using System.Linq;

Console.WriteLine("My Personal Agenda");
Console.WriteLine("Welcome to your contact list");

bool running = true;
List<Contact> contacts = new List<Contact>();

while (running)
{
    Console.Write("1. Add a Contact      ");
    Console.Write("2. View all Contact     ");
    Console.Write("3. Search a Contact      ");
    Console.Write("4. Modify a Contact        ");
    Console.Write("5. Delete a Contact     ");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");
    try
    {

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            AddContact(contacts);
            break;
        case 2:
            ViewContacts(contacts);
            break;
        case 3:
            SearchContact(contacts);
            break;
        case 4:
            EditContact(contacts);
            break;
        case 5:
            DeleteContact(contacts);
            break;       
        case 6:
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("An unexpected error has occurred, enter a valid number");
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Error: Contact not found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Oh, apparently, an unexpected error has occurred." + ex.Message);
    }
}


static void AddContact(List<Contact> contacts)
{
    string name;
    while (true)
    {
        Console.Write("Enter the person's name: ");
        name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) break;
        Console.WriteLine("Error: Name cannot be empty.");
    }

    string phone;
    while (true)
    {
        Console.Write("Enter the person's phone: ");
        phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit)) break;
        Console.WriteLine("Error: Phone must contain only numbers.");
    }

    string email;
    while (true)
    {
        Console.Write("Enter the person's email: ");
        email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".")) break;
        Console.WriteLine("Error: Invalid email.");
    }

    string address;
    while (true)
    {
        Console.Write("Enter the person's address: ");
        address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address)) break;
        Console.WriteLine("Error: Address cannot be empty.");
    }

    int id = contacts.Count + 1;

    contacts.Add(new Contact
    {
        Id = id,
        Name = name,
        Phone = phone,
        Email = email,
        Address = address
    });

    Console.WriteLine("Contact added successfully.");
}


static void ViewContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }
        Console.WriteLine("Id           Name          Phone            Email           Address");
    Console.WriteLine("___________________________________________________________________________");

    foreach (var c in contacts)
    {
            Console.WriteLine($"{c.Id}   {c.Name}   {c.Phone}   {c.Email}   {c.Address}");
        }
}

static void EditContact(List<Contact> contacts)
    {
    Console.WriteLine("Enter a Contact ID To Edit");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var contact = contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("New name:");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            contact.Name = name;

        string phone;
        while (true)
        {
            Console.WriteLine("New phone:");
            phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit)) break;
            Console.WriteLine("Error: Phone must contain only numbers.");
        }
        contact.Phone = phone;

        string email;
        while (true)
        {
            Console.WriteLine("New email:");
            email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".")) break;
            Console.WriteLine("Error: Invalid email.");
        }
        contact.Email = email;

        string address;
        while (true)
        {
            Console.WriteLine("New address:");
            address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address)) break;
            Console.WriteLine("Error: Address cannot be empty.");
        }
        contact.Address = address;

        Console.WriteLine("Contact updated.");
    }

    static void DeleteContact(List<Contact> contacts)
    {
    Console.WriteLine("Enter a Contact ID To Delete");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var contact = contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("1. Yes  2. No");
        int confirm = Convert.ToInt32(Console.ReadLine());

        if (confirm == 1)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted.");
        }
    }

    static void SearchContact(List<Contact> contacts)
    {
    Console.WriteLine("Enter a Contact ID To Show");
    string search = Console.ReadLine()?.ToLower() ?? "";

    bool found = false;

    foreach (var c in contacts)
    {
        if (c.Name.ToLower().Contains(search))
        {
            Console.WriteLine($"{c.Id} - {c.Name} | {c.Phone} | {c.Email}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("Contact not found.");
    }
}
