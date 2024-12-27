using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamDictionary.Domain;
namespace ExamDictionary
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tСЛОВАРИ");
                Console.WriteLine("1. Создать новый словарь");
                Console.WriteLine("2. Добавить слово");
                Console.WriteLine("3. Удалить слово");
                Console.WriteLine("4. Изменить слово");
                Console.WriteLine("5. Изменить перевод");
                Console.WriteLine("6. Изменить перевод и слово");
                Console.WriteLine("7. Удалить словарь");
                Console.WriteLine("8. Найти перевод");
                Console.WriteLine("9. Экспортировать словарь");
                Console.WriteLine("10. Импортировать словарь");
                Console.WriteLine("0. Выйти");
                
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateDictionary();
                        break;
                    case 2:
                        AddWord();
                        break;
                    case 3:
                        DeleteWord();
                        break;
                    case 4:
                        EditWord();
                        break;
                    //case 5:
                    //    EditTranslations();
                    //    break;
                    //case 6:
                    //    EditWordAndTranslations();
                    //    break;
                    case 7:
                        DeleteDictionary();
                        break;
                    case 8:
                        FindTranslations();
                        break;
                    case 9:
                        ExportDictionary();
                        break;
                    case 10:
                        ImportDictionary();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неправильный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                }
            }
        }
        private static void CreateDictionary()
        {
            Console.Clear();
            Console.WriteLine("Введите новый тип словаря");
            var name = Console.ReadLine();
            DictionariesManager.AddDictionary(new LanguageDictionary() { TypeTranslation = name});
            Console.WriteLine("Словарь был успешно создан");
            ShowMainMenu();
        }
        private static void AddWord()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите желаемое слово: ");
                var newWord = Console.ReadLine();
                Console.Write("Введите перевод(если вы желаете несколько вариантов перевода ввести то после каждого варианта пишиже ,): ");
                var translation = Console.ReadLine().Split(',').ToList();

                dictionary.AddWord(newWord, translation);
                Console.WriteLine("Слово добавлено.");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void DeleteWord()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите желаемое слово: ");
                var newWord = Console.ReadLine();
                dictionary.DeleteWord(newWord);
                Console.WriteLine("Слово было успешно удалено.");
                
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void EditWord()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите слово которое хотите изменить: ");
                var oldWord = Console.ReadLine();
                Console.Write("Введите новое слово: ");
                var newWord = Console.ReadLine();
                dictionary.EditWord(oldWord, newWord);
                Console.WriteLine("Слово было изменено.");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void EditTranslations()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите желаемое слово: ");
                var word = Console.ReadLine();
                Console.Write("Введите новый перевод(если вы желаете несколько вариантов перевода ввести то после каждого варианта пишиже ,): ");
                var newTranlations = Console.ReadLine().Split(',').ToList();
                dictionary.EditTranslations(word, newTranlations);
                Console.WriteLine("Перевод был успешно изменён.");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void EditWordAndTranslations()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите которое хотите изменить слово: ");
                var oldWord = Console.ReadLine();
                Console.WriteLine("Введите которое хотите изменить слово: ");
                var newWord = Console.ReadLine();
                Console.Write("Введите новый перевод(если вы желаете несколько вариантов перевода ввести то после каждого варианта пишиже ,): ");
                var newTranlations = Console.ReadLine().Split(',').ToList();
                dictionary.EditWordAndTranslations(oldWord, newWord, newTranlations);
                Console.WriteLine("Слово и перевод были успешно изменены.");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }

        }
        private static void DeleteDictionary()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                DictionariesManager.RemoveDictionary(name);
                Console.WriteLine("Словарь был успешно удален.");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void FindTranslations()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите желаемое слово: ");
            var word = Console.ReadLine();
            var foundWord = DictionariesManager.FindDictionary(name).FindWord(word);
            foreach (var translation in foundWord.Translations)
            {
                Console.WriteLine(translation);
            }
        }
        private static void ExportDictionary()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря: ");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите путь к файлу: ");
                var path = Console.ReadLine();
                DictionariesManager.Save(DictionariesManager.Serialize(dictionary), path);
                Console.WriteLine("Словарь был успешно экспортирован!");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }
        private static void ImportDictionary()
        {
            Console.Clear();
            Console.WriteLine("Введите тип словаря: ");
            var name = Console.ReadLine();
            var dictionary = DictionariesManager.FindDictionary(name);
            if (dictionary != null)
            {
                Console.WriteLine("Введите путь к файлу: ");
                var path = Console.ReadLine();
                DictionariesManager.AddDictionary(DictionariesManager.Deserialize(path));
                Console.WriteLine("Словарь был успешно импортирован!");
            }
            else
            {
                Console.WriteLine("Словарь не найден.");
            }
        }













        
    }
}
