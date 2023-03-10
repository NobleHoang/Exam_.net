using baseNetApi.models;
using baseNetApi.models.products;

namespace baseNetApi.service.interfaces;

public interface IContactService
{
    IEnumerable<Contacts> GetAll();
    Contacts GetById(int id);
    void Update(int id, UpdateContactRequest model);
    void Delete(int id);
    void Create(CreateContactRequest model);
}