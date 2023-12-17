using AutoMapper;
using CRM.Trust.Application.Services.Persons.Models;
using CRM.Trust.Domain.Core;

namespace CRM.Trust.Application.Services.Persons.Mappings;

public class PersonMappings : Profile
{
    public PersonMappings()
    {
        CreateMap<Person, UploadPersonModel>()
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(
                dest => dest.MiddleName,
                opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();
        
        CreateMap<Person, PersonDetailsModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(
                dest => dest.MiddleName,
                opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();
        
        CreateMap<PersonJob, PersonJobModel>()
            .ForMember(
                dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.CompanyName))
            .ForMember(
                dest => dest.Position,
                opt => opt.MapFrom(src => src.Position))
            .ForMember(
                dest => dest.SalaryAmount,
                opt => opt.MapFrom(src => src.SalaryAmount))
            .ForMember(
                dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate))
            .ReverseMap();
        
        CreateMap<PersonPassport, PersonPassportModel>()
            .ForMember(
                dest => dest.Series,
                opt => opt.MapFrom(src => src.Series))
            .ForMember(
                dest => dest.Number,
                opt => opt.MapFrom(src => src.Number))
            .ForMember(
                dest => dest.IssuedBy,
                opt => opt.MapFrom(src => src.IssuedBy))
            .ForMember(
                dest => dest.IssueDate,
                opt => opt.MapFrom(src => src.IssueDate))
            .ForMember(
                dest => dest.DepartmentNumber,
                opt => opt.MapFrom(src => src.DepartmentNumber))
            .ForMember(
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate))
            .ReverseMap();
        
        CreateMap<PersonContact, PersonContactModel>()
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber))
            .ReverseMap();
        
        CreateMap<Loan, PersonLoanModel>()
            .ForMember(
                dest => dest.LoanId,
                opt => opt.MapFrom(src => src.LoanId))
            .ForMember(
                dest => dest.CreditType,
                opt => opt.MapFrom(src => src.CreditType))
            .ForMember(
                dest => dest.Amount,
                opt => opt.MapFrom(src => src.Amount))
            .ForMember(
                dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate))
            .ForMember(
                dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate))
            .ReverseMap();
    }
}