using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace MauiApp4
{
    public class HikeDatabase
    {
        readonly SQLiteConnection database;

        public HikeDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Hike>();
        }

        public void AddHike(Hike hike)
        {
            try
            {
                database.Insert(hike);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding hike: {ex.Message}");
                throw;
            }
        }

        public Hike GetHike(int id)
        {
            try
            {
                return database.Table<Hike>().FirstOrDefault(h => h.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting hike: {ex.Message}");
                throw;
            }
        }

        public List<Hike> GetAllHikes()
        {
            try
            {
                return database.Table<Hike>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all hikes: {ex.Message}");
                throw;
            }
        }
    }
}
