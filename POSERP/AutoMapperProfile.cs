using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Repository.EDMX;

namespace POSERPAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductEntity>();
            //CreateMap<IEnumerable<Product>, IEnumerable<ProductEntity>>();
        }
    }
}
