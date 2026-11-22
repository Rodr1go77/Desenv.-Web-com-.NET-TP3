using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;
        public CityDetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }
        public City? City { get; set; }
        public async Task OnGetAsync(string name)
        {
            City = await _cityService.GetByNameAsync(name);
        }


    }
}
