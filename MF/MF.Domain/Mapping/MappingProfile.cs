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
                .ForMember(dest => dest.CityId, opts => opts.MapFrom(src => src.City.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.City, opts => opts.Ignore());
            CreateMap<Office, OfficeViewModel>()
                .ForPath(dest => dest.City.Id, input => input.MapFrom(src => src.CityId))
                .ForPath(dest => dest.City.Value, input => input.MapFrom(src => src.City.Name));

            CreateMap<ContactViewModel, Contact>()
                .ForPath(dest => dest.CityId, opts => opts.MapFrom(src => src.City.Id))
                .ForPath(dest => dest.ContactType, opts => opts.MapFrom(src => src.ContactType.Id))
                .ForPath(dest => dest.MaritialStatus, opts => opts.MapFrom(src => src.MaritialStatus.Id))
                .ForMember(dest => dest.City, opts => opts.Ignore());
            CreateMap<Contact, ContactViewModel>()
                .ForPath(dest => dest.City.Id, input => input.MapFrom(src => src.CityId))
                .ForPath(dest => dest.City.Value, input => input.MapFrom(src => src.City.Name))
                .ForPath(dest => dest.ContactType.Id, input => input.MapFrom(src => src.ContactType))
                .ForPath(dest => dest.ContactType.Value , input => input.MapFrom(src => Enum.GetName(typeof(Enums.ContactType), src.ContactType) ))
                .ForPath(dest => dest.MaritialStatus.Id, input => input.MapFrom(src => src.MaritialStatus))
                .ForPath(dest => dest.MaritialStatus.Value, input => input.MapFrom(src => Enum.GetName(typeof(Enums.MaritialStatus), src.MaritialStatus)));


            CreateMap<ApplicationViewModel, Application>()
                .ForPath(dest => dest.OfficeId, opts => opts.MapFrom(src => src.Office.Id))
                .ForPath(dest => dest.ClientContactId, opts => opts.MapFrom(src => src.ClientContact.Id))
                .ForPath(dest => dest.LoanOfficerContactId, opts => opts.MapFrom(src => src.LoanOfficerContact.Id))
                .ForPath(dest => dest.Status, opts => opts.MapFrom(src => src.Status.Id))
                .ForMember(dest => dest.Office, opts => opts.Ignore())
                .ForMember(dest => dest.ClientContact, opts => opts.Ignore())
                .ForMember(dest => dest.LoanOfficerContact, opts => opts.Ignore()); 
            CreateMap<Application, ApplicationViewModel>()
                .ForPath(dest => dest.Office.Id, input => input.MapFrom(src => src.OfficeId))
                .ForPath(dest => dest.Office.Value, input => input.MapFrom(src => src.Office.Name))
                .ForPath(dest => dest.ClientContact.Id, input => input.MapFrom(src => src.ClientContactId))
                .ForPath(dest => dest.ClientContact.Value, input => input.MapFrom(src => src.ClientContact.Name+' ' + src.ClientContact.Surname))
                .ForPath(dest => dest.LoanOfficerContact.Id, input => input.MapFrom(src => src.LoanOfficerContactId))
                .ForPath(dest => dest.LoanOfficerContact.Value, input => input.MapFrom(src => src.LoanOfficerContact.Name+ ' ' + src.LoanOfficerContact.Surname))
                .ForPath(dest => dest.Status.Id, input => input.MapFrom(src => src.Status))
                .ForPath(dest => dest.Status.Value, input => input.MapFrom(src => Enum.GetName(typeof(Enums.ApplicationStatus), src.Status)));


            CreateMap<ApplicationApprovalViewModel, ApplicationApproval>()
                 .ForPath(dest => dest.ApplicationId, opts => opts.MapFrom(src => src.Application.Id))
                 .ForPath(dest => dest.UserId, opts => opts.MapFrom(src => src.User.Id))
                 .ForPath(dest => dest.Status, opts => opts.MapFrom(src => src.Status.Id))
                .ForMember(dest => dest.Application, opts => opts.Ignore())
                .ForMember(dest => dest.User, opts => opts.Ignore());
            CreateMap<ApplicationApproval, ApplicationApprovalViewModel>()
                 .ForPath(dest => dest.Application.Id, opts => opts.MapFrom(src => src.ApplicationId))
                 .ForPath(dest => dest.Application.Value, opts => opts.MapFrom(src => src.Application.ApplicationNumber))
                 .ForPath(dest => dest.User.Id, opts => opts.MapFrom(src => src.UserId))
                 .ForPath(dest => dest.User.Value, opts => opts.MapFrom(src => src.User.UserName))
                 .ForPath(dest => dest.Status.Id, input => input.MapFrom(src => src.Status))
                 .ForPath(dest => dest.Status.Value, input => input.MapFrom(src => Enum.GetName(typeof(Enums.ApplicationApprovalStatus), src.Status)));


            CreateMap<LoanViewModel, Loan>()
                .ForPath(dest => dest.OfficeId, opts => opts.MapFrom(src => src.Office.Id))
                .ForPath(dest => dest.ApplicationId, opts => opts.MapFrom(src => src.Application.Id))
                .ForPath(dest => dest.ClientContactId, opts => opts.MapFrom(src => src.ClientContact.Id))
                .ForPath(dest => dest.LoanOfficerContactId, opts => opts.MapFrom(src => src.LoanOfficerContact.Id))
                .ForPath(dest => dest.Status, opts => opts.MapFrom(src => src.Status.Id))
                .ForMember(dest => dest.Application, opts => opts.Ignore())
                .ForMember(dest => dest.ClientContact, opts => opts.Ignore())
                .ForMember(dest => dest.Office, opts => opts.Ignore())
                .ForMember(dest => dest.LoanOfficerContact, opts => opts.Ignore());
            CreateMap<Loan, LoanViewModel>()
                .ForPath(dest => dest.Office.Id, input => input.MapFrom(src => src.OfficeId))
                .ForPath(dest => dest.Office.Value, input => input.MapFrom(src => src.Office.Name))
                .ForPath(dest => dest.Application.Id, input => input.MapFrom(src => src.ApplicationId))
                .ForPath(dest => dest.Application.Value, input => input.MapFrom(src => src.Application.ApplicationNumber))
                .ForPath(dest => dest.ClientContact.Id, input => input.MapFrom(src => src.ClientContactId))
                .ForPath(dest => dest.ClientContact.Value, input => input.MapFrom(src => src.ClientContact.Name + ' ' + src.ClientContact.Surname))
                .ForPath(dest => dest.LoanOfficerContact.Id, input => input.MapFrom(src => src.LoanOfficerContactId))
                .ForPath(dest => dest.LoanOfficerContact.Value, input => input.MapFrom(src => src.LoanOfficerContact.Name + ' ' + src.LoanOfficerContact.Surname))
                .ForPath(dest => dest.Status.Id, input => input.MapFrom(src => src.Status))
                .ForPath(dest => dest.Status.Value, input => input.MapFrom(src => Enum.GetName(typeof(Enums.LoanStatus), src.Status)));


            CreateMap<RepaymentPlanViewModel, RepaymentPlan>()
                .ForPath(dest => dest.LoanId, opts => opts.MapFrom(src => src.Loan.Id))
                .ForMember(dest => dest.Loan, opts => opts.Ignore());
            CreateMap<RepaymentPlan, RepaymentPlanViewModel>()
                .ForPath(dest => dest.Loan.Id, opts => opts.MapFrom(src => src.LoanId))
                .ForPath(dest => dest.Loan.Value, opts => opts.MapFrom(src => src.Loan.AgreementNumber));



            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.DecryptedPassword, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => string.Join(";", src.Roles)));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.DecryptedPassword))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles.Split(";", StringSplitOptions.RemoveEmptyEntries)));

        }

    }





}
