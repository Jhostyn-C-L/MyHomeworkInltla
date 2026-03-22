// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;

Console.WriteLine("Welcome to my Personal Agenda");
Console.WriteLine("This work for add and manage your contacts");

//List<string> names = new List<string>();
//List<string> lastNames = new List<string>();
//List<string> emails = new List<string>();
//List<string> address = new List<string>();
//List<int> ages = new List<int>();
//List<bool> favorites = new List<bool>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastName = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, string> address = new Dictionary<int, string>();
Dictionary<int, string> ages = new Dictionary<int, string>();
Dictionary<int, string> favorites = new Dictionary<int, string>();

List<int> ids = new List<int>();
bool running = true;

while (running)
{
    Console.WriteLine("What do you want to do? 1. Add contact, 2. Edit a Contact, 3. Show all Contacts, 4. Search a Contact, 5. Delete a Contact");
    int option = Convert.ToInt32(Console.ReadLine());
    switch(option)
    {
        case 1:
            {
                var id = ids.Count + 1;
                ids.Add(id);

                Console.WriteLine("Type the name of the contact");
                names.Add(id, Console.ReadLine());

                Console.WriteLine("Type the last name of the contact");
                lastName.Add(id, Console.ReadLine());

                Console.WriteLine("Type the email of the contact");
                emails.Add(id,Console.ReadLine());

                Console.WriteLine("Type the address of the contact");
                address.Add(id,Console.ReadLine());

                Console.WriteLine("Type the age of the contact");
                ages.Add(id, Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Is this contact a favorite? 1. Yes, 2. No");
                //int isFavoriteTyped = Convert.ToInt32(Console.ReadLine());
                //bool isFavorite = false;
                // if (isFavoriteTyped == 1)
                //  {
                //       isFavorite = true;
                //   }
                // else if (isFavoriteTyped == 2)
                //  {
                //    isFavorite = false;
                //
                // isFavorite = (isFavoriteTyped == 1)? true : false;
                //  favorites.Add(isFavoriteTyped == 1);  
                favorites.Add(id, Console.ReadLine() == "1");
            }
            break;
        case 2:
            {

                // Console.WriteLine("Type the of the contact you want to edit");
                //var name = Console.ReadLine();
                //var index = names.FindIndex(p => p == name);
                Console.WriteLine("Please type the id of the contact you want to edit");
                var idToEdit = Convert.ToInt32(Console.ReadLine());

             //   var index = idToEdit - 1;

                // 0 a 1
                            // 1 b 2 
                            // 1 c 3
                // 1 d 4
                var name = names[idToEdit];
                Console.WriteLine($"Type the new for: {name}");
                names[idToEdit] = name;

                Console.WriteLine($"Type the new last   name");
                lastName[idToEdit] = lastName;

                Console.WriteLine($"Type the new emails");
                emails[idToEdit] = emails;

                Console.WriteLine($"Type the new lastname");
                address[idToEdit] = address;

                Console.WriteLine($"Type the new lastname");
                ages[idToEdit] = ages;

                Console.WriteLine($"Type the new lastname");
                favorites[idToEdit] = favorites;
            }
            case 3:
            {
                foreach (var id in ids)
                {
                    Console.WriteLine($"Id: {id}, Name: {names}");
                }
            }
                break;
        case 6:
            running = false;
            break;
        default:
        Console.WriteLine("Invalid option, please try again.");
    break;
}
}
Console.WriteLine("Thank you for using my Personal Agenda, see you later!");
Console.ReadKey();


