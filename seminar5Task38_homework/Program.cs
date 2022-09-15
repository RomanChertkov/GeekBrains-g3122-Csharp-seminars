//=============================================================================
//                       Задача 38
// Задайте массив вещественных чисел. 
// Найдите разницу между максимальным и минимальным элементов массива.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа находит разницу между максимальным и минимальным " +
        "элементтами массива, вещественных чисел.\n"
    );

    int arrayLenght =
        ValidateIntNumber(ReadStringFromConsole("Введите длинну массива: "));
    int startRange =
        ValidateIntNumber(ReadStringFromConsole("Введите начало промежутка: "));
    int endRange =
        ValidateRangeEnd(
            startRange,
            ValidateIntNumber(
                ReadStringFromConsole("Введите конец промежутка: ")
            )
    );

    double[] randomNumbersArray =
        GenenerateRandomArray(arrayLenght, startRange, endRange);

    double[] subtractionResult = MaxMinSubtraction(randomNumbersArray);
    PrintResultToConsole(
        $"Исходный массив [{string.Join(' ', randomNumbersArray)}]\n" +
        $"Max элемент = {subtractionResult[0]}.\n" +
        $"Min элемент = {subtractionResult[1]}.\n" +
        "Разницу между максимальным и минимальным элементом массива = " +
        $"{subtractionResult[2]}"

    );

    ContinueProgram();
}


// Методвозвращает  массив из 3-x значений: 
// 0. max элемент массива, 
// 1. min элемент массива  
// 2. разницу между max и min
double[] MaxMinSubtraction(double[] array)
{
    double max = array[0];
    double min = array[0];

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max) max = array[i];
        if (array[i] < min) min = array[i];
    }

    return new double[3] { max, min, max - min };
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


// Метод проверяет верна ли конечная граница интервала
// Если не верна, то метод просит ввести новую границу
// Возвращает верную границу интервала
int ValidateRangeEnd(int startRange, int endRange)
{
    //int validEndRange = endRange;

    while (startRange > endRange)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(
            "Ошибка! " +
            $"Конец интервала должен быть больше начала ( > {startRange}).\n"
        );

        Console.ResetColor();
        Console.Write("Введите конец промежутка ещё раз: ");

        endRange =
            ValidateIntNumber(ReadStringFromConsole(""));
        Console.ResetColor();
    }
    return endRange;
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


// Метод генерирует массив случайных чисел.
// Принимает длинну будущего массива и диапазон для генерации случайного числа.
// Диапазон включает границы [startRange, endRange]
double[] GenenerateRandomArray(int arrayLenght, int startRange, int endRange)
{
    double[] randomArray = new double[arrayLenght];
    Random randomNumber = new Random();
    for (int i = 0; i < arrayLenght; i++)
    {
        // Генерация
        randomArray[i] = Math.Round(
            randomNumber.Next(startRange, endRange) +
            randomNumber.NextDouble(), 3
            );
    }
    return randomArray;
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
