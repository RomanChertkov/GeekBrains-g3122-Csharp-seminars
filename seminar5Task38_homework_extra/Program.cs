//=============================================================================
//                       Задача 38*
// Задайте массив целых чисел
// Отсортируйте массив методом вставки и методом подсчета, 
// а затем найдите разницу между первым и последним элементом. 
// Сравнить скорость работы алгоритмов между собой. 
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа сортирует заданный массив " +
        "методом вставки и методом подсчета, " +
        "а затем находит разницу между первым и последним элементом.\n"
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


    int[] insertionSort = InsertionSort(randomNumbersArray);

    int[] sortByCountingArray = SortByCounting(randomNumbersArray);

    PrintResultToConsole(
        $"Исходный массив [{string.Join(',', randomNumbersArray)}]\n" +
        $"Методом вставки [{string.Join(',', insertionSort)}]\n" +
        $"Метод подсчета [{string.Join(',', sortByCountingArray)}]\n"
    );

    //Сортировка методом подсчета работает быстрее
    SpeedTest(() => InsertionSort(randomNumbersArray), "Метод InsertionSort");
    SpeedTest(() => SortByCounting(randomNumbersArray), "Метод SortByCounting");


    ContinueProgram();
}



//Метод сортирует массив методом вставки
int[] InsertionSort(int[] sourceArray)
{
    int[] array = new int[sourceArray.Length];

    Array.Copy(sourceArray, array, sourceArray.Length);

    for (int i = 1; i < array.Length; i++)
    {
        for (int j = i - 1; j >= 0; j--)
        {
            if (array[j] > array[j + 1])
            {
                int tmp = array[j + 1];
                array[j + 1] = array[j];
                array[j] = tmp;
            }
        }
    }
    return array;
}


//Метод сортирует массив методом вставки подсчета
int[] SortByCounting(int[] sourceArray)
{
    int[] array = new int[sourceArray.Length];
    Array.Copy(sourceArray, array, sourceArray.Length);

    int max = array.Max();
    // массив нулей
    int[] countArray = new int[max + 1];

    for (int i = 0; i < array.Length; i++)
    {
        countArray[array[i]]++;
    }


    int idx = 0;
    for (int i = 0; i <= max; i++)
    {

        while (countArray[i]-- > 0)
        {
            array[idx++] = i;
        }
    }

    return array;
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

void SpeedTest(Action function, string description)
{
    DateTime startTime = DateTime.Now;

    function();

    Console.WriteLine();
    Console.WriteLine(
        $"{description} отработал за  {DateTime.Now - startTime}"
    );
}
