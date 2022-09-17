//=============================================================================
//                       Задача 42
// Напишите программу, которая будет преобразовывать 
// десятичное число в двоичное.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа преобразовывает десятичное число в двоичное. \n"
    );

    int number =
        ValidateIntNumber(ReadStringFromConsole("Введите число: "));

    PrintResultToConsole(
        $"Десятичное число {number} = {Convert.ToString(number, 2)} " +
        "в двоичной системе."
    );

    ContinueProgram();
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
