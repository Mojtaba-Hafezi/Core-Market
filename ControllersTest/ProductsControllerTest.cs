using Application.DTOs;
using Application.ServiceContracts;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
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

        private Product CreateProduct() => new Product
        {
            Id = 1,
            BrandId = 1,
            Name = "Test Product",
            Quantity = 100,
            Price = 100
        };

        private ProductDTO CreateProductDTO() => new ProductDTO
        {
            BrandId = 1,
            Name = "Test ProductDTO",
            Quantity = 100,
            Price = 100
        };

        private Brand CreateBrand() => new Brand
        {
            Id = 1,
            Name = "Test Brand",
            CategoryId = 1,
            Products = new List<Product> { CreateProduct() }
        };

        [Fact]
        public async Task Add_BrandDoesNotExist()
        {
            // Arrange
            ProductDTO productDTO = CreateProductDTO();
            Brand? brand = null;
            string expectedMessage = $"The brand was not found for id = {productDTO.BrandId}";
            _brandService.Setup(x => x.GetByIdAsync(productDTO.BrandId)).ReturnsAsync(brand);

            // Act
            var result = await _sut.Add(productDTO);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedMessage, notFoundResult.Value);
        }

        //[Fact]
        //public async Task Add_ProductNotAdded()
        //{
        //    // Arrange
        //    ProductDTO productDTO = CreateProductDTO();

        //    Product product = CreateProduct();
        //    product.Id = 0;

        //    Brand brand = CreateBrand();

        //    _brandService.Setup(x => x.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
        //    _mapper.Setup(m => m.Map<Product>(productDTO)).Returns(product);
        //    _productService.Setup(x => x.AddAsync(product)).ReturnsAsync(() => null);
        //    string expectedMessage = "An error occured! The product couldn't be added to the database";

        //    // Act
        //    var result = await _sut.Add(productDTO);

        //    // Assert
        //    var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(500, internalServerErrorResult.StatusCode);
        //    Assert.Equal(expectedMessage, internalServerErrorResult.Value);
        //}

        [Fact]
        public async Task Add_ProductAddedSuccessfully()
        {
            // Arrange
            ProductDTO productDTO = CreateProductDTO();

            Product product = CreateProduct();
            product.Id = 0;

            Brand brand = CreateBrand();

            _brandService.Setup(x => x.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
            _mapper.Setup(m => m.Map<Product>(productDTO)).Returns(product);
            int newProductId = 10;
            _productService.Setup(x => x.AddAsync(product)).ReturnsAsync(newProductId);


            // Act
            var result = await _sut.Add(productDTO);

            // Assert
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetById", createdAtRouteResult.RouteName);
            Assert.Equal(newProductId, createdAtRouteResult.RouteValues["id"]);

            var returnValue = Assert.IsType<ProductDTO>(createdAtRouteResult.Value);
            Assert.Equal(productDTO.BrandId, returnValue.BrandId);
            Assert.Equal(productDTO.Name, returnValue.Name);
            Assert.Equal(productDTO.Quantity, returnValue.Quantity);
            Assert.Equal(productDTO.Price, returnValue.Price);
        }

        [Fact]
        public async Task GetAll_Successfully()
        {
            // Arrange
            List<Product> productsList = new List<Product>
            {
                CreateProduct()
            };

            List<Product> expectedProductsList = new List<Product>
            {
                CreateProduct()
            };

            _productService.Setup(x => x.GetAllAsync()).ReturnsAsync(productsList);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedProducts = Assert.IsType<List<Product>>(okObjectResult.Value);

            Assert.Equal(productsList.Count, returnedProducts.Count);
            for (int i = 0; i < productsList.Count; i++)
            {
                Assert.Equal(expectedProductsList[i].Id, returnedProducts[i].Id);
                Assert.Equal(expectedProductsList[i].Name, returnedProducts[i].Name);
                Assert.Equal(expectedProductsList[i].BrandId, returnedProducts[i].BrandId);
                Assert.Equal(expectedProductsList[i].Quantity, returnedProducts[i].Quantity);
                Assert.Equal(expectedProductsList[i].Price, returnedProducts[i].Price);
                Assert.Equal(expectedProductsList[i].CreatedAt, returnedProducts[i].CreatedAt);
                Assert.Equal(expectedProductsList[i].CreatedByUserId, returnedProducts[i].CreatedByUserId);
                Assert.Equal(expectedProductsList[i].IsDeleted, returnedProducts[i].IsDeleted);
                Assert.Equal(expectedProductsList[i].DeletedAt, returnedProducts[i].DeletedAt);
                Assert.Equal(expectedProductsList[i].DeletedByUserId, returnedProducts[i].DeletedByUserId);
                Assert.Equal(expectedProductsList[i].ModifiedAt, returnedProducts[i].ModifiedAt);
                Assert.Equal(expectedProductsList[i].ModifiedByUserId, returnedProducts[i].ModifiedByUserId);
            }
        }

        //[Fact]
        //public async Task GetAll_InternalServerError()
        //{
        //    // Arrange
        //    _productService.Setup(x => x.GetAllAsync()).ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _sut.GetAll();

        //    // Assert
        //    var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
        //    Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        //}


        [Fact]
        public async Task GetById_IdIsNotPositive()
        {
            // Arrange
            int id = 0;
            string expectedMessage = "The id should be an integer greater than zero";

            // Act
            var result = await _sut.GetById(id);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ProductDoesNotExist()
        {
            // Arrange
            int id = 1;
            Product? product = null;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.GetById(id);

            // Assert
            var notFountResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal($"The product with id={id} was not found", notFountResult.Value);
        }

        [Fact]
        public async Task GetById_Successfully()
        {
            // Arrange
            int id = 1;
            Product product = CreateProduct();
            Product expectedProduct = CreateProduct();
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.GetById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedProdut = Assert.IsType<Product>(okObjectResult.Value);
            Assert.Equal(expectedProduct.Id, returnedProdut.Id);
            Assert.Equal(expectedProduct.Name, returnedProdut.Name);
            Assert.Equal(expectedProduct.Price, returnedProdut.Price);
            Assert.Equal(expectedProduct.Quantity, returnedProdut.Quantity);
            Assert.Equal(expectedProduct.BrandId, returnedProdut.BrandId);
            Assert.Equal(expectedProduct.CreatedAt, returnedProdut.CreatedAt);
            Assert.Equal(expectedProduct.CreatedByUserId, returnedProdut.CreatedByUserId);
            Assert.Equal(expectedProduct.IsDeleted, returnedProdut.IsDeleted);
            Assert.Equal(expectedProduct.DeletedAt, returnedProdut.DeletedAt);
            Assert.Equal(expectedProduct.DeletedByUserId, returnedProdut.DeletedByUserId);
            Assert.Equal(expectedProduct.ModifiedAt, returnedProdut.ModifiedAt);
            Assert.Equal(expectedProduct.ModifiedByUserId, returnedProdut.ModifiedByUserId);
        }


    }

}
