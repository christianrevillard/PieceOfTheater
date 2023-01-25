using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PieceOfTheater.Model
{
    public class Line
    {
        public string Character { get; set; }
        public string Comment { get; set; }
        public string Text { get; set; }

        public Line(string regexPattern, string line)
        {
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            var match = regex.Match(line);

            if (match.Success)
            {
                Character = match.Groups[1].Value.Trim();
                Comment = match.Groups[2].Value.Trim();
                Text = match.Groups[3].Value.Trim();
            }
        }
    }
}
