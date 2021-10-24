using System;
using System.Collections.Generic;
using System.Text;

namespace SF_25._7_E_Library
{
    static class UserLogic
    {
        static UserRepository user = new UserRepository();

        public static void SelectUserAction()
        {
            Console.WriteLine("Добавить пользователя введите- 1\n" +
                "Удалить пользователя - 2\n" +
                "Выбрать пользователя по id - 3\n" +
                "Вывести всех пользователей - 4\n" +
                "Обновить Имя пользователя - 5");

            var selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    AddUser();
                    break;

                case 2:
                    Console.Write("Введите Id пользователя для удаления:\t");
                    var id = int.Parse(Console.ReadLine());
                    user.DeleteUser(id);
                    break;

                case 3:
                    Console.Write("Введите Id пользователя для выбора:\t");
                    id = int.Parse(Console.ReadLine());
                    user.GetSelectedUser(id);
                    break;
                case 4:
                    user.GetAllUsers();
                    break;
                case 5:
                    Console.Write("Введите Id пользователя для изменения имени:\t");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Введите новое имя:\t");
                    string newName = Console.ReadLine();
                    user.UpdateUserName(id,newName);
                    break;
            }

        }

        static void AddUser()
        {
            var userData = InputUser();
            user.AddUser(userData.Item1, userData.Item2);
        }

        static (string, string) InputUser()
        {
            Console.Write("Введите имя пользователя:\t");
            string userName = Console.ReadLine();

            Console.Write("Введите email пользователя:\t");
            string userEmail = Console.ReadLine();

            return (userName, userEmail);
        }
    }
}

