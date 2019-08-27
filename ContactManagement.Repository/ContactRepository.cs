using ContactManagement.Domain;
using ContactManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Repository
{
    public class ContactRepository : IContact
    {

        private EFDbContext context = new EFDbContext();

        private bool disposed = false;

        public IEnumerable<Contact> Contacts
        {
            get { return context.Contacts; }
        }

        public Contact Get(int? contactId)
        {
            return context.Contacts.Find(contactId);
        }

        public List<Contact> GetAll()
        {
            return context.Contacts.ToList();
        }

        public void Delete(int contactId)
        {
            context.Contacts.Remove(Get(contactId));
        }

        public void Add(Contact contact)
        {
            context.Contacts.Add(contact);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual void Update(Contact contact)
        {
            context.Entry<Contact>(contact).State = EntityState.Modified;
        }
    }
}
