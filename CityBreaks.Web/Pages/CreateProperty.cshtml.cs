using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Pages;

public class CreatePropertyModel : PageModel
{
    private readonly CityBreaksContext _context;

    public CreatePropertyModel(CityBreaksContext context)
    {
        _context = context;
    }

    [BindProperty]

    public InputModel Input { get; set; } = new();
    public SelectList? CitiesSelectList { get; set; }
    [TempData]
    public string? MensagemConfirmacao { get; set; }

    public async Task OnGetAsync()
    {
        await CarregarCidadesAsync();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await CarregarCidadesAsync();
            return Page();
        }

        var novoHotel = new Property
        {
            Name = Input.Nome,
            PricePerNight = Input.ValorDiaria,
            CityId = Input.CityId
        };



        await _context.Properties.AddAsync(novoHotel);
        await _context.SaveChangesAsync();


        MensagemConfirmacao = $"Salvo no banco com sucesso! ID gerado: {novoHotel.Id}";
        await CarregarCidadesAsync();
        return Page();
    }


    public async Task CarregarCidadesAsync()
    {
        var cities = await _context.Cities.ToListAsync();
        CitiesSelectList = new SelectList(cities, "Id", "Name");
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do estabelecimento é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Range(0.01, 999999, ErrorMessage = "Informe um valor válido.")]
        public decimal ValorDiaria { get; set; }

        [Required(ErrorMessage = "Selecione uma cidade.")]
        public int CityId { get; set; }
    }

}

