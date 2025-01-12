using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExamDictionary.Domain
{
    public class LanguageDictionary
    {
        public string TypeTranslation { get; set; }
        public List<Word> Words  { get; set; } = new List<Word>();
        public void AddWord(string word, List<string> translations)
            {
                if (translations.Count == 0)
                {
                    throw new Exception("Должен быть хотя бы один перевод");
                }
                var exsistWord = Words.FirstOrDefault(w => w.Text == word);
                if (exsistWord == null)
                {
                    Words.Add(new Word { Text = word, Translations = translations });
                }
                else
                {
                    throw new Exception("Это слово уже есть в словаре.\n");
                }
            }
        public void DeleteWord(string word)
        {
            var exsistWord = Words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                Words.Remove(exsistWord);
            }
        }
        public void DeleteTranslation(string word, string translation)
        {
            var exsistWord = Words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                exsistWord.Translations.Remove(translation);
            }
        }
        public void EditWord(string word, string newWord)
        {
            var exsistWord = Words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                var temp = exsistWord.Translations;
                Words.Remove(exsistWord);
                Words.Add(new Word() { Text = newWord, Translations = temp });
            }
        }
        public void EditTranslations(string word, List<string> newTranslations)
        {
            var exsistWord = Words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                exsistWord.Translations = newTranslations;
            }
        }
        public void EditWordAndTranslations(string word, string newWord, List<string> newTranslations)
        {
            var exsistWord = Words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                Words.Remove(exsistWord);
                Words.Add(new Word() { Text = newWord, Translations = newTranslations });
            }
        }
        public Word? FindWord(string text)
        {
            return Words.FirstOrDefault(w => w.Text == text);
        }
    }
}
