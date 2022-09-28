//=============================================================================
//                       Задача 64
// Задайте значение N, M. Напишите программу, 
// которая выведет все натуральные числа в промежутке от N до M. 
// Выполнить с помощью рекурсии.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа выведет все натуральные числа в промежутке от N до M.\n"
    );

    int numberN =
        ValidateIntNumber(ReadStringFromConsole("Введите число N: "));

    int numberM =
        ValidateIntNumber(ReadStringFromConsole("Введите число M: "));

    if (numberN > numberM)
        PrintError($"Ошибка! {numberN} должно быть <= {numberM}.");
    else
        PrintResultToConsole(
            $"Числа от {numberN} до {numberM} \n"
            + RangeGenerate(numberN, numberM)
        );

    ContinueProgram();
}

//Выведет числа от N до M
string RangeGenerate(int numberN, int numberM)
{
    if (numberN == numberM) return numberM + "";
    return numberN + " " + RangeGenerate(numberN + 1, numberM);
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
