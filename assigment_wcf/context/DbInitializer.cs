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
                 address = "VietNam",
                birthday = "20-10-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            },
            new User(){
                id = 2, role = Role.User, username = "user",email = "user@gmail.com",
                firstName = "User", lastName = "New",
                address = "VietNam",
                birthday = "00-00-2003", gender = "Male",
                password = BCrypt.Net.BCrypt.HashPassword("123456")
                
            }
        );
        modelBuilder.Entity<Categories>().HasData(
            new Categories()
            {
                id = 1, category = "Home"
            },
            new Categories()
            {
                id = 2, category = "Camera"
            },
            new Categories()
            {
                id = 3, category = "Card"
            }
        );
        modelBuilder.Entity<Products>().HasData(
            new Products()
            {
                 name = "DSLA 60D"
            },
            new Products(){
               name = "XT-100"
            },
            new Products()
            {
             name = "16Gb"
            }
        );
    }
}