using ContactManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Interface
{
    public interface IContact
    {
        IEnumerable<Contact> Contacts { get; }

        Contact Get(int? contactId);

        List<Contact> GetAll();

        void Add(Contact contact);

        void SaveChanges();

        void Delete(int contactId);

        void Update(Contact contact);

    }
}
