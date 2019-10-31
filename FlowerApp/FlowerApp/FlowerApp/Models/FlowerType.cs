using System;
using SQLite;

namespace FlowerApp.Models
{
    public class FlowerType
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string typeName { get; set; }
    }
}
