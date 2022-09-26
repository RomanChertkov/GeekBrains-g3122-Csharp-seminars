//=============================================================================
//                       Задача 56
// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа находит строку с наименьшей суммой элементов в матрице.\n"
    );

    Console.WriteLine("Определение размера матрицы");
    int matrixRow =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество строк в матрице : ")
        );
    int matrixColumn =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество столбцов в матрице: ")
        );

    Console.WriteLine("\nОпределение диапазона для генерации случайных чисел");

    int startRange =
        ValidateIntNumber(ReadStringFromConsole("Введите начало диапазона : "));
    int endRange =
        ValidateRangeEnd(
            startRange,
            ValidateIntNumber(
                ReadStringFromConsole("Введите конец диапазона: ")
            )
    );

    Console.WriteLine();
    int[,] randomMatrix =
        GenerateRandomMatrix((matrixRow, matrixColumn), (startRange, endRange));

    Console.WriteLine("Исходная матрица");
    PrintMatrix(randomMatrix);

    PrintResultToConsole(
     "Строка с наименьшей суммой элементов: "
     + $"{RowIndex(SumsElementsInRow(randomMatrix)) + 1} строка"
     );

    ContinueProgram();
}


// получаем строку с min суммой элементов
int RowIndex(int[] sums)
{
    int min = sums[0];
    int index = 0;

    for (int i = 0; i < sums.Length; i++)
    {
        if (sums[i] < min) index = i;
    }

    return index;
}

// Получаем массив сумм элементов строки
int[] SumsElementsInRow(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    int sum = 0;
    int[] sums = new int[rows];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sum += matrix[i, j];
        }
        sums[i] = sum;
        sum = 0;
    }

    return sums;
}

//генерирует 2D массив
int[,] GenerateRandomMatrix(
    (int rows, int columns) matrixSize,
    (int rangeStart, int rangeEnd) valuesRange

    )
{

    int[,] matrix = new int[matrixSize.rows, matrixSize.columns];

    for (int i = 0; i < matrixSize.rows; i++)
    {
        List<int> sortedRow = new List<int>();

        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = new Random()
                    .Next(valuesRange.rangeStart, valuesRange.rangeEnd + 1);
        }
    }
    return matrix;
}


// Вывод матрицы в консоль
void PrintMatrix<T>(T[,] matrix)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "  ");
        }
        Console.WriteLine();
    }

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


//валидация диапазона
int ValidateRangeEnd(int startRange, int endRange)
{

    while (startRange > endRange)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(
            "Ошибка! " +
            $"Конец диапазона должен быть больше начала ( > {startRange}).\n"
        );

        Console.ResetColor();
        Console.Write("Введите конец диапазона ещё раз: ");

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
