using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class CreateCustomerModel : PageModel
    {
        private readonly AppDbInMemoryContext _db;

        private ILogger<CreateCustomerModel> _log;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customers { get; set; }

        public CreateCustomerModel(AppDbInMemoryContext db, ILogger<CreateCustomerModel> log)
        {
            this._db = db;
            this._log = log;
        }

        public async Task<IActionResult>  OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var msg = $"Customer {Customers.Name} added!!";
            _db.Customers.Add(this.Customers);
            await _db.SaveChangesAsync();
            Message = msg;
            _log.LogCritical(msg);
            return RedirectToPage("/Index");
        }
    }
}