using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.EntityFrameworkCore;


namespace CityBreaks.Web.Pages
{
    public class FilterPropertiesModel : PageModel
    {

        private readonly PropertyService _service;

        public FilterPropertiesModel(PropertyService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CityName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PropertyName { get; set; }

        public List<Property> Resultados { get; set; } = [];


        public async Task OnGetAsync()
        {
            Resultados = await _service.GetFilteredAsync(
                MinPrice,
                MaxPrice,
                CityName,
                PropertyName);
        }


    }


}
