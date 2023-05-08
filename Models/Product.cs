using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.SqlServer;

namespace SupermarketWEB.Models
{
	public class Product
	{
		//[Key] -> Anotacion si la propiedad no se llama Id, ejemplo ProductId
		public int Id { get; set; } //sera la llave primaria
        [Required]
        public string Name { get; set; }

		[Column(TypeName = "decimal(6,2)")]
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; } //Sera la LLave foranea
		public Category Category { get; set; } //Propiedad de navegación

	}
}
