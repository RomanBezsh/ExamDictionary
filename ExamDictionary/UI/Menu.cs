using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamDictionary.Domain;
using ExamDictionary.Managers;
namespace ExamDictionary.UI
{
    internal class Menu
    {
        private LanguageDictionary _currentDictionary;

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tСЛОВАРИ");
                Console.WriteLine("1. Создать новый словарь");
                Console.WriteLine("2. Выбрать словарь");
                Console.WriteLine("3. Импортировать словарь");
                Console.WriteLine("4. Выйти");

                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateDictionary();
                        break;
                    case 2:
                        SelectDictionary();
                        break;
                    case 3:
                        ImportDictionary();
                        if (_currentDictionary != null)
                        {
                            ShowDictionaryMenu();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Неправильный выбор. Пожалуйста, попробуйте еще раз.");
                        Console.WriteLine("Нажмите на enter, чтобы продолжить.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void SelectDictionary()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите тип словаря: ");
                    var type = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(type))
                    {
                        throw new Exception("Тип словаря не может быть пустым. Нажмите любую клавишу, чтобы вернуться в главное меню.");
                    }
                    _currentDictionary = DictionariesManager.FindDictionary(type);
                    if (_currentDictionary != null)
                    {
                        ShowDictionaryMenu();
                    }
                    else
                    {
                        throw new Exception("Словарь не найден. Нажмите любую клавишу, чтобы вернуться в главное меню.");
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Нажмите на enter, чтобы продолжить.");
                    Console.ReadLine();
                }
            }
        }

        private void ShowDictionaryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tМЕНЮ СЛОВАРЯ");
                Console.WriteLine("1. Добавить слово");
                Console.WriteLine("2. Удалить слово");
                Console.WriteLine("3. Редактировать слово");
                Console.WriteLine("4. Редактировать переводы");
                Console.WriteLine("5. Удалить перевод");
                Console.WriteLine("6. Найти переводы");
                Console.WriteLine("7. Экспортировать словарь");
                Console.WriteLine("8. Вернуться в главное меню");

                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddWord();
                        break;
                    case 2:
                        DeleteWord();
                        break;
                    case 3:
                        EditWord();
                        break;
                    case 4:
                        EditTranslations();
                        break;
                    case 5:
                        RemoveTranslation();
                        break;
                    case 6:
                        FindTranslations();
                        break;
                    case 7:
                        ExportDictionary();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Неправильный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                }
            }
        }

        private void CreateDictionary()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите тип словаря: ");
                    var type = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(type))
                    {
                        throw new Exception("Тип словаря не может быть пустым.");
                    }
                    if (DictionariesManager.FindDictionary(type) != null)
                    {
                        throw new Exception("Словарь с таким типом уже существует.");
                    }
                    DictionariesManager.AddDictionary(new LanguageDictionary() { TypeTranslation = type });
                    Console.WriteLine("Словарь был успешно создан.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void AddWord()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите новое слово: ");
                    var newWord = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newWord))
                    {
                        throw new Exception("Новое слово не может быть пустым.");
                    }
                    Console.WriteLine("Введите перевод (если вы желаете несколько вариантов перевода ввести, то после каждого варианта пишите ,): ");
                    var translations = Console.ReadLine().Split(',').ToList();
                    if (translations.Any(string.IsNullOrWhiteSpace))
                    {
                        throw new Exception("Переводы не могут быть пустыми.");
                    }
                    _currentDictionary.AddWord(newWord, translations);
                    Console.WriteLine("Слово было успешно добавлено.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void DeleteWord()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово, которое хотите удалить: ");
                    var word = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(word))
                    {
                        throw new Exception("Слово не может быть пустым.");
                    }
                    _currentDictionary.DeleteWord(word);
                    Console.WriteLine("Слово было успешно удалено.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void RemoveTranslation()
        {
            while(true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово для удаления перевода:");
                    var word = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(word))
                    {
                        throw new Exception("Слово не может быть пустым.");
                    }
                    Console.WriteLine("Введите перевод для удаления:");
                    var translation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(translation))
                    {
                        throw new Exception("Перевод не может быть пустым.");
                    }
                    _currentDictionary.DeleteTranslation(word, translation);
                    Console.WriteLine("Перевод был успешно удален.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }
        private void EditWord()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово, которое хотите изменить: ");
                    var oldWord = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(oldWord))
                    {
                        throw new Exception("Старое слово не может быть пустым.");
                    }
                    Console.Write("Введите новое слово: ");
                    var newWord = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newWord))
                    {
                        throw new Exception("Новое слово не может быть пустым.");
                    }
                    _currentDictionary.EditWord(oldWord, newWord);
                    Console.WriteLine("Слово было изменено.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        
        private void EditTranslations()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово, для которого хотите изменить перевод: ");
                    var word = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(word))
                    {
                        throw new Exception("Слово не может быть пустым.");
                    }
                    Console.Write("Введите новый перевод (если вы желаете несколько вариантов перевода ввести, то после каждого варианта пишите ,): ");
                    var newTranslations = Console.ReadLine().Split(',').ToList();
                    if (newTranslations.Any(string.IsNullOrWhiteSpace))
                    {
                        throw new Exception("Переводы не могут быть пустыми.");
                    }
                    _currentDictionary.EditTranslations(word, newTranslations);
                    Console.WriteLine("Перевод был успешно изменён.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void EditWordAndTranslations()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово, которое хотите изменить: ");
                    var oldWord = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(oldWord))
                    {
                        throw new Exception("Старое слово не может быть пустым.");
                    }
                    Console.Write("Введите новое слово: ");
                    var newWord = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newWord))
                    {
                        throw new Exception("Новое слово не может быть пустым.");
                    }
                    Console.Write("Введите новый перевод (если вы желаете несколько вариантов перевода ввести, то после каждого варианта пишите ,): ");
                    var newTranslations = Console.ReadLine().Split(',').ToList();
                    if (newTranslations.Any(string.IsNullOrWhiteSpace))
                    {
                        throw new Exception("Переводы не могут быть пустыми.");
                    }
                    _currentDictionary.EditWordAndTranslations(oldWord, newWord, newTranslations);
                    Console.WriteLine("Слово и перевод были успешно изменены.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void DeleteDictionary()
        {
            DictionariesManager.RemoveDictionary(_currentDictionary.TypeTranslation);
            Console.WriteLine("Словарь был успешно удален.");
            Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }

        private void FindTranslations()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите слово, для которого хотите найти перевод: ");
                    var word = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(word))
                    {
                        throw new Exception("Слово не может быть пустым.");
                    }
                    var foundWord = _currentDictionary.FindWord(word);
                    foreach (var translation in foundWord.Translations)
                    {
                        Console.WriteLine(translation);
                    }
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }

        private void ExportDictionary()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь для сохранения словаря: ");
                    var path = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        throw new Exception("Путь не может быть пустым.");
                    }
                    FileManager.Save(_currentDictionary, path);
                    Console.WriteLine("Словарь был успешно сохранен.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }

            }
        }
        private void ImportDictionary()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь к файлу: ");
                    var path = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        throw new Exception("Путь не может быть пустым.");
                    }
                    var dictionary = FileManager.Load(path);
                    if (DictionariesManager.FindDictionary(dictionary.TypeTranslation) != null)
                    {
                        throw new Exception("Словарь с таким типом уже существует.");
                    }
                    DictionariesManager.AddDictionary(dictionary);
                    Console.WriteLine("Словарь был успешно загружен.");
                    Console.WriteLine("Нажмите на enter, чтобы вернуться в главное меню.");
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте снова.");
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.ReadLine();
                }
            }
        }
    }
}
