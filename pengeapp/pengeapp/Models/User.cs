using System;
using SQLite;

namespace pengeapp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
        public DateTime Date { get; set; }
    }
}