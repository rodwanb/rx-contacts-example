using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using RxContactsDemo.Core.Extensions;
using RxContactsDemo.Core.Services;
using RxContactsDemo.Core.ViewModels.Items;

namespace RxContactsDemo.Core.ViewModels
{
    public class ContactsListViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        private string _filter;

        public ContactsListViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ObservableCollection<ContactItem> ContactItems { get; } = new ObservableCollection<ContactItem>();

        public string Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value);
        }

        protected override void SetupObservers()
        {
            base.SetupObservers();

            this.ObservableFromPropertyChanged()
                .Throttle(TimeSpan.FromSeconds(1.5))
                .Select(_ => Filter)
                .StartWith(string.Empty)
                .DistinctUntilChanged()
                .Do(_ => Busy = true)
                .Select(filter => Observable.FromAsync(token => _contactService.GetContactItems(filter, token))) // IObservable<IEnumerable<ContactItem>>
                .Switch() // IObservable<IEnumerable<ContactItem>> turns into IEnumerable<ContactItem>
                .Subscribe(results =>
                {
                    ContactItems.Clear();
                    results.ForEach(x => ContactItems.Add(x));
                    Busy = false;
                })
                .DisposeWith(Disposables);
        }
    }
}
