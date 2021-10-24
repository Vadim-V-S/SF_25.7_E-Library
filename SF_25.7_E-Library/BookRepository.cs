using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_25._7_E_Library
{

    public class BookRepository
    {
    public AppContext db = new AppContext();

        public void AddBook(string name, string year)
        {
            var book = new Book { Name = name, IssueYear = year };
            db.Books.Add(book);

            db.SaveChanges();

            Console.WriteLine("Книга {0} добавлена", name);
        }

        public void DeleteBook(int id)
        {
            var book = new Book { Id = id };
            db.Books.Remove(book);

            db.SaveChanges();

            Console.WriteLine("Книга удалена");
        }

        public void GetSelectedBook(int id)
        {
            PrintSelection(db.Books.Where(book => book.Id == id).ToList());
        }

        public void GetAllBooks()
        {
            PrintSelection(db.Books.ToList());
        }

        public void UpdateBookIssueYear(int id, string newYear)
        {
            var selection = db.Books.Where(book => book.Id == id).ToList();

            var firstBook = selection.FirstOrDefault();
            var oldYear = firstBook.IssueYear;
            firstBook.IssueYear = newYear;

            db.SaveChanges();

            Console.WriteLine("Год издания книги изменено с {0} на {1}", oldYear, newYear);
        }

        public void PrintSelection(List<Book> list)
        {
            if (list.Any())
            {
                foreach (var b in list)
                {
                    Console.WriteLine("Id: {0}   Название: {1}   Год издания: {2}", b.Id, b.Name, b.IssueYear);
                }
            }
            else
            {
                Console.WriteLine("Нет книги с таким Id");
            }

        }
    }
}
