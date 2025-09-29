using Application.DataTransferObjects;
using Application.DomainEvents;
using AutoMapper;
using Domain.Entities;
using Automovil = Domain.Entities.Automovil;

namespace Application.Mappings
{
    /// <summary>
    /// El mapeo entre objetos debe ir definido aqui
    /// </summary>
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DummyEntity, DummyEntityCreated>().ReverseMap();
            CreateMap<DummyEntity, AutomovilUpdated>().ReverseMap();
            CreateMap<DummyEntity, DummyEntityDto>().ReverseMap();
            CreateMap<Automovil, AutomovilCreado>().ReverseMap();

            CreateMap<Alumno, AlumnoCreado>().ReverseMap();
        }
    }
}
