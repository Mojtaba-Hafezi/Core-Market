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
using System.Collections;
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

        private PhysicalProduct CreatePhysicalProduct() => new PhysicalProduct
        {
            Id = 1,
            BrandId = 1,
            Name = "Test Product",
            Quantity = 100,
            Weight = 2,
            Price = 100,
            CreatedAt = DateTime.Now
        };

        private DigitalProduct CreateDigitalProduct() => new DigitalProduct
        {
            Id = 1,
            BrandId = 1,
            Name = "Test Product",
            FileSize = 6,
            Price = 100,
            CreatedAt = DateTime.Now
        };

        private ProductDTO CreateProductDTOForDigitalProduct() => new ProductDTO
        {
            BrandId = 1,
            Name = "Test ProductDTO",
            FileSize = 20,
            Price = 100
        };

        private ProductDTO CreateProductDTOForPhysicalProduct() => new ProductDTO
        {
            BrandId = 1,
            Name = "Test ProductDTO",
            Quantity = 100,
            Weight = 7,
            FileSize = 20,
            Price = 100
        };

        private Brand CreateBrand() => new Brand
        {
            Id = 1,
            Name = "Test Brand",
            CategoryId = 1,
            BaseProducts = new List<BaseProduct>
            {
                CreatePhysicalProduct(),
                CreateDigitalProduct()
            }
        };

        #region Add
        [Fact]
        public async Task Add_ProductTypeIsNotValid()
        {
            // Arrange
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            productDTO.Weight = 3;
            string expectedMessage = "Product should be either Physical or Digital!";

            // Act
            var result = await _sut.Add(productDTO);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task Add_BrandDoesNotExist()
        {
            // Arrange
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
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
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();

            DigitalProduct product = CreateDigitalProduct();
            product.Id = 0;

            Brand brand = CreateBrand();

            _brandService.Setup(x => x.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
            _mapper.Setup(m => m.Map<DigitalProduct>(productDTO)).Returns(product);
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
            Assert.Equal(productDTO.FileSize, returnValue.FileSize);
            Assert.Equal(productDTO.Price, returnValue.Price);
        }

        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Successfully()
        {
            // Arrange
            DateTime createdDateTime = DateTime.Now;

            int page = 2;
            int limit = 2;
            string term = "s";
            int expectedtotalCount = 10;
            int expectedtotalPaged = 5;

            DigitalProduct digitalProduct = CreateDigitalProduct();
            digitalProduct.CreatedAt = createdDateTime;

            PhysicalProduct physicalProduct = CreatePhysicalProduct();
            physicalProduct.CreatedAt = createdDateTime;


            List<BaseProduct> expectedProductsList = new List<BaseProduct>
            {
                digitalProduct,
                physicalProduct
            };

            PagedEntityDTO<BaseProduct> PagedEntityDTO =
                new PagedEntityDTO<BaseProduct>
                {
                    PagedEntities = expectedProductsList,
                    TotalCount = expectedtotalCount,
                    TotalPages = expectedtotalPaged
                };
            PagedProductDTO expectedPagedProductDTO =
                new PagedProductDTO
                {
                    PagedEntities = [.. PagedEntityDTO.PagedEntities],
                    TotalCount = PagedEntityDTO.TotalCount,
                    TotalPages = PagedEntityDTO.TotalPages
                };

            _productService.Setup(x => x.GetAllAsync(page, limit, term)).ReturnsAsync(PagedEntityDTO);
            // Act
            var result = await _sut.GetAll(page, limit, term);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            PagedProductDTO returnedPagedProductDTO = Assert.IsType<PagedProductDTO>(okObjectResult.Value);
            Assert.Equal(expectedPagedProductDTO.TotalCount, returnedPagedProductDTO.TotalCount);
            Assert.Equal(expectedPagedProductDTO.TotalPages, returnedPagedProductDTO.TotalPages);
            Assert.Equal(expectedPagedProductDTO.PagedEntities.Count, returnedPagedProductDTO.PagedEntities.Count);
            for (int i=0; i<expectedPagedProductDTO.PagedEntities.Count; i++)
            {
                if ( returnedPagedProductDTO.PagedEntities[i].GetType() == typeof(DigitalProduct))
                {
                    DigitalProduct returnedProduct = (DigitalProduct)returnedPagedProductDTO.PagedEntities[i];
                    DigitalProduct expectedProduct = (DigitalProduct)expectedPagedProductDTO.PagedEntities[i];
                    Assert.Equal(expectedProduct.Id, returnedProduct.Id);
                    Assert.Equal(expectedProduct.Name, returnedProduct.Name);
                    Assert.Equal(expectedProduct.BrandId, returnedProduct.BrandId);
                    Assert.Equal(expectedProduct.Price, returnedProduct.Price);
                    Assert.Equal(expectedProduct.FileSize, returnedProduct.FileSize);
                    Assert.Equal(expectedProduct.CreatedAt, returnedProduct.CreatedAt);
                    Assert.Equal(expectedProduct.CreatedByUserId, returnedProduct.CreatedByUserId);
                    Assert.Equal(expectedProduct.IsDeleted, returnedProduct.IsDeleted);
                    Assert.Equal(expectedProduct.DeletedAt, returnedProduct.DeletedAt);
                    Assert.Equal(expectedProduct.DeletedByUserId, returnedProduct.DeletedByUserId);
                    Assert.Equal(expectedProduct.ModifiedAt, returnedProduct.ModifiedAt);
                    Assert.Equal(expectedProduct.ModifiedByUserId, returnedProduct.ModifiedByUserId);
                }
                if (returnedPagedProductDTO.PagedEntities[i].GetType() == typeof(PhysicalProduct))
                {
                    PhysicalProduct returnedProduct = (PhysicalProduct)returnedPagedProductDTO.PagedEntities[i];
                    PhysicalProduct expectedProduct = (PhysicalProduct)expectedPagedProductDTO.PagedEntities[i];
                    Assert.Equal(expectedProduct.Id, returnedProduct.Id);
                    Assert.Equal(expectedProduct.Name, returnedProduct.Name);
                    Assert.Equal(expectedProduct.BrandId, returnedProduct.BrandId);
                    Assert.Equal(expectedProduct.Price, returnedProduct.Price);
                    Assert.Equal(expectedProduct.Quantity, returnedProduct.Quantity);
                    Assert.Equal(expectedProduct.Weight, returnedProduct.Weight);
                    Assert.Equal(expectedProduct.CreatedAt, returnedProduct.CreatedAt);
                    Assert.Equal(expectedProduct.CreatedByUserId, returnedProduct.CreatedByUserId);
                    Assert.Equal(expectedProduct.IsDeleted, returnedProduct.IsDeleted);
                    Assert.Equal(expectedProduct.DeletedAt, returnedProduct.DeletedAt);
                    Assert.Equal(expectedProduct.DeletedByUserId, returnedProduct.DeletedByUserId);
                    Assert.Equal(expectedProduct.ModifiedAt, returnedProduct.ModifiedAt);
                    Assert.Equal(expectedProduct.ModifiedByUserId, returnedProduct.ModifiedByUserId);
                }
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
            BaseProduct? product = null;
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

            DigitalProduct product = CreateDigitalProduct();
            product.CreatedAt = createdDateTime;

            DigitalProduct expectedProduct = CreateDigitalProduct();
            expectedProduct.CreatedAt = createdDateTime;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.GetById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedProdut = Assert.IsType<DigitalProduct>(okObjectResult.Value);
            Assert.Equal(expectedProduct.Id, returnedProdut.Id);
            Assert.Equal(expectedProduct.Name, returnedProdut.Name);
            Assert.Equal(expectedProduct.Price, returnedProdut.Price);
            Assert.Equal(expectedProduct.BrandId, returnedProdut.BrandId);
            Assert.Equal(expectedProduct.FileSize, returnedProdut.FileSize);
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
            BaseProduct? product = null;
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
            BaseProduct product = CreateDigitalProduct();
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
            BaseProduct product = CreateDigitalProduct();
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
            BaseProduct product = CreateDigitalProduct();
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
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();

            // Act
            var result = await _sut.Update(productDTO, id);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task Update_ProductTypeIsNotValid()
        {
            // Arrange
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            int id = 1;
            productDTO.Weight = 3;
            string expectedMessage = "Product should be either Physical or Digital!";

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
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            BaseProduct? product = null;
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
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            BaseProduct product = CreateDigitalProduct();
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
        public async Task Update_ProductTypeIsChanged()
        {
            // Arrange
            int id = 1;
            string expectedMessage = "The type of the product cannot be changed";
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            DigitalProduct digitalProduct = CreateDigitalProduct();
            BaseProduct baseProduct = CreatePhysicalProduct();
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(baseProduct);
            _mapper.Setup(m => m.Map<DigitalProduct>(productDTO)).Returns(digitalProduct);

            // Act
            var result = await _sut.Update(productDTO, id);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedMessage, badRequestObjectResult.Value);
        }

        [Fact]
        public async Task Update_Successfully()
        {
            // Arrange
            int id = 1;
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            DateTime createdDateTime = DateTime.Now;
            BaseProduct productFromGetByIdService = CreateDigitalProduct();
            productFromGetByIdService.CreatedAt = createdDateTime;
            BaseProduct productFromMapper = CreateDigitalProduct();
            productFromMapper.CreatedAt = createdDateTime;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productFromGetByIdService);
            _mapper.Setup(x => x.Map<BaseProduct>(productDTO)).Returns(productFromMapper);
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
            ProductDTO productDTO = CreateProductDTOForDigitalProduct();
            DateTime createdDateTime = DateTime.Now;
            BaseProduct productFromGetByIdService = CreateDigitalProduct();
            productFromGetByIdService.CreatedAt = createdDateTime;
            BaseProduct productFromMapper = CreateDigitalProduct();
            productFromMapper.CreatedAt = createdDateTime;
            _productService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productFromGetByIdService);
            _mapper.Setup(x => x.Map<BaseProduct>(productDTO)).Returns(productFromMapper);
            _productService.Setup(x => x.UpdateAsync(productFromMapper)).ReturnsAsync(false);



            // Act
            var result = await _sut.Update(productDTO, id);


            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedStatusCode, objectResult.StatusCode);
            Assert.Equal(expectedMessage, objectResult.Value);
        }

        #endregion

        #region DeletedProductCount
        [Fact]
        public async Task GetDeletedProductCountSuccessfully()
        {
            // Arrange 
            int deletedProductsCount = 3;
            string expectedMessage = $"There are {deletedProductsCount} product(s) That are deleted!";
            _productService.Setup(x => x.DeletedProductCount()).ReturnsAsync(deletedProductsCount);


            // Act
            var result = await _sut.GetDeletedProductCount();


            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedMessage, okObjectResult.Value);
        }

        #endregion
    }

}
