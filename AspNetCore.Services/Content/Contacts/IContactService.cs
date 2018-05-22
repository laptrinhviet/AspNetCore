using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Content.Contacts.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Contacts
{
    public interface IContactService : IWebServiceBase<Contact, string, ContactViewModel>
    {
        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);
        //
        //void Add(ContactViewModel contactVm);
        //void Update(ContactViewModel contactVm);    
        //void Delete(int id);
        //ContactViewModel GetById(int id);
        //List<ContactViewModel> GetAll();  
    }
}