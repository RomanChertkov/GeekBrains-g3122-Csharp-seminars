//=============================================================================
//                       Задача 24
// Напишите программу, которая принимает на вход число (А) 
// и выдаёт сумму чисел от 1 до А.
//=============================================================================


ProgramDescription(
    "Напишите программу, которая принимает на вход число (А) " +
    "и выдаёт сумму чисел от 1 до А.\n"
);

string number = ReadStringFromConsole("Введите число А: ");

PrintResultToConsole(
   $"Сумма чисел числа {number} = {sumNumbers(number)}"
);


// Подсчет суммы чисел числа 
// Метод принимает число
// и возвращает сумму чилел этого числа
int sumNumbers(string number)
{
    int sum = 0;

    for (int i = 0; i < number.Length; i++)
    {
        sum += int.Parse(number[i].ToString());
    }

    return sum;
}

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}


// Получение числа из консоли
string ReadStringFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return (Console.ReadLine() ?? "").Trim();
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
