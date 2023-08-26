namespace PieceofTheater.Lib.Model
{

    public class Act : Subdivision<Scene> 
    {
        public override bool ParseTitle(string line)
        {
            if (Parse("^(PROLOGUE)()()$", line))
                return true;

            if (Parse("^(.{1,2}PILOGUE)()()$", line))
                return true;

            // explicit "acte", any type of numbers
            if (Parse("^(ACTE)(?: *)((?:[IXV]+)|(?:[0-9]+))(?: *[ :.] *)(.*)$", line))
                return true;

            // no explicit "acte", require roman numbers
            if (Parse("^()(?: *)([IXV]+)(?: *[ :.] *)(.*)$", line))
                return true;

            return false;
        }
    }
}
