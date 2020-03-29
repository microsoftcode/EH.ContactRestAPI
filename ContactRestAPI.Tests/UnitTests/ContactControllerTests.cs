using ContactRestAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using ContactRestAPI.Data;
using Microsoft.Extensions.Logging;
using ContactApi.Data;
using System.Threading.Tasks;

namespace ContactRestAPI.Tests.UnitTests
{
    public class ContactControllerTests
    {
        private readonly Mock<IContactRepository> _contactRepository;
        private readonly Mock<ILogger<ContactController>> _logger;
        private readonly ContactController controller;

        public ContactControllerTests()
        {
            _contactRepository = new Mock<IContactRepository>();
            _logger = new Mock<ILogger<ContactController>>();
            controller = new ContactController(_contactRepository.Object, _logger.Object);
        }

        [Fact]
        public void Delete_IdDoesNotExists_ReturnsNotFoundResult()
        {
            //Arange
            int tobeDeletedId = 1;
            Contact fakeContact = null;
            _contactRepository.Setup(x => x.GetById(tobeDeletedId)).Returns(Task.FromResult(fakeContact));
            //Act
            var result = controller.Delete(tobeDeletedId);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            _contactRepository.VerifyAll();
            _contactRepository.Verify(x => x.GetById(tobeDeletedId), Times.Once);
            _contactRepository.Verify(x => x.Delete(tobeDeletedId), Times.Never);

        }

        [Fact]
        public void Delete_IdExists_ReturnsOkResult()
        {
            //Arange
            int tobeDeletedId = 1;
            Contact fakeContact = new Contact { Id = 1, FirstName = "Amit", LastName = "Patil", Email = "patilbamit@gmail.com", Status = (int)StatusEnum.Active };
            _contactRepository.Setup(x => x.GetById(tobeDeletedId)).Returns(Task.FromResult(fakeContact));
            //Act
            var result = controller.Delete(tobeDeletedId);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            _contactRepository.VerifyAll();
            _contactRepository.Verify(x => x.GetById(tobeDeletedId), Times.Once);
            _contactRepository.Verify(x => x.Delete(tobeDeletedId), Times.Once);



        }

        [Fact]
        public void GetById_IdDoesNotExists_ReturnsNotFoundResult()
        {

            //Arange
            int fakeId = 1;
            Contact fakeContact = null;
            _contactRepository.Setup(x => x.GetById(fakeId)).Returns(Task.FromResult(fakeContact));

            //Act
            var result = controller.GetById(fakeId);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            _contactRepository.VerifyAll();
            _contactRepository.Verify(x => x.GetById(fakeId), Times.Once);
        }

        [Fact]
        public void GetById_IdExists_ReturnsOkResult()
        {


            //Arange
            int fakeId = 1;
            Contact fakeContact = new Contact { Id = 1, FirstName = "Amit", LastName = "Patil", Email = "patilbamit@gmail.com", Status = (int)StatusEnum.Active };
            _contactRepository.Setup(x => x.GetById(fakeId)).Returns(Task.FromResult(fakeContact));

            //Act
            var result = controller.GetById(fakeId);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            _contactRepository.VerifyAll();
            _contactRepository.Verify(x => x.GetById(fakeId), Times.Once);
        }
    }
}
