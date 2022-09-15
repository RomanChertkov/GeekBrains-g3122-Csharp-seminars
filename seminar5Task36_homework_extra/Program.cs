//=============================================================================
//                       Задача 36*
// Задайте одномерный массив, заполненный случайными числами. 
// Найдите сумму элементов, стоящих на нечётных позициях.
// *Найдите все пары в массиве и выведите пользователю
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа находит сумму элементов d массиве, " +
        "стоящих на нечётных позициях и все пары в массиве.\n"
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
        "Сумма элементов на нечётных позициях = " +
        $"{NotEvenIndexSum(randomNumbersArray)}\n\n" +
        "Пары элементов " +
        "(парой считаются элемент и первый равный ему элемент):\n" +
        GetPairsInArray(randomNumbersArray) +
        "\nВсе пары элементов:\n" +
        GetAllPairs(randomNumbersArray)
    );

    ContinueProgram();
}


// Метод возвращает словарь строк вида a [b,c] 
// где  a-элемент, b- индекс элемента, а c- индекс его пары
// парой считаются элемент и первый равный ему элемент.

string GetPairsInArray(int[] array)
{
    Dictionary<int, string> pairsDictionary = new Dictionary<int, string> { };
    List<int> matchIndexes = new List<int> { };
    //  int[] matchIndexArray = new int[10];
    string resultString = string.Empty;
    for (int i = 0; i < array.Length; i++)
    {
        if (matchIndexes.Contains(i)) continue;

        for (int j = i + 1; j < array.Length; j++)
        {
            if (matchIndexes.Contains(j)) continue;

            if (array[i] == array[j])
            {
                resultString +=
                    $"Для элемента {array[i]} пара(индекс,индекс): [{i},{j}]\n";

                matchIndexes.Add(j);
                break;
            }

        }
    }

    return resultString;
}


// Метод возвращает все пары 
string GetAllPairs(int[] array)
{
    string resultString = string.Empty;

    for (int i = 0; i < array.Length; i++)
    {

        for (int j = i + 1; j < array.Length; j++)
        {

            if (array[i] == array[j])
            {
                resultString +=
                    $"Для элемента {array[i]} пара [индекс,индекс]:[{i},{j}]\n";

            }

        }
    }
    return resultString;
}


// Метод возвращает сумму элементов на нечётных позициях
int NotEvenIndexSum(int[] array)
{
    int sum = 0;

    for (int i = 1; i < array.Length; i = i + 2)
    {
        sum += array[i];
    }

    return sum;
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
