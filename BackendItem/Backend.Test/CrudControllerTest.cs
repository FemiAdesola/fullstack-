using AutoMapper;
using Backend.DTOs;
using Backend.Errors;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers;
using FakeItEasy;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class CrudControllerTest
    {

        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IProductService _productService;

        public CrudControllerTest()
        {

            _mapper = A.Fake<IMapper>();
            _authorizationService = A.Fake<IAuthorizationService>();
            _productService = A.Fake<IProductService>();
        }

        [Fact]
        public async Task<ActionResult> ProductController_GetAllProduct_ReturnOK([FromQuery] QueryOptions options)
        {
            var products = A.Fake<IEnumerable<ProductToReturnDTO>();
            var productList = A.Fake <ICollection<ProductToReturnDTO>();
            A.CallTo(() => _mapper.Map<List<ProductToReturnDTO>>(products)).Returns(productList);
            var controller = new ProductController(_productService, _authorizationService, _mapper);

            var result = await controller.GetAll();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}