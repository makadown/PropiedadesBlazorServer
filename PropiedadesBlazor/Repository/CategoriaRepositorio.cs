using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropiedadesBlazor.Repository
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CategoriaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try 
            {
                if (categoriaDTO != null && categoriaId == categoriaDTO.Id)
                { 
                    var categoria = await db.Categoria.FindAsync(categoriaDTO.Id);
                    if (categoria == null)
                    {
                        return null;
                    }
                    var cate = mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaActualizada = db.Categoria.Update(cate);
                    await db.SaveChangesAsync();
                    return mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
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

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            var categoriaCreada = await db.Categoria.AddAsync(categoria);
            await db.SaveChangesAsync();
            return mapper.Map<Categoria, CategoriaDTO>(categoriaCreada.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriasDTO =
                    mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(await db.Categoria.ToArrayAsync());
                return categoriasDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                var cat = await db.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId);
                CategoriaDTO categoriaDTO =
                    mapper.Map<Categoria,CategoriaDTO>(cat);
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await db.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId);
            if (categoria != null) 
            {
                db.Categoria.Remove(categoria);
                return await db.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<CategoriaDTO> NombreCategoriaExiste(string nombre)
        {
            try
            {
                var cat = await db.Categoria.FirstOrDefaultAsync(c => c.NombreCategoria.ToLower() == nombre.ToLower());
                CategoriaDTO categoriaDTO =
                    mapper.Map<Categoria, CategoriaDTO>(cat);
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias()
        {
            try
            {
                IEnumerable<DropDownCategoriaDTO> dropDownCategoriasDTO =
                    mapper.Map<IEnumerable<Categoria>, IEnumerable<DropDownCategoriaDTO>>(db.Categoria);
                return (dropDownCategoriasDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
