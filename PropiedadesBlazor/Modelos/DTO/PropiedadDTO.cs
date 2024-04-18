using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Modelos.DTO
{
	public class PropiedadDTO
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El campo es requerido")]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "El campo debe tener longitud entre 5 y 30 caracteres")]
		public string Nombre { get; set; } = string.Empty;
		[Required(ErrorMessage = "El campo es requerido")]
		[StringLength(300, MinimumLength = 20, ErrorMessage = "El campo debe tener longitud entre 20 y 300 caracteres")]
		public string Descripcion { get; set; } = string.Empty;
		/// <summary>
		/// Area en metros^2
		/// </summary>
		[Required(ErrorMessage = "El campo es requerido")]
		[Range(1, 5000, ErrorMessage = "El valor debe estar entre 1 y 5000")]
		public int Area { get; set; }
		[Required(ErrorMessage = "El campo es requerido")]
		[Range(1, 10, ErrorMessage = "El valor debe estar entre 1 y 10")]
		public int Habitaciones { get; set; }
		[Required(ErrorMessage = "El campo es requerido")]
		[Range(1, 5, ErrorMessage = "El valor debe estar entre 1 y 5")]
		public int Banios { get; set; }
		[Required(ErrorMessage = "El campo es requerido")]
		[Range(1, 20, ErrorMessage = "El valor debe estar entre 1 y 20")]
		public int Parqueaderos { get; set; } = 0;
		[Required(ErrorMessage = "El campo es requerido")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Precio { get; set; }
		[Required(ErrorMessage = "El campo es requerido")]
		public bool Activo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaActualizacion { get; set; }

		// Relación con modelo/tabla categoria
		public int CategoriaId { get; set; }
	}
}
