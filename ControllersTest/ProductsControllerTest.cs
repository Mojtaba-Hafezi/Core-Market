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
            Price = 100,
            CreatedAt = DateTime.Now
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

        #region Add

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

        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Successfully()
        {
            // Arrange
            DateTime createdDateTime = DateTime.Now;

            Product product = CreateProduct();
            product.CreatedAt = createdDateTime;

            Product expectedProductInProductList = CreateProduct();
            expectedProductInProductList.CreatedAt = createdDateTime;
            List<Product> productsList = new List<Product>
            {
                product
            };

            List<Product> expectedProductsList = new List<Product>
            {
                expectedProductInProductList
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
        #endregion

        #region GetById
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
            string expectedMessage = $"The product with id={id} was not found";
            Product? product = null;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.GetById(id);

            // Assert
            var notFountResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedMessage, notFountResult.Value);
        }

        [Fact]
        public async Task GetById_Successfully()
        {
            // Arrange
            int id = 1;
            DateTime createdDateTime = DateTime.Now;

            Product product = CreateProduct();
            product.CreatedAt = createdDateTime;

            Product expectedProduct = CreateProduct();
            expectedProduct.CreatedAt = createdDateTime;
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
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_IdIsNotPositive()
        {
            // Arrange
            int id = 0;
            string expectedMessage = "The id should be an integer greater than zero";

            // Act
            var result = await _sut.Delete(id);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task Delete_ProductDoesNotExist()
        {
            // Arrange
            int id = 1;
            string expectedMessage = $"The product with id={id} was not found";
            Product? product = null;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedMessage, notFoundResult.Value);
        }

        [Fact]
        public async Task Delete_ProductIsDeletedAlready()
        {
            // Arrange
            int id = 1;
            string expectedMessage = $"The product with id={id} has beed deleted already";
            var expectedStatusCode = StatusCodes.Status410Gone;
            Product product = CreateProduct();
            product.DeletedAt = DateTime.Now;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            //Act
            var result = await _sut.Delete(id);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedMessage, objectResult.Value);
            Assert.Equal(expectedStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Successfully()
        {
            // Arrange
            int id = 1;
            Product product = CreateProduct();
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);
            _productService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);


            // Act
            var result = await _sut.Delete(id);


            // Assert
            Assert.IsType<OkResult>(result);

        }

        [Fact]
        public async Task Delete_InternalServerError()
        {
            // Arrange
            int id = 1;
            string expectedMessage = "An error occured! The product couldn't be deleted from database";
            var expectedStatusCode = StatusCodes.Status500InternalServerError;
            Product product = CreateProduct();
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);
            _productService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(false);


            // Act
            var result = await _sut.Delete(id);


            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedStatusCode, objectResult.StatusCode);
            Assert.Equal(expectedMessage, objectResult.Value);
        }

        #endregion

        #region Update
        [Fact]
        public async Task Update_IdIsNotPositive()
        {
            // Arrange
            int id = 0;
            string expectedMessage = "The id should be an integer greater than zero";
            ProductDTO productDTO = CreateProductDTO();

            // Act
            var result = await _sut.Update(productDTO, id);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task Update_ProductDoesNotExist()
        {
            // Arrange
            int id = 1;
            string expectedMessage = $"The product with id={id} was not found";
            ProductDTO productDTO = CreateProductDTO();
            Product? product = null;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.Update(productDTO, id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedMessage, notFoundResult.Value);
        }

        [Fact]
        public async Task Update_ProductIsDeleted()
        {
            // Arrange
            int id = 1;
            string expectedMessage = $"The product with id={id} has beed deleted";
            var expectedStatusCode = StatusCodes.Status410Gone;
            ProductDTO productDTO = CreateProductDTO();
            Product product = CreateProduct();
            product.DeletedAt = DateTime.Now;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            //Act
            var result = await _sut.Update(productDTO, id);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedMessage, objectResult.Value);
            Assert.Equal(expectedStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public async Task Update_Successfully()
        {
            // Arrange
            int id = 1;
            ProductDTO productDTO = CreateProductDTO();
            DateTime createdDateTime = DateTime.Now;
            Product productFromGetByIdService = CreateProduct();
            productFromGetByIdService.CreatedAt = createdDateTime;
            Product productFromMapper = CreateProduct();
            productFromMapper.CreatedAt = createdDateTime;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productFromGetByIdService);
            _mapper.Setup(x => x.Map<Product>(productDTO)).Returns(productFromMapper);
            _productService.Setup(x => x.UpdateAsync(productFromMapper)).ReturnsAsync(true);

            // Act
            var result = await _sut.Update(productDTO, id);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);

        }

        [Fact]
        public async Task Update_InternalServerError()
        {
            // Arrange
            int id = 1;
            string expectedMessage = "An error occured! The product couldn't be updated in database";
            var expectedStatusCode = StatusCodes.Status500InternalServerError;
            ProductDTO productDTO = CreateProductDTO();
            DateTime createdDateTime = DateTime.Now;
            Product productFromGetByIdService = CreateProduct();
            productFromGetByIdService.CreatedAt = createdDateTime;
            Product productFromMapper = CreateProduct();
            productFromMapper.CreatedAt = createdDateTime;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productFromGetByIdService);
            _mapper.Setup(x => x.Map<Product>(productDTO)).Returns(productFromMapper);
            _productService.Setup(x => x.UpdateAsync(productFromMapper)).ReturnsAsync(false);



            // Act
            var result = await _sut.Update(productDTO, id);


            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedStatusCode, objectResult.StatusCode);
            Assert.Equal(expectedMessage, objectResult.Value);
        }

        #endregion
    }

}
