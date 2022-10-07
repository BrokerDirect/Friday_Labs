using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationExample.Generators;
using ValidationExample.Validation;

namespace ValidationExample
{
    internal class BookLoader
    {
        public void Load()
        {

            var books = BookGenerator.GetBooks(10000).ToList();

            books[0].Author.Forename = "Jeff";

            books[1].Title = "";



            foreach (var book in books)
            {
                var validator = new BookValidator();
                var result = validator.Validate(book);

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine("##################################");
                        Console.WriteLine("Book Title: " + book.Title);
                        Console.WriteLine("Book Blurb: " + book.Blurb);
                        Console.WriteLine("Book Review: " + book.Reviews.FirstOrDefault().ReviewContent);
                        Console.WriteLine(error.ErrorMessage);
                        Console.WriteLine("##################################");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
