using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace KrchEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCompanies() => Ok(_service.CompanyService.GetAllCompanies(false));

    [HttpGet("{id:guid}")]
    public IActionResult GetCompany(Guid id) => Ok(_service.CompanyService.GetCompany(id, false));
}