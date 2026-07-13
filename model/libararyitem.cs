using System;
namespace LibraryManagementSystem.model
{
public class libraryitem()
{
public int id{ get; set; }
public string title{ get; set; }
public DateTime added_date{ get; set; }
public libraryitem()
{
    added_date = DateTime.now;
}
public abstract get_info(){}
}
}