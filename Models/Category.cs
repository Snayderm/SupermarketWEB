namespace SupermarketWEB.Models
{
	public class Category
	{
		public int Id { get; set; } //sera la llave primaria
		public string Name { get; set; }
		public string? Description { get; set; }


		public ICollection<Product> Products { get; set; }//Propiedad de navegacion

	}
}