using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class FormatterText
    {
        private string _plainText;
        private List<TextRange> _formatting = new List<TextRange>();

        public FormatterText(string plainText)
        {
            _plainText = plainText;
        }

        public TextRange For(int start, int end)
        {
            var range = new TextRange {Start = start, End = end};
            _formatting.Add(range);
            return range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i=0;  i < _plainText.Length; i++)
            {
                var c = _plainText[i];
                foreach(var f in _formatting)  //c = _formatting.Where(f => f.Covers(i) && f.Capitalize).Aggregate(c, (current, f) => char.ToUpper(current));
                    if (f.Covers(i) && f.Capitalize)
                        c = char.ToUpper(c);
                sb.Append(c);
            }

            return sb.ToString();
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Italic, Bold;

            public bool Covers(int pos) => pos >= Start && pos <= End;
        }
    }
}