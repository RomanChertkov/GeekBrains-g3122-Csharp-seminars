//=============================================================================
//                       Задача 29*
// Написать программу которая из имен через запятую выберет случайное
// имя и выведет в терминал
//=============================================================================

ProgramDescription(
    "Напишите программу, которая из имен через запятую выберет случайное " +
    "имя и выведет в терминал.\n"
);

string names = ReadStringFromConsole("Введите список имен через запятую: ");

if (names.Equals(string.Empty))
{
    Console.WriteLine("Сегодня все останутся без пива :(");
    Environment.Exit(0);
}

PrintResultToConsole(
   $"Совершенно случайно за пивом бежит {RandomName(names)} :)"
);


// МЕТОДЫ

// Метод парсит строку и выводит случайное имя
string RandomName(string stringWithNames)
{
    string[] namesList = stringWithNames.Split(',');
    return namesList[new Random().Next(0, namesList.Length)].Trim();
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
    Console.WriteLine();
    Console.WriteLine(result);
}
