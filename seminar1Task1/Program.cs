//=============================================================================
//Напишите программу, которая на вход принимает два числа и проверяет,
// является ли первое число квадратом второго
//=============================================================================

Console.WriteLine("Является ли первое число квадратом второго?");

Console.WriteLine("Введите первое число: ");
int firstNumber = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Введите второе число: ");
int secondNumber = int.Parse(Console.ReadLine() ?? "");

string compareResult =
    Math.Sqrt(firstNumber) == secondNumber ? " является" : " не является";

Console.WriteLine(
    "Первое число " + firstNumber + compareResult +
    " квадратом второго числа " + secondNumber
);
