using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_CQRS_MediatR.ProductFeatures.Command.Add;
using Product_CQRS_MediatR.ProductFeatures.Command.Delete;
using Product_CQRS_MediatR.ProductFeatures.Command.Update;
using Product_CQRS_MediatR.ProductFeatures.Queries.FindProductById;
using Product_CQRS_MediatR.ProductFeatures.Queries.GetProductList;
using System.Security.Cryptography.X509Certificates;

namespace Product_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;

        }
        ///<summary>
        ///Create a Product
        ///</summary>
        ///<param name="command"></param>
        ///<returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(AddProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        ///<summary>
        ///Update a Product
        ///</summary>
        ///<param name="command"></param>
        ///<returns></returns>
        
        [HttpPut]
        public async Task<IActionResult>Update(UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        ///<summary>
        ///Delete a Product
        ///</summary>
        ///<param name="command"></param>
        ///<returns></returns>
        [HttpDelete]
        public async Task<IActionResult>Delete(DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("get")]
        public async Task<IActionResult> GetProductById(GetProductByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Gets Products.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAllProduct(GetProductListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

    }
}

