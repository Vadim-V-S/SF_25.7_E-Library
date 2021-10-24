using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_25._7_E_Library
{
    public class UserRepository
    {
        public AppContext db = new AppContext();

        public void AddUser(string name, string email)
        {
            var user = new User { Name = name, Email = email };
            db.Users.Add(user);

            db.SaveChanges();

            Console.WriteLine("Пользователь {0} добавлен", name);
        }

        public void DeleteUser(int id)
        {
            var user = new User { Id = id };
            db.Users.Remove(user);

            db.SaveChanges();

            Console.WriteLine("Пользователь удален");
        }

        public void GetSelectedUser(int id)
        {
            PrintSelection(db.Users.Where(user => user.Id == id).ToList());
        }

        public void GetAllUsers()
        {
            PrintSelection(db.Users.ToList());
        }

        public void UpdateUserName(int id, string newName)
        {
            var selection = db.Users.Where(user => user.Id == id).ToList();

            var firstUser = selection.FirstOrDefault();
            var oldName = firstUser.Name;
            firstUser.Name = newName;

            db.SaveChanges();

            Console.WriteLine("Имя пользователя изменен с {0} на {1}", oldName, newName);
        }


        public void PrintSelection(List<User> list)
        {
            if (list.Any())
            {
                foreach (var u in list)
                {
                    Console.WriteLine("id: {0}   Имя: {1}   Email: {2}", u.Id, u.Name, u.Email);
                }
            }
            else
            {
                Console.WriteLine("Нет пользователя с таким Id");
            }
        }

    }
}
