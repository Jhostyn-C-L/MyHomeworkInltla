Console.WriteLine("Welcome to my List of Contact");
Console.WriteLine("This work for add and manage your list of contacts");

//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"What do you want to do? 1. Add a Contact     2. View all Contact    3. Search a Contact     4. Modify a Contact   5. Delete a Contact    6. Exit");
    try
    {
        int typeOption = Convert.ToInt32(Console.ReadLine());

        switch (typeOption)
        {
            case 1://this is add
                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                break;
            case 2: //extract this to a method
                {
                    Console.WriteLine($"Name          LastName            Address           Phone            Email           Age            Is Best Friend?");
                    Console.WriteLine($"____________________________________________________________________________________________________________________________");
                    foreach (var id in ids)
                    {
                        var isBestFriend = bestFriends[id];

                        string isBestFriendStr = (isBestFriend == true) ? "Yes" : "No";
                        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                    }
                }
                break;
            case 3: //search
                SearchContact(ids, names, lastnames);
                break;

            case 4: //modify

                ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                break;
            case 5: //delete

                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                break;
            case 6:
                runing = false;
                break;
            default:
                Console.WriteLine("Why do you choose this number? It is not valid.");// or Invalid option, please try again
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("An unexpected error has occurred");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Oh, apparently, an unexpected error has occurred." + ex.Message);
    }
}



static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    string name;
    while (true)
    {
        Console.WriteLine("Enter the person's name");
        name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) break;
        Console.WriteLine("Oh, apparently, an unexpected error has occurred. Name cannot be empty");
    }
    string lastname;
    while (true)
    {
        Console.WriteLine("Enter the person's lastname");
        lastname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastname)) break;
        Console.WriteLine("Oh, apparently, an unexpected error has occurred. Lastname cannot be empty");
    }

    string address;
    while (true)
    {
        Console.WriteLine("Enter the person's address");
        address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address)) break;
        Console.WriteLine("Oh, apparently, an unexpected error has occurred. Address cannot be empty");
    }
        string phone;
        while (true)
        {
            Console.WriteLine("Enter the person's phone");
            phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit)) break;
            Console.WriteLine("Oh, apparently, an unexpected error has occurred. Phone must contain only numbers.");
        }

        string email;
        while (true)
        {
            Console.WriteLine("Enter the person's email");
            email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains("."))
                break;

            Console.WriteLine("Oh, apparently, an unexpected error has occurred. Invalid email format.");
        }
        int age;
        while (true)
        {
            Console.WriteLine("Enter the person's age");
            if (int.TryParse(Console.ReadLine(), out age)) break;
            Console.WriteLine("Oh, apparently, an unexpected error has occurred. Invalid Age.");
        }

        bool isBestFriend;
        while (true)
        {
            Console.WriteLine("Please specify if he/she is a best friend: 1. Yes, 2. No");
            string input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                isBestFriend = input == "1";
                break;
            }
            Console.WriteLine("Please, just enter 1 or 2");
        }

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
        Console.WriteLine("Contact added successfully.");
    }

    static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames)
    {
        Console.WriteLine("Enter the person's Lastname");
        string search = Console.ReadLine()?.ToLower() ?? "";
        bool found = false;

        foreach (var id in ids)
        {
            if (lastnames[id].ToLower().Contains(search))
            {
                Console.WriteLine($"Found {id} -{names[id]} {lastnames[id]}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No found.");
        }
    }
    static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Enter the person's ID");

        if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.WriteLine("new name");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) names[id] = name;

        Console.WriteLine("new lastname");
        string lastname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastname)) lastnames[id] = lastname;

    string newAddress;
    while (true)
    {
        Console.WriteLine("Enter new address");
        newAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddress)) break;
        Console.WriteLine("Oh, apparently, an unexpected error has occurred. Address cannot be empty");
    }
        addresses[id] = newAddress;

        string phone;
        while (true)
        {
            Console.WriteLine("new phone");
            phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit)) break;
            Console.WriteLine("Oh, apparently, an unexpected error has occurred. Phone must contain only numbers.");
        }
        telephones[id] = phone;

    string newemail;
    while (true)
    {
        Console.WriteLine("Enter new email");
        newemail = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newemail) && newemail.Contains("@") && newemail.Contains("."))
            break;

        Console.WriteLine("Oh, apparently, an unexpected error has occurred. Invalid email format.");
    }
        emails[id] = newemail;

        Console.WriteLine("new age");
        if (int.TryParse(Console.ReadLine(), out int age))
            ages[id] = age;

        Console.WriteLine("1. yes, 2. no");
        string input = Console.ReadLine();
        if (input == "1" || input == "2")
            bestFriends[id] = input == "1";

        Console.WriteLine("Contact updated");
    }
    static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite Id to delete");

        if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contact deteled");
    }