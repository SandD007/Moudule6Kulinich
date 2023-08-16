﻿using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.UnitTest.Services
{
    public class CatalogTypeServiceTest
    {
        private readonly ICatalogTypeService _catalogTypeService;

        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogTypeService>> _logger;

        private readonly CatalogType _testItem = new CatalogType()
        {
            Id = 1,
            Name = "Name",
        };

        public CatalogTypeServiceTest()
        {
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogTypeService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogTypeService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            var testResult = 1;

            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Add(_testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            int? testResult = null;

            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Add(_testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            var testResult = new CatalogType
            {
                Id = _testItem.Id,
                Name = _testItem.Name,
            };

            _catalogTypeRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Update(_testItem.Id, _testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            CatalogType? testResult = null;

            _catalogTypeRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Update(_testItem.Id, _testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var testResult = true;

            _catalogTypeRepository.Setup(s => s.Delete(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Delete(_testItem.Id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            var testResult = false;

            _catalogTypeRepository.Setup(s => s.Delete(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Delete(_testItem.Id);

            // assert
            result.Should().Be(testResult);
        }
    }
}
