using System.Text.RegularExpressions;

namespace PieceofTheater.Lib.Model
{
    public class Line
    {
        public string Character { get; set; }
        public string Comment { get; set; }
        public string Text { get; set; }
        public int LineWordCount { get; set; }

        public Line() { }

        private int CountWord(string text)
        {
            int wordCount = 0, index = 0;

            int inParenthesis = 0;

            while (index < text.Length && !char.IsLetterOrDigit(text[index]))
            {
                if (text[index] == '(')
                    ++inParenthesis;

                if (text[index] == ')')
                    --inParenthesis;

                index++;
            }


            while (index < text.Length)
            {
                while (index < text.Length && char.IsLetterOrDigit(text[index]))
                    index++;

                if (inParenthesis == 0)
                {
                    wordCount++;
                }

                while (index < text.Length && !char.IsLetterOrDigit(text[index]))
                {
                    if (text[index] == '(')
                        ++inParenthesis;

                    if (text[index] == ')')
                        --inParenthesis;

                    index++;
                }
            }

            return wordCount;
        }

        public Line(string regexPattern, string line)
        {
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            var match = regex.Match(line);

            if (match.Success)
            {
                Character = match.Groups[1].Value.Trim();
                Comment = match.Groups[2].Value.Trim();
                Text = match.Groups[3].Value.Trim();
                LineWordCount = CountWord(Text);

            }
            else 
            {
                //pure comment
                Character = "";
                Comment = line;
                Text = "";
                LineWordCount = 0;
            }
        }
    }
}
