//=============================================================================
// Напишите программу, которая на вход принимает два числа 
// и выдаёт, какое число большее, а какое меньшее.
//=============================================================================

Console.WriteLine("Найти максимальное из 2-х чисел");

Console.Write("Введите первое число: ");
int firstNumber = int.Parse(Console.ReadLine() ?? "");

Console.Write("Введите второе число: ");
int secondNumber = int.Parse(Console.ReadLine() ?? "");

if (firstNumber > secondNumber) 
    Console.WriteLine("Число " + firstNumber + " больше числа " +secondNumber);
else 
    Console.WriteLine("Число " + secondNumber + " больше числа " +firstNumber);
