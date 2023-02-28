using AutoMapper;
using Entities;
using Entities.Models;
using Shared.DataTransferObjects;

namespace KrchEmployees;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForCtorParam(
                nameof(CompanyDto.FullAddress),
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country))
            );
        CreateMap<Employee, EmployeeDto>();
    }
}