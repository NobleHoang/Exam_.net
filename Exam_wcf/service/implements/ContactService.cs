using AutoMapper;
using baseNetApi.config;
using baseNetApi.context;
using baseNetApi.models;
using baseNetApi.models.products;
using baseNetApi.service.interfaces;

namespace baseNetApi.service;

public class ContactService : IContactService
{
    private MySQLDBContext _context;
    private readonly IMapper _mapper;
    
    public ContactService(
        MySQLDBContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public IEnumerable<Contacts> GetAll()
    {
        return _context.Contacts;
    }

    public Contacts GetById(int id)
    {
        return getContacts(id);
    }

    public void Update(int id, UpdateContactRequest model)
    {
        var contacts = getContacts(id);
        
        if(model.name == null)
            throw new AppException("Name invalid!");
        contacts.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        var groups = _context.Groups.Find(model.group_id);
        if (groups == null)
        {
            throw new KeyNotFoundException("Group not found");
        }
        _mapper.Map(model, contacts);
        _context.Contacts.Update(contacts);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var contacts = getContacts(id);
        contacts.DeletedAt = DateTimeOffset.Now.AddHours(7);
        _context.Contacts.Remove(contacts);
        _context.SaveChanges();
    }

    public void Create(CreateContactRequest model)
    {
        var contacts = _mapper.Map<Contacts>(model);

        if (model.name == null)
        {
            throw new AppException("Name invalid!");
        }
        var groups = _context.Groups.Find(model.group_id);
        if (groups == null)
        {
            throw new KeyNotFoundException("Group not found");
        }
        contacts.CreatedAt = DateTimeOffset.Now.AddHours(7);

        _context.Contacts.Add(contacts);
        _context.SaveChanges();
    }
    
    private Contacts getContacts(int id)
    {
        var contacts = _context.Contacts.Find(id);
        if (contacts == null) 
            throw new KeyNotFoundException("Contact not found");
        return contacts;
    }
}