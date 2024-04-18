using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.Repository
{
	public class PropiedadRepositorio : IPropiedadRepositorio
	{
		private readonly ApplicationDbContext db;
		private readonly IMapper mapper;

		public PropiedadRepositorio(ApplicationDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}
		public async Task<PropiedadDTO?> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO)
		{
			try
			{
				if (propiedadDTO != null && propiedadId == propiedadDTO.Id)
				{
					var Propiedad = await db.Propiedad.FindAsync(propiedadDTO.Id);
					if (Propiedad == null)
					{
						return null;
					}
					var prope = mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO, Propiedad);
					prope.FechaActualizacion = DateTime.Now;
					var PropiedadActualizada = db.Propiedad.Update(prope);
					await db.SaveChangesAsync();
					return mapper.Map<Propiedad, PropiedadDTO>(PropiedadActualizada.Entity);
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO)
		{
			var propiedad = mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO);
			propiedad.FechaCreacion = DateTime.Now;
			var PropiedadCreada = await db.Propiedad.AddAsync(propiedad);
			await db.SaveChangesAsync();
			return mapper.Map<Propiedad, PropiedadDTO>(PropiedadCreada.Entity);
		}

		public async Task<IEnumerable<PropiedadDTO>> GetAll()
		{
			try
			{
				IEnumerable<PropiedadDTO> PropiedadsDTO =
					mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(await db.Propiedad.ToArrayAsync());
				return PropiedadsDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<PropiedadDTO?> GetPropiedad(int PropiedadId)
		{
			try
			{
				var cat = await db.Propiedad.FirstOrDefaultAsync(c => c.Id == PropiedadId);
				if (cat == null) return null;
				PropiedadDTO PropiedadDTO =
					mapper.Map<Propiedad, PropiedadDTO>(cat);
				return PropiedadDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<int> BorrarPropiedad(int propiedadId)
		{
			var propiedad = await db.Propiedad.FirstOrDefaultAsync(c => c.Id == propiedadId);
			if (propiedad != null)
			{
				db.Propiedad.Remove(propiedad);
				return await db.SaveChangesAsync();
			}
			return -1;
		}

		public async Task<PropiedadDTO> NombrePropiedadExiste(string nombre)
		{
			try
			{
				var prop = await db.Propiedad.FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
				if (prop == null) return null;
				PropiedadDTO PropiedadDTO =
					mapper.Map<Propiedad, PropiedadDTO>(prop);
				return PropiedadDTO;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
