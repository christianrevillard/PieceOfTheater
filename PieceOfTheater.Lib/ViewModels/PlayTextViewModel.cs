using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;

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

        private string _input = @"1. Découverte du concours
Braou et Crouic entrent ensemble.

Braou : Eh ! Regarde, une affiche?
Crouic : Ça dit quoi ?

Ils lisent.

Braou : Des Olympiades pour les enfants !
Crouic : Avec des récompenses pour les meilleurs !
Braou : Je vais gagner ! Il faut que je m?inscrive !
Crouic : Euh? Il faut que JE m?inscrive parce que JE vais gagner !
Braou : Tu rêves? T?es aussi nul qu?une mouche?
Crouic : Tu rigoles ?
Braou : Attends, moi, je suis super fort en plein de choses !
Crouic : Et moi, encore plus de choses !
Braou : Ouais, ben moi, mon frère a une trottinette !
Crouic : Et moi, mon oncle, il est boucher !
Braou : Mon père connaît le maire !
Crouic : Ben moi, je vais faire la meilleure équipe du monde !
Braou : JE vais faire la meilleure équipe ! Toi, tu vas te faire éplucher !
Crouic : Prépare-toi à pleurer comme une sardine !

Ils sortent chacun d?un côté

2. Casting pour l?équipe

Doumb : Vous avez vu qu?il y avait des Olympiades ?
Frisk : Oui, c?est pour ça qu?on";

        //        private string _input = @"I. L'arc-en-ciel

        //1. Le vert
        //Rico: c'est tout vert
        //Gai: Ben oui
        //Rico: c'est rigolo 'ben oui'
        //Gai: Ben oui

        //2. Le rouge
        //Rico: tiens, voilà berek.
        //Gai: ben oui.
        //berek: bon j'ai trouvé quatre solutions possibles à la jaune
        //Rico: prout.On rouge, là.

        //II.Acteurs et Actrices

        //1. la triche
        //Zab: j'ai refait le classement, berek est dernier
        //Rico: c'est pas bien
        //Gai: Ben non
        //berek (dépité): y'a de la triche, je m'en vais

        //2. début de la fin
        //Rico: tiens, plus de berek
        //Gai (gai): ben non.
        //Zab: bon je vais me coucher

        //3. fin de la fin
        //Rico (fatigué): tiens, plus de zab
        //Gai (expressif): ben non.";
        public string Input { get { return _input; } set { Set(ref _input, value); } }

    }
}