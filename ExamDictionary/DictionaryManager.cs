using ExamDictionary.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamDictionary
{
    public static class DictionariesManager
    {
        public static List<LanguageDictionary> _dictionaries = new List<LanguageDictionary>();

        public static void AddDictionary(LanguageDictionary dictionary)
        {
            var existDictionary = _dictionaries.FirstOrDefault(w => w.TypeTranslation == dictionary.TypeTranslation);
            if (existDictionary == null)
            {
                _dictionaries.Add(dictionary);
            }
            else
            {
                throw new ArgumentException("Словарь с таким типом уже есть.");
            }
        }
        public static void RemoveDictionary(string type)
        {
            var dictionary = FindDictionary(type);
            if (dictionary != null)
            {
                _dictionaries.Remove(dictionary);
            }
        }
        public static List<LanguageDictionary> GetDictionaries()
        {
            return _dictionaries;
        }
        public static LanguageDictionary? FindDictionary(string type)
        {
            return _dictionaries.FirstOrDefault(d => d.TypeTranslation == type);
        }


        public static string Serialize(LanguageDictionary dictionary)
        {
            ArgumentNullException.ThrowIfNull(dictionary);
            return JsonSerializer.Serialize(dictionary) ?? throw new JsonException("Serialize error");
        }
        public static void Save(string json, string path)
        {
            ArgumentNullException.ThrowIfNull(json);
            ArgumentNullException.ThrowIfNull(path);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            using FileStream fstream = File.Create(path);
            fstream.Write(bytes, 0, bytes.Length);
        }
        //public static string Load(string path)
        //{
        //    ArgumentNullException.ThrowIfNull(path);
        //    if (!File.Exists(path))
        //    {
        //        throw new FileNotFoundException(path);
        //    }
        //    return File.ReadAllText(path);
        //}
        public static LanguageDictionary Deserialize(string json)
        {
            ArgumentNullException.ThrowIfNull(json);
            return JsonSerializer.Deserialize<LanguageDictionary>(json) ?? throw new JsonException("Deserialize error");
        }


    }
}
