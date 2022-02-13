using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            CreateMap<AppUserEntity, IdentityUser>();
            //CreateMap<UserForRegistrationDto, User>()
            //    .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
