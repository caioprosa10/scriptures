using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizerProject
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w.Trim()))
                .ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine(string.Join(' ', _words.Select(w => w.GetDisplayText())));
            Console.WriteLine();
        }

        public void HideRandomWords(int count)
        {
            var visible = _words.Where(w => !w.IsHidden()).ToList();
            if (!visible.Any()) return;

            for (int i = 0; i < count && visible.Count > 0; i++)
            {
                int idx = _random.Next(visible.Count);
                visible[idx].Hide();
                visible.RemoveAt(idx);
            }
        }

        public bool AllWordsHidden() => _words.All(w => w.IsHidden());
    }
}
