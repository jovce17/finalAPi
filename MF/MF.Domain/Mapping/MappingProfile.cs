using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MF.Entity;
using MF.Domain;

namespace MF.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create automap mapping profiles
        /// </summary>
        public MappingProfile()
        {
            CreateMap<AccountViewModel, Account>();
            CreateMap<Account, AccountViewModel>();

            CreateMap<CityViewModel, City>();
            CreateMap<City, CityViewModel>();

            CreateMap<ContactViewModel, Contact>()
                .ForMember(dest => dest.CityId, opts => opts.MapFrom(src => src.City.Id));
                

            CreateMap<Contact, ContactViewModel>()
                .ForMember(dest => dest.City.Id, input => input.MapFrom(src => src.CityId))
                .ForMember(dest => dest.City.Value, input => input.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.ContactType.Id, input => input.MapFrom(src => src.ContactType))
                .ForMember(dest => dest.ContactType.Value , input => input.MapFrom(src => Enum.GetName(typeof(Enums.ContactType), src.ContactType) ));




            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.DecryptedPassword, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => string.Join(";", src.Roles)));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.DecryptedPassword))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles.Split(";", StringSplitOptions.RemoveEmptyEntries)));

        }

    }





}
