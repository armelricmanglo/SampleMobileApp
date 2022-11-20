using System;
using SQLite;

namespace SampleMobileApp.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int subjectID { get; set; }
        public string Text { get; set; }
        public string Text1 { get; set; }
        public DateTime Date { get; set; }
    }
}

