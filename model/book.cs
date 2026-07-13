using System;
using LibraryManagementSystem.interfaces;
namespace LibraryManagementSystem.model
{
    public class book : LibraryItem, ISearchable
    {
        //author,year,genre,available
        public string author{get;set;}
        public int year{get;set;}
        public string genre {get;set;}
        public bool isavailable {get;set;}

        public book()
        {
            IsAvailable = true;
        }
        public override string get_info()
        {
            return "Book ID: " + id + "\nTitle: " + title + "\nAuthor: " + author + "\nYear: " + year + "\nGenre: " + genre + "\nAvailable: " + isavailable;
        }
        public bool MatchesQuery(string query)
        {
            return title.ToLower().Contains(query) || author.ToLower().Contains(query) || genre.ToLower().Contains(query);
        }
        
    }

}