using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WlZ.Products.Api.Models.DTOs;
using WlZ.Products.Api.Models.Entities;

namespace WlZ.Products.Api
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Subcategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, Subcategory>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Subcategory, opts => opts.MapFrom(src => src.IdsubcategoryNavigation.Name))
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.IdsubcategoryNavigation.IdcategoryNavigation.Name))
                ;
            CreateMap<ProductDto, Product>();
        }
    }
}
