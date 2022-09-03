//=============================================================================
//                       Задача 15 * (Решить используя Dictionary)
// Напишите программу, которая принимает на вход цифру, 
// обозначающую день недели, и проверяет, является ли этот день выходным.
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа принимает на вход цифру, обозначающую день недели, "+
    "и проверяет, является ли этот день выходным.\n"
);

int dayNumber;
string result = "";
bool checkNumber = false;

Dictionary<int, string> daysOfWeek = new Dictionary<int, string>()
{
    [1] = "Понедельник - будний день",
    [2] = "Вторник - будний день",
    [3] = "Среда - будний день",
    [4] = "Четверг - будний день",
    [5] = "Пятница - будний день",
    [6] = "Суббота - выходной день",
    [7] = "Воскресенье - выходной день"
};

ReadData();
CalculateData();
PrintData();

// Считывает число от пользователя
void ReadData () {
    Console.Write("Введите число: ");
    dayNumber = int.Parse( Console.ReadLine() ?? "" );
}

// Проверка на выходной день
void CalculateData(){
    if (dayNumber >= 1 && dayNumber <= 7){
        result = daysOfWeek[dayNumber];
        checkNumber = true;
    }
}

//Выводит результат в консоль
void PrintData(){
    Console.WriteLine(
        (checkNumber) 
            ? result
            : "Такого дня нет. В неделе 7 дней."
    );
}
