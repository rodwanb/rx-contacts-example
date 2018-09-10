using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace RxContactsDemo.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private bool _busy;

        protected readonly List<IDisposable> Disposables = new List<IDisposable>();

        public bool Busy
        {
            get => _busy;
            set => SetProperty(ref _busy, value);
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            SetupObservers();
        }

        public override void ViewDisappeared()
        {
            DisposeObservables();
            base.ViewDisappeared();
        }

        protected virtual void SetupObservers()
        {

        }

        protected virtual void DisposeObservables()
        {
            Disposables.ForEach(x => x.Dispose());
        }
    }
}
