using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Features.Users.Handlers;
using MaxCoRetailManager.Application.Features.Users.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using Moq;

namespace MaxCoretailManager.Application.Test.Users.Handler;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IAuthRepository> _mockUserRepository;
    private readonly Mock<IMapper> _mockMapper;
    public CreateUserCommandHandlerTests()
    {
        _mockUserRepository = new Mock<IAuthRepository>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_Should_Return_WhenEmailIsNotUnique()
    {

        //Arrange
        var mockUserRepository = new Mock<IAuthRepository>();
        var mockMapper = new Mock<IMapper>();

        UserCreateDto userCreateDto = new UserCreateDto();

        var command = new CreateUserCommand()
        {
            UserCreateDto = new UserCreateDto()
            {
                Email = "max@example.com",
                Password = "123455P,",
                UserName = "max@example.com",
                FirstName = "Max",
                LastName = "Doe",

            }
        };


        _mockMapper.Setup(m => m.Map<User>(command.UserCreateDto)).Returns(new User());

        var handler = new CreateUserHandler(
            mockUserRepository.Object, mockMapper.Object);

        //Act
        var result = await handler.Handle(command, CancellationToken.None);


        //Assert
        Assert.NotNull(result.IsSuccess.Equals(false));
        result.IsSuccess.Equals(false);
        result.Message.Equals("User exist already");


    }

    [Fact]
    public async Task Handle_Should_Return_WhenEmailIsUnqiue()
    {

        //Arrange
        var mockUserRepository = new Mock<IAuthRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateUserCommand()
        {
            UserCreateDto = new UserCreateDto()
            {
                Email = "admin@example.com",
                Password = "Password12$",
                UserName = "admin@example.com",
                FirstName = "Admin",
                LastName = "ADMIN",

            }
        };

        var handler = new CreateUserHandler(
            mockUserRepository.Object, mockMapper.Object);

        //Act
        var result = await handler.Handle(command, CancellationToken.None);


        //Assert
        Assert.NotNull(result.IsSuccess.Equals(true));
        result.IsSuccess.Equals(true);


    }

}
