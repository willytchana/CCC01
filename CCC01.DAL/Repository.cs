using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC01.DAL
{
    public class Repository<T>
    {
        private static List<T> data;
        private readonly string FILE_NAME = $"{typeof(T).GetType()}.json";
        private readonly string dbFolder;
        private FileInfo file;
        public Repository(string dbFolder)
        {
            this.dbFolder = dbFolder;
            file = new FileInfo(Path.Combine(this.dbFolder, FILE_NAME));
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            if (!file.Exists)
            {
                file.Create().Close();
                file.Refresh();
            }
            if (file.Length > 0)
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string json = sr.ReadToEnd();
                    data = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }
            if (data == null)
            {
                data = new List<T>();
            }
        }

        public void Set(T oldT, T newT)
        {
            var oldIndex = data.IndexOf(oldT);
            var newIndex = data.IndexOf(newT);
            if (oldIndex < 0)
                throw new KeyNotFoundException($"The {typeof(T).GetType()} doesn't exists !");
            if (newIndex >= 0 && oldIndex != newIndex)
                throw new DuplicateNameException($"This {typeof(T).GetType()} reference already exists !");
            data[oldIndex] = newT;
            Save();
        }

        public void Add(T t)
        {
            var index = data.IndexOf(t);
            if (index >= 0)
                throw new DuplicateNameException($"This {typeof(T).GetType()} matricule already exists !");
            data.Add(t);
            Save();
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(file.FullName, false))
            {
                string json = JsonConvert.SerializeObject(data);
                sw.WriteLine(json);
            }
        }

        public void Remove(T t)
        {
            data.Remove(t);//base sur Product.Equals redefini
            Save();
        }

        public IEnumerable<T> Find()
        {
            return new List<T>(data);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return new List<T>(data.Where(predicate).ToArray());
        }
    }
}
