using System.Collections.Generic;
using AspNetCore.Services.Content.Contacts.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Contacts
{
    public interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(string id);

        List<ContactViewModel> GetAll();

        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void SaveChanges();
    }
}