using MvvmCross.ViewModels;

namespace RxContactsDemo.Core.ViewModels.Items
{
    public class ContactItem : MvxNotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _number;
        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }
    }
}
