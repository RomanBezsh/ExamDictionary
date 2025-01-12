using ExamDictionary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamDictionary.Managers
{
    internal static class FileManager
    {
        public static void Save(LanguageDictionary dictionary, string path)
        {
            ArgumentNullException.ThrowIfNull(dictionary);
            ArgumentNullException.ThrowIfNull(path);
            var json = Serialize(dictionary);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            using FileStream fstream = File.Create(path);
            fstream.Write(bytes, 0, bytes.Length);
        }
        private static string Serialize(LanguageDictionary dictionary)
        {
            ArgumentNullException.ThrowIfNull(dictionary);
            return JsonSerializer.Serialize(dictionary) ?? throw new JsonException("Serialize error");
        }
        public static LanguageDictionary Load(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            var json = File.ReadAllText(path);
            return Deserialize(json);
        }
        private static LanguageDictionary Deserialize(string json)
        {
            ArgumentNullException.ThrowIfNull(json);
            return JsonSerializer.Deserialize<LanguageDictionary>(json) ?? throw new JsonException("Deserialize error");
        }
    }
}
