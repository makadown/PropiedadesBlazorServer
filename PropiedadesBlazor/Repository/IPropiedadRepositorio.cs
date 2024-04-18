using PropiedadesBlazor.Modelos.DTO;
using System.Linq;

namespace PropiedadesBlazor.Repository
{
    public interface IPropiedadRepositorio
    {
        public Task<IEnumerable<PropiedadDTO>> GetAll();
        public Task<PropiedadDTO> GetPropiedad(int PropiedadId);
        public Task<PropiedadDTO> CrearPropiedad(PropiedadDTO PropiedadDTO);
        public Task<PropiedadDTO> ActualizarPropiedad(int PropiedadId, PropiedadDTO PropiedadDTO);
        public Task<PropiedadDTO> NombrePropiedadExiste(string nombre);
        public Task<int> BorrarPropiedad(int PropiedadId);
    }
}
