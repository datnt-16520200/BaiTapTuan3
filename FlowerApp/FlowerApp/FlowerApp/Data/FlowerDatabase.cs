using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using FlowerApp.Models;

namespace FlowerApp.Data
{
    public class FlowerDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FlowerDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FlowerType>().Wait();
            _database.CreateTableAsync<Flower>().Wait();
        }

        public Task<List<FlowerType>> GetFlowerTypesAsync()
        {
            return _database.Table<FlowerType>().ToListAsync();
        }

        public Task<FlowerType> GetFlowerTypeAsync(int id)
        {
            return _database.Table<FlowerType>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFlowerTypeAsync(FlowerType flowerType)
        {
            if (flowerType.ID != 0)
            {
                return _database.UpdateAsync(flowerType);
            }
            else
            {
                return _database.InsertAsync(flowerType);
            }
        }

        public Task<int> DeleteFlowerTypeAsync(FlowerType flowerType)
        {
            return _database.DeleteAsync(flowerType);
        }

        public Task<List<Flower>> GetFlowersAsync()
        {
            return _database.Table<Flower>().ToListAsync();
        }

        public Task<List<Flower>> GetFlowersByFlowerTypeAsync(int ft)
        {
            return _database.Table<Flower>()
                            .Where(i => i.flowerType == ft)
                            .ToListAsync();
        }

        public Task<Flower> GetFlowerAsync(int id)
        {
            return _database.Table<Flower>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFlowerAsync(Flower flower)
        {
            if (flower.ID != 0)
            {
                return _database.UpdateAsync(flower);
            }
            else
            {
                return _database.InsertAsync(flower);
            }
        }

        public Task<int> DeleteFlowerAsync(Flower flower)
        {
            return _database.DeleteAsync(flower);
        }
    }
}