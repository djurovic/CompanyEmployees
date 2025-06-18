using CompanyEmployees.Presentation.Extensions;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies")]
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompaniesV2Controller : ApiControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesV2Controller(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var baseResult = _service.CompanyService.GetAllCompanies(trackChanges: false);
            var companies = baseResult.GetResult<IEnumerable<CompanyDto>>();
            return Ok(companies);
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetCompany(Guid id)
        {
            var baseResult = _service.CompanyService.GetCompany(id, trackChanges: false);
            if (!baseResult.Success)
                return ProcessError(baseResult);
            var company = baseResult.GetResult<CompanyDto>();

            return Ok(company);
        }

    }
}
