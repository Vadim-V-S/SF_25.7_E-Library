using System;
using System.Collections.Generic;
using System.Text;

namespace SF_25._7_E_Library
{
    static class BookLogic
    {
        static BookRepository book = new BookRepository();

        public static void SelectBookAction()
        {

            Console.WriteLine("Добавить книгу введите- 1\n" +
                "Удалить книгу - 2\n" +
                "Выбрать книгу по id - 3\n" +
                "Вывести все книги - 4\n" +
                "Обновить год выпука книги - 5");

            var selection = int.Parse(Console.ReadLine());


            switch (selection)
            {
                case 1:
                    AddBook();
                    break;

                case 2:
                    Console.Write("Введите Id книги для удаления:\t");
                    var id = int.Parse(Console.ReadLine());
                    book.DeleteBook(id);
                    break;

                case 3:
                    Console.Write("Введите Id для выбора книги:\t");
                    id = int.Parse(Console.ReadLine());
                    book.GetSelectedBook(id);
                    break;
                case 4:
                    book.GetAllBooks();
                    break;
                case 5:
                    Console.Write("Введите Id книги для изменения года издания:\t");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Введите новый год издания:\t");
                    string newYear = Console.ReadLine();
                    book.UpdateBookIssueYear(id, newYear);
                    break;
            }

        }

        static void AddBook()
        {
            var bookData = InputBook();
            book.AddBook(bookData.Item1, bookData.Item2);
        }

        static (string, string) InputBook()
        {
            Console.Write("Введите название книги:\t");
            string bookName = Console.ReadLine();

            Console.Write("Введите год выпука:\t");
            string issueYear = Console.ReadLine();

            return (bookName, issueYear);
        }

    }
}
