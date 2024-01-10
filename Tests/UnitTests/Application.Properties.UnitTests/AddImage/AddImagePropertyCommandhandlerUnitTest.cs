using MU.Application.UseCases.Properties.Commands.AddImage;
using MU.Application.UseCases.Properties.Commands.Create;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace Application.Properties.UnitTests.AddImage
{
    public class AddImagePropertyCommandhandlerUnitTest
    {
        private Mock<IRepositoryProperty> _mockPropertyRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private AddImagePropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockPropertyRepository = new Mock<IRepositoryProperty>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new AddImagePropertyCommandHandler(_mockPropertyRepository.Object, _mockUnitOfWork.Object);
        }

        // Nomclature Used in tests name
        // what tests
        // the fact
        // should return
        [Test]
        public async Task HandleAddImageProperty_WhenExtentionFileIsInvalid_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[145];
            AddImagePropertyCommand command = new AddImagePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                "",
                bytes,
                "filename.pdf",
                145
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyImageErrors.ExtentionFileInvalid.Code);
        }

        [Test]
        public async Task HandleAddImageProperty_WhenFileLengthIsMoreGrant_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[1024*51];
            AddImagePropertyCommand command = new AddImagePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                "",
                bytes,
                "filename.png",
                (1024*51)
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyImageErrors.SizeFileInvalid.Code);
        }

        [Test]
        public async Task HandleAddImageProperty_WhenPropertyNotExists_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[1024 * 51];
            AddImagePropertyCommand command = new AddImagePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                "..\\MU.Infrastructure\\Services\\ImageStorage\\Properties\\047263c3-8c4f-4274-8103-dc74cf87f71d",
                bytes,
                "filename.png",
                (1024 * 50)
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.NotFound);
            result.FirstError.Code.Should().Be(PropertyImageErrors.PropertyNotFound.Code);
        }

        [Test]
        public async Task HandleAddImageProperty_WhenPathDirectoryNotSended_ShouldReturnValidationError()
        {
            // Arrange
            byte[] bytes = new byte[1024 * 51];
            AddImagePropertyCommand command = new AddImagePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                "",
                bytes,
                "filename.png",
                (1024 * 50)
            );

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(PropertyImageErrors.PathDirectoryNotGetted.Code);
        }

        [Test]
        public async Task HandleAddImageProperty_WhenPropertyImageIsSaved_ShouldReturnGuid()
        {
            // Arrange
            byte[] bytes = new byte[1024 * 51];
            AddImagePropertyCommand command = new AddImagePropertyCommand(
                new Guid("047263c3-8c4f-4274-8103-dc74cf87f71d"),
                "..\\MU.Infrastructure\\Services\\ImageStorage\\Properties\\047263c3-8c4f-4274-8103-dc74cf87f71d",
                bytes,
                "filename.png",
                (1024 * 50)
            );

            // set property in repository
            _mockPropertyRepository
            .Setup(x => x.SearchByIdAsync(It.IsAny<PropertyId>()))
            .ReturnsAsync(new Property(new PropertyId(Guid.NewGuid()), "", Address.Create("", "", "", "", ""), 0, InternalCodeProperty.Create("dasdds", 2018), 2018, new OwnerId(Guid.NewGuid()), true));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeFalse();
            Guid guidResult;
            Assert.IsTrue(Guid.TryParse(result.Value.ToString(), out guidResult));
        }
    }
}
