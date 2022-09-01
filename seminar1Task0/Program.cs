//=========================================================================
// Напишите программу, которая на вход принимает число и выдаёт его квадрат 
// (число умноженное на само себя).
//=========================================================================

Console.WriteLine("Возведение числа в квадрат");
Console.Write("Введите число: ");

string inputNumber = Console.ReadLine()??"";

int number = int.Parse(inputNumber);
// int squareNumber  = number * number;
int squareNumber = (int)Math.Pow(number, 2);  

Console.WriteLine("Квадрат числа " + inputNumber + " = " + squareNumber);
