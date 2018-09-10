using System;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace RxContactsDemo.iOS.Views.Cells
{
    public abstract class TableViewCell : MvxTableViewCell
    {
        private bool _constraintsSetup;

        protected TableViewCell(IntPtr handle) : base(handle)
        {
            TranslatesAutoresizingMaskIntoConstraints = false;
            BackgroundColor = UIColor.Clear;
            SelectionStyle = UITableViewCellSelectionStyle.None;
            Setup();
        }

        protected virtual void ViewUpdated()
        {
            // To be implemented by derived classes
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            ViewUpdated();
        }

        public override void LayoutIfNeeded()
        {
            base.LayoutIfNeeded();
            ViewUpdated();
        }

        private void Setup()
        {
            SetupSubviews();
            SetupBindings();
        }

        protected abstract void SetupConstraints();
        protected abstract void SetupBindings();
        protected abstract void SetupSubviews();

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();

            if (_constraintsSetup)
            {
                return;
            }

            SetupConstraints();

            _constraintsSetup = true;
        }
    }
}
