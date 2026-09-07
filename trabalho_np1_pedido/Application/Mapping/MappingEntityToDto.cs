using AutoMapper;
using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Domain.Entity;

namespace trabalho_np1_pedido.Application.Mapping
{
    public class MappingEntityToDto : Profile
    {
        public MappingEntityToDto()
        {
            CreateMap<Order, OrderItemDto>();
            CreateMap<Order, OrderItemAddDto>();
        }
    }
}
