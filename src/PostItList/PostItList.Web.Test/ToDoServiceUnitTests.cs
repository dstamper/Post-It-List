using System;
using System.Linq;
using Microsoft.Extensions.Options;

using PostItList.Web.Services;

using Xunit;
using Moq;
using PostItList.Models;
using System.Threading.Tasks;

namespace PostItList.Web.Test
{
    public class ToDoServiceUnitTests : IDisposable
    {
        private readonly Mock<IOptions<Config.UserSettings>> mockOptions = new Mock<IOptions<Config.UserSettings>>();
        public ToDoServiceUnitTests()
        {
            // mock options to avoid null strings in service. 
            mockOptions
                .SetupGet(options => options.Value)
                .Returns(new Config.UserSettings
                {
                    APIURL = "http://fake.com"
                });
        }
        public void Dispose()
        {
            // clean up code here.
        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldNotAllowNullToBeReturnedFromGetAll()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object);

            // act 
            var items = await service.GetAll();

            // assert
            Assert.NotNull(items);
        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldNotAllowNullToBeAdded()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object);
            
            // act 
            var result = await service.Add(null);
            var items = await service.GetAll();

            // assert
            Assert.False(result, "Adding null was successful, but shouldn't be.");
            Assert.DoesNotContain(null, items);
        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldIncreaseAllCountByOneWhenCallingAdd()
        {
            // TODO refactor code to make this test case possible.

            // arrange
            IToDoService service = new ToDoService(mockOptions.Object);

            var item = new ToDoItem
            {
                Title = "Fix more unit tests."
            };

            // act
            var countBefore = (await service.GetAll()).Count();
            await service.Add(item);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(countBefore + 1, afterCount);
        }
    }
}
