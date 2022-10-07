using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationExample.Enitites;

namespace ValidationExample.Generators
{
    internal static class BookGenerator
    {

        public static IEnumerable<Book> GetBooks(int numberOfBooks)
        {
            var books = new List<Book>();
            
            for (int i = 0; i < numberOfBooks; i++)
            {
                books.Add(GetBook());
            }

            return books;
        }

        private static Book GetBook()
        {
            var bogusBook = new Bogus.Faker();

            string title = bogusBook.Commerce.ProductName();
            var book = new Book
            {
                Title = title,
                Blurb = bogusBook.Lorem.Paragraph(5),
                ReleaseDate = bogusBook.Date.Between(new DateTime(2000, 01, 01), new DateTime(2022, 10, 07)),
                Author = GetAuthor(),
                Reviews = GetReviews(title, bogusBook.Random.Int(0, 20))
            };

            return book;
        }


        private static IEnumerable<Review> GetReviews(string bookName, int NumberOfReviews)
        {
            var reviews = new List<Review>();

            for(int i = 0; i < NumberOfReviews; i++)
            {
                reviews.Add(GetReview(bookName));
            }
            return reviews;
        }
        private static Review GetReview(string bookName)
        {
            var bogusReview = new Bogus.Faker().Rant;
            var review = new Review();
            review.ReviewContent = bogusReview.Review(bookName);

            return review;
        }

        private static Author GetAuthor()
        {
            var bogusAuthor = new Bogus.Faker().Person;
            var author = new Author
            {
                Forename = bogusAuthor.FirstName,
                Surname = bogusAuthor.LastName,
                BirthDate = DateOnly.FromDateTime(bogusAuthor.DateOfBirth)
            };

            return author;
        }
    }
}
