using Microsoft.Extensions.Logging;
using Moq;
using ToDoList.Core.Services;
using ToDoList.Infrastructure.Models;
using ToDoList.Tests.ServiceMocks;

namespace ToDoList.Tests.CoreTests
{
    public class ToDoServiceTests
    {
        private IToDoService? _sut;
        private ToDoRepositoryMock? _repositoryMock;
        private readonly Mock<ILogger<ToDoService>> _loggerMock = new();

        [Fact]
        public void Test_Constructor_InitializationFailure_WhenServiceIsNull()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();

            //Act
            var arrangeRepoNull = new Action(() => new ToDoService(null, _loggerMock.Object));
            var arrangeLoggerNull = new Action(() => new ToDoService(_repositoryMock.Object, null));

            //Assert 
            var exceptionRepo = Record.Exception(arrangeRepoNull);
            var exceptionLogger = Record.Exception(arrangeLoggerNull);
            Assert.NotNull(exceptionRepo);
            Assert.NotNull(exceptionLogger);
        }

        #region GetAll

        [Fact]
        public async Task Test_GetAllToDosAsync_WhenMethodThrowsException_ResultException()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_GetAll_WithException();
            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            Func<Task> act = async () => await _sut.GetAllToDosAsync();

            //Assert 
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Test_GetAllToDosAsync_WhenMethodWorksCorrectly_ResultList()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();

            IEnumerable<ToDo> dataToTest = new List<ToDo>() { new() { Id = 1, Title = "Test" } };
            _repositoryMock.Setup_GetAll_WithCustomResponse(dataToTest);

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var result = await _sut.GetAllToDosAsync();

            //Assert 
            Assert.NotNull(result);
            Assert.Equal(dataToTest.Count(), result.Count);
        }

        #endregion

        #region GetById

        [Fact]
        public async Task Test_GetToDoByIdAsync_WhenMethodThrowsException_ResultException()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_GetById_WithException();
            int id = 1;

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            Func<Task> act = async () => await _sut.GetToDoByIdAsync(id);

            //Assert 
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Test_GetToDoByIdAsync_WhenMethodWorksCorrectly_ResultList()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();

            var dataToTest = new ToDo { Id = 1, Title = "Test" };
            _repositoryMock.Setup_GetById_WithCustomResponse(dataToTest);
            int id = 1;

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var result = await _sut.GetToDoByIdAsync(id);

            //Assert 
            Assert.NotNull(result);
            Assert.Equal(dataToTest.Id, result.Id);
            Assert.Equal(dataToTest.Title, result.Title);
        }

        #endregion

        #region CreateNewToDo

        [Fact]
        public async Task Test_CreateNewToDoAsync_WhenMethodThrowsException_ResultException()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_AddNew_WithException();

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            Func<Task> act = async () => await _sut.CreateNewToDoAsync(new ToDo());

            //Assert 
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Test_CreateNewToDoAsync_WhenMethodWorksCorrectly_ResultList()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();

            var dataToTest = new ToDo { Title = "Test" };
            _repositoryMock.Setup_AddNew_WithCustomResponse(true);

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var result = await _sut.CreateNewToDoAsync(dataToTest);

            //Assert 
            Assert.True(result);
        }

        #endregion

        #region UpdateToDo
        
        [Fact]
        public async Task Test_UpdateToDoAsync_WhenMethodThrowsException_ResultException()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_Update_WithException();

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            Func<Task> act = async () => await _sut.UpdateToDoAsync(new ToDo());

            //Assert 
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Test_UpdateToDoAsync_WhenMethodWorksCorrectly_ResultList()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();

            var dataToTest = new ToDo { Id = 1, Title = "Test" };
            _repositoryMock.Setup_Update_WithCustomResponse(true);

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var result = await _sut.UpdateToDoAsync(dataToTest);

            //Assert 
            Assert.True(result);
        }
        #endregion

        #region Delete
        
        [Fact]
        public async Task Test_DeleteToDoAsync_WhenMethodThrowsException_ResultException()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_Delete_WithException();
            int id = 1;

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            Func<Task> act = async () => await _sut.DeleteToDoAsync(id);

            //Assert 
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Test_DeleteToDoAsync_WhenMethodWorksCorrectly_ResultList()
        {
            //Arrange
            _repositoryMock = new ToDoRepositoryMock();
            _repositoryMock.Setup_Delete_WithCustomResponse(true);
            int id = 1;

            _sut = new ToDoService(_repositoryMock.Object, _loggerMock.Object);

            //Act
            var result = await _sut.DeleteToDoAsync(id);

            //Assert 
            Assert.True(result);
        }
        #endregion
    }
}