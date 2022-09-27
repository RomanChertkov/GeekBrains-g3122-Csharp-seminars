//=============================================================================
//                       Задача 62
// Напишите программу, которая заполнит спирально произвольный массив.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа заполнит спирально произвольный массив.\n"
    );

    Console.WriteLine($"Определение размера матрицы");
    int matrixRow =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество строк в матрице : ")
        );
    int matrixColumn =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество столбцов в матрице: ")
        );


    PrintMatrix(FillSpiralMatrix(matrixRow, matrixColumn), "Исходная матрица");

    //FillSpiralMatrix(matrixRow, matrixColumn);

    ContinueProgram();
}


//Заполняет строку 
void FillMatrixRow(int[,] matrix, int startPosition, ref int number)
{
    int totalRows = matrix.GetLength(0);
    int totalCols = matrix.GetLength(1);

    for (int j = startPosition; j < totalCols - startPosition; j++)
    {

        if (number > totalRows * totalCols) break;
        matrix[startPosition, j] = number;

        number++;
    }
}


//Заполняет строку в обратном порядке
void FillMatrixRowRevers(int[,] matrix, int startPosition, ref int number)
{
    int totalRows = matrix.GetLength(0);
    int totalCols = matrix.GetLength(1);

    int currentRow = totalRows - startPosition - 1;
    int startColPosition = totalCols - startPosition - 2;

    while (startColPosition >= startPosition)
    {
        if (number > totalRows * totalCols) break;

        matrix[currentRow, startColPosition] = number;
        number++;

        startColPosition--;
    }
}


//Заполняет столбец
void FillMatrixColumn(int[,] matrix, int startPosition, ref int number)
{
    int totalRows = matrix.GetLength(0);
    int totalCols = matrix.GetLength(1);

    for (int i = startPosition + 1; i < totalRows - startPosition; i++)
    {
        if (number > totalRows * totalCols) break;

        matrix[i, totalCols - startPosition - 1] = number;
        number++;
    }
}


//Заполняет столбец в обратном порядке
void FillMatrixColumnRevers(int[,] matrix, int startPosition, ref int number)
{
    int totalRows = matrix.GetLength(0);
    int totalCols = matrix.GetLength(1);

    int currentRow = totalRows - startPosition - 2;

    while (currentRow > startPosition)
    {
        if (number > totalRows * totalCols) break;

        matrix[currentRow, startPosition] = number;
        number++;

        currentRow--;
    }
}


//Заполнение матрицы по спирали
int[,] FillSpiralMatrix(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];

    int matrixElementsNumber = rows * cols;
    int number = 1;

    int startPosition = 0;

    while (number <= matrixElementsNumber)
    {

        FillMatrixRow(matrix, startPosition, ref number);
        FillMatrixColumn(matrix, startPosition, ref number);
        FillMatrixRowRevers(matrix, startPosition, ref number);
        FillMatrixColumnRevers(matrix, startPosition, ref number);
        startPosition++;
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
            Console.Write(matrix[i, j] + "\t");
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
