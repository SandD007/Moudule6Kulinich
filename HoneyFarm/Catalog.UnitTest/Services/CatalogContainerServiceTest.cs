using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using FluentAssertions;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.UnitTest.Services
{
    public class CatalogContainerServiceTest
    {
        private readonly ICatalogContainerService _catalogContainerService;

        private readonly Mock<ICatalogContainerRepository> _catalogContainerRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogContainerService>> _logger;

        private readonly CatalogContainer _testItem = new CatalogContainer()
        {
            Id = 1,
            Name = "Name",
        };

        public CatalogContainerServiceTest()
        {
            _catalogContainerRepository = new Mock<ICatalogContainerRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogContainerService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogContainerService = new CatalogContainerService(_dbContextWrapper.Object, _logger.Object, _catalogContainerRepository.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            var testResult = 1;

            _catalogContainerRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Add(_testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            int? testResult = null;

            _catalogContainerRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Add(_testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            var testResult = new CatalogContainer
            {
                Id = _testItem.Id,
                Name = _testItem.Name,
            };

            _catalogContainerRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Update(_testItem.Id, _testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            CatalogContainer? testResult = null;

            _catalogContainerRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Update(_testItem.Id, _testItem.Name);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var testResult = true;

            _catalogContainerRepository.Setup(s => s.Delete(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Delete(_testItem.Id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            var testResult = false;

            _catalogContainerRepository.Setup(s => s.Delete(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogContainerService.Delete(_testItem.Id);

            // assert
            result.Should().Be(testResult);
        }
    }
}
