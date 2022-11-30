using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ISE.CodingChallenge.API
{
    public class DBService : IDisposable
    {
        public static DBService? _instance;

        public static DBService Instance
        {
            get
            {
                _instance ??= new DBService();
                return _instance;
            }
        }
        private LiteDatabase? _database;
        public LiteDatabase Database
        {
            get
            {
                _database ??= new LiteDatabase(Path);
                return _database;
            }
        }
        private string _path = string.Empty;
        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    _path = @"C:\Temp\MyData.db";
                }
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    _database?.Dispose();
                    _database = new LiteDatabase(Path);
                }
            }
        }
        public DBService() : this("") { }
        public DBService(string DatabasePath)
        {
            Path = DatabasePath;
            _database = new LiteDatabase(Path);
        }

        public void Clear()
        {
            var db = Database;
            var collections = Database.GetCollectionNames();
            foreach (var collection in collections)
            {
                var col = Database.GetCollection(collection);
                col.DeleteAll();
            }
        }

        public void Dispose()
        {
            _database?.Dispose();
            _database = null;
        }
    }
}
