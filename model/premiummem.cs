using System;
namespace LibraryManagementSystem.model
{
    public class premiummem : Member
    {
        public int maxlimit { get; set; }

        public premiummem()
        {
           maxlimit = 100;
        }
        public override string get_info()
        {
            return base.get_info() + "\nMax Limit: " + maxlimit;
        }
    }
    }