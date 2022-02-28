using System.Security.AccessControl;
using System.Threading.Channels;
using ADO_Exam;
using ADO_Exam.Model;


string ConString = "Server=mysql60.hostland.ru;Database=host1323541_vrn04;User Id=host1323541_itstep;Password=269f43dc";
//Строка подключения: Server=mysql60.hostland.ru;Database=host1323541_vrn04;User Id=host1323541_itstep;Password=269f43dc
BooksDB DataBase = new BooksDB(ConString);
Console.WriteLine("Здравствуйте, что бы Вы хотели сделать?");
Console.WriteLine("1) Посмотреть/добавить/удалить информацию о жанрах");
Console.WriteLine("0) Выйти из приложения");
 uint choise = uint.Parse(Console.ReadLine());
if (choise > 0)
{
    do
    {
        switch (choise)
        {
            case 1:
                Console.WriteLine("1) Посмотреть информацию");
                Console.WriteLine("2) добавить информацию");
                Console.WriteLine("3) Удалить конкретный жанр");
                Console.WriteLine("4) Изменить название жанра");
                Console.WriteLine("0) Вернуться назад");
                choise = uint.Parse(Console.ReadLine());
                while (choise != 0)
                {
                    if (choise == 1)
                    {
                        DataBase.GetAllGenres();
                    }
                    else if (choise == 2)
                    {
                        Console.WriteLine(
                            "Введите наименование нового жанра: "); //TODO добавить обработку ошибок, например нельзя в жанры ввести цифры
                        string name = Console.ReadLine();
                        Genre genre = new Genre();
                        genre.name = name;
                        DataBase.Add_genre(genre);
                    }
                    else if (choise == 3)
                    {
                        Console.WriteLine("Чтобы удалить какой-либо жанр из списка, укажите его номер: ");
                        uint id = uint.Parse(Console.ReadLine());
                        DataBase.Remove_genre(id); //TODO добавить вывод сообщения об успешном/неуспешном удалении 
                    }else if (choise == 4)
                    {
                        Console.WriteLine("Чтобы изменить название какого-либо жанра, укажите его номер: ");
                        uint id = uint.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое название этому жанру: ");
                        string str = Console.ReadLine();
                        DataBase.UpdateGenre(id, str);
                    }

                    Console.WriteLine();
                    Console.WriteLine("что бы Вы хотели сделать?: ");
                    Console.WriteLine("1) Посмотреть информацию");
                    Console.WriteLine("2) добавить информацию");
                    Console.WriteLine("3) Удалить конкретный жанр");
                    Console.WriteLine("4) Изменить название жанра");
                    Console.WriteLine("0) Вернуться назад");
                    choise = uint.Parse(Console.ReadLine());
                }

                break;
            case 0:
                Console.WriteLine("Всего доброго, программа завершает свою работу!");
                break;
            default:
                Console.WriteLine("Не получилось определить число, введите заново");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("что бы Вы хотели сделать?: ");
        Console.WriteLine("1) Посмотреть/добавить/удалить информацию о жанрах");
        Console.WriteLine("0) Выйти из приложения");
        choise = uint.Parse(Console.ReadLine());
        if (choise == 0)
        {
            Console.WriteLine("Всего доброго, программа завершает свою работу!");
        }
    } while (choise > 0);
}
else
{
    Console.WriteLine("Всего доброго, программа завершает свою работу!");
}

    
