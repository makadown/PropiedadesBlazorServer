using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Modelos
{
	public class Propiedad
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; } = string.Empty;
		[Required]
		public string Descripcion { get; set; } = string.Empty;
		/// <summary>
		/// Area en metros^2
		/// </summary>
		[Required]
		public int Area { get; set; }
		[Required]
		public int Habitaciones { get; set; }
		[Required]
		public int Banios { get; set; }
		[Required]
		public int Parqueaderos { get; set; } = 0;
		[Required]
		public decimal Precio { get; set; }
		[Required]
		public bool Activo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaActualizacion { get; set; }

		// Relación con modelo/tabla categoria
		public int CategoriaId { get; set; }
		[ForeignKey("CategoriaId")]
		public virtual Categoria? Categoria { get; set; }
	}
}
