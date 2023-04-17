using System;
using System.Collections.Generic;
using System.IO;

namespace p5
{
    class Worker
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public override string ToString()
        {
            return $"{ID}#{AddDate.ToString("dd.MM.yyyy HH:mm")}#{FullName}#{Age}#{Height}#{BirthDate.ToString("dd.MM.yyyy")}#{BirthPlace}";
        }
    }
    class Repository
    {
        private string fileName;
        public Repository(string fileName)
        {
            this.fileName = fileName;
        }
        public void ViewAll()
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("Список всех записей:");
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }
        public void ViewByID(int id)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    if (parts.Length == 7 && Convert.ToInt32(parts[0]) == id)
                    {
                        Console.WriteLine("Запись с ID {0}: {1} {2} {3} лет, рост {4} см, дата рождения {5}, место рождения {6}",
                        id, parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]);
                        return;
                    }
                }
                Console.WriteLine("Запись с ID {0} не найдена.", id);
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }
        public void Create(Worker worker)
        {
            if (File.Exists(fileName))
            {
                string line = worker.ToString();
                File.AppendAllText(fileName, line + Environment.NewLine);
                Console.WriteLine("Запись добавлена.");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }
        public void Delete(int id)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                List<string> updatedLines = new List<string>();
                bool recordDeleted = false;
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    if (parts.Length == 7 && Convert.ToInt32(parts[0]) != id)
                    {
                        updatedLines.Add(line);
                    }
                    else if (parts.Length == 7 && Convert.ToInt32(parts[0]) == id) ;
                }
            }
        }
    }
}
