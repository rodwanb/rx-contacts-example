using System;
using System.Reactive.Linq;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using RxContactsDemo.Core.Extensions;
using RxContactsDemo.Core.ViewModels;
using RxContactsDemo.iOS.TableViewSources;
using UIKit;
using System.Collections.Generic;

namespace RxContactsDemo.iOS.Views
{
    public class ContactsListView : BaseViewController<ContactsListViewModel>
    {
        #region Privates
        private readonly UITextField _searchTextField = new UITextField
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Placeholder = "Search",
            TextColor = UIColor.Black,
            BackgroundColor = UIColor.Clear
        };

        private readonly UIView _separatorView = new UIView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.LightGray
        };

        private readonly UITableView _tableView = new UITableView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            RowHeight = UITableView.AutomaticDimension,
            EstimatedRowHeight = 80,
            BackgroundColor = UIColor.Clear,
        };
        #endregion

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            Title = "Contacts";
            NavigationController.NavigationBar.Translucent = false;
            View.BackgroundColor = UIColor.White;

            View.Add(_searchTextField);
            View.Add(_separatorView);
            View.Add(_tableView);
        }

        protected override void SetupConstraints()
        {
            base.SetupConstraints();

            View.AddConstraints(new[]
            {
                _searchTextField.AtTopOf(View, 15),
                _searchTextField.AtLeftOf(View, 20),
                _searchTextField.AtRightOf(View, 20),

                _separatorView.Below(_searchTextField, 15),
                _separatorView.AtLeftOf(View),
                _separatorView.AtRightOf(View),
                _separatorView.Height().EqualTo(1),

                _tableView.Below(_separatorView),
                _tableView.AtLeftOf(View),
                _tableView.AtRightOf(View),
                _tableView.AtBottomOf(View)
            });
        }

        protected override void SetupBindings()
        {
            base.SetupBindings();

            var source = new ContactsListTableViewSource(_tableView);
            _tableView.Source = source;

            var set = this.CreateBindingSet<ContactsListView, ContactsListViewModel>();

            set.Bind(source)
               .For(s => s.ItemsSource)
               .To(vm => vm.ContactItems);

            set.Bind(_searchTextField)
               .For(v => v.BindText())
               .To(vm => vm.Filter);

            set.Apply();
        }

        protected override void SetupObservers()
        {
            base.SetupObservers();

            ViewModel.ObservableFromPropertyChanged()
                     .Where(x => x.EventArgs.PropertyName == nameof(ViewModel.Busy))
                     .Select(_ => ViewModel.Busy)
                     .StartWith(false)
                     .DistinctUntilChanged()
                     .Subscribe(busy => UIApplication.SharedApplication.NetworkActivityIndicatorVisible = busy)
                     .DisposeWith(Disposables);
        }
    }
}
