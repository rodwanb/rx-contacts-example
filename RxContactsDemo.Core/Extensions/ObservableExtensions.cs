using System;
using System.Reactive;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace RxContactsDemo.Core.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<EventPattern<PropertyChangedEventArgs>> ObservableFromPropertyChanged(this INotifyPropertyChanged source)
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                h => source.PropertyChanged += h,
                h => source.PropertyChanged -= h);
        }

        public static void DisposeWith(this IDisposable source, IList<IDisposable> disposables)
        {
            disposables?.Add(source);
        }
    }
}
