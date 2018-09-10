using System;
using Foundation;
using UIKit;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using RxContactsDemo.Core.ViewModels.Items;
using MvvmCross.Platforms.Ios.Binding;

namespace RxContactsDemo.iOS.Views.Cells
{
    public class ContactItemTableViewCell : TableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(ContactItemTableViewCell));

        private readonly UILabel _nameLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextAlignment = UITextAlignment.Left,
            Lines = 1,
            TextColor = UIColor.Gray,
            Font = UIFont.BoldSystemFontOfSize(16),
            LineBreakMode = UILineBreakMode.TailTruncation
        };

        private readonly UILabel _numberLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextAlignment = UITextAlignment.Left,
            TextColor = UIColor.LightGray,
            Lines = 1,
            LineBreakMode = UILineBreakMode.TailTruncation,
            Font = UIFont.SystemFontOfSize(14)
        };

        public ContactItemTableViewCell(IntPtr handle) : base(handle)
        {
        }

        protected override void SetupSubviews()
        {
            ContentView.Add(_nameLabel);
            ContentView.Add(_numberLabel);
        }

        protected override void SetupConstraints()
        {
            ContentView.AddConstraints(new[]
            {
                _nameLabel.AtTopOf(ContentView, 10),
                _nameLabel.AtLeftOf(ContentView, 20),
                _nameLabel.AtRightOf(ContentView, 20),

                _numberLabel.Below(_nameLabel, 5),
                _numberLabel.WithSameLeft(_nameLabel),
                _numberLabel.WithSameRight(_nameLabel),
                _numberLabel.AtBottomOf(ContentView, 10),
            });
        }

        protected override void SetupBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactItemTableViewCell, ContactItem>();

                set.Bind(_nameLabel)
                   .For(v => v.BindText())
                   .To(vm => vm.Name);

                set.Bind(_numberLabel)
                   .For(v => v.BindText())
                   .To(vm => vm.Number);

                set.Apply();
            });
        }
    }
}
