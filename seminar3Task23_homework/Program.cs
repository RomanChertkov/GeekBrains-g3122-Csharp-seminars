//=============================================================================
//                       Задача 23
// Напишите программу, которая принимает на вход число (N) 
// и выдаёт таблицу кубов чисел от 1 до N.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход принимает на вход число (N)  " +
    "и выдаёт таблицу кубов чисел от 1 до N.\n"
);

int number = ReadNumberFromConsole("Введите число N: ");

string[] result = GetCubesOfN(number);

PrintResultToConsole(
    $"Таблица кубов числа {number}\n" +
    $"{result[0]} \n{result[1]} "
);

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

//Метод возвращает массив строк. 
// 0 элемент - это строка из чисел от 1 до N 
// 1 элемент - это  строка из квадратов чисел от 1 до N
string[] GetCubesOfN(int number)
{

    string numbersString = string.Empty;
    string cubesString = string.Empty;

    for (int i = 1; i <= number; i++)
    {
        numbersString += i.ToString() + "\t";
        cubesString += ((int)Math.Pow(i, 3)).ToString() + "\t";
    }

    return new string[2] { numbersString, cubesString };
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
