using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactFormApi.Data;
using ContactFormApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactFormApi.Services
{
    public class ContactFormService
    {
        private readonly ContactFormDbContext _context;

        public ContactFormService(ContactFormDbContext context)
        {
            _context = context;
        }

        public async Task<ContactForm> CreateContactForm(ContactForm contactForm)
        {
            _context.ContactForms.Add(contactForm);
            await _context.SaveChangesAsync();
            return contactForm;
        }

        public async Task<ContactForm> GetContactForm(int id)
        {
            return await _context.ContactForms.FindAsync(id);
        }

        public async Task<IEnumerable<ContactForm>> GetAllContactForms()
        {
            return await _context.ContactForms.ToListAsync();
        }

        public async Task<ContactForm> UpdateContactForm(ContactForm contactForm)
        {
            _context.Entry(contactForm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contactForm;
        }

        public async Task DeleteContactForm(int id)
        {
            var contactForm = await _context.ContactForms.FindAsync(id);
            if (contactForm != null)
            {
                _context.ContactForms.Remove(contactForm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MonthlyReport>> GetMonthlyReport()
        {
            return await _context.MonthlyReports.FromSqlRaw("EXEC GetMonthlyReport").ToListAsync();
        }
    }
}