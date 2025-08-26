using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContactFormApi.Tests
{
    public class ContactFormControllerTests
    {
        private readonly ContactFormController _controller;
        private readonly Mock<IContactFormService> _mockService;
        private readonly Mock<ILogger<ContactFormController>> _mockLogger;

        public ContactFormControllerTests()
        {
            _mockService = new Mock<IContactFormService>();
            _mockLogger = new Mock<ILogger<ContactFormController>>();
            _controller = new ContactFormController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateContactForm_ReturnsCreatedResult()
        {
            var contactForm = new ContactForm { Name = "John Doe", Phone = "1234567890", Email = "john@example.com", Departments = new[] { "Sales" }, Description = "Test description" };
            _mockService.Setup(service => service.CreateContactFormAsync(contactForm)).ReturnsAsync(true);

            var result = await _controller.CreateContactForm(contactForm);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task GetContactForm_ReturnsOkResult()
        {
            var contactForm = new ContactForm { Id = 1, Name = "John Doe", Phone = "1234567890", Email = "john@example.com", Departments = new[] { "Sales" }, Description = "Test description" };
            _mockService.Setup(service => service.GetContactFormAsync(1)).ReturnsAsync(contactForm);

            var result = await _controller.GetContactForm(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateContactForm_ReturnsNoContentResult()
        {
            var contactForm = new ContactForm { Id = 1, Name = "John Doe", Phone = "1234567890", Email = "john@example.com", Departments = new[] { "Sales" }, Description = "Updated description" };
            _mockService.Setup(service => service.UpdateContactFormAsync(contactForm)).ReturnsAsync(true);

            var result = await _controller.UpdateContactForm(contactForm.Id, contactForm);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteContactForm_ReturnsNoContentResult()
        {
            _mockService.Setup(service => service.DeleteContactFormAsync(1)).ReturnsAsync(true);

            var result = await _controller.DeleteContactForm(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetMonthlyReport_ReturnsOkResult()
        {
            var reportData = new List<MonthlyReportDto> { new MonthlyReportDto { Month = "January", Count = 5 } };
            _mockService.Setup(service => service.GetMonthlyReportAsync()).ReturnsAsync(reportData);

            var result = await _controller.GetMonthlyReport();

            Assert.IsType<OkObjectResult>(result);
        }
    }
}