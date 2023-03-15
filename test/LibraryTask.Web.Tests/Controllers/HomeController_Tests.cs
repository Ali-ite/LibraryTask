using System.Threading.Tasks;
using LibraryTask.Models.TokenAuth;
using LibraryTask.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibraryTask.Web.Tests.Controllers
{
    public class HomeController_Tests: LibraryTaskWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}