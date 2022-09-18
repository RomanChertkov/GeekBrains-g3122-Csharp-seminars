//=============================================================================
//                       Задача 41
// Пользователь вводит с клавиатуры M чисел. Посчитайте, 
// сколько чисел больше 0 ввёл пользователь.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа найдёт сколько чисел больше 0 ввёл пользователь.\n"
    );
    int number =
       ValidateIntNumber(ReadStringFromConsole("Введите количество чисел: "));

    PrintResultToConsole(
        $"Количество чисел > 0 = {CountPositiveNumbers(number)} "
    );

    ContinueProgram();

}


// Метод просит у пользователя ввести n чисел в консоли
// возвращает количество чисел >0

int CountPositiveNumbers(int countNumber)
{
    int positiveNumbersCount = 0;
    for (int i = 0; i < countNumber; i++)
    {
        int number =
            ValidateIntNumber(ReadStringFromConsole("Введите число: "));
        if (number > 0) positiveNumbersCount++;
    }

    return positiveNumbersCount;
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
