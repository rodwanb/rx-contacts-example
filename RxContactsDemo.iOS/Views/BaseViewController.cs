using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System;

namespace RxContactsDemo.iOS.Views
{
    public abstract class BaseViewController<T> : MvxBaseViewController<T> where T : MvxViewModel
    {
        protected readonly List<IDisposable> Disposables = new List<IDisposable>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupSubviews();
            SetupConstraints();
            SetupBindings();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            SetupObservers();
        }

        public override void ViewDidDisappear(bool animated)
        {
            DisposeObservers();
            base.ViewDidDisappear(animated);
        }

        protected virtual void SetupSubviews()
        {

        }

        protected virtual void SetupConstraints()
        {

        }

        protected virtual void SetupBindings()
        {

        }

        protected virtual void SetupObservers()
        {

        }

        protected virtual void DisposeObservers()
        {
            Disposables.ForEach(x => x.Dispose());
        }
    }
}
