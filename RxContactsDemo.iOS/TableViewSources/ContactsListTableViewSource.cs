using UIKit;
using MvvmCross.Platforms.Ios.Binding.Views;
using Foundation;
using RxContactsDemo.iOS.Views.Cells;
using System;

namespace RxContactsDemo.iOS.TableViewSources
{
    public class ContactsListTableViewSource : MvxTableViewSource
    {
        public ContactsListTableViewSource(UITableView tableView) : base(tableView)
        {
            tableView.RegisterClassForCellReuse(typeof(ContactItemTableViewCell), ContactItemTableViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            MvxTableViewCell cell = (MvxTableViewCell)tableView.DequeueReusableCell(ContactItemTableViewCell.Key);
            cell.DataContext = item;
            cell.SetNeedsUpdateConstraints();
            cell.UpdateConstraintsIfNeeded();
            return cell;
        }
    }
}
