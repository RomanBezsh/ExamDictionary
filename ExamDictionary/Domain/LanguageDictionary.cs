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
        public string? TypeTranslation { get; set; }
        private List<Word> _words = new List<Word>();
        public void AddWord(string? word, List<string> translations)
        {
            ArgumentNullException.ThrowIfNull(word, nameof(word));
            ArgumentNullException.ThrowIfNull(translations, nameof(translations));
            if (translations.Count == 0)
            {
                throw new ArgumentException("Должен быть хотя бы один перевод");
            }
            var exsistWord = _words.FirstOrDefault(w => w.Text == word);
            if (exsistWord == null)
            {
                _words.Add(new Word { Text = word, Translations = translations });
            }
            else
            {
                throw new ArgumentException("Это слово уже есть в словаре.\n");
            }
        }
        public void DeleteWord(string word)
        {
            var exsistWord = _words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                _words.Remove(exsistWord);
            }
        }
        public void EditWord(string? word, string? newWord)
        {
            ArgumentNullException.ThrowIfNull(word, nameof(word));
            ArgumentNullException.ThrowIfNull(newWord, nameof(newWord));

            var exsistWord = _words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                var temp = exsistWord.Translations;
                _words.Remove(exsistWord);
                _words.Add(new Word() { Text = newWord, Translations = temp });
            }
        }
        public void EditTranslations(string word, List<string> newTranslations)
        {
            ArgumentNullException.ThrowIfNull(word, nameof(word));
            ArgumentNullException.ThrowIfNull(newTranslations, nameof(newTranslations));

            var exsistWord = _words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                exsistWord.Translations = newTranslations;
            }
        }
        public void EditWordAndTranslations(string word, string newWord, List<string> newTranslations)
        {
            ArgumentNullException.ThrowIfNull(word, nameof(word));
            ArgumentNullException.ThrowIfNull(newWord, nameof(newWord));

            var exsistWord = _words.FirstOrDefault(w => w.Text == word);
            if (exsistWord != null)
            {
                _words.Remove(exsistWord);
                _words.Add(new Word() { Text = newWord, Translations = newTranslations });
            }
        }
        public Word? FindWord(string text)
        {
            return _words.FirstOrDefault(w => w.Text == text);
        }
    }
}
