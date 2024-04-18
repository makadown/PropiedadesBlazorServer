using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Modelos;

namespace PropiedadesBlazor.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Categoria> Categoria { get; set; }
		public DbSet<Propiedad> Propiedad { get; set; }
	}
}
