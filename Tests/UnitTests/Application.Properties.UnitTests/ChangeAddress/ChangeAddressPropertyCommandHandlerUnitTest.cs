using MU.Application.UseCases.Properties.Commands.ChangeAddress;
using MU.Application.UseCases.Properties.Commands.ChangePrice;
using MU.Application.UseCases.Properties.Commands.UpdatePrice;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace Application.Properties.UnitTests.ChangeAddress
{
    internal class ChangeAddressPropertyCommandHandlerUnitTest
    {
        private Mock<IRepositoryProperty> _mockPropertyRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private ChangeAddressPropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockPropertyRepository = new Mock<IRepositoryProperty>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new ChangeAddressPropertyCommandHandler(_mockPropertyRepository.Object, _mockUnitOfWork.Object);
        }

        // Nomclature Used in tests name
        // what tests
        // the fact
        // should return
        [Test]
        public async Task HandleChangeAddressProperty_WhenAddressHasbadFormat_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[145];
            ChangeAddressPropertyCommand command = new ChangeAddressPropertyCommand(
                Guid.NewGuid(),
                "",
                "",
                "",
                "",
                ""
            );

            // set property in repository
            _mockPropertyRepository
                .Setup(x => x.SearchByIdAsync(It.IsAny<PropertyId>()))
                .ReturnsAsync(new Property(new PropertyId(Guid.NewGuid()), "", Address.Create("", "", "", "", ""), 0, InternalCodeProperty.Create("dasdds", 2018), 2018, new OwnerId(Guid.NewGuid()), true));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyErrors.AddressWithBadFormat.Code);
        }
    }
}