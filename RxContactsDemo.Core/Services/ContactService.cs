using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RxContactsDemo.Core.ViewModels.Items;
using System;
using System.Linq;

namespace RxContactsDemo.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly List<ContactItem> _contactItems = new List<ContactItem>
        {
            new ContactItem { Name = "Rodwan Barbier", Number = "071 352 8666" },
            new ContactItem { Name = "Andy Arendse", Number = "073 325 0176" },
            new ContactItem { Name = "Liam Pillaye", Number = "083 444 3211" },
            new ContactItem { Name = "Loyiso Mtshali", Number = "076 737 6893" },
            new ContactItem { Name = "Regardt Schindler", Number = "078 110 5868" },
            new ContactItem { Name = "Martin Kirsten", Number = "073 223 0276" },
            new ContactItem { Name = "Amina Latief", Number = "071 504 9773" },
            new ContactItem { Name = "Unathi Gqontshi", Number = "076 225 5658" },
            new ContactItem { Name = "Loanne Myburgh", Number = "078 889 2231" }
        };

        public async Task<IEnumerable<ContactItem>> GetContactItems(
            string filter = null,
            CancellationToken token = default(CancellationToken))
        {
            await Task.Delay(TimeSpan.FromMilliseconds(300), token);
            var results = string.IsNullOrWhiteSpace(filter)
                ? _contactItems
                : _contactItems.Where(x => x.Name.ToLower().Contains(filter.ToLower()) || x.Number.Contains(filter));

            return results.OrderBy(x => x.Name);
        }
    }
}
