//=============================================================================
//                                  Задача 11
// Напишите программу, которая выводит случайное трёхзначное число 
// и удаляет вторую цифру этого числа.
//=============================================================================

/*
Альтернативный метод

int del2Digit (int number) {
    int firstDigit = number / 100;
    int secondDigit = number % 10;
    return firstDigit*10+secondDigit;
}

*/

int del2Digit (int number) {
    char[] digitArray = number.ToString().ToCharArray();
    int lastDigitIndex = digitArray.Length-1;
    return int.Parse($"{digitArray[0]}{digitArray[lastDigitIndex]}");
}

Console.Clear();
Console.WriteLine(
    "Программа выводит случайное трёхзначное число и удаляет вторую цифру этого числа.\n"
);

int randomNumber = new Random().Next(100, 1000);
Console.WriteLine($"Случайное число: {randomNumber}");

Console.WriteLine($"Новое число без 2-й цифры: {del2Digit(randomNumber)}");
