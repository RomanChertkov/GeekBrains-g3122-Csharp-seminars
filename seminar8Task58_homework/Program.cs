//=============================================================================
//                       Задача 58
// Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц. 
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа находит произведение двух матриц.\n"
    );

    var matrix1 = ReadMatrix(1);
    var matrix2 = ReadMatrix(2);

    int[,] randomMatrix1 =
        GenerateRandomMatrix(
            (matrix1.row, matrix1.column),
            (matrix1.startRange, matrix1.endRange)
        );

    int[,] randomMatrix2 =
       GenerateRandomMatrix(
           (matrix2.row, matrix2.column),
           (matrix2.startRange, matrix2.endRange)
       );

    int[,] resultMatrix = MatrixMultiplication(randomMatrix1, randomMatrix2);

    PrintMatrix(randomMatrix1, "Исходная матрица 1");
    PrintMatrix(randomMatrix2, "Исходная матрица 2");

    if (IsMultiplicationPosible(randomMatrix1, randomMatrix2))
        PrintMatrix(resultMatrix, "Произведение матрицы 1 и 2");
    else
        PrintError(
            "Ошибка! Матрицы не возможно перемножить."
        );

    ContinueProgram();
}


// Вывод ошибки в консоль
void PrintError(string errorText)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine();
    Console.WriteLine(errorText);
    Console.ResetColor();
}

//Возможно ли умножение
bool IsMultiplicationPosible(int[,] matrix1, int[,] matrix2)
{
    return (matrix1.GetLength(1) == matrix2.GetLength(0))
            && (matrix1.GetLength(1) <= matrix2.GetLength(1));
}


// произведение матриц
int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int rows = matrix1.GetLength(0);
    int columns = matrix1.GetLength(1);
    int[,] resultMatrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < rows; k++)
            {
                resultMatrix[i, j] += matrix1[i, k] * matrix2[j, k];
            }
        }
    }

    return resultMatrix;
}


// Ввод данных для генерации матрицы
(int row, int column, int startRange, int endRange) ReadMatrix(int number = 1)
{
    Console.WriteLine($"Определение размера матрицы {number}");
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

    return (matrixRow, matrixColumn, startRange, endRange);
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
        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = new Random()
                    .Next(valuesRange.rangeStart, valuesRange.rangeEnd + 1);
        }
    }
    return matrix;
}


// Вывод матрицы в консоль
void PrintMatrix<T>(T[,] matrix, string title)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine(title);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
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
