//===========================================================================
//                               Задача 9
// Напишите программу, которая выводит случайное число из отрезка [10,99]
// и показывает наибольшую цифру числа
//===========================================================================


/*
System.Random randomNumber = new System.Random();
int number =  randomNumber.Next(10,100);
 */

char maxDigit (int number) {
    char[] digitArray = number.ToString().ToCharArray();
    return  ((int)digitArray[0] > (int)digitArray[1]) ? digitArray[0] : digitArray[1];
    
 }

Console.Clear();
Console.WriteLine(
    "Программа выводит случайное число из отрезка [10,99] и показывает наибольшую цифру числа \n"
);

int randomNumber = new Random().Next(10,100); 
Console.WriteLine($"Случайное число: {randomNumber}");

Console.WriteLine("Наибольшая цифра: " + maxDigit(randomNumber));

