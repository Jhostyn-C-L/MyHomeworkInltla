Console.WriteLine("Please enter a number to check if it is even or odd.");
while (true)
{
    try
    {
        double number = Convert.ToDouble(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("It is even");
        }
        else
        {
            Console.WriteLine("It is odd");
        }
        break;
    }
    catch (FormatException)
    { Console.WriteLine("That is not number valid, please try again"); }
    catch (OverflowException)
    {
        Console.WriteLine("Sorry, that number is very long, try again");
    } 
    catch (Exception ex) 
    { Console.WriteLine("Oh, apparently, an unexpected error has occurred." + ex.Message); }
}


