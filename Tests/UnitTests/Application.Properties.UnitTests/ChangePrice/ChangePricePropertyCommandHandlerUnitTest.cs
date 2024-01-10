using MU.Application.UseCases.Properties.Commands.AddImage;
using MU.Application.UseCases.Properties.Commands.ChangePrice;
using MU.Application.UseCases.Properties.Commands.UpdatePrice;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Primitives;

namespace Application.Properties.UnitTests.ChangePrice
{
    public class ChangePricePropertyCommandHandlerUnitTest
    {
        private Mock<IRepositoryProperty> _mockPropertyRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private ChangePricePropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockPropertyRepository = new Mock<IRepositoryProperty>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new ChangePricePropertyCommandHandler(_mockPropertyRepository.Object, _mockUnitOfWork.Object);
        }

        // Nomclature Used in tests name
        // what tests
        // the fact
        // should return
        [Test]
        public async Task HandleChangePriceProperty_WhenPropertyNotExists_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[145];
            ChangePricePropertyCommand command = new ChangePricePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                0
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.NotFound);
            result.FirstError.Code.Should().Be(PropertyErrors.propertyNotFound.Code);
        }
    }
}