using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace Catalog.Host.Controllers
{
        [ApiController]
        [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
        [Route(ComponentDefaults.DefaultRoute)]
        public class CatalogBffController : ControllerBase
        {
            private readonly ILogger<CatalogBffController> _logger;
            private readonly ICatalogService _catalogService;
            private readonly IOptions<CatalogConfig> _config;
            private readonly ICatalogItemService _itemService;

            public CatalogBffController(
            ILogger<CatalogBffController> logger,
            ICatalogService catalogService,
            IOptions<CatalogConfig> config,
            ICatalogItemService itemService)
            {
                _logger = logger;
                _catalogService = catalogService;
                _config = config;
                _itemService = itemService;
            }

            [HttpPost]
            [AllowAnonymous]
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
            {
                var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
                return Ok(result);
            }
           
            [HttpPost]
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetById(GetItemByIdRequest request)
            {
                var result = await _itemService.GetItemById(request.Id);
                return Ok(result);
            }
           
            [HttpPost]
            [AllowAnonymous]
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetItemsByContainer(GetItemByIdRequest request)
            {
                var result = await _itemService.GetItemsByContainer(request.Id);
                return Ok(result);
            }
            
            [HttpPost]
            [AllowAnonymous]
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetItemsByType(GetItemByIdRequest request)
            {
                var result = await _itemService.GetItemsByType(request.Id);
                return Ok(result);
            }
           
            [HttpGet]
            [AllowAnonymous]
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetContainers()
            {
                var result = await _itemService.GetItemsContainers();
                return Ok(result);
            }
           
            [HttpGet]
            [AllowAnonymous]    
            [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetTypes()
            {
                var result = await _itemService.GetItemsTypes();
                return Ok(result);
            }
    }
}
