//=============================================================================
//                       Задача 
// Задайте массив из 12 элементов, заполненный случайными числами 
// из промежутка [-9, 9].
// Найдите сумму отрицательных и положительных элементов массива.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Задайте массив из 12 элементов, заполненный случайными числами " +
        "из промежутка [-9, 9]." +
        "Найдите сумму отрицательных и положительных элементов массива.\n"
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


    int[] randomNumbersArray =
        GenenerateRandomArray(arrayLenght, startRange, endRange);

    int[] sumsArray = PositiveNegativeSums(randomNumbersArray);

    PrintResultToConsole(
       $"В массиве [{string.Join(',', randomNumbersArray)}] \n" +
       $"сумма положительных чисел равна {sumsArray[0]}, " +
       $" сумма отрицательных равна {sumsArray[1]}."
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
int[] GenenerateRandomArray(int arrayLenght, int startRange, int endRange)
{
    int[] randomArray = new int[arrayLenght];
    Random randomNumber = new Random();
    for (int i = 0; i < arrayLenght; i++)
    {
        randomArray[i] = randomNumber.Next(startRange, endRange + 1);
    }
    return randomArray;
}


// Метод считает суммы положительных и отрицательных чисел
// Возвращает первым элементом массива сумму положительных чисел, 
// а вторым элементом сумму отрицательных чисел
int[] PositiveNegativeSums(int[] array)
{
    int positiveNumberSum = 0;
    int negativeNumberSum = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] >= 0)
            positiveNumberSum += array[i];
        else
            negativeNumberSum += array[i];

    }

    return new int[2] { positiveNumberSum, negativeNumberSum };
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

}
