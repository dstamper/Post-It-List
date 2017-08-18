/* Copyright(c) 2017 Jonathan Jensen, David Stamper
    This work is available under the "MIT license".
    Please see the file LICENSE in the PostItList Github
    for license terms.*/
using System;
using System.Linq;
using Microsoft.Extensions.Options;

using PostItList.Web.Services;

using Xunit;
using Moq;
using PostItList.Models;
using System.Threading.Tasks;
using System.Net.Http;
using PostItList.Web.Test.ToDoServiceMocks;

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
        public async void MultipleAdds()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreaseMessageHandler());

            // act 
            var item = new ToDoItem { Title = "Same Item" };
            var item1 = await service.Add(item);
            var item2 = await service.Add(item);

            // assert
            Assert.NotEqual(item1, item2);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldNotAllowNullInEdit()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreaseMessageHandler());
            
            // act 
            var result = await service.Edit(null);

            // assert
            Assert.Equal(result, false);
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
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreaseMessageHandler());

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
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreaseMessageHandler());

            var item = new ToDoItem();
            var item2 = new ToDoItem();
            item.Id = Guid.NewGuid();

            // act
            await service.Add(item);
            await service.Add(item2);
            var countBefore = (await service.GetAll()).Count();
            await service.Delete(item.Id);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(countBefore - 1, afterCount);

        }
        [Fact]
        [Trait("Category", "Unit")]
        public async void ShouldHandleEmptyDelete()
        {
            // arrange
            IToDoService service = new ToDoService(mockOptions.Object, new IncreaseDecreaseMessageHandler());

            var item = new ToDoItem();
            item.Id = Guid.NewGuid();

            // act
            await service.Delete(item.Id);
            var afterCount = (await service.GetAll()).Count();

            // assert
            Assert.Equal(0, afterCount);

        }
    }
}
