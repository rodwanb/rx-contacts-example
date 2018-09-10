using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace RxContactsDemo.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<Core.App>, Core.App>
    {
    }
}

