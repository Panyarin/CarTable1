using System;
using SQLite;

namespace CarTable.MVVM.Models;

public class Car
{
    [PrimaryKey , AutoIncrement]
    public int CarID { get ; set ;}
    
    [Column("model")]
    public string Model { get; set; }
    
    [Column("color")]
    public string Color { get; set; }
   

}