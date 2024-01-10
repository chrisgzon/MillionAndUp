using MU.Application.UseCases.Properties.Commands.Create;
using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces.Repositories;
using MU.Domain.Primitives;

namespace Application.Properties.UnitTests.Create
{
    public class CreatePropertyCommandHandlerUnitTest
    {
        private Mock<IRepositoryOwner> _mockOwnerRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private CreatePropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockOwnerRepository = new Mock<IRepositoryOwner>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreatePropertyCommandHandler(_mockOwnerRepository.Object, _mockUnitOfWork.Object);
        }

        // Nomclature Used in tests name
        // what tests
        // the fact
        // should return
        [Test]
        public async Task HandleCreateProperty_WhenAddressHasBadFormat_ShouldReturnValidationError()
        {
            // Arrange
            CreatePropertyCommand command = new CreatePropertyCommand(
                "",
                "Miami",
                "Florida",
                "", 
                "", // not passed value in line and line2
                "1105",
                0, 
                0, 
                Guid.NewGuid(),
                true
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyErrors.AddressWithBadFormat.Code);
        }

        [Test]
        public async Task HandleCreateProperty_WhenNameOrYearIsNotSended_ShouldReturnValidationError()
        {
            // Arrange
            CreatePropertyCommand command = new CreatePropertyCommand(
                "name", // passed name length less than 5 chars
                "Miami",
                "Florida",
                "1102",
                "",
                "1105",
                2018,
                0, // or not passed year or year is more grand than year current
                Guid.NewGuid(),
                true
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyErrors.cannotCreateCodeInternal.Code);
        }

        [Test]
        public async Task HandleCreateProperty_WhenOwnerNotExists_ShouldReturnValidationError()
        {
            // Arrange
            CreatePropertyCommand command = new CreatePropertyCommand(
                "names",
                "Miami",
                "Florida",
                "1102",
                "",
                "1105",
                2018,
                2022,
                Guid.NewGuid(),
                true
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.NotFound);
            result.FirstError.Code.Should().Be(PropertyErrors.ownerNotFound.Code);
        }
    }
}