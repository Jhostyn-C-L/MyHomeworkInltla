Console.WriteLine("Please enter a number to check if it is even or odd.");
int number = Convert.ToInt32(Console.ReadLine());
if (number % 2 == 0)
{
    Console.WriteLine("It is even");
}   else
{
    Console.WriteLine("It is odd");
}
Console.WriteLine(number);