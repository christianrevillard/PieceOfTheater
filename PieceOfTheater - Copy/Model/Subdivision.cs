using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Xaml.Shapes;

namespace PieceOfTheater.Model
{
    public abstract class Subdivision<T>
    {
        public string Label { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }

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
            return true;
        }
    }

    public class Subdivision
    {
        //protected string DefaultLabel {get; set;}
        //protected string ParsedLabel { get; set;}
        //protected string ParsedKey { get; set; }
        //protected string ParsedTitle { get; set; }

        //public string GetLabel()
        //{
        //    return ParsedLabel ?? DefaultLabel;
        //}

        //public string GetKey()
        //{
        //    return ParsedKey ?? DisplayString().Substring(0,1);
        //}

        //public string DisplayString()
        //{
        //    return string.IsNullOrEmpty(ParsedKey) ?
        //        (string.IsNullOrEmpty(ParsedLabel) ? "" : $"{GetLabel()} {ParsedTitle}") :
        //            $"{GetLabel()} {ParsedKey} {ParsedTitle}";
            
//        }
    }
}
