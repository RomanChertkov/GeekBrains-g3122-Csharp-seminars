//=============================================================================
//                       Задача 66
// Задайте значения M и N. 
// Напишите программу, которая найдёт сумму натуральных элементов 
// в промежутке от M до N.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа найдёт сумму натуральных элементов в промежутке от M до N.\n"
    );

    int numberN =
        ValidateIntNumber(ReadStringFromConsole("Введите число N: "));

    int numberM =
        ValidateIntNumber(ReadStringFromConsole("Введите число M: "));

    if (numberN > numberM)
        PrintError($"Ошибка! {numberN} должно быть <= {numberM}.");
    else
        PrintResultToConsole(
            "Cумма натуральных элементов в промежутке (включая значения) "
            + $"от {numberN} до {numberM} = " + RangeSum(numberN, numberM)
        );

    ContinueProgram();
}

//Cумма натуральных элементов в промежутке от N до M
int RangeSum(int numberN, int numberM)
{
    if (numberN == numberM) return numberM;
    return numberN + RangeSum(numberN + 1, numberM);
}


// Вывод ошибки в консоль
void PrintError(string errorText)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine();
    Console.WriteLine(errorText);
    Console.ResetColor();
}


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
