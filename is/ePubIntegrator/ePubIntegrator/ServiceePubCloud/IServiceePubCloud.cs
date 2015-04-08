using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceePubCloud
{
   
    [ServiceContract]
    public interface IServiceePubCloud
    {
        // System - This returns the "uptime" in a production enviroment the service time would be configured with REAL (GMT+X) time
        [OperationContract]
        Double GetServiceCurrentTime();
        // User
        [OperationContract]
        bool RegisterUser(UserContract user);

        [OperationContract]
        bool DeleteUser(string username);

        [OperationContract]
        UserContract Login(string username, string password);
        // eBook
        [OperationContract]
        bool CreateEbookRegistry(EBookContract ebook);

        [OperationContract]
        bool DeleteEbookRegistry(string folderPath);
        // Bookmark
        [OperationContract]
        bool CreateBookmark(User user, string ChapterTitle);
       
        [OperationContract]
        bool DeleteBookmark(User user, Chapter chapter);
        // Favourite
        [OperationContract]
        bool CreateFavouriteChapter(User user, Chapter chapter);

        [OperationContract]
        bool DeleteFavouriteChapter(User user, Chapter chapter);

        [OperationContract]
        bool CreateFavouriteEbook(User user, eBook eBook);

        [OperationContract]
        bool DeleteFavouriteEbook(User user, eBook eBook);
        // Author
        [OperationContract]
        bool CreateAuthor(string name);

        [OperationContract]
        bool DeleteAuthor(string name);
        // Publisher
        [OperationContract]
        bool CreatePublisher(string name);

        [OperationContract]
        bool DeletePublisher(string name);
        // Language
        [OperationContract]
        bool CreateLanguage(string name);

        [OperationContract]
        bool DeleteLanguage(string name);
        // Access
        [OperationContract]
        bool CreateAccess(User user, short type);
    }

    [DataContract]
    public class UserContract
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public Double LastLogin { get; set; }
    }

    [DataContract]
    public class EBookContract
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string FolderPath { get; set; }

        [DataMember]
        public string ImageUri { get; set; }

        [DataMember]
        public string Language { get; set; }
    }

    [DataContract]
    public class BookmarkContract
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Chapter { get; set; }
    }

    [DataContract]
    public class FavouriteContract
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Chapter { get; set; }

        [DataMember]
        public string Ebook { get; set; }
    }

    [DataContract]
    public class ChapterContract
    {
        [DataMember]
        public ICollection<eBook> Ebook { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Index { get; set; }
    }

    [DataContract]
    public class AuthorContract
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class GenreContract
    {
        [DataMember]
        public string Genre { get; set; }
    }

    [DataContract]
    public class PublisherContract
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class LanguageContract
    {
        [DataMember]
        public string Language { get; set; }
    }

}
