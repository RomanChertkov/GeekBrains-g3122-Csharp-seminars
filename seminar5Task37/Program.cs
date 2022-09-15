//=============================================================================
//                       Задача 37
// Найдите произведение пар чисел в одномерном массиве. 
// Парой считаем первый и последний элемент, второй и предпоследний и т.д. 
// Результат запишите в новом массиве.
// Например:
// [1 2 3 4 5] -> 5 8 3
// [6 7 3 6] -> 36 21
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа находит произведение пар чисел в одномерном массиве. " +
        "Парой считаем первый и последний элемент, " +
        "второй и предпоследний и т.д."
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


    PrintResultToConsole(
        $"Исходный массив [{string.Join(',', randomNumbersArray)}]\n" +
        "Массив произведений пар " +
        $"[{string.Join(',', pairsMultiplication(randomNumbersArray))}]\n"
      );

    ContinueProgram();
}

// Метод перемножает пары в массиве 
// возвращает массив пар
int[] pairsMultiplication(int[] array)
{
    int arrayLength = array.Length;
    int newArrayLenght = arrayLength / 2;

    bool isEven = IsEven(arrayLength);

    // Если количество элементов не чётное, то
    // включаем в массив центральный элемент
    // обусловлено примером к задаче
    // [1 2 3 4 5] -> 5 8 3
    // [6 7 3 6] -> 36 21
    if (!isEven) newArrayLenght++;

    int[] multiplicationArray = new int[newArrayLenght];

    for (int i = 0; i < arrayLength / 2; i++)
    {
        multiplicationArray[i] = array[i] * array[array.Length - 1 - i];
    }

    // Включаем в массив центральный элемент
    if (!isEven)
        multiplicationArray[newArrayLenght - 1] = array[newArrayLenght - 1];

    return multiplicationArray;
}


// Метод проверяет является ли число чётным
bool IsEven(int number)
{
    return (number % 2 == 0) ? true : false;
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
