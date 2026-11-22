
using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        public Property? Property { get; set; }

        public SelectList? CitiesSelectList { get; set; }

        [TempData]
        public string? MensagemConfirmacao { get; set; }

        public IActionResult OnGet(int id)
        {
            Property = _context.Properties.FindAsync(id).GetAwaiter().GetResult();

            if (Property is null)
            {
                return NotFound();
            }

            CitiesSelectList = new SelectList(_context.Cities.ToList(), "Id", "Name");
            return Page();

        }


        public IActionResult OnPost(int id)
        {
            var propertyToEdit = _context.Properties.FindAsync(id).GetAwaiter().GetResult();

            if (propertyToEdit is null)
            {
                return NotFound();
            }

            var propertyAtualizada = TryUpdateModelAsync(
                propertyToEdit,
                nameof(Property),
                i => i.Name,
                i => i.PricePerNight,
                i => i.CityId)
                .GetAwaiter()
                .GetResult();

            if (!propertyAtualizada || !ModelState.IsValid)
            {
                CitiesSelectList = new SelectList(_context.Cities.ToList(), "Id", "Name");
                Property = propertyToEdit;
                return Page();
            }

            _context.SaveChangesAsync().GetAwaiter().GetResult();

            MensagemConfirmacao = "Registro editado e salvo com sucesso!";
            return RedirectToPage("/Index");
        }


    }
}
