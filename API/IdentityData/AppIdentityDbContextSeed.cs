using System.Linq;
using System.Threading.Tasks;
using API.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.IdentityData
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Adress = new Adress {
                        FirstName = "Bob",
                        LastNAme = "Bobsy",
                        Street = "Sojana Miljkovica",
                        City = "Drazevac",
                        ZipCode = " 11000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}