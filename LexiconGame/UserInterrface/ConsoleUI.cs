internal class ConsoleUI
{
    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
   
}