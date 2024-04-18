using AutoMapper;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.Mapper
{
    /// <inheritdoc />
    public class MapProfile: Profile
    {
        /// <inheritdoc />
        public MapProfile()
        {
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<PropiedadDTO, Propiedad>().ReverseMap();
        }
    }
}
