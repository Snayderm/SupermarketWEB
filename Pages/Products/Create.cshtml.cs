using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        // Esta propiedad se utiliza para mostrar la lista de categor�as en el formulario
        public List<Category> CategoryList { get; set; }

        // Esta acci�n se ejecuta cuando se carga la p�gina (m�todo HTTP GET)
        public async Task<IActionResult> OnGetAsync()
        {
            // Cargamos la lista de categor�as desde la base de datos
            CategoryList = await _context.Categories.ToListAsync();

            // Devolvemos la p�gina correspondiente
            return Page();
        }

        // Esta propiedad se utiliza para enlazar los datos del formulario con el modelo de datos Product
        [BindProperty]
        public Product Product { get; set; }

        // Esta acci�n se ejecuta cuando se env�a el formulario (m�todo HTTP POST)
        public async Task<IActionResult> OnPostAsync()
        {
            // Verificamos si el modelo de datos Product es v�lido y si no es nulo
            Console.WriteLine(Product);
            if (!ModelState.IsValid || Product == null || _context.Products == null)
            {
                // Si el modelo no es v�lido o es nulo, recargamos la lista de categor�as y devolvemos la p�gina correspondiente
                CategoryList = await _context.Categories.ToListAsync();
                //return Page();
            }

            // Agregamos el objeto Product a la base de datos
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            // Redirigimos al usuario a la p�gina de Index de productos
            return RedirectToPage("./Index");
        }
    }
}
