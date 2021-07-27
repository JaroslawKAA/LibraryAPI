using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public class LibrarySeeder
    {
        private readonly LibraryContext _context;
        private readonly User _admin;
        private IEnumerable<User> _usersList { get; set; }

        public LibrarySeeder(LibraryContext context)
        {
            _context = context;
            _admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin",
                // Password = admin
                PasswordHash = "$2a$11$3C0BAwSbIIGYT8wiYt2xauRoyhCJMPC9SknVBW5JcAjOTN47oDfgS",
                UserName = "Admin Admin",
                BirthDate = new DateTime(2001, 2, 14),
                Localization = "Cracow"
            };
            _usersList = GetUsers();
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {

                if (!_context.Book.Any())
                {
                    var books = GetBooks();
                    _context.Book.AddRange(books);
                    _context.SaveChanges();
                }

                if (!_context.Bookcase.Any())
                {
                    var bookcases = GetBookcases();
                    _context.Bookcase.AddRange(bookcases);
                    _context.SaveChanges();
                }

                if (!_context.Borrowing.Any())
                {
                    var borrowings = GetBorrowings();
                    _context.Borrowing.AddRange(borrowings);
                    _context.SaveChanges();
                }

                if (!_context.User.Any())
                {
                    var users = GetUsers();
                    _context.User.AddRange(users);
                    _context.SaveChanges();
                }

                if (!_context.Friends.Any())
                {
                    var friends = GetFriends();
                    _context.Friends.AddRange(friends);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                _admin,
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Janek",
                    Email = "Email",
                    PasswordHash = "$2a$11$3C0BAwSbIIGYT8wiYt2xauRoyhCJMPC9SknVBW5JcAjOTN47oDfgS",
                    Localization = "Cracow"
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Brian",
                    Email = "Email2",
                    PasswordHash = "$2a$11$3C0BAwSbIIGYT8wiYt2xauRoyhCJMPC9SknVBW5JcAjOTN47oDfgS",
                    Localization = "Warsaw"
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Pep",
                    Email = "Email3",
                    PasswordHash = "$2a$11$3C0BAwSbIIGYT8wiYt2xauRoyhCJMPC9SknVBW5JcAjOTN47oDfgS",
                    Localization = "Cracow"
                }
            };
        }

        private IEnumerable<Friends> GetFriends()
        {
            return new List<Friends>()
            {
                new Friends()
                {
                    UserId = _admin.Id,
                    FriendId = _usersList.ToArray()[1].Id
                },
                new Friends()
                {
                    UserId = _admin.Id,
                    FriendId = _usersList.ToArray()[2].Id
                },
                new Friends()
                {
                    UserId = _admin.Id,
                    FriendId = _usersList.ToArray()[3].Id
                }
            };
        }

        private IEnumerable<Borrowing> GetBorrowings()
        {
            return new List<Borrowing>()
            {
                new Borrowing()
                {
                    BookId = 5,
                    Borrower = _admin,
                    Client = _usersList.ToList()[0],
                    Date = new DateTime(2021, 5, 4),
                    ReturnDate = new DateTime(2021, 9, 3),
                },
                new Borrowing()
                {
                    BookId = 4,
                    Borrower = _admin,
                    Client = _usersList.ToList()[1],
                    Date = new DateTime(2021, 5, 2),
                    ReturnDate = new DateTime(2021, 10, 21),
                },
                new Borrowing()
                {
                    BookId = 3,
                    Borrower = _admin,
                    Client = _usersList.ToList()[2],
                    Date = new DateTime(2021, 5, 1),
                    ReturnDate = new DateTime(2021, 8, 12),
                }
            };
        }

        private IEnumerable<Bookcase> GetBookcases()
        {
            return new List<Bookcase>()
            {
                new Bookcase()
                {
                    Name = "Main"
                }
            };
        }

        private IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            books.Add(new Book()
            {
                // Id = 0,
                Title = "First book Title",
                Authors = "Jarek, Krzysiek",
                PublishingYear = new DateTime(2020, 1, 1),
                Read = true,
                Available = false,
                Owner = _admin,
                Category = Category.Crime
            });
            books.Add(new Book()
            {
                // Id = 1,
                Title = "Second super book",
                Authors = "Jarek",
                PublishingYear = new DateTime(2020, 1, 1),
                Available = true,
                Read = true,
                Owner = _admin,
                Category = Category.Novel
            });
            books.Add(new Book()
            {
                // Id = 2,
                Title = "Third book",
                Authors = "Krzysiek",
                PublishingYear = new DateTime(2020, 1, 1),
                Available = true,
                Read = false,
                Owner = _admin,
                Category = Category.Documentary
            });
            books.Add(new Book()
            {
                // Id = 3,
                Title = "Book1",
                Authors = "Jarek, Krzysiek",
                PublishingYear = new DateTime(2020, 1, 1),
                Read = true,
                Available = false,
                Owner = _admin,
                Category = Category.Crime
            });
            books.Add(new Book()
            {
                // Id = 4,
                Title = "Book2",
                Authors = "Jarek",
                PublishingYear = new DateTime(2020, 1, 1),
                Available = true,
                Read = true,
                Owner = _admin,
                Category = Category.Novel
            });
            books.Add(new Book()
            {
                // Id = 5,
                Title = "Book3",
                Authors = "Krzysiek",
                PublishingYear = new DateTime(2020, 1, 1),
                Available = true,
                Read = false,
                Owner = _admin,
                Category = Category.Documentary
            });


            return books;
        }
    }
}
