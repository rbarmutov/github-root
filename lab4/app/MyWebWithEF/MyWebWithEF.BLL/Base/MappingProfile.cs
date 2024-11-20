using AutoMapper;
using MyWebWithEF.BLL.Components.CategoryComponent.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг для Travel
        CreateMap<Travel, TravelDto>().ReverseMap();

        // Мапінг для Category
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
