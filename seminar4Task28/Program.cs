//=============================================================================
//                       Задача 28
// Напишите программу, которая принимает на вход число N
// и выдаёт произведение чисел от 1 до N.
//=============================================================================

ProgramDescription(
    "Напишите программу, которая принимает на вход число N " +
    "и выдаёт произведение чисел от 1 до N.\n"
);

int number = ReadNumberFromConsole("Введите число N: ");

PrintResultToConsole(
   $"Произведение чисел от 1 до {number} = {Factorial(number)}"
);
// Тесты скорости выполнения методов
SpeedTest(() => FactorialRecursion(number), "Метод FactorialRecursion");
SpeedTest(() => Factorial(number), "Метод Factorial");




// Метод вычисление факторил числа через цикл
// на вход принимат число number
// возвращает произведение чисел от 1 до number
long Factorial(int number)
{
    long factorial = 1;
    for (int i = 1; i <= number; i++)
    {
        factorial *= i;
    }
    return factorial;
}

// Метод вычисление факторил числа через рекурсию
// на вход принимат число number
// возвращает произведение чисел от 1 до number
long FactorialRecursion(int number)
{
    if (number == 1) return 1;

    return number * FactorialRecursion(number - 1);
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

// Метод подсчитывает время выполнения переданного в аргументах метода
// примает другой метод и описание, которое будет выведено в консоль
void SpeedTest(Action function, string description)
{
    DateTime startTime = DateTime.Now;

    function();

    Console.WriteLine();
    Console.WriteLine(
        $"{description} отработал за  {DateTime.Now - startTime}"
    );
}
