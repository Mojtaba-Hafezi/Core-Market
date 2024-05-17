using Application.DTOs;
using Application.ServiceContracts;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace ControllersTest
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _sut;
        private readonly Mock<IBrandService> _brandService = new Mock<IBrandService>();
        private readonly Mock<IProductService> _productService = new Mock<IProductService>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public ProductsControllerTest()
        {
            _sut = new ProductsController(_productService.Object, _brandService.Object, _mapper.Object);
        }

        Product ProductFactory() => new Product
        {
            Id = 1,
            BrandId = 1,
            Name = "Test Product",
            Quantity = 100,
            Price = 100
        };

        ProductDTO ProductDTOFactory()=> new ProductDTO
        {
            BrandId = 1,
            Name = "Test ProductDTO",
            Quantity = 100,
            Price = 100
        };

        Brand BrandFactory()=> new Brand
        {
            Id = 1,
            Name = "Test Brand",
            CategoryId = 1,
            Products = new List<Product> { ProductFactory() }
        };

        [Fact]
        public async void AddProduct_NullBrand()
        {
            //Arrange
            ProductDTO productDTO = ProductDTOFactory();
            Brand? brand = null;
            string expectedMessage = $"The brand was not found for id = {productDTO.BrandId}";
            _brandService.Setup(x => x.GetByIdAsync(productDTO.BrandId)).ReturnsAsync(brand);

            //Act
            var result = await _sut.Add(productDTO);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedMessage, notFoundResult.Value);
        }

        [Fact]
        public async void AddProduct_ProductNotAdded()
        {
            //Arrange
            ProductDTO productDTO = ProductDTOFactory();

            Product product = ProductFactory();
            product.Id = 0;

            Brand brand = BrandFactory();

            _brandService.Setup(x => x.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
            _mapper.Setup(m => m.Map<Product>(productDTO)).Returns(product);
            _productService.Setup(x => x.AddAsync(product)).ReturnsAsync(value: null);
            string expectedMessage = "An error occured! The product couldn't be added to the database";

            //Act
            var result = await _sut.Add(productDTO);

            //Assert
            var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, internalServerErrorResult.StatusCode);
            Assert.Equal(expectedMessage, internalServerErrorResult.Value);
        }

        [Fact]
        public async void AddProduct_ProperProductDetails()
        {
            //Arrange
            ProductDTO productDTO = ProductDTOFactory();

            Product product = ProductFactory();
            product.Id = 0;

            Brand brand = BrandFactory();

            _brandService.Setup(x => x.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
            _mapper.Setup(m => m.Map<Product>(productDTO)).Returns(product);
            int newProductId = 10;
            _productService.Setup(x => x.AddAsync(product)).ReturnsAsync(newProductId);
            

            //Act
            var result = await _sut.Add(productDTO);

            //Assert
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetById", createdAtRouteResult.RouteName);
            Assert.Equal(newProductId, createdAtRouteResult.RouteValues["id"]);
            var returnValue = Assert.IsType<ProductDTO>(createdAtRouteResult.Value);
            Assert.Equal(productDTO.BrandId, returnValue.BrandId);
            Assert.Equal(productDTO.Name, returnValue.Name);
            Assert.Equal(productDTO.Quantity, returnValue.Quantity);
            Assert.Equal(productDTO.Price, returnValue.Price);
        }
    }
}
