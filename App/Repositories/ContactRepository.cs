﻿using App.Data;
using App.Models;

namespace App.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToList();
        }
        public ContactModel Create(ContactModel contact)
        {
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();

            return contact; 
        }
    }
}
