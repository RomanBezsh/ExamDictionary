using ExamDictionary.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamDictionary.Managers
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


        


    }
}
