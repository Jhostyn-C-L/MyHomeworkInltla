Console.WriteLine("Please, write a number");
int number = Convert.ToInt32(Console.ReadLine());
if (number % 2 == 0)
{
    Console.WriteLine("It is even");
}   else
{
    Console.WriteLine("It is odd");
}
Console.WriteLine(number);