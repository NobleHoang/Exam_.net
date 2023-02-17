using baseNetApi.models;
using Microsoft.EntityFrameworkCore;

namespace baseNetApi.context;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }
    
    public void Seed()
    {
        modelBuilder.Entity<User>().HasData(
             new User()
            {
                id = 1, role = Role.Admin, username = "admin",email = "admin@gmail.com",
                firstName = "Hiéu", lastName = "Hoang",
                phoneNumber = "0375886096", address = "VietNam",
                birthday = "20-10-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            },
            new User(){
                id = 2, role = Role.User, username = "user",email = "user@gmail.com",
                firstName = "User", lastName = "New",
                phoneNumber = "0968886868", address = "VietNam",
                birthday = "00-00-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
                
            }
        );
        modelBuilder.Entity<Groups>().HasData(
            new Groups()
            {
                id = 1, group_name = "Home"
            },
            new Groups()
            {
                id = 2, group_name = "Work"
            },
            new Groups()
            {
                id = 3, group_name = "Company"
            }
        );
        modelBuilder.Entity<Contacts>().HasData(
            new Contacts()
            {
                id = 1, group_id = 1, name = "DSLA",number = "0123456789"
            },
            new Contacts(){
                id = 2, group_id = 1, name = "XT-100",number = "0123456789"
            }
        );
    }
}