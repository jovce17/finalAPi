﻿using System;
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

            CreateMap<OfficeViewModel, Office>()
                .ForPath(dest => dest.CityId, opts => opts.MapFrom(src => src.City.Id));
            CreateMap<Office, OfficeViewModel>()
                .ForPath(dest => dest.City.Id, input => input.MapFrom(src => src.CityId))
                .ForPath(dest => dest.City.Value, input => input.MapFrom(src => src.City.Name));

            CreateMap<ContactViewModel, Contact>()
                .ForPath(dest => dest.CityId, opts => opts.MapFrom(src => src.City.Id))
                .ForPath(dest => dest.ContactType, opts => opts.MapFrom(src => src.ContactType.Id))
                .ForPath(dest => dest.MaritialStatus, opts => opts.MapFrom(src => src.MaritialStatus.Id));
            CreateMap<Contact, ContactViewModel>()
                .ForPath(dest => dest.City.Id, input => input.MapFrom(src => src.CityId))
                .ForPath(dest => dest.City.Value, input => input.MapFrom(src => src.City.Name))
                .ForPath(dest => dest.ContactType.Id, input => input.MapFrom(src => src.ContactType))
                .ForPath(dest => dest.ContactType.Value , input => input.MapFrom(src => Enum.GetName(typeof(Enums.ContactType), src.ContactType) ))
                .ForPath(dest => dest.MaritialStatus.Id, input => input.MapFrom(src => src.MaritialStatus))
                .ForPath(dest => dest.MaritialStatus.Value, input => input.MapFrom(src => Enum.GetName(typeof(Enums.MaritialStatus), src.MaritialStatus)));





            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.DecryptedPassword, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => string.Join(";", src.Roles)));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.DecryptedPassword))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles.Split(";", StringSplitOptions.RemoveEmptyEntries)));

        }

    }





}
