//=============================================================================
//                       Задача 68
// Напишите программу вычисления функции Аккермана с помощью рекурсии. 
// Даны два неотрицательных числа m и n.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Вычисление функции Аккермана с помощью рекурсии.\n"
    );

    int numberM =
        ValidateIntNumber(ReadStringFromConsole("Введите число M: "));

    int numberN =
        ValidateIntNumber(ReadStringFromConsole("Введите число N: "));

    if (numberN < 0 || numberM < 0)
        PrintError($"Ошибка! Числа N и M  должно быть неотрицательными.");
    else
        PrintResultToConsole(
            "Функция Аккермана " +
            $"A({numberM},{numberN}) = {AckermanFunction(numberM, numberN)}"

        );

    ContinueProgram();
}

// вычислание функции Аккермана
int AckermanFunction(int numberM, int numberN)
{
    if (numberM == 0) return numberN + 1;

    if (numberN == 0) return AckermanFunction(numberM - 1, 1);

    return
        AckermanFunction(numberM - 1, AckermanFunction(numberM, numberN - 1));
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
