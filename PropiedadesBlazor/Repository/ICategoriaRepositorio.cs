using PropiedadesBlazor.Modelos.DTO;
using System.Linq;

namespace PropiedadesBlazor.Repository
{
    public interface ICategoriaRepositorio
    {
        public Task<IEnumerable<CategoriaDTO>> GetAll();
        public Task<CategoriaDTO> GetCategoria(int categoriaId);
        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);
        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);
        public Task<CategoriaDTO> NombreCategoriaExiste(string nombre);
        public Task<int> BorrarCategoria(int categoriaId);
        // public Task<IEnumerable<CategoriaDTO>> GetDropDownCategorias();
    }
}
