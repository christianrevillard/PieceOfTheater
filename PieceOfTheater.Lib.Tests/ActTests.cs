using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PieceofTheater.Lib.Model;

namespace PieceOfTheater.Lib.Tests
{
    public class ActTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("I.abcdef", "roman, dot separator")]
        [TestCase("II:abcdef", "roman, colon separator")]
        [TestCase("V abcdef", "roman, space separator")]
        [TestCase("XX : abcdef", "roman additional spaces")]
        [TestCase("Acte I.abcdef", "Explicit Acte, roman, dot")]
        [TestCase("ActeII:abcdef", "Explicit Acte, roman, colon")]
        [TestCase("Acte   1 abcdef", "Explicit Acte, roman, spaces")]
        [TestCase("Acte 23.abcdef", "Explicit Acte, arabic, dot")]
        [TestCase("Acte4:abcdef", "Explicit Acte, arabic, colon")]
        [TestCase("Acte   5 abcdef", "Explicit Acte, arabic, spaces")]
        public void ActTests_ParseTitle_Success(string title, string message)
        {
            Act act= new Act();
            Assert.That(act.ParseTitle(title), message);
        }

        [Test]
        [TestCase("IIabcdef", "No separator")]
        [TestCase("1: abcdef", "Must use roman number or explicit ACTE")]
        public void ActTests_ParseTitle_NotATitle(string title, string message)
        {
            Act act= new Act();
            Assert.That(act.ParseTitle(title) == false, message);
        }
    }
}