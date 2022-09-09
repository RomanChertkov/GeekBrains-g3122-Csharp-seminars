//=============================================================================
//                       Задача 21
// Напишите программу, которая принимает на вход координаты двух точек 
// и находит расстояние между ними в 3D пространстве.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход координаты двух точек " +
    "и находит расстояние между ними в 3D пространстве.\n"
);

int[] pointA ={
    ReadNumberFromConsole("Введите координату x точки A: "),
    ReadNumberFromConsole("Введите координату y точки A: "),
    ReadNumberFromConsole("Введите координату z точки A: ")

};
int[] pointB ={
    ReadNumberFromConsole("Введите координату x точки B: "),
    ReadNumberFromConsole("Введите координату y точки B: "),
    ReadNumberFromConsole("Введите координату z точки B: ")
};


PrintResultToConsole(
   "Расстояние между точками" +
   $"А({pointA[0]},{pointA[1]}) и B({pointB[0]},{pointB[1]}) " +
   $"в 3D пространстве = {DistanceBetween2Points(pointA, pointB)}"
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

//Вычисление расстояния между 2 точками
double DistanceBetween2Points(int[] pointA, int[] pointB)
{

    int sum = 0;

    for (int i = 0; i < pointA.Length; i++)
    {
        sum += (int)Math.Pow(pointB[i] - pointA[i], 2);
    }

    return Math.Round(Math.Sqrt(sum), 2);
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
