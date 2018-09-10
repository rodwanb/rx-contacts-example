using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RxContactsDemo.Core.ViewModels.Items;

namespace RxContactsDemo.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactItem>> GetContactItems(
            string filter = null,
            CancellationToken token = default(CancellationToken));
    }
}
