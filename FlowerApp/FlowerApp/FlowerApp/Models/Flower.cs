using System;
using SQLite;

namespace FlowerApp.Models
{
    public class Flower
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public int flowerType { get; set; }
        public string flowerName { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
