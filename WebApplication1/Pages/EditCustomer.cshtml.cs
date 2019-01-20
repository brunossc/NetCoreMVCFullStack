using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditCustomerModel : PageModel
    {
        private readonly AppDbInMemoryContext _db;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditCustomerModel(AppDbInMemoryContext db)
        {
            this._db = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customers.FindAsync(id);

            if (Customer == null)
            {
                return RedirectToPage("./index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
  
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Customer).State = EntityState.Modified;
 
            try
            {               
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception($"Customer {Customer.Name} not found!", ex);
            }
            
            return RedirectToPage("./index");
            
        }
    }

}