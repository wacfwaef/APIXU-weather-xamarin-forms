using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using sun_or_rain.Model;

namespace sun_or_rain.db
{
    public class FavouritesDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FavouritesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Favourite>().Wait();
            seed();
        }

        private void seed()
        {
            if(database.)
            database.InsertAsync(new Favourite { Cityname = "Porto" });
            database.InsertAsync(new Favourite { Cityname = "Lisbon" });
            database.InsertAsync(new Favourite { Cityname = "Penafiel" });
        }

        public Task<List<Favourite>> GetItemsAsync()
        {
            return database.Table<Favourite>().ToListAsync();
        }

        public Task<Favourite> GetItemsCitynameAsync(String Cityname)
        {
            return database.Table<Favourite>().Where(i => i.Cityname == Cityname).FirstOrDefaultAsync();
        }

        public Task<Favourite> GetItemAsync(int id)
        {
            return database.Table<Favourite>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Favourite item)
        {
            if (item.ID != 0)
                return database.UpdateAsync(item);
            else
                return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Favourite item)
        {
            return database.DeleteAsync(item);
        }
    }
}
