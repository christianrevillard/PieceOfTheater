using PieceofTheater.Lib.Model;

namespace PieceOfTheater.Lib.Tests
{
    public class PlayModelTests
    {
        private string _testPlay = @"I. L'arc-en-ciel

1. Le vert
Rico: c'est tout vert
Gai: Ben oui
Rico: c'est rigolo 'ben oui'
Gai: Ben oui

2. Le rouge
Rico: tiens, voilà berek.
Gai: ben oui.
berek: bon j'ai trouvé quatre solutions possibles à la jaune
Rico: prout.On rouge, là.

II.Acteurs et Actrices

1. la triche
Zab: j'ai refait le classement, berek est dernier
Rico: c'est pas bien
Gai: Ben non
berek (dépité): y'a de la triche, je m'en vais

2. début de la fin
Rico: tiens, plus de berek
Gai (gai): ben non.
Zab: bon je vais me coucher

3. fin de la fin
Rico (fatigué): tiens, plus de zab
Gai (expressif): ben non.";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlayModelTest1()
        {
            IPlayModel playModel = new Play();

            playModel.Parse(_testPlay);

            Assert.That(playModel.Acts.Count(), Is.EqualTo(2));
            Assert.That(playModel.Acts.SelectMany(act=>act.Elements).Count(), Is.EqualTo(5));
            Assert.That(playModel.Acts.SelectMany(act => act.Elements).SelectMany(scene=>scene.Elements).Select(line=>line.Character).Distinct().Count(), Is.EqualTo(4));
        }
    }
}