using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.DTO;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.Mapping;

namespace Tibia.Ciclopedia.Tests.MappingTest.CrossCuttingTest
{
    public class MappingItemMarketPriceTests
    {
        private readonly IMapper _mapper;

        public MappingItemMarketPriceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingItemMarketPrice>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Mapping_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingItemMarketPrice>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Mapping_GetPricingResponseBpi_To_ItemMarketPrice_MapsCorrectly()
        {
            // Arrange
            var source = new GetPricingResponse
            {

             Price = 123.45

            };

            // Act
            var result = _mapper.Map<ItemMarketPrice>(source);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(123.45, result.Price);
        }
    }
}