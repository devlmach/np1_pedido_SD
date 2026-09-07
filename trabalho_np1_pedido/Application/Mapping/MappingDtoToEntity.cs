using AutoMapper;
using trabalho_np1_pedido.Domain.Entity;

namespace trabalho_np1_pedido.Application.Mapping
{
    public class MappingDtoToEntity : Profile
    {
        public MappingDtoToEntity()
        {
            CreateMap<OrderItemDto, Order>();
            CreateMap<OrderItemAddDto, Order>();
        }
    }
}
