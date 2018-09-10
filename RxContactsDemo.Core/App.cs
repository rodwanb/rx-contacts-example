using MvvmCross;
using MvvmCross.ViewModels;
using RxContactsDemo.Core.Services;
using RxContactsDemo.Core.ViewModels;

namespace RxContactsDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<IContactService, ContactService>();

            RegisterAppStart<ContactsListViewModel>();
        }
    }
}
