using Microsoft.AspNetCore.Mvc;
using ContactFormApi.Models;
using ContactFormApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactFormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly ContactFormService _contactFormService;

        public ContactFormController(ContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        [HttpPost]
        public async Task<ActionResult<ContactForm>> CreateContactForm(ContactForm contactForm)
        {
            var createdForm = await _contactFormService.CreateContactFormAsync(contactForm);
            return CreatedAtAction(nameof(GetContactForm), new { id = createdForm.Id }, createdForm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactForm>> GetContactForm(int id)
        {
            var contactForm = await _contactFormService.GetContactFormByIdAsync(id);
            if (contactForm == null)
            {
                return NotFound();
            }
            return contactForm;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactForm(int id, ContactForm contactForm)
        {
            if (id != contactForm.Id)
            {
                return BadRequest();
            }

            await _contactFormService.UpdateContactFormAsync(contactForm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactForm(int id)
        {
            var result = await _contactFormService.DeleteContactFormAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("monthly-report")]
        public async Task<ActionResult<IEnumerable<ContactForm>>> GetMonthlyReport()
        {
            var report = await _contactFormService.GetMonthlyReportAsync();
            return Ok(report);
        }
    }
}