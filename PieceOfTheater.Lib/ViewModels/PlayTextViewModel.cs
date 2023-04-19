using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System.Linq;
using System.Windows.Input;

namespace PieceofTheater.Lib.ViewModels
{
    public interface IPlayTextViewModel
    {
    }


    internal class PlayTextViewModel : BaseViewModel, IPlayTextViewModel
    {
        IPlayModel _model;
        public PlayTextViewModel(IPlayModel playModel, IMediator mediator) :base (mediator)
        {
            _model = playModel;
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            _model.Parse(Input);
        }

        private string _input = @"I. L'arc-en-ciel

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
        public string Input { get { return _input; } set { Set(ref _input, value); } }

    }
}