//=============================================================================
//                                     Задача 10
// Напишите программу, которая принимает на вход трёхзначное число 
// и на выходе показывает вторую цифру этого числа.
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа принимает на вход трёхзначное число \n"+
    "и на выходе показывает вторую цифру этого числа.\n"
);

string number;
char secondDigit = '0';
bool checkResult = false;

ReadData();
CalculateData();
PrintData();

// Считывает число от пользователя
void ReadData () {
    Console.Write("Введите число: ");
    number = Console.ReadLine() ?? "";
}

// Находит вторую цифру
void CalculateData(){
    if (number.Length == 3 ) 
    {
        char[] digitArray = number.ToCharArray();
        secondDigit = digitArray[1];
        checkResult = true;
    }
}

//Выводит результат в консоль
void PrintData(){
    Console.WriteLine(
        checkResult 
        ? $"Вторая цифра числа {number} = {secondDigit}"
        : $"Число должно быть трёхзначным"
    );
}
