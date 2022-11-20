using System;
using SQLite;

namespace SampleMobileApp.Models
{
    public class TDL
    {
        [PrimaryKey, AutoIncrement]
        public int tdlID { get; set; }
        public string Text { get; set; }
        public string Text1 { get; set; }
        public DateTime Date { get; set; }
    }
}
