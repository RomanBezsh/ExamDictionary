using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDictionary.Domain
{
    public class Word
    {
        public string? Text { get; set; }
        public List<string>? Translations { get; set; }
    }
}
