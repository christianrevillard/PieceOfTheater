using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace PieceOfTheater.Model
{

    public class Act : Subdivision<Scene> 
    {
        // defaultLabel = Acte

        public override bool ParseTitle(string line)
        {
            //var actRegex = @"^((?:PROLOGUE)|(?:.{1,2}PILOGUE)|(?:ACTE)|(?:))(?: *)((?:[IXV]{1,4}\.?)|(?:[0-9]*\.?))(?: *)(.*)$";
            //       $standAloneKeyFormat = "/^[IXV]{0,4}\.$/i";

            if (Parse("^(PROLOGUE)()()$", line))
                return true;

            if (Parse("^(.{1,2}PILOGUE)()()$", line))
                return true;

            if (Parse("^(ACTE)(?: *)((?:[IXV]{1,4}\\.?)|(?:[0-9]*\\.?))(?: *)(.*)$", line))
                return true;

            if (Parse("^()((?:[IXV]{1,4}\\.?))(?: *)(.*)$", line))
                return true;

            return false;
        }
    }
}
