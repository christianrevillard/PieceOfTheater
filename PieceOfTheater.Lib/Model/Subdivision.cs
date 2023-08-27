using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PieceofTheater.Lib.Model
{
    public abstract class Subdivision<T>
    {
        public string Label { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public bool IsDefined { get { return !string.IsNullOrEmpty(Label); } }

        public List<T> Elements { get; } = new List<T>();

        public abstract bool ParseTitle(string line);

        protected bool Parse(string regexPattern, string line)
        {
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            var match = regex.Match(line);

            if (!match.Success)
                return false;

            if (match.Groups.Count < 4)
                return false;

            Label = match.Groups[1].Value.Trim();
            Key = match.Groups[2].Value.Trim();
            Title = match.Groups[3].Value.Trim();

            if (string.IsNullOrEmpty(Label)) 
            {
                Label = (this is Act) ? "Acte" : "Scène";
            }

            return true;
        }
    }
}
