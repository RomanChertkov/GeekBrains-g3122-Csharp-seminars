//=============================================================================
//                       Задача 20* (Сделать метод загрузки точек)
// Напишите программу, которая принимает на вход координаты двух точек 
// и находит расстояние между ними в 3D пространстве. 
// на вход строка A(x,y,z);B(x,y,z);
//=============================================================================

ProgramDescription(
    "Программа принимает на вход координаты двух точек " +
    "и находит расстояние между ними в 3D пространстве.\n"
);

string[] coordinates = ParsePointsFromString(
    ReadStringFromConsole(
        "Введите кординаты точек A и B в формате A(x,y,z);B(x,y,z) : "
    )
);


int[] pointA = PointCoordinates(coordinates[0]);
int[] pointB = PointCoordinates(coordinates[1]);



PrintResultToConsole(
   "Расстояние между точками " +
   $"А({pointA[0]},{pointA[1]},{pointA[2]}) и " +
   $"B({pointB[0]},{pointB[1]},{pointA[2]}) " +
   $"в 3D пространстве = {DistanceBetween2Points(pointA, pointB)}"
);

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

//Принимает строку и получает многомерный массив координат точек
string[] ParsePointsFromString(string pointsString)
{
    string[] points = pointsString.Split(new char[] { ';' });
    return points;
}

int[] PointCoordinates(string point)
{
    string[] coortdinateArrayString =
        point.
            Remove(0, 1).
            Trim(new char[] { '(', ')' }).
            Split(new char[] { ',' });

    int[] coortdinateArrayInt = new int[3];

    for (int i = 0; i < coortdinateArrayString.Length; i++)
    {
        coortdinateArrayInt[i] = int.Parse(coortdinateArrayString[i]);
    }

    return coortdinateArrayInt;
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
