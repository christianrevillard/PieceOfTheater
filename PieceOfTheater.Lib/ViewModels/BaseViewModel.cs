using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PieceofTheater.Lib.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        IMediator _mediator;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }
        public virtual void OnAppearing() { }
        public virtual void OnDisappearing() { }

        protected BaseViewModel(IMediator mediator)
        {
            _mediator = mediator;

            _mediator.Subscribe("Disappearing", () =>
            {
                if (IsSelected)
                {
                    IsSelected = false;
                    this.OnDisappearing();
                }
            });

            _mediator.Subscribe<Type>("Appearing", selectedViewModel =>
            {
                if (selectedViewModel.IsAssignableFrom(this.GetType()) && !IsSelected)
                {
                    IsSelected = true;
                    this.OnAppearing();
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName))
            {
                return false;
            }
            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}