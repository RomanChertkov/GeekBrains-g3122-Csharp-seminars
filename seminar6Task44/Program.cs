//=============================================================================
//                       Задача 44
// Не используя рекурсию, выведите первые N чисел Фибоначчи. 
// Первые два числа Фибоначчи: 0 и 1.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа выводит первые N чисел Фибоначчи. \n"
    );

    int number =
        ValidateIntNumber(ReadStringFromConsole("Введите число: "));

    if (number > 0)
    {
        PrintResultToConsole(
            $"Числа Фибоначчи.  Первые {number} \n" +
            $"{string.Join(' ', FiboNumbers(number))}"
        );

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.WriteLine();
        Console.WriteLine("Число должно быть > 0");

        Console.ResetColor();

    }

    ContinueProgram();
}

//Метод выводит первые N чисел Фибоначчи
// принимает N и выводит массив с числами Фибоначчи
int[] FiboNumbers(int number)
{
    int[] fiboArray = new int[number];

    if (number > 1) fiboArray[1] = 1;


    for (int i = 2; i < fiboArray.Length; i++)
    {
        fiboArray[i] = fiboArray[i - 1] + fiboArray[i - 2];
    }

    return fiboArray;
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
