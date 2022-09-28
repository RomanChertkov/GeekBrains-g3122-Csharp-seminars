//=============================================================================
//                       Задача 69
// Напишите программу, которая принимает на вход два числа А и B 
// и возводит A в натуральную степень B с помощью рекурсии.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа принимает на вход два числа А и B "
        + "и возводит A в натуральную степень B.\n"
    );

    int numberA =
        ValidateIntNumber(ReadStringFromConsole("Введите число A: "));

    int numberB =
        ValidateIntNumber(ReadStringFromConsole("Введите число B: "));

    PrintResultToConsole(
        $"{numberA} в степени {numberB} = {PowRec(numberA, numberB)}"
    );

    ContinueProgram();
}


// A в степени B
int PowRec(int numberA, int numberB)
{
    if (numberB == 1) return numberA;
    return numberA * PowRec(numberA, numberB - 1);
}

// Более быстрый метод
// int MyPow(int number, int pow)
// {
//     if (pow == 2)
//     {
//         return number * number;
//     }
//     if (pow == 1)
//     {
//         return number;
//     }

//     if (pow % 2 == 0)
//     {
//         return MyPow(number, pow / 2) * MyPow(number, pow / 2);
//     }
//     else
//     {
//         return MyPow(number, pow / 2) * MyPow(number, pow / 2 + 1);
//     }

// }

// Метод проверяет ввел ли пользователь в консоли число
// Если ввёл не число, то  метод просит ввести число
// Возвращает число
int ValidateIntNumber(string number)
{
    int cleanNumber = 0;
    while (!int.TryParse(number, out cleanNumber))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.WriteLine("Ошибка! Вы ввели не число.\n");

        Console.ResetColor();
        Console.Write("Введите целое число: ");

        number = Console.ReadLine() ?? "";

    }

    Console.ResetColor();

    return cleanNumber;

}


//Метод зпрашивает у пользователя разрешение на выход или продолжение
void ContinueProgram()
{
    //Изменение цвета вывода в консоль 
    Console.ForegroundColor = ConsoleColor.DarkYellow;

    Console.WriteLine();
    Console.WriteLine(
        "Для выхода из программы нажмите клавишу Escape (Esc). \n" +
        "Для повторного запуска нажмите любую клавишу."
    );

    if (Console.ReadKey().Key == ConsoleKey.Escape) endApp = true;

    Console.ResetColor();
    Console.WriteLine();
}


//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}


// Получение строки из консоли
string ReadStringFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return (Console.ReadLine() ?? "").Trim();
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();
    Console.WriteLine(result);

    Console.ResetColor();
}
