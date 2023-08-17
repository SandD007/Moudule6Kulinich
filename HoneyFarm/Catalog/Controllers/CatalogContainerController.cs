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
    public class CatalogContainerController : ControllerBase
    {
        private readonly ILogger<CatalogContainerController> _logger;
        private readonly ICatalogContainerService _catalogContainerService;

        public CatalogContainerController(
            ILogger<CatalogContainerController> logger,
            ICatalogContainerService catalogContainerService)
        {
            _logger = logger;
            _catalogContainerService = catalogContainerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddContainerResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateContainerRequest request)
        {
            var result = await _catalogContainerService.Add(request.Name);
            return Ok(new AddContainerResponse<int?>() { Id = result });
        }

        [HttpPut]
        [ProducesResponseType(typeof(GetItemByIdResponse<CatalogContainer>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CreateUpdateBrandRequest request)
        {
            var result = await _catalogContainerService.Update(request.Id, request.Brand);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(GetItemByIdRequest request)
        {
            var result = await _catalogContainerService.Delete(request.Id);
            return Ok(result);
        }
    }
}
