using System;
using System.Linq;

namespace SF_25._7_E_Library
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                SelectAction();

                Console.ReadKey();
            }
        }

        static void SelectAction()
        {
            Console.Clear();

            Console.WriteLine("Для действий с:\nпользователем ввести - 1\n" +
                "книгами ввести - 2");
            var selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    UserLogic.SelectUserAction();

                    break;

                case 2:
                    BookLogic.SelectBookAction();

                    break;
            }

        }

    }
}
