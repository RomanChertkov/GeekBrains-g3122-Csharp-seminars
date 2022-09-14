//=============================================================================
//                       Задача 32
// Напишите программу замена элементов массива: 
// положительные элементы замените на соответствующие отрицательные, 
// и наоборот.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа заменяет элементы массива." +
        "Положительные элементы замените на соответствующие отрицательные," +
        "и наоборот. \n"
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
        $"Исходный массив [{string.Join(',', randomNumbersArray)}] \n" +
        "Изменённый массив " +
        $"[{string.Join(',', InversArray(randomNumbersArray))}] \n"
    );

    ContinueProgram();
}


//Метод возвращает новый массив, в котором элементы противоположны исходному 
int[] InversArray(int[] array)
{
    int[] newArray = array;

    for (int i = 0; i < newArray.Length; i++)
    {
        newArray[i] *= -1;
    }

    return newArray;
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

}
