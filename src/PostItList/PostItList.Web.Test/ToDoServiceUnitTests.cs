using System;
using System.Linq;
using Microsoft.Extensions.Options;

using PostItList.Web.Services;

using Xunit;
using Moq;
using PostItList.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace PostItList.Web.Test
{
    public class ToDoServiceUnitTests : IDisposable
    {
        //Credit to Tom Dodson https://github.com/t3dodson for help with UnitTesting

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
            IToDoService service = new ToDoService(mockOptions.Object, new GetAllNullHttpMessageHandler());

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
            IToDoService service = new ToDoService(mockOptions.Object, null);
            
            // act 
            var result = await service.Add(null);

            // assert
            Assert.Equal(result, default(Guid));
        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldIncreaseAllCountByOneWhenCallingAdd()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreeaseMessageHandler());

            var item = new ToDoItem();

            // act
            var countBefore = (await service.GetAll()).Count();
            await service.Add(item);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(countBefore + 1, afterCount);
        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldDecreaseAllCountByOneWhenCallingDelete()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreeaseMessageHandler());

            var item = new ToDoItem();

            // act
            await service.Add(item);
            await service.Add(item);
            var countBefore = (await service.GetAll()).Count();
            await service.Delete(item);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(countBefore - 1, afterCount);

        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldHandleEmptyDelete()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreeaseMessageHandler());

            var item = new ToDoItem();

            // act
            await service.Delete(item);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(0, afterCount);

        }
    }
}
