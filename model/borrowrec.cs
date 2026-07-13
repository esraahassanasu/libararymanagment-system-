using System;
namespace LibraryManagementSystem.model
{
    public class borrowrec 
    {
        public int memberid { get; set; }
       
        public int bookid { get; set; }
        public DateTime borrow_date { get; set; }
        public DateTime return_date { get; set; }

        public borrowrec()
        {
            borrow_date = DateTime.Now;
            return_date = DateTime.Now.AddDays(14);
        }
        public bool islate()
        {
            return DateTime.Now > return_date;
        }
        public int daysoverdue()
        {
            return (int)(DateTime.Now - return_date).TotalDays;
        }
        public override string get_info()
        {
            return "Borrow Record ID: " + id + "\nMember ID: " + memberid + "\nBook ID: " + bookid + "\nBorrow Date: " + borrow_date + "\nReturn Date: " + return_date;
        }
        
    }
}