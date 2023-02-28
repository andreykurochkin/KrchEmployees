using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace KrchEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetEmployeesForCompany(Guid companyId) =>
        Ok(_service.EmployeeService.GetEmployees(companyId, false));
}