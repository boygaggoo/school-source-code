using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ServiceePubCloud
{
    public class ServiceePubCloud : IServiceePubCloud
    {
        readonly ePubBdModelContainer _context = new ePubBdModelContainer();

        public Double GetServiceCurrentTime()
        {
            return DateTime.Now.Millisecond;
        }

        public UserContract Login(string username, string password)
        {
            try
            {
                var userRegistry = _context.UserSet.First(i => i.username == username && i.password == password);
                if (userRegistry == null)
                {
                    return null;
                }
                userRegistry.lastLogin = DateTime.Now.Millisecond;
                _context.UserSet.AddOrUpdate(userRegistry);
                _context.SaveChanges();

                var user = new UserContract
                {
                    FirstName = userRegistry.firstName,
                    LastName = userRegistry.lastName,
                    Username = userRegistry.username,
                    Password = userRegistry.password,
                    Email = userRegistry.email,
                    Gender = userRegistry.gender,
                    LastLogin = userRegistry.lastLogin
                };
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool RegisterUser(UserContract registeredUser)
        {
            if (_context.UserSet.Any(i => i.username == registeredUser.Username))
            {
                return false;
            }

            var user = new User
            {
                username = registeredUser.Username,
                password = registeredUser.Password,
                firstName = registeredUser.FirstName,
                lastName = registeredUser.LastName,
                gender = registeredUser.Gender,
                email = registeredUser.Email,
                lastLogin = DateTime.Now.Millisecond
            };

            _context.UserSet.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(string username)
        {
            var user = _context.UserSet.First(i => i.username == username);
            if (user == null)
            {
                Console.Write("DeleteUser(): User is null, can't delete");
                return false;
            }
            _context.UserSet.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool CreateEbookRegistry(EBookContract ebookContract)
        {
            var ebook = new eBook
            {
                title = ebookContract.Title,
                folderPath = ebookContract.FolderPath,
                imageUrl = ebookContract.ImageUri,
            };
            if (_context.eBookSet.Any(i => i.folderPath == ebook.folderPath))
            {
                return false;
            }
            _context.eBookSet.Add(ebook);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateEBookRegistry(string folderPath, string title, string imageUrl, string newFolderPath)
        {
            var ebook = _context.eBookSet.First(i => i.folderPath == folderPath);
            if (ebook == null)
            {
                return false;
            }

            if (title != null && !String.Equals(ebook.title, title))
            {
                ebook.title = title;   
            }

            if (imageUrl != null && !String.Equals(ebook.imageUrl, imageUrl))
            {
                ebook.imageUrl = imageUrl;
            }

            if (newFolderPath != null && !String.Equals(ebook.folderPath, newFolderPath))
            {
                ebook.folderPath = newFolderPath;
            }

            _context.eBookSet.AddOrUpdate(ebook);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteEbookRegistry(string folderPath)
        {
            var ebook = _context.eBookSet.First(i => i.folderPath == folderPath);
            if (ebook == null)
            {
                return false;
            }
            _context.eBookSet.Remove(ebook);
            _context.SaveChanges();
            return true;
        }

        public bool CreateBookmark(User user, string ChapterTitle)
        {
            throw new NotImplementedException();
        }

        public bool CreateBookmark(User user, Chapter chapter)
        {
            if (_context.BookmarkSet.First(i => i.User.username == user.username && i.Chapter.title == chapter.title) != null)
            {
                return false;
            }
            var bookmark = new Bookmark { User = user, Chapter = chapter };
            _context.BookmarkSet.Add(bookmark);
            _context.SaveChanges();
            return true;
        }

        
        public bool UpdateBookmark(User user, Chapter chapter, Chapter newChapter)
        {
            var bookmark = _context.BookmarkSet.First(i => i.User == user && i.Chapter == chapter);
            if (bookmark == null || newChapter == null)
            {
                return false;
            }
            bookmark.Chapter = newChapter;
            _context.BookmarkSet.AddOrUpdate(bookmark);
            _context.SaveChanges();
            return true;
        }
        

        public bool DeleteBookmark(User user, Chapter chapter)
        {
            if (_context.BookmarkSet.First(i => i.User.username == user.username && i.Chapter.title == chapter.title) == null)
            {
                return false;
            }
            var bookmark = new Bookmark { User = user, Chapter = chapter };
            _context.BookmarkSet.Remove(bookmark);
            _context.SaveChanges();
            return true;
        }

        // eBook
        public bool CreateFavouriteEbook(User user, eBook eBook)
        {            
            if (_context.FavouriteSet.First(i => i.User == user && i.eBook == eBook) != null)
            {
                // TODO alert error dialog: Favourite exists
                return false;
            }
            var favourite = new Favourite
            {
                User = user,
                eBook = eBook
            };
            _context.FavouriteSet.Add(favourite);
            _context.SaveChanges();
            return true;
        }

        // Chapter
        public bool CreateFavouriteChapter(User user, Chapter chapter)
        {
            if (_context.FavouriteSet.First(i => i.User == user && i.Chapter == chapter) != null)
            {
                // TODO alert error dialog: Favourite exists
                return false;
            }
            var favourite = new Favourite
            {
                User = user,
                Chapter = chapter
            };
            _context.FavouriteSet.Add(favourite);
            _context.SaveChanges();
            return true;
        }

        // eBook
        public bool UpdateFavourite(User user, eBook ebook, eBook newEBook)
        {
            if (user == null || ebook == null || newEBook == null)
            {
                return false;
            }
            var favourite = _context.FavouriteSet.First(i => i.User == user && i.eBook == ebook);
            if (favourite != null && favourite.eBook != newEBook)
            {
                favourite.eBook = newEBook;
            }
            _context.FavouriteSet.AddOrUpdate(favourite);
            _context.SaveChanges();
            return true;
        }

        // Chapter
        public bool UpdateFavourite(User user, Chapter chapter, Chapter newChapter)
        {
            if (user == null || chapter == null || newChapter == null)
            {
                return false;
            }
            var favourite = _context.FavouriteSet.First(i => i.User == user && i.Chapter == chapter);
            if (favourite != null && favourite.Chapter != newChapter)
            {
                favourite.Chapter = chapter;
            }
            _context.FavouriteSet.AddOrUpdate(favourite);
            _context.SaveChanges();
            return true;
        }

        // eBook
        public bool DeleteFavouriteEbook(User user, eBook eBook)
        {
            var favourite = _context.FavouriteSet.First(i => i.User == user && i.eBook == eBook);
            if (favourite == null)
            {
                return false;
            }
            _context.FavouriteSet.Remove(favourite);
            _context.SaveChanges();
            return true;

        }

        // Chapter
        public bool DeleteFavouriteChapter(User user, Chapter chapter)
        {
            var favourite = _context.FavouriteSet.First(i => i.User == user && i.Chapter == chapter);
            if (favourite == null)
            {
                return false;
            }
            _context.FavouriteSet.Remove(favourite);
            _context.SaveChanges();
            return true;

        }

        public bool CreateAuthor(string name)
        {
            if (_context.AuthorSet.First(i => i.name == name) != null)
            {
                return false;
            }
            var author = new Author
            {
                name = name
            };
            _context.AuthorSet.Add(author);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteAuthor(string name)
        {
            var author = _context.AuthorSet.First(i => i.name == name);
            if (author == null)
            {
                return false;
            }
            _context.AuthorSet.Remove(author);
            _context.SaveChanges();
            return true;
        }

        public bool CreatePublisher(string name)
        {
            if (_context.PublisherSet.First(i => i.name == name) != null)
            {
                return false;
            }
            var publisher = new Publisher
            {
                name = name
            };
            _context.PublisherSet.Add(publisher);
            _context.SaveChanges();
            return true;
        }

        public bool DeletePublisher(string name)
        {
            var publisher = _context.PublisherSet.First(i => i.name == name);
            if (publisher == null)
            {
                return false;
            }
            _context.PublisherSet.Remove(publisher);
            _context.SaveChanges();
            return true;
        }

        public bool CreateAccess(User user, short type)
        {
            var access = new Access
            {
                User = user,
                type = type
            };
            _context.AccessSet.Add(access);
            _context.SaveChanges();
            return true;
        }

        public bool CreateLanguage(string name)
        {
            if (_context.PublisherSet.First(i => i.name == name) != null)
            {
                return false;
            }
            var language = new Language
            {
                name = name
            };
            _context.LanguageSet.Add(language);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLanguage(string name)
        {
            var language = _context.LanguageSet.First(i => i.name == name);
            if (language == null)
            {
                return false;
            }
            _context.LanguageSet.Remove(language);
            _context.SaveChanges();
            return true;
        }

    }
}