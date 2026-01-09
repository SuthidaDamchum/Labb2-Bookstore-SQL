using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_Domain;
using BookStore_Infrastrcuture.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Presentation.Services
{
    public class AuthorService
    {
        private readonly BookStoreContext _context;

        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }


        public bool IsValidAuthor(string firstName, string lastName, string? birthDayText, out string? errorMessage)
        {
            errorMessage = null;

            if(string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit))
            {
                errorMessage = "First name is required and cannot contain numbers.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit))
            {
                errorMessage = "Last name is required and cannot contain numbers.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(birthDayText))
            {
                if (!DateOnly.TryParse(birthDayText, out _))
                {
                    errorMessage = "Birth date is invalid. Use YYYY-MM-DD.";
                    return false;
                }
            }

            return true;
        }


        public async Task<Author> CreateAuthorAsync(string firstName, string lastName, DateOnly? birthDate)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDay = birthDate
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }
        public async Task<Author> UpdateAuthorAsync(int authorId, string firstName, string lastName, DateOnly? birthday)
        {

            if (!IsValidAuthor(firstName, lastName, birthday?.ToString(), out var error))
                throw new ArgumentException(error);

            var author = await _context.Authors.FindAsync(authorId);
            if (author == null)
                throw new Exception("Author not found.");


            author.FirstName = firstName;
            author.LastName = lastName;
            author.BirthDay = birthday;

            await _context.SaveChangesAsync();
            return author;
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await _context.Authors
                    
            .Include(a => a.BookAuthors)
            .FirstOrDefaultAsync(a => a.AuthorId == authorId);

            if (author == null)
                throw new Exception("Author not found.");

            if (author.BookAuthors != null && author.BookAuthors.Any())
                throw new Exception("Cannot delete the author linked to books");

            _context.Authors.Remove(author);
           await  _context.SaveChangesAsync();
        }


    }
}
