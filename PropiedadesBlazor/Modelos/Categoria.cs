﻿using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCategoria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        public virtual ICollection<Propiedad> Propiedades { get; set; } = new List<Propiedad>();
    }
}
