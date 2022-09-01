//=============================================================================
// Напишите программу, которая будет выдавать название дня недели 
// по заданному номеру
//=============================================================================

Console.WriteLine("Название дня недели по номеру.");

Console.Write("Введите номер дня недели: ");
int dayNumber = int.Parse(Console.ReadLine() ?? "");
    
string dayToString = ""; // or string.Empty;

switch (dayNumber) {
    case 1 :
        dayToString = "Понедельник";
        break;
    case 2 :
        dayToString = "Вторник";
        break;
    case 3 :
        dayToString = "Среда";
        break;
    case 4 :
        dayToString = "Четверг";
        break;
    case 5 :
        dayToString = "Пятница";
        break;
    case 6 :
        dayToString = "Суббота";
        break;
    case 7 :
        dayToString = "Воскресенье";
        break;
    default : 
        dayToString = "Такого дня нет. В неделе 7 дней";
        break;
}

Console.WriteLine(dayToString);
