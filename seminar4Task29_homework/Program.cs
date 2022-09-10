//=============================================================================
//                       Задача 29
// Напишите программу, которая задаёт массив из 8 элементов 
// и выводит их на экран. Ввести с клавиатуры длину массива 
// и диапазон значений элементов
//=============================================================================

ProgramDescription(
    "Напишите программу, которая выводит массив из 8 элементов, " +
    "и выводит их на экран. \n"
);

int arrayLenght = ReadNumberFromConsole("Ведите размер массива: ");

int[] range =
    {
        ReadNumberFromConsole("Ведите начало диапазона случайных значений: "),
        ReadNumberFromConsole("Ведите конец диапазона случайных значений: ")
    };


PrintResultToConsole(
    $"Массив из {arrayLenght} случайных чисел в диапазоне " +
    $"[{range[0]},{range[1]}] \n" +
    $"[{string.Join(",", GenerateRandomArray(arrayLenght, range[0], range[1]))}]"
);



/*
Метод заполняет массив случайными числами 
в заданном диапазоне включая эти значения.
Принимает длину будущего массива,
начало и конец диапазона случайных значений 
*/
int[] GenerateRandomArray(int arrayLenght, int startRange, int finishRange)
{
    int[] randomArray = new int[arrayLenght];
    Random randomNumber = new Random();

    for (int i = 0; i < arrayLenght; i++)
    {
        randomArray[i] = randomNumber.Next(startRange, finishRange + 1);
    }

    return randomArray;
}



//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}

// Получение числа из консоли
int ReadNumberFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return int.Parse(Console.ReadLine() ?? "0");
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
