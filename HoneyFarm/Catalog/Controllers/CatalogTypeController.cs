using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogTypeController : ControllerBase
    {
        private readonly ILogger<CatalogTypeController> _logger;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogTypeController(
            ILogger<CatalogTypeController> logger,
            ICatalogTypeService catalogTypeService)
        {
            _catalogTypeService = catalogTypeService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddTypeResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateTypeRequest request)
        {
            var result = await _catalogTypeService.Add(request.Name);
            return Ok(new AddTypeResponse<int?>() { Id = result });
        }

        [HttpPut]
        [ProducesResponseType(typeof(GetItemByIdResponse<CatalogType>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateTypeRequest request)
        {
            var result = await _catalogTypeService.Update(request.Id, request.Name);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(GetItemByIdRequest request)
        {
            var result = await _catalogTypeService.Delete(request.Id);
            return Ok(result);
        }
    }
}
