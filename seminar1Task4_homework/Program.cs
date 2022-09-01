//=============================================================================
// Напишите программу, которая принимает на вход три числа 
// и выдаёт максимальное из этих чисел.
//=============================================================================

Console.Clear();
Console.WriteLine("Найти максимальное из 3-х чисел");

Console.Write("Введите 1-е число: ");
int firstNumber = int.Parse(Console.ReadLine() ?? "");

Console.Write("Введите 2-е число: ");
int secondNumber = int.Parse(Console.ReadLine() ?? "");

Console.Write("Введите 3-е число: ");
int thirdNumber = int.Parse(Console.ReadLine() ?? "");


if (firstNumber > secondNumber) 
{
    if (firstNumber > thirdNumber)  
        Console.WriteLine($"Число {firstNumber} максимальное");
    else 
        Console.WriteLine($"Число {thirdNumber} максимальное");
}
else 
{
    if (secondNumber > thirdNumber) 
        Console.WriteLine($"Число {secondNumber} максимальное");
    else 
        Console.WriteLine($"Число {thirdNumber} максимальное");
}
