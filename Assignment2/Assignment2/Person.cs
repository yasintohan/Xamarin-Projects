using SQLite;
using System;

namespace Assignment2
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public String DateOfBirth { get; set; }
        public double Balance { get; set; }


    }
}